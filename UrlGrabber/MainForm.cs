using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace UrlGrabber
{
    /// <summary>
    /// Main form for accepting Url Grabber settings and start / stop execution
    /// </summary>
    public partial class UrlGrabberSettingsForm : Form
    {
        private int p_duration;
        private bool p_isOperationStarted;
        private Thread p_grabberThread;
        private ThreadStart p_threadStart;

        /// <summary>
        /// Constructor
        /// Thread creation and form closing event handling
        /// </summary>
        public UrlGrabberSettingsForm()
        {
            InitializeComponent();
            p_threadStart = new ThreadStart(GrabUrl);
            p_grabberThread = new Thread(p_threadStart);
            FormClosing += UrlGrabberSettingsForm_FormClosing;
        }

        /// <summary>
        /// FormClosing event handler. 
        /// If the grabberThread is running, need to abort it and update state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UrlGrabberSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (p_isOperationStarted && p_grabberThread.IsAlive)
            {
                p_grabberThread.Abort();
                p_isOperationStarted = false;
            }
        }

        /// <summary>
        /// Choose location button click handler.
        /// Lets user select the firefox.exe installation path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseLocationButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Firefox executable|firefox.exe";
            openFileDialog1.Title = "Select Firefox installation path";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                firefoxLocationTextBox.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Find output location button click handler.
        /// Lets user select the output location to post Url grabs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outputPathFindButton_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                outputFolderPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void startGrabButton_Click(object sender, EventArgs e)
        {
            if (p_isOperationStarted && p_grabberThread.IsAlive)
            {
                p_grabberThread.Abort();
                toggleStates();
            }
            else
            {
                if (File.Exists(firefoxLocationTextBox.Text) &&
                    Directory.Exists(outputFolderPathTextBox.Text) &&
                    int.TryParse(durationTextBox.Text, out p_duration) &&
                    !string.IsNullOrWhiteSpace(urlTextBox.Text))
                {
                    if (!p_grabberThread.IsAlive)
                    {
                        p_grabberThread = new Thread(p_threadStart);
                        p_grabberThread.Start();
                        toggleStates();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect configuration. Please correct and start again");
                }
            }
        }

        private void toggleStates()
        {
            if (p_isOperationStarted)
            {
                startGrabButton.Text = "Start";
                p_isOperationStarted = false;
                chooseLocationButton.Enabled = true;
                urlTextBox.Enabled = true;
                durationTextBox.Enabled = true;
                outputPathFindButton.Enabled = true;
            }
            else
            {
                startGrabButton.Text = "Stop";
                p_isOperationStarted = true;
                chooseLocationButton.Enabled = false;
                urlTextBox.Enabled = false;
                durationTextBox.Enabled = false;
                outputPathFindButton.Enabled = false;
            }
        }

        private void GrabUrl()
        {
            while (true)
            {
                var currentTimeStamp = DateTime.Now;
                var outputFilename = Path.Combine(outputFolderPathTextBox.Text, string.Concat(currentTimeStamp, ".png"));
                Process p = new Process();
                ProcessStartInfo info = new ProcessStartInfo();
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.FileName = "cmd.exe";
                info.RedirectStandardInput = true;
                info.UseShellExecute = false;

                p.StartInfo = info;
                p.Start();

                using (StreamWriter writer = p.StandardInput)
                {
                    if (writer.BaseStream.CanWrite)
                    {
                        writer.WriteLine(string.Format("cd /d \"{0}\"", Path.GetDirectoryName(firefoxLocationTextBox.Text)));
                        writer.WriteLine(string.Format("firefox -saveimage \"{0}\" -saveas \"{1}\"", urlTextBox.Text, outputFilename));
                    }
                }

                Thread.Sleep(p_duration * 1000);
            }
        }
    }
}
