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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrlGrabberSettingsForm));
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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.preRequisiteLabel = new System.Windows.Forms.Label();
            this.pluginLinkLabel = new System.Windows.Forms.LinkLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // pathRequestLabel
            // 
            this.pathRequestLabel.AutoSize = true;
            this.pathRequestLabel.Location = new System.Drawing.Point(26, 22);
            this.pathRequestLabel.Name = "pathRequestLabel";
            this.pathRequestLabel.Size = new System.Drawing.Size(149, 13);
            this.pathRequestLabel.TabIndex = 0;
            this.pathRequestLabel.Text = "Mozilla Firefox installation path";
            // 
            // firefoxLocationTextBox
            // 
            this.firefoxLocationTextBox.Location = new System.Drawing.Point(26, 38);
            this.firefoxLocationTextBox.Name = "firefoxLocationTextBox";
            this.firefoxLocationTextBox.ReadOnly = true;
            this.firefoxLocationTextBox.Size = new System.Drawing.Size(355, 20);
            this.firefoxLocationTextBox.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chooseLocationButton
            // 
            this.chooseLocationButton.Location = new System.Drawing.Point(390, 38);
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
            this.urlRequestLabel.Location = new System.Drawing.Point(26, 137);
            this.urlRequestLabel.Name = "urlRequestLabel";
            this.urlRequestLabel.Size = new System.Drawing.Size(98, 13);
            this.urlRequestLabel.TabIndex = 3;
            this.urlRequestLabel.Text = "URL to be grabbed";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(26, 153);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(355, 20);
            this.urlTextBox.TabIndex = 4;
            this.urlTextBox.TextChanged += new System.EventHandler(this.urlTextBox_TextChanged);
            // 
            // grabGap
            // 
            this.grabGap.AutoSize = true;
            this.grabGap.Location = new System.Drawing.Point(26, 185);
            this.grabGap.Name = "grabGap";
            this.grabGap.Size = new System.Drawing.Size(178, 13);
            this.grabGap.TabIndex = 5;
            this.grabGap.Text = "Time gap in seconds between grabs";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Location = new System.Drawing.Point(26, 201);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(100, 20);
            this.durationTextBox.TabIndex = 6;
            // 
            // outputRequestLabel
            // 
            this.outputRequestLabel.AutoSize = true;
            this.outputRequestLabel.Location = new System.Drawing.Point(26, 224);
            this.outputRequestLabel.Name = "outputRequestLabel";
            this.outputRequestLabel.Size = new System.Drawing.Size(79, 13);
            this.outputRequestLabel.TabIndex = 7;
            this.outputRequestLabel.Text = "Output location";
            // 
            // outputFolderPathTextBox
            // 
            this.outputFolderPathTextBox.Location = new System.Drawing.Point(26, 240);
            this.outputFolderPathTextBox.Name = "outputFolderPathTextBox";
            this.outputFolderPathTextBox.ReadOnly = true;
            this.outputFolderPathTextBox.Size = new System.Drawing.Size(355, 20);
            this.outputFolderPathTextBox.TabIndex = 8;
            // 
            // outputPathFindButton
            // 
            this.outputPathFindButton.Location = new System.Drawing.Point(390, 240);
            this.outputPathFindButton.Name = "outputPathFindButton";
            this.outputPathFindButton.Size = new System.Drawing.Size(70, 20);
            this.outputPathFindButton.TabIndex = 9;
            this.outputPathFindButton.Text = "Choose";
            this.outputPathFindButton.UseVisualStyleBackColor = true;
            this.outputPathFindButton.Click += new System.EventHandler(this.outputPathFindButton_Click);
            // 
            // startGrabButton
            // 
            this.startGrabButton.Location = new System.Drawing.Point(176, 287);
            this.startGrabButton.Name = "startGrabButton";
            this.startGrabButton.Size = new System.Drawing.Size(143, 23);
            this.startGrabButton.TabIndex = 10;
            this.startGrabButton.Text = "Start";
            this.startGrabButton.UseVisualStyleBackColor = true;
            this.startGrabButton.Click += new System.EventHandler(this.startGrabButton_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(498, 322);
            this.shapeContainer1.TabIndex = 11;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Location = new System.Drawing.Point(17, 122);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(462, 152);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(17, 13);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(462, 91);
            // 
            // preRequisiteLabel
            // 
            this.preRequisiteLabel.AutoSize = true;
            this.preRequisiteLabel.Location = new System.Drawing.Point(26, 69);
            this.preRequisiteLabel.Name = "preRequisiteLabel";
            this.preRequisiteLabel.Size = new System.Drawing.Size(250, 13);
            this.preRequisiteLabel.TabIndex = 12;
            this.preRequisiteLabel.Text = "Ensure Pearl Crescent page saver plugin is installed";
            // 
            // pluginLinkLabel
            // 
            this.pluginLinkLabel.AutoSize = true;
            this.pluginLinkLabel.Location = new System.Drawing.Point(26, 82);
            this.pluginLinkLabel.Name = "pluginLinkLabel";
            this.pluginLinkLabel.Size = new System.Drawing.Size(293, 13);
            this.pluginLinkLabel.TabIndex = 13;
            this.pluginLinkLabel.TabStop = true;
            this.pluginLinkLabel.Text = "https://addons.mozilla.org/en-US/firefox/addon/pagesaver/";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Url Grabber is running";
            this.notifyIcon1.BalloonTipTitle = "Url Grabber";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Url Grabber";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // UrlGrabberSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 322);
            this.Controls.Add(this.pluginLinkLabel);
            this.Controls.Add(this.preRequisiteLabel);
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
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "UrlGrabberSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Url grabber";
            this.Resize += new System.EventHandler(this.UrlGrabberSettingsForm_Resize);
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
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label preRequisiteLabel;
        private System.Windows.Forms.LinkLabel pluginLinkLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

