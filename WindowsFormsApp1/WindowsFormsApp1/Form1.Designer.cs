namespace WindowsFormsApp1
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VideoBox = new System.Windows.Forms.PictureBox();
            this.OnOffButton = new System.Windows.Forms.Button();
            this.WebcamsBox = new System.Windows.Forms.ComboBox();
            this.CaptureButton = new System.Windows.Forms.Button();
            this.PicName = new System.Windows.Forms.TextBox();
            this.GrayscaleButton = new System.Windows.Forms.Button();
            this.CompButton = new System.Windows.Forms.Button();
            this.ComparePic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.VideoBox);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // VideoBox
            // 
            this.VideoBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.VideoBox.Location = new System.Drawing.Point(6, 19);
            this.VideoBox.Name = "VideoBox";
            this.VideoBox.Size = new System.Drawing.Size(400, 250);
            this.VideoBox.TabIndex = 0;
            this.VideoBox.TabStop = false;
            // 
            // OnOffButton
            // 
            this.OnOffButton.Location = new System.Drawing.Point(284, 480);
            this.OnOffButton.Name = "OnOffButton";
            this.OnOffButton.Size = new System.Drawing.Size(100, 23);
            this.OnOffButton.TabIndex = 1;
            this.OnOffButton.Text = "On/Off";
            this.OnOffButton.UseVisualStyleBackColor = true;
            this.OnOffButton.Click += new System.EventHandler(this.OnOffButton_Click);
            // 
            // WebcamsBox
            // 
            this.WebcamsBox.FormattingEnabled = true;
            this.WebcamsBox.Location = new System.Drawing.Point(26, 480);
            this.WebcamsBox.Name = "WebcamsBox";
            this.WebcamsBox.Size = new System.Drawing.Size(233, 21);
            this.WebcamsBox.TabIndex = 2;
            // 
            // CaptureButton
            // 
            this.CaptureButton.Location = new System.Drawing.Point(654, 480);
            this.CaptureButton.Name = "CaptureButton";
            this.CaptureButton.Size = new System.Drawing.Size(100, 23);
            this.CaptureButton.TabIndex = 3;
            this.CaptureButton.Text = "Capture";
            this.CaptureButton.UseVisualStyleBackColor = true;
            this.CaptureButton.Click += new System.EventHandler(this.CaptureButton_Click);
            // 
            // PicName
            // 
            this.PicName.Location = new System.Drawing.Point(420, 480);
            this.PicName.Name = "PicName";
            this.PicName.Size = new System.Drawing.Size(215, 20);
            this.PicName.TabIndex = 4;
            this.PicName.Text = "C:\\Users\\RuggedOne\\Desktop\\";
            // 
            // GrayscaleButton
            // 
            this.GrayscaleButton.Location = new System.Drawing.Point(26, 515);
            this.GrayscaleButton.Name = "GrayscaleButton";
            this.GrayscaleButton.Size = new System.Drawing.Size(100, 23);
            this.GrayscaleButton.TabIndex = 5;
            this.GrayscaleButton.Text = "Grayscale";
            this.GrayscaleButton.UseVisualStyleBackColor = true;
            this.GrayscaleButton.Click += new System.EventHandler(this.GrayscaleButton_Click);
            // 
            // CompButton
            // 
            this.CompButton.Location = new System.Drawing.Point(654, 515);
            this.CompButton.Name = "CompButton";
            this.CompButton.Size = new System.Drawing.Size(100, 23);
            this.CompButton.TabIndex = 6;
            this.CompButton.Text = "Compare";
            this.CompButton.UseVisualStyleBackColor = true;
            this.CompButton.Click += new System.EventHandler(this.CompButton_Click);
            // 
            // ComparePic
            // 
            this.ComparePic.Location = new System.Drawing.Point(420, 515);
            this.ComparePic.Name = "ComparePic";
            this.ComparePic.Size = new System.Drawing.Size(215, 20);
            this.ComparePic.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 515);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Reference image:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComparePic);
            this.Controls.Add(this.CompButton);
            this.Controls.Add(this.GrayscaleButton);
            this.Controls.Add(this.PicName);
            this.Controls.Add(this.CaptureButton);
            this.Controls.Add(this.WebcamsBox);
            this.Controls.Add(this.OnOffButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Webcam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.VideoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OnOffButton;
        private System.Windows.Forms.ComboBox WebcamsBox;
        private System.Windows.Forms.PictureBox VideoBox;
        private System.Windows.Forms.Button CaptureButton;
        private System.Windows.Forms.TextBox PicName;
        private System.Windows.Forms.Button GrayscaleButton;
        private System.Windows.Forms.Button CompButton;
        private System.Windows.Forms.TextBox ComparePic;
        private System.Windows.Forms.Label label1;
    }
}

