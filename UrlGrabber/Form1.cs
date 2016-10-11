using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace UrlGrabber
{
    public partial class UrlGrabberSettingsForm : Form
    {
        private int p_duration;
        private bool p_isOperationStarted;
        private Thread p_grabberThread;
        public UrlGrabberSettingsForm()
        {
            InitializeComponent();
            var threadStart = new ThreadStart(GrabUrl);
            p_grabberThread = new Thread(threadStart);
            FormClosing += UrlGrabberSettingsForm_FormClosing;
        }

        private void UrlGrabberSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

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
            if (p_isOperationStarted)
            {
                p_grabberThread.Abort();
                p_isOperationStarted = false;

            }

            if (File.Exists(firefoxLocationTextBox.Text) &&
                Directory.Exists(outputFolderPathTextBox.Text) &&
                int.TryParse(durationTextBox.Text, out p_duration) &&
                !string.IsNullOrWhiteSpace(urlTextBox.Text))
            {
                if (!p_grabberThread.IsAlive)
                {
                    p_isOperationStarted = true;
                    p_grabberThread.Start();
                }
            }
            else
            {
                MessageBox.Show("Incorrect configuration. Please correct and start again");
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
                info.FileName = "cmd.exe";
                info.RedirectStandardInput = true;
                info.UseShellExecute = false;

                p.StartInfo = info;
                p.Start();

                using (StreamWriter sw = p.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine(string.Format("cd /d \"{0}\"", Path.GetDirectoryName(firefoxLocationTextBox.Text)));
                        sw.WriteLine(string.Format("firefox -saveimage \"{0}\" -saveas \"{1}\"", urlTextBox.Text, outputFilename));
                        //sw.WriteLine("use mydb;");
                        //-saveimage www.google.com -saveas c:\\temp\\1.png
                    }
                }

                Thread.Sleep(p_duration * 1000);
            }
        }

      
    }
}
