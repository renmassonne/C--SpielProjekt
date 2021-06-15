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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.virusTimer = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblLevelDisplay = new System.Windows.Forms.Label();
            this.pbHealth2 = new System.Windows.Forms.PictureBox();
            this.pbHealth1 = new System.Windows.Forms.PictureBox();
            this.pbHealth = new System.Windows.Forms.PictureBox();
            this.pbBullet = new System.Windows.Forms.PictureBox();
            this.pbBackGround = new System.Windows.Forms.PictureBox();
            this.pbCharacterBounds = new System.Windows.Forms.PictureBox();
            this.pbCharacter = new Prototype_Virus_Game.Character();
            this.pbBossHealthBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterBounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            // 
            // virusTimer
            // 
            this.virusTimer.Interval = 30;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(300, 20);
            this.lblScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(118, 50);
            this.lblScore.TabIndex = 9;
            this.lblScore.Text = "Score: ";
            // 
            // lblLevelDisplay
            // 
            this.lblLevelDisplay.AutoSize = true;
            this.lblLevelDisplay.BackColor = System.Drawing.Color.DarkGray;
            this.lblLevelDisplay.Font = new System.Drawing.Font("Segoe Print", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelDisplay.Location = new System.Drawing.Point(20, 20);
            this.lblLevelDisplay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevelDisplay.Name = "lblLevelDisplay";
            this.lblLevelDisplay.Size = new System.Drawing.Size(33, 50);
            this.lblLevelDisplay.TabIndex = 13;
            this.lblLevelDisplay.Text = " ";
            // 
            // pbHealth2
            // 
            this.pbHealth2.BackColor = System.Drawing.Color.Transparent;
            this.pbHealth2.BackgroundImage = global::Prototype_Virus_Game.Properties.Resources.Heart;
            this.pbHealth2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbHealth2.InitialImage = null;
            this.pbHealth2.Location = new System.Drawing.Point(37, 33);
            this.pbHealth2.Margin = new System.Windows.Forms.Padding(4);
            this.pbHealth2.Name = "pbHealth2";
            this.pbHealth2.Size = new System.Drawing.Size(77, 62);
            this.pbHealth2.TabIndex = 12;
            this.pbHealth2.TabStop = false;
            // 
            // pbHealth1
            // 
            this.pbHealth1.BackColor = System.Drawing.Color.Transparent;
            this.pbHealth1.BackgroundImage = global::Prototype_Virus_Game.Properties.Resources.Heart;
            this.pbHealth1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbHealth1.InitialImage = null;
            this.pbHealth1.Location = new System.Drawing.Point(123, 33);
            this.pbHealth1.Margin = new System.Windows.Forms.Padding(4);
            this.pbHealth1.Name = "pbHealth1";
            this.pbHealth1.Size = new System.Drawing.Size(77, 62);
            this.pbHealth1.TabIndex = 11;
            this.pbHealth1.TabStop = false;
            // 
            // pbHealth
            // 
            this.pbHealth.BackColor = System.Drawing.Color.Transparent;
            this.pbHealth.BackgroundImage = global::Prototype_Virus_Game.Properties.Resources.Heart;
            this.pbHealth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbHealth.InitialImage = null;
            this.pbHealth.Location = new System.Drawing.Point(208, 33);
            this.pbHealth.Margin = new System.Windows.Forms.Padding(4);
            this.pbHealth.Name = "pbHealth";
            this.pbHealth.Size = new System.Drawing.Size(77, 62);
            this.pbHealth.TabIndex = 10;
            this.pbHealth.TabStop = false;
            // 
            // pbBullet
            // 
            this.pbBullet.BackgroundImage = global::Prototype_Virus_Game.Properties.Resources.BlueDot;
            this.pbBullet.Location = new System.Drawing.Point(123, 133);
            this.pbBullet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.pbBackGround.Size = new System.Drawing.Size(2681, 1401);
            this.pbBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackGround.TabIndex = 2;
            this.pbBackGround.TabStop = false;
            this.pbBackGround.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClickShootBullet);
            // 
            // pbCharacterBounds
            // 
            this.pbCharacterBounds.Location = new System.Drawing.Point(12, 12);
            this.pbCharacterBounds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbCharacterBounds.Name = "pbCharacterBounds";
            this.pbCharacterBounds.Size = new System.Drawing.Size(103, 167);
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
            // pbBossHealthBar
            // 
            this.pbBossHealthBar.Location = new System.Drawing.Point(467, 364);
            this.pbBossHealthBar.Name = "pbBossHealthBar";
            this.pbBossHealthBar.Size = new System.Drawing.Size(100, 23);
            this.pbBossHealthBar.TabIndex = 14;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1062, 673);
            this.Controls.Add(this.pbBossHealthBar);
            this.Controls.Add(this.lblLevelDisplay);
            this.Controls.Add(this.pbHealth2);
            this.Controls.Add(this.pbHealth1);
            this.Controls.Add(this.pbHealth);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbBullet);
            this.Controls.Add(this.pbBackGround);
            this.Controls.Add(this.pbCharacterBounds);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virus Game";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterBounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).EndInit();
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
        public Timer gameTimer;
        public Timer virusTimer;      
        private BackgroundWorker backgroundWorker1;
        private Character pbCharacter;
        public PictureBox pbCharacterBounds;        
        public PictureBox pbBullet;
        public Label lblScore;
        public PictureBox pbHealth;
        public PictureBox pbHealth1;
        public PictureBox pbHealth2;
        public Label lblLevelDisplay;
        public ProgressBar pbBossHealthBar;
    }
}

