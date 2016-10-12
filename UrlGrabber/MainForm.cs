using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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

            notifyIcon1.Visible = false;
            p_viewModel = new UrlGrabSettingsViewModel();
            p_threadStart = new ThreadStart(GrabUrl);
            p_grabberThread = new Thread(p_threadStart);
            FormClosing += UrlGrabberSettingsForm_FormClosing;

            pluginLinkLabel.Links.Remove(pluginLinkLabel.Links[0]);
            pluginLinkLabel.Links.Add(0, pluginLinkLabel.Text.Length, "https://addons.mozilla.org/en-US/firefox/addon/pagesaver/");
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

        /// <summary>
        /// Start/Stop button click event handler. 
        /// Invoke grabber thread and update UI state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Text changed event handler for URL text box.
        /// Storing the URL in view model.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            var source = sender as TextBox;
            if (source != null)
            {
                p_viewModel.Url = source.Text;
            }
        }

        /// <summary>
        ///  Click event handler for notify icon.
        ///  Need to show form in normal mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        /// <summary>
        /// Click event handler for link label.
        /// Open the add-on URL in default browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pluginLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
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

        /// <summary>
        /// Code which actually take screenshots using the firefox add-on indefinitely.
        /// </summary>
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
                        writer.WriteLine(string.Format("firefox -saveimage \"{0}\" -saveas \"{1}\" -width 640 -height 480 -saveoptions element=octable", p_viewModel.Url, outputFilename));
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

        /// <summary>
        /// Form resize event handler. 
        /// Need to minimize to system tray as notify icon when minimized.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
