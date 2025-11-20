namespace AchatJeuxVideo
{
    partial class AchatJeuxVideo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AchatJeuxVideo));
            this.clientGroupBox = new System.Windows.Forms.GroupBox();
            this.nomJeuMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.nomJeuLabel = new System.Windows.Forms.Label();
            this.telephoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.codePostalMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.adresseMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.prenomMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.nomMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.codePostalLabel = new System.Windows.Forms.Label();
            this.adresseLabel = new System.Windows.Forms.Label();
            this.prenomLabel = new System.Windows.Forms.Label();
            this.nomLabel = new System.Windows.Forms.Label();
            this.transactionGroupBox = new System.Windows.Forms.GroupBox();
            this.prixLabel = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.platformeComboBox = new System.Windows.Forms.ComboBox();
            this.dateAchatDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.platformeLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.prixJeuxLabel = new System.Windows.Forms.Label();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.achatsLabel = new System.Windows.Forms.Label();
            this.consolesPictureBox = new System.Windows.Forms.PictureBox();
            this.jeuxPictureBox = new System.Windows.Forms.PictureBox();
            this.jeuxVideosMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aproposDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterButton = new System.Windows.Forms.Button();
            this.enregistrerButton = new System.Windows.Forms.Button();
            this.clientGroupBox.SuspendLayout();
            this.transactionGroupBox.SuspendLayout();
            this.imagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.consolesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jeuxPictureBox)).BeginInit();
            this.jeuxVideosMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientGroupBox
            // 
            this.clientGroupBox.Controls.Add(this.nomJeuMaskedTextBox);
            this.clientGroupBox.Controls.Add(this.nomJeuLabel);
            this.clientGroupBox.Controls.Add(this.telephoneMaskedTextBox);
            this.clientGroupBox.Controls.Add(this.codePostalMaskedTextBox);
            this.clientGroupBox.Controls.Add(this.adresseMaskedTextBox);
            this.clientGroupBox.Controls.Add(this.prenomMaskedTextBox);
            this.clientGroupBox.Controls.Add(this.nomMaskedTextBox);
            this.clientGroupBox.Controls.Add(this.telephoneLabel);
            this.clientGroupBox.Controls.Add(this.codePostalLabel);
            this.clientGroupBox.Controls.Add(this.adresseLabel);
            this.clientGroupBox.Controls.Add(this.prenomLabel);
            this.clientGroupBox.Controls.Add(this.nomLabel);
            this.clientGroupBox.Location = new System.Drawing.Point(70, 642);
            this.clientGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clientGroupBox.Name = "clientGroupBox";
            this.clientGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.clientGroupBox.Size = new System.Drawing.Size(657, 590);
            this.clientGroupBox.TabIndex = 2;
            this.clientGroupBox.TabStop = false;
            this.clientGroupBox.Text = "Client";
            // 
            // nomJeuMaskedTextBox
            // 
            this.nomJeuMaskedTextBox.Location = new System.Drawing.Point(219, 506);
            this.nomJeuMaskedTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.nomJeuMaskedTextBox.Name = "nomJeuMaskedTextBox";
            this.nomJeuMaskedTextBox.Size = new System.Drawing.Size(399, 29);
            this.nomJeuMaskedTextBox.TabIndex = 33;
            this.nomJeuMaskedTextBox.Enter += new System.EventHandler(this.MaskedTextBoxEnter);
            // 
            // nomJeuLabel
            // 
            this.nomJeuLabel.AutoSize = true;
            this.nomJeuLabel.Location = new System.Drawing.Point(25, 510);
            this.nomJeuLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nomJeuLabel.Name = "nomJeuLabel";
            this.nomJeuLabel.Size = new System.Drawing.Size(119, 24);
            this.nomJeuLabel.TabIndex = 32;
            this.nomJeuLabel.Text = "Nom du jeu :";
            // 
            // telephoneMaskedTextBox
            // 
            this.telephoneMaskedTextBox.Location = new System.Drawing.Point(219, 420);
            this.telephoneMaskedTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.telephoneMaskedTextBox.Name = "telephoneMaskedTextBox";
            this.telephoneMaskedTextBox.Size = new System.Drawing.Size(399, 29);
            this.telephoneMaskedTextBox.TabIndex = 31;
            this.telephoneMaskedTextBox.Enter += new System.EventHandler(this.MaskedTextBoxEnter);
            // 
            // codePostalMaskedTextBox
            // 
            this.codePostalMaskedTextBox.Location = new System.Drawing.Point(219, 334);
            this.codePostalMaskedTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.codePostalMaskedTextBox.Name = "codePostalMaskedTextBox";
            this.codePostalMaskedTextBox.Size = new System.Drawing.Size(448, 29);
            this.codePostalMaskedTextBox.TabIndex = 30;
            this.codePostalMaskedTextBox.Enter += new System.EventHandler(this.MaskedTextBoxEnter);
            // 
            // adresseMaskedTextBox
            // 
            this.adresseMaskedTextBox.Location = new System.Drawing.Point(219, 240);
            this.adresseMaskedTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.adresseMaskedTextBox.Name = "adresseMaskedTextBox";
            this.adresseMaskedTextBox.Size = new System.Drawing.Size(448, 29);
            this.adresseMaskedTextBox.TabIndex = 29;
            this.adresseMaskedTextBox.Enter += new System.EventHandler(this.MaskedTextBoxEnter);
            // 
            // prenomMaskedTextBox
            // 
            this.prenomMaskedTextBox.Location = new System.Drawing.Point(219, 144);
            this.prenomMaskedTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.prenomMaskedTextBox.Name = "prenomMaskedTextBox";
            this.prenomMaskedTextBox.Size = new System.Drawing.Size(448, 29);
            this.prenomMaskedTextBox.TabIndex = 28;
            this.prenomMaskedTextBox.Enter += new System.EventHandler(this.MaskedTextBoxEnter);
            // 
            // nomMaskedTextBox
            // 
            this.nomMaskedTextBox.Location = new System.Drawing.Point(219, 57);
            this.nomMaskedTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.nomMaskedTextBox.Name = "nomMaskedTextBox";
            this.nomMaskedTextBox.Size = new System.Drawing.Size(448, 29);
            this.nomMaskedTextBox.TabIndex = 27;
            this.nomMaskedTextBox.Enter += new System.EventHandler(this.MaskedTextBoxEnter);
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Location = new System.Drawing.Point(25, 424);
            this.telephoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(113, 24);
            this.telephoneLabel.TabIndex = 4;
            this.telephoneLabel.Text = "Téléphone :";
            // 
            // codePostalLabel
            // 
            this.codePostalLabel.AutoSize = true;
            this.codePostalLabel.Location = new System.Drawing.Point(25, 344);
            this.codePostalLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.codePostalLabel.Name = "codePostalLabel";
            this.codePostalLabel.Size = new System.Drawing.Size(126, 24);
            this.codePostalLabel.TabIndex = 3;
            this.codePostalLabel.Text = "Code Postal : ";
            // 
            // adresseLabel
            // 
            this.adresseLabel.AutoSize = true;
            this.adresseLabel.Location = new System.Drawing.Point(25, 254);
            this.adresseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.adresseLabel.Name = "adresseLabel";
            this.adresseLabel.Size = new System.Drawing.Size(90, 24);
            this.adresseLabel.TabIndex = 2;
            this.adresseLabel.Text = "Adresse :";
            // 
            // prenomLabel
            // 
            this.prenomLabel.AutoSize = true;
            this.prenomLabel.Location = new System.Drawing.Point(23, 153);
            this.prenomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prenomLabel.Name = "prenomLabel";
            this.prenomLabel.Size = new System.Drawing.Size(87, 24);
            this.prenomLabel.TabIndex = 1;
            this.prenomLabel.Text = "Prénom :";
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Location = new System.Drawing.Point(25, 66);
            this.nomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(61, 24);
            this.nomLabel.TabIndex = 0;
            this.nomLabel.Text = "Nom :";
            // 
            // transactionGroupBox
            // 
            this.transactionGroupBox.Controls.Add(this.prixLabel);
            this.transactionGroupBox.Controls.Add(this.genreComboBox);
            this.transactionGroupBox.Controls.Add(this.platformeComboBox);
            this.transactionGroupBox.Controls.Add(this.dateAchatDateTimePicker);
            this.transactionGroupBox.Controls.Add(this.dateLabel);
            this.transactionGroupBox.Controls.Add(this.platformeLabel);
            this.transactionGroupBox.Controls.Add(this.genreLabel);
            this.transactionGroupBox.Controls.Add(this.prixJeuxLabel);
            this.transactionGroupBox.Location = new System.Drawing.Point(766, 642);
            this.transactionGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.transactionGroupBox.Name = "transactionGroupBox";
            this.transactionGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.transactionGroupBox.Size = new System.Drawing.Size(676, 368);
            this.transactionGroupBox.TabIndex = 3;
            this.transactionGroupBox.TabStop = false;
            this.transactionGroupBox.Text = "Transaction";
            // 
            // prixLabel
            // 
            this.prixLabel.BackColor = System.Drawing.Color.White;
            this.prixLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prixLabel.Location = new System.Drawing.Point(263, 258);
            this.prixLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.prixLabel.Name = "prixLabel";
            this.prixLabel.Size = new System.Drawing.Size(382, 50);
            this.prixLabel.TabIndex = 28;
            this.prixLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // genreComboBox
            // 
            this.genreComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.genreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(264, 189);
            this.genreComboBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(379, 32);
            this.genreComboBox.TabIndex = 27;
            this.genreComboBox.SelectedIndexChanged += new System.EventHandler(this.PlatformeComboBox_SelectedIndexChanged);
            // 
            // platformeComboBox
            // 
            this.platformeComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.platformeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.platformeComboBox.FormattingEnabled = true;
            this.platformeComboBox.Location = new System.Drawing.Point(264, 111);
            this.platformeComboBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.platformeComboBox.Name = "platformeComboBox";
            this.platformeComboBox.Size = new System.Drawing.Size(379, 32);
            this.platformeComboBox.TabIndex = 26;
            // 
            // dateAchatDateTimePicker
            // 
            this.dateAchatDateTimePicker.Location = new System.Drawing.Point(264, 44);
            this.dateAchatDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateAchatDateTimePicker.Name = "dateAchatDateTimePicker";
            this.dateAchatDateTimePicker.Size = new System.Drawing.Size(426, 29);
            this.dateAchatDateTimePicker.TabIndex = 11;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(26, 51);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(111, 24);
            this.dateLabel.TabIndex = 7;
            this.dateLabel.Text = "Date Achat :";
            // 
            // platformeLabel
            // 
            this.platformeLabel.AutoSize = true;
            this.platformeLabel.Location = new System.Drawing.Point(26, 123);
            this.platformeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.platformeLabel.Name = "platformeLabel";
            this.platformeLabel.Size = new System.Drawing.Size(103, 24);
            this.platformeLabel.TabIndex = 8;
            this.platformeLabel.Text = "Platforme : ";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(26, 201);
            this.genreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(73, 24);
            this.genreLabel.TabIndex = 9;
            this.genreLabel.Text = "Genre :";
            // 
            // prixJeuxLabel
            // 
            this.prixJeuxLabel.AutoSize = true;
            this.prixJeuxLabel.Location = new System.Drawing.Point(26, 272);
            this.prixJeuxLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prixJeuxLabel.Name = "prixJeuxLabel";
            this.prixJeuxLabel.Size = new System.Drawing.Size(52, 24);
            this.prixJeuxLabel.TabIndex = 10;
            this.prixJeuxLabel.Text = "Prix :";
            // 
            // imagePanel
            // 
            this.imagePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.imagePanel.Controls.Add(this.achatsLabel);
            this.imagePanel.Controls.Add(this.consolesPictureBox);
            this.imagePanel.Controls.Add(this.jeuxPictureBox);
            this.imagePanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.imagePanel.Location = new System.Drawing.Point(70, 68);
            this.imagePanel.Margin = new System.Windows.Forms.Padding(4);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(1646, 514);
            this.imagePanel.TabIndex = 4;
            // 
            // achatsLabel
            // 
            this.achatsLabel.AutoSize = true;
            this.achatsLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.achatsLabel.Font = new System.Drawing.Font("Cooper Black", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.achatsLabel.Location = new System.Drawing.Point(144, 0);
            this.achatsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.achatsLabel.Name = "achatsLabel";
            this.achatsLabel.Size = new System.Drawing.Size(1133, 110);
            this.achatsLabel.TabIndex = 2;
            this.achatsLabel.Text = "Achats de Jeux Videos";
            // 
            // consolesPictureBox
            // 
            this.consolesPictureBox.Image = global::AchatJeuxVideo.Properties.Resources.consoles;
            this.consolesPictureBox.Location = new System.Drawing.Point(80, 222);
            this.consolesPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.consolesPictureBox.Name = "consolesPictureBox";
            this.consolesPictureBox.Size = new System.Drawing.Size(473, 266);
            this.consolesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.consolesPictureBox.TabIndex = 1;
            this.consolesPictureBox.TabStop = false;
            // 
            // jeuxPictureBox
            // 
            this.jeuxPictureBox.Image = global::AchatJeuxVideo.Properties.Resources.jeux_video1;
            this.jeuxPictureBox.Location = new System.Drawing.Point(960, 158);
            this.jeuxPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.jeuxPictureBox.Name = "jeuxPictureBox";
            this.jeuxPictureBox.Size = new System.Drawing.Size(682, 357);
            this.jeuxPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jeuxPictureBox.TabIndex = 0;
            this.jeuxPictureBox.TabStop = false;
            // 
            // jeuxVideosMenuStrip
            // 
            this.jeuxVideosMenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.jeuxVideosMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.jeuxVideosMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.jeuxVideosMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.jeuxVideosMenuStrip.Name = "jeuxVideosMenuStrip";
            this.jeuxVideosMenuStrip.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.jeuxVideosMenuStrip.Size = new System.Drawing.Size(1771, 37);
            this.jeuxVideosMenuStrip.TabIndex = 27;
            this.jeuxVideosMenuStrip.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enregistrerToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // enregistrerToolStripMenuItem
            // 
            this.enregistrerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("enregistrerToolStripMenuItem.Image")));
            this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
            this.enregistrerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.enregistrerToolStripMenuItem.Text = "&Enregistrer";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(277, 34);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.QuitterToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aproposDeToolStripMenuItem});
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.aideToolStripMenuItem.Text = "&Aide";
            // 
            // aproposDeToolStripMenuItem
            // 
            this.aproposDeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aproposDeToolStripMenuItem.Image")));
            this.aproposDeToolStripMenuItem.Name = "aproposDeToolStripMenuItem";
            this.aproposDeToolStripMenuItem.Size = new System.Drawing.Size(226, 34);
            this.aproposDeToolStripMenuItem.Text = "À &propos de...";
            this.aproposDeToolStripMenuItem.Click += new System.EventHandler(this.AproposDeToolStripMenuItem_Click);
            // 
            // quitterButton
            // 
            this.quitterButton.Location = new System.Drawing.Point(1151, 1056);
            this.quitterButton.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.quitterButton.Name = "quitterButton";
            this.quitterButton.Size = new System.Drawing.Size(327, 176);
            this.quitterButton.TabIndex = 31;
            this.quitterButton.Text = "&Quitter";
            this.quitterButton.UseVisualStyleBackColor = true;
            // 
            // enregistrerButton
            // 
            this.enregistrerButton.Location = new System.Drawing.Point(766, 1056);
            this.enregistrerButton.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.enregistrerButton.Name = "enregistrerButton";
            this.enregistrerButton.Size = new System.Drawing.Size(327, 176);
            this.enregistrerButton.TabIndex = 30;
            this.enregistrerButton.Text = "&Enregistrer";
            this.enregistrerButton.UseVisualStyleBackColor = true;
            this.enregistrerButton.Click += new System.EventHandler(this.EnregistrerButton_Click);
            // 
            // AchatJeuxVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1771, 1281);
            this.Controls.Add(this.quitterButton);
            this.Controls.Add(this.enregistrerButton);
            this.Controls.Add(this.jeuxVideosMenuStrip);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.transactionGroupBox);
            this.Controls.Add(this.clientGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AchatJeuxVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Achat de Jeu Video";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AchatJeuxVideo_Load);
            this.clientGroupBox.ResumeLayout(false);
            this.clientGroupBox.PerformLayout();
            this.transactionGroupBox.ResumeLayout(false);
            this.transactionGroupBox.PerformLayout();
            this.imagePanel.ResumeLayout(false);
            this.imagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.consolesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jeuxPictureBox)).EndInit();
            this.jeuxVideosMenuStrip.ResumeLayout(false);
            this.jeuxVideosMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox clientGroupBox;
        private System.Windows.Forms.GroupBox transactionGroupBox;
        private System.Windows.Forms.Label telephoneLabel;
        private System.Windows.Forms.Label codePostalLabel;
        private System.Windows.Forms.Label adresseLabel;
        private System.Windows.Forms.Label prenomLabel;
        private System.Windows.Forms.Label nomLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label platformeLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label prixJeuxLabel;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.MenuStrip jeuxVideosMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aproposDeToolStripMenuItem;
        private System.Windows.Forms.PictureBox jeuxPictureBox;
        private System.Windows.Forms.PictureBox consolesPictureBox;
        private System.Windows.Forms.Label achatsLabel;
        private System.Windows.Forms.DateTimePicker dateAchatDateTimePicker;
        private System.Windows.Forms.MaskedTextBox telephoneMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox codePostalMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox adresseMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox prenomMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox nomMaskedTextBox;
        private System.Windows.Forms.Label prixLabel;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.ComboBox platformeComboBox;
        private System.Windows.Forms.Label nomJeuLabel;
        private System.Windows.Forms.MaskedTextBox nomJeuMaskedTextBox;
        private System.Windows.Forms.Button quitterButton;
        private System.Windows.Forms.Button enregistrerButton;
    }
}

