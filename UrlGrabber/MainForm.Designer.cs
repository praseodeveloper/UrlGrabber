namespace UrlGrabber
{
    partial class UrlGrabberSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathRequestLabel = new System.Windows.Forms.Label();
            this.firefoxLocationTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chooseLocationButton = new System.Windows.Forms.Button();
            this.urlRequestLabel = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.grabGap = new System.Windows.Forms.Label();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.outputRequestLabel = new System.Windows.Forms.Label();
            this.outputFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.outputPathFindButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.startGrabButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pathRequestLabel
            // 
            this.pathRequestLabel.AutoSize = true;
            this.pathRequestLabel.Location = new System.Drawing.Point(12, 9);
            this.pathRequestLabel.Name = "pathRequestLabel";
            this.pathRequestLabel.Size = new System.Drawing.Size(192, 13);
            this.pathRequestLabel.TabIndex = 0;
            this.pathRequestLabel.Text = "1. Provide the path of firefox installation";
            // 
            // firefoxLocationTextBox
            // 
            this.firefoxLocationTextBox.Location = new System.Drawing.Point(15, 26);
            this.firefoxLocationTextBox.Name = "firefoxLocationTextBox";
            this.firefoxLocationTextBox.ReadOnly = true;
            this.firefoxLocationTextBox.Size = new System.Drawing.Size(368, 20);
            this.firefoxLocationTextBox.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chooseLocationButton
            // 
            this.chooseLocationButton.Location = new System.Drawing.Point(390, 26);
            this.chooseLocationButton.Name = "chooseLocationButton";
            this.chooseLocationButton.Size = new System.Drawing.Size(70, 20);
            this.chooseLocationButton.TabIndex = 2;
            this.chooseLocationButton.Text = "Locate";
            this.chooseLocationButton.UseVisualStyleBackColor = true;
            this.chooseLocationButton.Click += new System.EventHandler(this.chooseLocationButton_Click);
            // 
            // urlRequestLabel
            // 
            this.urlRequestLabel.AutoSize = true;
            this.urlRequestLabel.Location = new System.Drawing.Point(15, 53);
            this.urlRequestLabel.Name = "urlRequestLabel";
            this.urlRequestLabel.Size = new System.Drawing.Size(156, 13);
            this.urlRequestLabel.TabIndex = 3;
            this.urlRequestLabel.Text = "2. Enter the URL to be grabbed";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(15, 70);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(368, 20);
            this.urlTextBox.TabIndex = 4;
            // 
            // grabGap
            // 
            this.grabGap.AutoSize = true;
            this.grabGap.Location = new System.Drawing.Point(15, 97);
            this.grabGap.Name = "grabGap";
            this.grabGap.Size = new System.Drawing.Size(230, 13);
            this.grabGap.TabIndex = 5;
            this.grabGap.Text = "3. Enter the duration in seconds between grabs";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Location = new System.Drawing.Point(15, 114);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(100, 20);
            this.durationTextBox.TabIndex = 6;
            // 
            // outputRequestLabel
            // 
            this.outputRequestLabel.AutoSize = true;
            this.outputRequestLabel.Location = new System.Drawing.Point(15, 141);
            this.outputRequestLabel.Name = "outputRequestLabel";
            this.outputRequestLabel.Size = new System.Drawing.Size(159, 13);
            this.outputRequestLabel.TabIndex = 7;
            this.outputRequestLabel.Text = "4. Enter the grab output location";
            // 
            // outputFolderPathTextBox
            // 
            this.outputFolderPathTextBox.Location = new System.Drawing.Point(15, 158);
            this.outputFolderPathTextBox.Name = "outputFolderPathTextBox";
            this.outputFolderPathTextBox.ReadOnly = true;
            this.outputFolderPathTextBox.Size = new System.Drawing.Size(368, 20);
            this.outputFolderPathTextBox.TabIndex = 8;
            // 
            // outputPathFindButton
            // 
            this.outputPathFindButton.Location = new System.Drawing.Point(390, 158);
            this.outputPathFindButton.Name = "outputPathFindButton";
            this.outputPathFindButton.Size = new System.Drawing.Size(70, 20);
            this.outputPathFindButton.TabIndex = 9;
            this.outputPathFindButton.Text = "Choose";
            this.outputPathFindButton.UseVisualStyleBackColor = true;
            this.outputPathFindButton.Click += new System.EventHandler(this.outputPathFindButton_Click);
            // 
            // startGrabButton
            // 
            this.startGrabButton.Location = new System.Drawing.Point(164, 191);
            this.startGrabButton.Name = "startGrabButton";
            this.startGrabButton.Size = new System.Drawing.Size(143, 23);
            this.startGrabButton.TabIndex = 10;
            this.startGrabButton.Text = "Start";
            this.startGrabButton.UseVisualStyleBackColor = true;
            this.startGrabButton.Click += new System.EventHandler(this.startGrabButton_Click);
            // 
            // UrlGrabberSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 226);
            this.Controls.Add(this.startGrabButton);
            this.Controls.Add(this.outputPathFindButton);
            this.Controls.Add(this.outputFolderPathTextBox);
            this.Controls.Add(this.outputRequestLabel);
            this.Controls.Add(this.durationTextBox);
            this.Controls.Add(this.grabGap);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.urlRequestLabel);
            this.Controls.Add(this.chooseLocationButton);
            this.Controls.Add(this.firefoxLocationTextBox);
            this.Controls.Add(this.pathRequestLabel);
            this.MaximizeBox = false;
            this.Name = "UrlGrabberSettingsForm";
            this.Text = "Url grabber";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pathRequestLabel;
        private System.Windows.Forms.TextBox firefoxLocationTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button chooseLocationButton;
        private System.Windows.Forms.Label urlRequestLabel;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Label grabGap;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.Label outputRequestLabel;
        private System.Windows.Forms.TextBox outputFolderPathTextBox;
        private System.Windows.Forms.Button outputPathFindButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button startGrabButton;
    }
}

