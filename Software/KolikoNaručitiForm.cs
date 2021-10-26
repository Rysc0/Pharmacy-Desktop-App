using Ljekarna.Database___Entity_Framework;
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
    public partial class KolikoNaručitiForm : Form
    {
        public List<KoličinaZaNarudžbu> kolicine { get; set; }

        List<Lijek> ljekoviNaNarudzbi;
        List<KoličinaZaNarudžbu> listaKolicinaILijekova;
        List<string> listImenaLijekova;

        /// <summary>
        /// Konstruktor forme, inicijalizira formu
        /// </summary>
        /// <param name="listaNarudzbe"></param>
        public KolikoNaručitiForm(List<Lijek> listaNarudzbe)
        {
            InitializeComponent();
            ljekoviNaNarudzbi = listaNarudzbe;
            OsvjeziDGV();
        }

        /// <summary>
        /// Postavlja DGV-ove na početno stanje
        /// </summary>
        private void OsvjeziDGV()
        {
            dgvNaNarudzbi.DataSource = null;
            dgvNaNarudzbi.DataSource = ljekoviNaNarudzbi;
            dgvNaNarudzbi.Columns[8].Visible = false;
            dgvNaNarudzbi.Columns[9].Visible = true;
            dgvNaNarudzbi.Columns[10].Visible = false;
            dgvNaNarudzbi.Columns[11].Visible = false;
            dgvNaNarudzbi.Columns[12].Visible = false;
            dgvNaNarudzbi.Columns[13].Visible = false;
            dgvNaNarudzbi.Columns[14].Visible = false;
            dgvNaNarudzbi.Columns[15].Visible = false;

            dgvSKolicinama.DataSource = null;
            dgvSKolicinama.DataSource = listaKolicinaILijekova;          
        }

        /// <summary>
        /// Inicijalizira potrebne liste i postavlja DGV-ove na početno stanje
        /// </summary>
        private void KolikoNaručitiForm_Load(object sender, EventArgs e)
        {
            listaKolicinaILijekova = new List<KoličinaZaNarudžbu>();
            listImenaLijekova = new List<string>();
            btnPotvrdi.Enabled = false;
            kolicine = new List<KoličinaZaNarudžbu>();
            OsvjeziDGV();
        }

        /// <summary>
        /// Uzima podatke iz forme, kreira novi zapis i dodaje ga na listu za narudžbu 
        /// </summary>
        private void ZabiljeziKolicinu(int kolicina)
        {
            int novaKolicina = kolicina;
            Lijek selektiraniLijek = dgvNaNarudzbi.CurrentRow.DataBoundItem as Lijek;

            KoličinaZaNarudžbu kolicinaZaLijek = new KoličinaZaNarudžbu
            {
                Lijek = selektiraniLijek.Naziv,
                KoličinaZaNaručiti = novaKolicina
            };

            listaKolicinaILijekova.Add(kolicinaZaLijek);
            listImenaLijekova.Add(selektiraniLijek.Naziv);

            OsvjeziDGV();
            btnPotvrdi.Enabled = true;
        }

        /// <summary>
        /// Provjerava postoji li odabrani lijek već na popisu za narudžbu, ako ne postoji dodaje ga, ako postoji ažurira količinu za narudžbu
        /// </summary>
        /// <param name="kolicina"></param>
        private void DodajNaNarudzbu(int kolicina)
        {
            if (!CheckIfExists(kolicina))
            {
                ZabiljeziKolicinu(kolicina);
                return;
            }
            MessageBox.Show($"Lijek je već na narudžbi, količina za narudžbu će biti ažurirana!");
            AzurirajKolicine(kolicina);
        }

        /// <summary>
        /// Ažurira količinu koja se treba naručiti za odabrani lijek
        /// </summary>
        /// <param name="kolicina"></param>
        private void AzurirajKolicine(int kolicina)
        {
            Lijek selektiraniLijek = dgvNaNarudzbi.CurrentRow.DataBoundItem as Lijek;
            int novaKolicina = kolicina;

            foreach (var item in listaKolicinaILijekova)
            {
                if(item.Lijek == selektiraniLijek.Naziv)
                {
                    item.KoličinaZaNaručiti = novaKolicina;
                }
            }
            OsvjeziDGV();
        }

        /// <summary>
        /// Provjerava postoji li lijek na narudžbi
        /// </summary>
        /// <returns>Ako postoji vraća true, inače vraća false</returns>
        private bool CheckIfExists(int kolicina)
        {
            Lijek selektiraniLijek = dgvNaNarudzbi.CurrentRow.DataBoundItem as Lijek;

            if (listImenaLijekova.Contains(selektiraniLijek.Naziv))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Zatvara formu
        /// </summary>
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Otvara formu za unos količine i dodaje zapis na narudžbu
        /// </summary>
        private void dgvNaNarudzbi_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // forma za dodavanje količine za pojedini lijek
            int kolicina = 0;
            using (var form = new KoličinaZaNarudžbuForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    kolicina = form.Količina;
                    DodajNaNarudzbu(kolicina);
                }
            }
        }

        /// <summary>
        /// Potvrđuje narudžbu i obaviještava korisnika da je narudžba kreirana, zatvara formu
        /// </summary>
        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            kolicine = listaKolicinaILijekova;
            MessageBox.Show("Narudžba je kreirana!");
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
