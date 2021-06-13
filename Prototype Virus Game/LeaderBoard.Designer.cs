namespace Prototype_Virus_Game
{
    partial class LeaderBoard
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
            this.lbScore = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbScore
            // 
            this.lbScore.BackColor = System.Drawing.SystemColors.Menu;
            this.lbScore.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lbScore.FormattingEnabled = true;
            this.lbScore.ItemHeight = 16;
            this.lbScore.Location = new System.Drawing.Point(123, 35);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(524, 340);
            this.lbScore.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(351, 391);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "zurück";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // LeaderBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lbScore);
            this.Name = "LeaderBoard";
            this.Text = "LeaderBoard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbScore;
        private System.Windows.Forms.Button btnBack;
    }
}