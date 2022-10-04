namespace gifToBitmap
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.buttonSplit = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonGenerateFile = new System.Windows.Forms.Button();
            this.trackBarThreshold = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxGif = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGif)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBrowse.Location = new System.Drawing.Point(14, 14);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(5);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(147, 67);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxFile
            // 
            this.textBoxFile.Location = new System.Drawing.Point(426, 32);
            this.textBoxFile.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(370, 33);
            this.textBoxFile.TabIndex = 1;
            // 
            // buttonSplit
            // 
            this.buttonSplit.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSplit.Location = new System.Drawing.Point(14, 103);
            this.buttonSplit.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSplit.Name = "buttonSplit";
            this.buttonSplit.Size = new System.Drawing.Size(147, 91);
            this.buttonSplit.TabIndex = 2;
            this.buttonSplit.Text = "Split into frames";
            this.buttonSplit.UseVisualStyleBackColor = true;
            this.buttonSplit.Click += new System.EventHandler(this.buttonSplit_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(14, 213);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(5);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(147, 95);
            this.buttonGenerate.TabIndex = 3;
            this.buttonGenerate.Text = "Generate code";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonGenerateFile
            // 
            this.buttonGenerateFile.Location = new System.Drawing.Point(14, 328);
            this.buttonGenerateFile.Name = "buttonGenerateFile";
            this.buttonGenerateFile.Size = new System.Drawing.Size(147, 79);
            this.buttonGenerateFile.TabIndex = 8;
            this.buttonGenerateFile.Text = "GenerateFile";
            this.buttonGenerateFile.UseVisualStyleBackColor = true;
            this.buttonGenerateFile.Click += new System.EventHandler(this.buttonGenerateFile_Click);
            // 
            // trackBarThreshold
            // 
            this.trackBarThreshold.Enabled = false;
            this.trackBarThreshold.Location = new System.Drawing.Point(358, 328);
            this.trackBarThreshold.Maximum = 255;
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Size = new System.Drawing.Size(496, 45);
            this.trackBarThreshold.TabIndex = 10;
            this.trackBarThreshold.Value = 127;
            this.trackBarThreshold.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(528, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Threshold value";
            // 
            // pictureBoxGif
            // 
            this.pictureBoxGif.Location = new System.Drawing.Point(518, 103);
            this.pictureBoxGif.Name = "pictureBoxGif";
            this.pictureBoxGif.Size = new System.Drawing.Size(176, 175);
            this.pictureBoxGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGif.TabIndex = 12;
            this.pictureBoxGif.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 775);
            this.Controls.Add(this.pictureBoxGif);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarThreshold);
            this.Controls.Add(this.buttonGenerateFile);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonSplit);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.buttonBrowse);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button buttonBrowse;
        private TextBox textBoxFile;
        private Button buttonSplit;
        private Button buttonGenerate;
        private Button buttonGenerateFile;
        private TrackBar trackBarThreshold;
        private Label label1;
        private PictureBox pictureBoxGif;
    }
}