using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AchatJeuxVideo
{
    public partial class FrmAPropos : Form
    {
        public FrmAPropos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void FrmAPropos_Load(object sender, EventArgs e)
        {
            labelTitre.Text = "Achat de Jeux Vidéo";
            labelAuteur.Text = "Développé par : Lydianne, Labib, Mohamed";
            labelEntreprise.Text = "Entreprise : GameSoft Solutions inc.";
            labelVersion.Text = "Version 1.0.0 (2025)";
        }

        private void buttonFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
