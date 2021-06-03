using Prototype_Virus_Game.Properties;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timervirus = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbBullet = new System.Windows.Forms.PictureBox();
            this.pbBackGround = new System.Windows.Forms.PictureBox();
            this.pbCharacterBounds = new System.Windows.Forms.PictureBox();
            this.pbPlatform1 = new System.Windows.Forms.PictureBox();
            this.pbPlatform2 = new System.Windows.Forms.PictureBox();
            this.pbPlatform3 = new System.Windows.Forms.PictureBox();
            this.pbPlatform4 = new System.Windows.Forms.PictureBox();
            this.pbCharacter = new Prototype_Virus_Game.Character();
            ((System.ComponentModel.ISupportInitialize)(this.pbBullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterBounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 20;
            // 
            // timervirus
            // 
            this.timervirus.Enabled = true;
            this.timervirus.Interval = 30;
            // 
            // pbBullet
            // 
            this.pbBullet.Image = global::Prototype_Virus_Game.Properties.Resources.BlueDot;
            this.pbBullet.Location = new System.Drawing.Point(122, 133);
            this.pbBullet.Name = "pbBullet";
            this.pbBullet.Size = new System.Drawing.Size(15, 15);
            this.pbBullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBullet.TabIndex = 7;
            this.pbBullet.TabStop = false;
            // 
            // pbBackGround
            // 
            this.pbBackGround.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBackGround.BackColor = System.Drawing.Color.White;
            this.pbBackGround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBackGround.Location = new System.Drawing.Point(0, 0);
            this.pbBackGround.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbBackGround.Name = "pbBackGround";
            this.pbBackGround.Size = new System.Drawing.Size(1920, 1080);
            this.pbBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackGround.TabIndex = 2;
            this.pbBackGround.TabStop = false;
            this.pbBackGround.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickShootBullet);
            // 
            // pbCharacterBounds
            // 
            this.pbCharacterBounds.Location = new System.Drawing.Point(12, 12);
            this.pbCharacterBounds.Name = "pbCharacterBounds";
            this.pbCharacterBounds.Size = new System.Drawing.Size(103, 167);
            this.pbCharacterBounds.TabIndex = 6;
            this.pbCharacterBounds.TabStop = false;
            this.pbCharacterBounds.Text = "pbCharacterBounds";
            // 
            // pbPlatform1
            // 
            this.pbPlatform1.Location = new System.Drawing.Point(15, 204);
            this.pbPlatform1.Name = "pbPlatform1";
            this.pbPlatform1.Size = new System.Drawing.Size(100, 50);
            this.pbPlatform1.TabIndex = 6;
            this.pbPlatform1.TabStop = false;
            // 
            // pbPlatform2
            // 
            this.pbPlatform2.Location = new System.Drawing.Point(15, 274);
            this.pbPlatform2.Name = "pbPlatform2";
            this.pbPlatform2.Size = new System.Drawing.Size(100, 50);
            this.pbPlatform2.TabIndex = 6;
            this.pbPlatform2.TabStop = false;
            // 
            // pbPlatform3
            // 
            this.pbPlatform3.Location = new System.Drawing.Point(0, 0);
            this.pbPlatform3.Name = "pbPlatform3";
            this.pbPlatform3.Size = new System.Drawing.Size(100, 50);
            this.pbPlatform3.TabIndex = 6;
            this.pbPlatform3.TabStop = false;
            // 
            // pbPlatform4
            // 
            this.pbPlatform4.Location = new System.Drawing.Point(0, 0);
            this.pbPlatform4.Name = "pbPlatform4";
            this.pbPlatform4.Size = new System.Drawing.Size(100, 50);
            this.pbPlatform4.TabIndex = 6;
            this.pbPlatform4.TabStop = false;
            // 
            // pbCharacter
            // 
            this.pbCharacter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCharacter.BackColor = System.Drawing.Color.White;
            this.pbCharacter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCharacter.Image = ((System.Drawing.Image)(resources.GetObject("pbCharacter.Image")));
            this.pbCharacter.Location = new System.Drawing.Point(157, 439);
            this.pbCharacter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbCharacter.Name = "pbCharacter";
            this.pbCharacter.Size = new System.Drawing.Size(103, 167);
            this.pbCharacter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCharacter.TabIndex = 3;
            this.pbCharacter.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(301, 353);
            this.Controls.Add(this.pbBullet);
            this.Controls.Add(this.pbBackGround);
            this.Controls.Add(this.pbCharacterBounds);
            this.Controls.Add(this.pbPlatform1);
            this.Controls.Add(this.pbPlatform2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Game";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterBounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).EndInit();
            this.ResumeLayout(false);

        }

        private void InitializeGameBoard()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(GameState.GameBoardWidth, GameState.GameBoardHeight);
            this.Controls.Add(this.pbCharacter);                    
            this.Controls.Add(this.pbBackGround);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virüs Schmirüs";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
        }



        #endregion
        public PictureBox pbBackGround;
        private Timer timer;
        private Timer timervirus;      
        private BackgroundWorker backgroundWorker1;
        private Character pbCharacter;
        public PictureBox pbCharacterBounds;
        public PictureBox pbPlatform1;
        public PictureBox pbPlatform2;
        private PictureBox pbPlatform3;
        private PictureBox pbPlatform4;
        public PictureBox pbBullet;
    }
}

