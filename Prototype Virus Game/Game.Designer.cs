using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Prototype_Virus_Game
{
    partial class Game
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timervirus = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            UiComponents.Components = new List<PictureBox>();
            this.pbPlatform = new System.Windows.Forms.PictureBox();
            UiComponents.Platform = this.pbPlatform;
            this.pbCharacter = new Character();
            UiComponents.Character = this.pbCharacter;
            this.pbVirus = new Virus();
            UiComponents.Virus = this.pbVirus;

            this.pbBackGround = new System.Windows.Forms.PictureBox();
            UiComponents.BackGround = this.pbBackGround;
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVirus)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            this.timer.Tick += new System.EventHandler(new CharacterLogic().Logic);
            //
            // timervirus
            //
            this.timervirus.Enabled = true;
            this.timervirus.Interval = 30;
            this.timervirus.Tick += new System.EventHandler(new VirusLogic().Logic);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // pbPlatform
            // 
            this.pbPlatform.BackColor = System.Drawing.Color.White;
            this.pbPlatform.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPlatform.ErrorImage = null;
            this.pbPlatform.Image = global::Prototype_Virus_Game.Properties.Resources.platform;
            this.pbPlatform.Location = new System.Drawing.Point(443, 355);
            this.pbPlatform.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbPlatform.Name = "pbPlatform";
            this.pbPlatform.Size = new System.Drawing.Size(326, 95);
            this.pbPlatform.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlatform.TabIndex = 4;
            this.pbPlatform.TabStop = false;
            this.pbPlatform.Tag = "platform";

            // 
            // pbBackGround
            // 
            this.pbBackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBackGround.BackColor = System.Drawing.Color.White;
            this.pbBackGround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBackGround.Image = global::Prototype_Virus_Game.Properties.Resources.Level_1;
            this.pbBackGround.Location = new System.Drawing.Point(0, 0);
            this.pbBackGround.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbBackGround.Name = "pbBackGround";
            this.pbBackGround.Size = new System.Drawing.Size(1262, 673);
            this.pbBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackGround.TabIndex = 2;
            this.pbBackGround.TabStop = false;
            // 
            // Game
            // 
            InitializeGameBoard();

            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(new KeyDownEventHandler().Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(new KeyUpEventHandler().Game_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVirus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeGameBoard()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.pbCharacter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbPlatform);
            this.Controls.Add(this.pbBackGround);
            this.Controls.Add(this.pbVirus);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virüs Schmirüs";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
        }

        #endregion
        private PictureBox pbBackGround;
        private PictureBox pbCharacter;
        private PictureBox pbVirus;
        private Timer timer;
        private Timer timervirus;
        private PictureBox pbPlatform;
        private BackgroundWorker backgroundWorker1;
        private Label label1;
    }
}

