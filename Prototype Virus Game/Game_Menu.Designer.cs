using System.Drawing;

namespace Prototype_Virus_Game
{
    partial class Game_Menu
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
            this.btnWeiter = new System.Windows.Forms.Button();
            this.btnVollbildToggle = new System.Windows.Forms.Button();
            this.btnLautstärke = new System.Windows.Forms.Button();
            this.btnLeaderBoard = new System.Windows.Forms.Button();
            this.btnBeenden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWeiter
            // 
            this.btnWeiter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnWeiter.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnWeiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeiter.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeiter.Location = new System.Drawing.Point(38, 59);
            this.btnWeiter.Name = "btnWeiter";
            this.btnWeiter.Size = new System.Drawing.Size(416, 68);
            this.btnWeiter.TabIndex = 0;
            this.btnWeiter.Text = "Weiter ";
            this.btnWeiter.UseCompatibleTextRendering = true;
            this.btnWeiter.UseVisualStyleBackColor = false;
            this.btnWeiter.Click += new System.EventHandler(this.btnWeiter_Click);
            // 
            // btnVollbildToggle
            // 
            this.btnVollbildToggle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVollbildToggle.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnVollbildToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVollbildToggle.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVollbildToggle.Location = new System.Drawing.Point(38, 166);
            this.btnVollbildToggle.Name = "btnVollbildToggle";
            this.btnVollbildToggle.Size = new System.Drawing.Size(416, 68);
            this.btnVollbildToggle.TabIndex = 1;
            this.btnVollbildToggle.Text = "Vollbild: Aus";
            this.btnVollbildToggle.UseCompatibleTextRendering = true;
            this.btnVollbildToggle.UseVisualStyleBackColor = false;
            this.btnVollbildToggle.Click += new System.EventHandler(this.btnVollbildToggle_Click);
            // 
            // btnLautstärke
            // 
            this.btnLautstärke.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLautstärke.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnLautstärke.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLautstärke.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLautstärke.Location = new System.Drawing.Point(38, 276);
            this.btnLautstärke.Name = "btnLautstärke";
            this.btnLautstärke.Size = new System.Drawing.Size(416, 68);
            this.btnLautstärke.TabIndex = 2;
            this.btnLautstärke.Text = "Lautstärke";
            this.btnLautstärke.UseCompatibleTextRendering = true;
            this.btnLautstärke.UseVisualStyleBackColor = false;
            this.btnLautstärke.Click += new System.EventHandler(this.btnLautstärke_Click);
            // 
            // btnLeaderBoard
            // 
            this.btnLeaderBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLeaderBoard.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnLeaderBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeaderBoard.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaderBoard.Location = new System.Drawing.Point(38, 393);
            this.btnLeaderBoard.Name = "btnLeaderBoard";
            this.btnLeaderBoard.Size = new System.Drawing.Size(416, 68);
            this.btnLeaderBoard.TabIndex = 3;
            this.btnLeaderBoard.Text = "Leaderboard";
            this.btnLeaderBoard.UseCompatibleTextRendering = true;
            this.btnLeaderBoard.UseVisualStyleBackColor = false;
            // 
            // btnBeenden
            // 
            this.btnBeenden.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBeenden.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnBeenden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeenden.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeenden.Location = new System.Drawing.Point(38, 552);
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.Size = new System.Drawing.Size(416, 68);
            this.btnBeenden.TabIndex = 4;
            this.btnBeenden.Text = "Spiel beenden";
            this.btnBeenden.UseCompatibleTextRendering = true;
            this.btnBeenden.UseVisualStyleBackColor = false;
            this.btnBeenden.Click += new System.EventHandler(this.btnBeenden_Click);
            // 
            // Game_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(500, 660);
            this.Controls.Add(this.btnBeenden);
            this.Controls.Add(this.btnLeaderBoard);
            this.Controls.Add(this.btnLautstärke);
            this.Controls.Add(this.btnVollbildToggle);
            this.Controls.Add(this.btnWeiter);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Game_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWeiter;
        private System.Windows.Forms.Button btnVollbildToggle;
        private System.Windows.Forms.Button btnLautstärke;
        private System.Windows.Forms.Button btnLeaderBoard;
        private System.Windows.Forms.Button btnBeenden;
    }
}