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
            this.lblScore = new System.Windows.Forms.Label();
            this.pbHealth = new System.Windows.Forms.PictureBox();
            this.pbBullet = new System.Windows.Forms.PictureBox();
            this.pbBackGround = new System.Windows.Forms.PictureBox();
            this.pbCharacterBounds = new System.Windows.Forms.PictureBox();
            this.pbCharacter = new Prototype_Virus_Game.Character();
            this.pbHealth1 = new System.Windows.Forms.PictureBox();
            this.pbHealth2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterBounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth2)).BeginInit();
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
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Location = new System.Drawing.Point(33, 27);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(0, 13);
            this.lblScore.TabIndex = 9;
            // 
            // pbHealth
            // 
            this.pbHealth.BackColor = System.Drawing.Color.Transparent;
            this.pbHealth.BackgroundImage = global::Prototype_Virus_Game.Properties.Resources.Hearth;
            this.pbHealth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbHealth.InitialImage = null;
            this.pbHealth.Location = new System.Drawing.Point(156, 27);
            this.pbHealth.Name = "pbHealth";
            this.pbHealth.Size = new System.Drawing.Size(58, 50);
            this.pbHealth.TabIndex = 10;
            this.pbHealth.TabStop = false;
            this.pbHealth.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbBullet
            // 
            this.pbBullet.Image = global::Prototype_Virus_Game.Properties.Resources.BlueDot;
            this.pbBullet.Location = new System.Drawing.Point(92, 108);
            this.pbBullet.Margin = new System.Windows.Forms.Padding(2);
            this.pbBullet.Name = "pbBullet";
            this.pbBullet.Size = new System.Drawing.Size(11, 12);
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
            this.pbBackGround.BackgroundImage = global::Prototype_Virus_Game.Properties.Resources.Level_1;
            this.pbBackGround.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBackGround.Location = new System.Drawing.Point(0, 0);
            this.pbBackGround.Margin = new System.Windows.Forms.Padding(2);
            this.pbBackGround.Name = "pbBackGround";
            this.pbBackGround.Size = new System.Drawing.Size(1440, 878);
            this.pbBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackGround.TabIndex = 2;
            this.pbBackGround.TabStop = false;
            this.pbBackGround.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickShootBullet);
            // 
            // pbCharacterBounds
            // 
            this.pbCharacterBounds.Location = new System.Drawing.Point(9, 10);
            this.pbCharacterBounds.Margin = new System.Windows.Forms.Padding(2);
            this.pbCharacterBounds.Name = "pbCharacterBounds";
            this.pbCharacterBounds.Size = new System.Drawing.Size(77, 136);
            this.pbCharacterBounds.TabIndex = 6;
            this.pbCharacterBounds.TabStop = false;
            this.pbCharacterBounds.Text = "pbCharacterBounds";
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
            // pbHealth1
            // 
            this.pbHealth1.BackColor = System.Drawing.Color.Transparent;
            this.pbHealth1.BackgroundImage = global::Prototype_Virus_Game.Properties.Resources.Hearth;
            this.pbHealth1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbHealth1.InitialImage = null;
            this.pbHealth1.Location = new System.Drawing.Point(92, 27);
            this.pbHealth1.Name = "pbHealth1";
            this.pbHealth1.Size = new System.Drawing.Size(58, 50);
            this.pbHealth1.TabIndex = 11;
            this.pbHealth1.TabStop = false;
            // 
            // pbHealth2
            // 
            this.pbHealth2.BackColor = System.Drawing.Color.Transparent;
            this.pbHealth2.BackgroundImage = global::Prototype_Virus_Game.Properties.Resources.Hearth;
            this.pbHealth2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbHealth2.InitialImage = null;
            this.pbHealth2.Location = new System.Drawing.Point(28, 27);
            this.pbHealth2.Name = "pbHealth2";
            this.pbHealth2.Size = new System.Drawing.Size(58, 50);
            this.pbHealth2.TabIndex = 12;
            this.pbHealth2.TabStop = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(226, 287);
            this.Controls.Add(this.pbHealth2);
            this.Controls.Add(this.pbHealth1);
            this.Controls.Add(this.pbHealth);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbBullet);
            this.Controls.Add(this.pbBackGround);
            this.Controls.Add(this.pbCharacterBounds);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Game";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterBounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        public PictureBox pbBullet;
        public Label lblScore;
        public PictureBox pbHealth;
        public PictureBox pbHealth1;
        public PictureBox pbHealth2;
    }
}

