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
        private bool p_isOperationStarted;
        private Thread p_grabberThread;
        private ThreadStart p_threadStart;
        private UrlGrabSettingsViewModel p_viewModel;

        /// <summary>
        /// Constructor
        /// Thread creation and form closing event handling
        /// </summary>
        public UrlGrabberSettingsForm()
        {
            InitializeComponent();

            p_viewModel = new UrlGrabSettingsViewModel();
            p_threadStart = new ThreadStart(GrabUrl);
            p_grabberThread = new Thread(p_threadStart);
            FormClosing += UrlGrabberSettingsForm_FormClosing;
        }

        #region Controls event handlers.
        /// <summary>
        /// Choose location button click handler.
        /// Lets user select the firefox.exe installation path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseLocationButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "firefox.exe";
            openFileDialog1.Filter = "Firefox executable|firefox.exe";
            openFileDialog1.Title = "Select Firefox installation path";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                firefoxLocationTextBox.Text = openFileDialog1.FileName;
                p_viewModel.FirefoxPath = openFileDialog1.FileName;
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
                p_viewModel.OutputPath = folderBrowserDialog1.SelectedPath;
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
                var duration = 0;
                if (File.Exists(firefoxLocationTextBox.Text) &&
                    Directory.Exists(outputFolderPathTextBox.Text) &&
                    int.TryParse(durationTextBox.Text, out duration) &&
                    !string.IsNullOrWhiteSpace(urlTextBox.Text))
                {
                    p_viewModel.Duration = duration;
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

        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            var source = sender as TextBox;
            if (source != null)
            {
                p_viewModel.Url = source.Text;
            }
        }
        #endregion

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
                var currentTimeStamp = string.Format("{0:s}", DateTime.Now);
                var outputFilename = Path.Combine(p_viewModel.OutputPath, string.Concat(currentTimeStamp, ".png"));
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
                        writer.WriteLine(string.Format("cd /d \"{0}\"", Path.GetDirectoryName(p_viewModel.FirefoxPath)));
                        writer.WriteLine(string.Format("firefox -saveimage \"{0}\" -saveas \"{1}\"", p_viewModel.Url, outputFilename));
                    }
                }

                Thread.Sleep(p_viewModel.Duration * 1000);
            }
        }

        #region Form event handlers.
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

        private void UrlGrabberSettingsForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                this.Hide();
            }
        }
        #endregion

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }
    }
}
