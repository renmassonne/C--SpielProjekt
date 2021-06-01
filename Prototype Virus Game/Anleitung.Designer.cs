
namespace Prototype_Virus_Game
{
    partial class Anleitung
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkOrchid;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(249, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anleitung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkOrchid;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(40, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(688, 172);
            this.label2.TabIndex = 1;
            this.label2.Text = "Erziele 100 Punkte durch das besiegen von Viren.\r\nJe stärker die Viren, desto meh" +
    "r Punkte bekommst du.\r\n(Bild von Virus Level 1) = 1 Punkt\r\n(Bild von Virus Level" +
    " 2) = 2 Punkte\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkOrchid;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(253, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 57);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ziel des Spiels:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkOrchid;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(286, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 57);
            this.label5.TabIndex = 4;
            this.label5.Text = "Steuerung:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkOrchid;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(221, 449);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(326, 215);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nach Rechts laufen: D\r\nNach Links laufen: A\r\nSpringen: Leertaste\r\nZielen: Mauszei" +
    "ger\r\nSchießen: linke Maustaste";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrchid;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(257, 711);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 88);
            this.button1.TabIndex = 6;
            this.button1.Text = "Zurück";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Anleitung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(768, 843);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Anleitung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anleitung";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}