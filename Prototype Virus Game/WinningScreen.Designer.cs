namespace Prototype_Virus_Game
{
    partial class WinningScreen
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
            this.btnNeustart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBeenden = new System.Windows.Forms.Button();
            this.tbSpielerName = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblGespeichert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkOrchid;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(764, 215);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dr. Astra Willi den Virus und seine Arme von Viren besiegen \r\nund hat die Welt ge" +
    "rettet. \r\n\r\nGib deinen Namen ein, um deinen Score zu speichern:\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNeustart
            // 
            this.btnNeustart.BackColor = System.Drawing.Color.DarkViolet;
            this.btnNeustart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNeustart.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNeustart.Location = new System.Drawing.Point(130, 530);
            this.btnNeustart.Name = "btnNeustart";
            this.btnNeustart.Size = new System.Drawing.Size(155, 64);
            this.btnNeustart.TabIndex = 1;
            this.btnNeustart.Text = "Neustart";
            this.btnNeustart.UseVisualStyleBackColor = false;
            this.btnNeustart.Click += new System.EventHandler(this.btnNeustart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkOrchid;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(624, 105);
            this.label2.TabIndex = 2;
            this.label2.Text = "Du hast gewonnen!\r\n";
            // 
            // btnBeenden
            // 
            this.btnBeenden.BackColor = System.Drawing.Color.DarkViolet;
            this.btnBeenden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeenden.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeenden.Location = new System.Drawing.Point(538, 530);
            this.btnBeenden.Name = "btnBeenden";
            this.btnBeenden.Size = new System.Drawing.Size(155, 64);
            this.btnBeenden.TabIndex = 3;
            this.btnBeenden.Text = "Beenden";
            this.btnBeenden.UseVisualStyleBackColor = false;
            this.btnBeenden.Click += new System.EventHandler(this.btnBeenden_Click);
            // 
            // tbSpielerName
            // 
            this.tbSpielerName.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSpielerName.Location = new System.Drawing.Point(61, 421);
            this.tbSpielerName.Multiline = true;
            this.tbSpielerName.Name = "tbSpielerName";
            this.tbSpielerName.Size = new System.Drawing.Size(616, 52);
            this.tbSpielerName.TabIndex = 4;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.DarkViolet;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(695, 421);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(81, 52);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "OK";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblGespeichert
            // 
            this.lblGespeichert.AutoSize = true;
            this.lblGespeichert.BackColor = System.Drawing.Color.DarkOrchid;
            this.lblGespeichert.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGespeichert.Location = new System.Drawing.Point(277, 476);
            this.lblGespeichert.Name = "lblGespeichert";
            this.lblGespeichert.Size = new System.Drawing.Size(270, 35);
            this.lblGespeichert.TabIndex = 6;
            this.lblGespeichert.Text = "Nutzer wurde gespeichert";
            this.lblGespeichert.Visible = false;
            // 
            // WinningScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(887, 623);
            this.Controls.Add(this.lblGespeichert);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tbSpielerName);
            this.Controls.Add(this.btnBeenden);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNeustart);
            this.Controls.Add(this.label1);
            this.Name = "WinningScreen";
            this.Text = "WinningScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNeustart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBeenden;
        private System.Windows.Forms.TextBox tbSpielerName;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblGespeichert;
    }
}