using System.Drawing;

namespace Prototype_Virus_Game
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbPlatform = new System.Windows.Forms.PictureBox();
            this.pbCharacter = new System.Windows.Forms.PictureBox();
            this.pbBackGround = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbPlatform
            // 
            this.pbPlatform.BackColor = System.Drawing.Color.Transparent;
            this.pbPlatform.Image = global::Prototype_Virus_Game.Properties.Resources.kisscc0_computer_icons_video_games_mario_series_platform_g_ilmenskie_flying_platform_4_5b728ee6203db5_8750860715342343421321;
            this.pbPlatform.Location = new System.Drawing.Point(657, 348);
            this.pbPlatform.Margin = new System.Windows.Forms.Padding(2);
            this.pbPlatform.Name = "pbPlatform";
            this.pbPlatform.Size = new System.Drawing.Size(182, 63);
            this.pbPlatform.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlatform.TabIndex = 4;
            this.pbPlatform.TabStop = false;
            this.pbPlatform.Tag = "platform";
            // 
            // pbCharacter
            // 
            this.pbCharacter.BackColor = System.Drawing.Color.Transparent;
            this.pbCharacter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCharacter.Image = global::Prototype_Virus_Game.Properties.Resources.Unbenannt_1;
            this.pbCharacter.Location = new System.Drawing.Point(159, 435);
            this.pbCharacter.Margin = new System.Windows.Forms.Padding(2);
            this.pbCharacter.Name = "pbCharacter";
            this.pbCharacter.Size = new System.Drawing.Size(106, 179);
            this.pbCharacter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCharacter.TabIndex = 3;
            this.pbCharacter.TabStop = false;
            // 
            // pbBackGround
            // 
            this.pbBackGround.BackColor = System.Drawing.SystemColors.Control;
            this.pbBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackGround.Image = global::Prototype_Virus_Game.Properties.Resources.Level_1;
            this.pbBackGround.Location = new System.Drawing.Point(0, 0);
            this.pbBackGround.Margin = new System.Windows.Forms.Padding(2);
            this.pbBackGround.Name = "pbBackGround";
            this.pbBackGround.Size = new System.Drawing.Size(1264, 681);
            this.pbBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackGround.TabIndex = 2;
            this.pbBackGround.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.pbPlatform);
            this.Controls.Add(this.pbCharacter);
            this.Controls.Add(this.pbBackGround);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Virüs Schmirüs";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbBackGround;
        private System.Windows.Forms.PictureBox pbCharacter;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbPlatform;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

