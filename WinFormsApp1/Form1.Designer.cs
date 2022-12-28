namespace WinFormsApp1
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
            this.player = new System.Windows.Forms.PictureBox();
            this.txtScore = new System.Windows.Forms.Label();
            this.Gametimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Image = global::WinFormsApp1.Properties.Resources.tank;
            this.player.Location = new System.Drawing.Point(715, 600);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(77, 97);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtScore.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtScore.Location = new System.Drawing.Point(28, 700);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(214, 71);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Score: 0";
            this.txtScore.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Gametimer
            // 
            this.Gametimer.Interval = 20;
            this.Gametimer.Tick += new System.EventHandler(this.Gametimerevent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1474, 779);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.player);
            this.Name = "Form1";
            this.Text = "Space Invaders";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox player;
        private Label txtScore;
        private System.Windows.Forms.Timer Gametimer;
    }
}