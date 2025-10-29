namespace AchatJeuxVideo
{
    partial class FrmAPropos
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
            this.labelTitre = new System.Windows.Forms.Label();
            this.labelAuteur = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.buttonFermer = new System.Windows.Forms.Button();
            this.labelEntreprise = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitre
            // 
            this.labelTitre.AutoSize = true;
            this.labelTitre.Location = new System.Drawing.Point(280, 63);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(155, 20);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "Achat de Jeux Vidéo";
            // 
            // labelAuteur
            // 
            this.labelAuteur.AutoSize = true;
            this.labelAuteur.Location = new System.Drawing.Point(12, 243);
            this.labelAuteur.Name = "labelAuteur";
            this.labelAuteur.Size = new System.Drawing.Size(310, 20);
            this.labelAuteur.TabIndex = 1;
            this.labelAuteur.Text = "Développé par : Lydianne, Labib,Mohamed";
            this.labelAuteur.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 500);
            this.label2.TabIndex = 2;
            this.label2.Text = "Entreprise : GameSoft Solutions inc.";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(12, 280);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(160, 20);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Version : 1.0.0 (2025)";
            // 
            // buttonFermer
            // 
            this.buttonFermer.Location = new System.Drawing.Point(593, 362);
            this.buttonFermer.Name = "buttonFermer";
            this.buttonFermer.Size = new System.Drawing.Size(159, 40);
            this.buttonFermer.TabIndex = 4;
            this.buttonFermer.Text = "Fermer";
            this.buttonFermer.UseVisualStyleBackColor = true;
            this.buttonFermer.Click += new System.EventHandler(this.buttonFermer_Click);
            // 
            // labelEntreprise
            // 
            this.labelEntreprise.AutoSize = true;
            this.labelEntreprise.Location = new System.Drawing.Point(13, 197);
            this.labelEntreprise.Name = "labelEntreprise";
            this.labelEntreprise.Size = new System.Drawing.Size(266, 20);
            this.labelEntreprise.TabIndex = 5;
            this.labelEntreprise.Text = "Entreprise : GameSoft Solutions inc.";
            // 
            // FrmAPropos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 431);
            this.Controls.Add(this.labelEntreprise);
            this.Controls.Add(this.buttonFermer);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelAuteur);
            this.Controls.Add(this.labelTitre);
            this.Name = "FrmAPropos";
            this.Text = "FrmAPropos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.Label labelAuteur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button buttonFermer;
        private System.Windows.Forms.Label labelEntreprise;
    }
}