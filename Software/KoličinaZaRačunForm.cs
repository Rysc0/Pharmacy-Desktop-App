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
    public partial class KoličinaZaRačunForm : Form
    {
        public int Kolicina { get; set; }

        /// <summary>
        /// Konstruktor forme, inicijalizira formu
        /// </summary>
        public KoličinaZaRačunForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Prazna metoda, nije potreban nikakav setup kod pokretanja forme
        /// </summary>
        private void KoličinaZaRačunForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Bilježi unesenu količinu i zatvara formu
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Kolicina = (int)numericSelect.Value;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Zatvara formu
        /// </summary>
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
