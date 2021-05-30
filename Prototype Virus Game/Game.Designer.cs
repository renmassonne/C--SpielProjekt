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
            GameState.GameBoardHeight = 720;
            GameState.GameBoardWidth = 1280;
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timervirus = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            UiComponents.Components = new List<PictureBox>();
            UiComponents.Viruses = new List<Virus>();
            this.pbPlatform = new System.Windows.Forms.PictureBox();          
            this.pbCharacter = new Character();
            this.pbCharacterBounds = new System.Windows.Forms.PictureBox();
            this.pbPlatform2 = new System.Windows.Forms.PictureBox();
            this.pbPlatform1 = new System.Windows.Forms.PictureBox();
            UiComponents.Platform = pbPlatform1;
            UiComponents.Platform = pbPlatform2;           
            UiComponents.Character = this.pbCharacter;
           

            this.pbBackGround = new System.Windows.Forms.PictureBox();
            UiComponents.BackGround = this.pbBackGround;
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterBounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform2)).BeginInit();
            this.SuspendLayout();

            //for (int i = 0; i < 2; i++)
            //{
            //    var virus = new Virus();
            //    UiComponents.AddVirus(virus);
            //    ((System.ComponentModel.ISupportInitialize)(virus)).BeginInit();
            //    this.Controls.Add(virus);
            //    ((System.ComponentModel.ISupportInitialize)(virus)).EndInit();
            //}
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
            // pbCharacterBounds
            //            
            this.pbCharacterBounds.Location = new System.Drawing.Point(250, 485);
            this.pbCharacterBounds.Name = "pbCharacterBounds";
            this.pbCharacterBounds.Size = new System.Drawing.Size(103, 167);
            this.pbCharacterBounds.TabIndex = 6;
            this.pbCharacterBounds.Text = "pbCharacterBounds";
            // 
            // pbPlatform1
            //            
            this.pbPlatform1.Location = new System.Drawing.Point(250, 485);
            this.pbPlatform1.BackColor = System.Drawing.Color.Black;
            this.pbPlatform1.Name = "pbPlatform1";
            this.pbPlatform1.Size = new System.Drawing.Size(103, 167);
            this.pbPlatform1.TabIndex = 6;
            this.pbPlatform1.Text = "pbPlatform1";
            this.pbPlatform.Tag = "platform";
            // 
            // pbPlatform2
            //            
            this.pbPlatform2.Location = new System.Drawing.Point(250, 485);
            this.pbPlatform2.BackColor = System.Drawing.Color.Black;
            this.pbPlatform2.Name = "pbPlatform2";
            this.pbPlatform2.Size = new System.Drawing.Size(103, 167);
            this.pbPlatform2.TabIndex = 6;
            this.pbPlatform2.Text = "pbPlatform2";
            this.pbPlatform.Tag = "platform";
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
            this.pbBackGround.Size = new System.Drawing.Size(GameState.GameBoardWidth, GameState.GameBoardHeight);
            this.pbBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackGround.TabIndex = 2;
            this.pbBackGround.TabStop = false;            
            // 
            // Game
            //            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(GameState.GameBoardWidth, GameState.GameBoardHeight);
            //this.Controls.Add(this.pbCharacter);
            //this.Controls.Add(this.pbPlatform);
            this.Controls.Add(this.pbBackGround);
            this.Controls.Add(this.pbCharacterBounds);
            this.Controls.Add(this.pbPlatform1);
            this.Controls.Add(this.pbPlatform2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Virüs Schmirüs";
            this.TransparencyKey = System.Drawing.SystemColors.Control;

            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(new KeyDownEventHandler().Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(new KeyUpEventHandler().Game_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharacterBounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlatform2)).EndInit();
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
            this.Controls.Add(this.pbPlatform);
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
        private PictureBox pbPlatform;
        private BackgroundWorker backgroundWorker1;
        private Character pbCharacter;
        public PictureBox pbCharacterBounds;
        public PictureBox pbPlatform1;
        public PictureBox pbPlatform2;
    }
}

