using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ljekarna
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Konstruktor fome, inicijalizira formu
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Otvara formu za dodavanje lijekova
        /// </summary>
        private void btnDodavanjeLijekova_Click(object sender, EventArgs e)
        {
            DodajLijekForm form = new DodajLijekForm();
            form.Show();
        }

        /// <summary>
        /// Otvara formu za naručivanje
        /// </summary>
        private void btnNaručivanje_Click(object sender, EventArgs e)
        {
            NapraviNarudžbuForm form = new NapraviNarudžbuForm();
            form.Show();
        }

        /// <summary>
        /// Otvara formu za prodaju
        /// </summary>
        private void btnProdaja_Click(object sender, EventArgs e)
        {
            ProdajaForm form = new ProdajaForm();
            form.ShowDialog();
        }
    }
}
