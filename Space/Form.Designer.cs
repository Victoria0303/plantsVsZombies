using System.Drawing;

namespace Space
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TxtScore = new System.Windows.Forms.Label();
            this.plant = new System.Windows.Forms.PictureBox();
            this.totalScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.plant)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtScore
            // 
            this.TxtScore.AutoSize = true;
            this.TxtScore.BackColor = System.Drawing.Color.Transparent;
            this.TxtScore.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TxtScore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtScore.Location = new System.Drawing.Point(-2, 515);
            this.TxtScore.Name = "TxtScore";
            this.TxtScore.Size = new System.Drawing.Size(98, 31);
            this.TxtScore.TabIndex = 1;
            this.TxtScore.Visible = false;
            this.TxtScore.Text = "Score: 0";
            // 
            // plant
            // 
            this.plant.BackColor = System.Drawing.Color.Transparent;
            this.plant.Image = ((System.Drawing.Image)(resources.GetObject("plant.Image")));
            this.plant.Location = new System.Drawing.Point(285, 463);
            this.plant.Name = "plant";
            this.plant.Size = new System.Drawing.Size(70, 92);
            this.plant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.plant.TabIndex = 0;
            this.plant.TabStop = false;
            // 
            // totalScore
            // 
            this.totalScore.AutoSize = true;
            this.totalScore.BackColor = System.Drawing.Color.Transparent;
            this.totalScore.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.totalScore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalScore.Location = new System.Drawing.Point(550, 515);
            this.totalScore.Name = "totalScore";
            this.totalScore.Size = new System.Drawing.Size(98, 31);
            this.totalScore.TabIndex = 2;
            this.totalScore.Visible = false;
            this.totalScore.Text = "Total Score: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.MainGameTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = new Bitmap(Properties.Resources.background);
            this.ClientSize = new System.Drawing.Size(732, 553);
            this.Controls.Add(this.totalScore);
            this.Controls.Add(this.TxtScore);
            this.Controls.Add(this.plant);
            this.Name = "Form1";
            this.DoubleBuffered = true;
            this.Text = "Zombie Defense";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.plant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label TxtScore;
        private System.Windows.Forms.PictureBox plant;
        private System.Windows.Forms.Label totalScore;
        private System.Windows.Forms.Timer gameTimer;
    }
}

