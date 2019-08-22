namespace FishFinderX
{
    partial class FishFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FishFinder));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelPoints = new System.Windows.Forms.Label();
            this.labelFilename = new System.Windows.Forms.Label();
            this.labelMin = new System.Windows.Forms.Label();
            this.labelMax = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelHelp = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox.Location = new System.Drawing.Point(90, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 50);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.ForeColor = System.Drawing.Color.Gold;
            this.labelPoints.Location = new System.Drawing.Point(10, 9);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(52, 13);
            this.labelPoints.TabIndex = 1;
            this.labelPoints.Text = "{x=0;y=0}";
            // 
            // labelFilename
            // 
            this.labelFilename.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelFilename.AutoSize = true;
            this.labelFilename.ForeColor = System.Drawing.Color.Gold;
            this.labelFilename.Location = new System.Drawing.Point(340, 431);
            this.labelFilename.Name = "labelFilename";
            this.labelFilename.Size = new System.Drawing.Size(46, 13);
            this.labelFilename.TabIndex = 2;
            this.labelFilename.Text = "filename";
            // 
            // labelMin
            // 
            this.labelMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMin.AutoSize = true;
            this.labelMin.ForeColor = System.Drawing.Color.Gold;
            this.labelMin.Location = new System.Drawing.Point(10, 431);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(23, 13);
            this.labelMin.TabIndex = 3;
            this.labelMin.Text = "min";
            // 
            // labelMax
            // 
            this.labelMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMax.AutoSize = true;
            this.labelMax.ForeColor = System.Drawing.Color.Gold;
            this.labelMax.Location = new System.Drawing.Point(717, 431);
            this.labelMax.Name = "labelMax";
            this.labelMax.Size = new System.Drawing.Size(26, 13);
            this.labelMax.TabIndex = 4;
            this.labelMax.Text = "max";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.progressBar.Location = new System.Drawing.Point(1, 405);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(753, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            // 
            // labelHelp
            // 
            this.labelHelp.BackColor = System.Drawing.Color.LightGray;
            this.labelHelp.Font = new System.Drawing.Font("Monospac821 BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelp.Location = new System.Drawing.Point(40, 65);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(569, 314);
            this.labelHelp.TabIndex = 6;
            this.labelHelp.Text = resources.GetString("labelHelp.Text");
            // 
            // FishFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(755, 453);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelMax);
            this.Controls.Add(this.labelMin);
            this.Controls.Add(this.labelFilename);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FishFinder";
            this.Text = "Fish Finder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FishFinder_FormClosing);
            this.Load += new System.EventHandler(this.FishFinder_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FishFinder_KeyDown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FishFinder_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.Label labelFilename;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelHelp;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        
    }
}

