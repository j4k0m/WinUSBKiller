
namespace WUSBKiller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.TargetBox = new System.Windows.Forms.TextBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.Drives = new System.Windows.Forms.ComboBox();
            this.HideVolumesBox = new System.Windows.Forms.CheckBox();
            this.FormatBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::WUSBKiller.Properties.Resources.done;
            this.pictureBox3.Location = new System.Drawing.Point(606, 184);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 69);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WUSBKiller.Properties.Resources.toxic;
            this.pictureBox2.Location = new System.Drawing.Point(356, 184);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 69);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WUSBKiller.Properties.Resources._480px_Windows_Settings_app_icon;
            this.pictureBox1.Location = new System.Drawing.Point(106, 184);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 69);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(106, 268);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(113, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Random Overwrite";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(181, 207);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(169, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(431, 207);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(169, 23);
            this.progressBar2.TabIndex = 5;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(106, 291);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(144, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "Choose File To Overwrite";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // TargetBox
            // 
            this.TargetBox.Enabled = false;
            this.TargetBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.TargetBox.Location = new System.Drawing.Point(106, 314);
            this.TargetBox.Name = "TargetBox";
            this.TargetBox.Size = new System.Drawing.Size(144, 20);
            this.TargetBox.TabIndex = 7;
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.NextButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.NextButton.Location = new System.Drawing.Point(649, 380);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(120, 46);
            this.NextButton.TabIndex = 8;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Drives
            // 
            this.Drives.Enabled = false;
            this.Drives.FormattingEnabled = true;
            this.Drives.Location = new System.Drawing.Point(305, 287);
            this.Drives.Name = "Drives";
            this.Drives.Size = new System.Drawing.Size(170, 21);
            this.Drives.TabIndex = 9;
            // 
            // HideVolumesBox
            // 
            this.HideVolumesBox.AutoSize = true;
            this.HideVolumesBox.Enabled = false;
            this.HideVolumesBox.Location = new System.Drawing.Point(331, 315);
            this.HideVolumesBox.Name = "HideVolumesBox";
            this.HideVolumesBox.Size = new System.Drawing.Size(133, 17);
            this.HideVolumesBox.TabIndex = 10;
            this.HideVolumesBox.TabStop = false;
            this.HideVolumesBox.Text = "Show Hidden Volumes";
            this.HideVolumesBox.UseVisualStyleBackColor = true;
            this.HideVolumesBox.CheckedChanged += new System.EventHandler(this.HideVolumesBox_CheckedChanged);
            // 
            // FormatBox
            // 
            this.FormatBox.AutoSize = true;
            this.FormatBox.Enabled = false;
            this.FormatBox.Location = new System.Drawing.Point(331, 338);
            this.FormatBox.Name = "FormatBox";
            this.FormatBox.Size = new System.Drawing.Size(101, 17);
            this.FormatBox.TabIndex = 11;
            this.FormatBox.Text = "Format to NTFS";
            this.FormatBox.UseVisualStyleBackColor = true;
            this.FormatBox.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(781, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FormatBox);
            this.Controls.Add(this.HideVolumesBox);
            this.Controls.Add(this.Drives);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.TargetBox);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox TargetBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.ComboBox Drives;
        private System.Windows.Forms.CheckBox HideVolumesBox;
        private System.Windows.Forms.CheckBox FormatBox;
        private System.Windows.Forms.Button button1;
    }
}

