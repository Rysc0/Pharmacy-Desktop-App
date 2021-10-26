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
    public partial class DodajLijekForm : Form
    {
        List<Lijek> DohvaceniLijekovi;
        List<Lijek> NekompatibilniLijekovi;

        /// <summary>
        /// Konstruktor forme, inicijalizira formu i potrebne liste
        /// </summary>
        public DodajLijekForm()
        {
            InitializeComponent();
            DohvaceniLijekovi = new List<Lijek>();
            NekompatibilniLijekovi = new List<Lijek>();
        }

        /// <summary>
        /// Postavlja formu na početno stanje prilikom otvaranja
        /// </summary>
        private void DodajLijekForm_Load(object sender, EventArgs e)
        {
            RefreshGUI();            
        }

        /// <summary>
        /// Dohvaća sve potrebne podatke i postavlja formu u početno stanje
        /// </summary>
        private void RefreshGUI()
        {
            txtNaziv.Clear();
            txtCijena.Clear();
            txtNaStanju.Clear();
            txtMinimalnaKolicina.Clear();
            txtNabavnaCijena.Clear();
            ProizvodaciComboBox();
            OblikComboBox();
            TipComboBox();
            DohvatiSveLijekove();
            OdabraniLijekoviRefresh();
            UkloniJedan.Enabled = false;
        }

        /// <summary>
        /// Refresha ListBox koji prikazuje koji su lijekovi odabrani kao nekompatibilni (desni listbox)
        /// </summary>
        private void OdabraniLijekoviRefresh()
        {
            OdabraniLijekoviListBox.DataSource = null;
            OdabraniLijekoviListBox.DataSource = NekompatibilniLijekovi;        }

        /// <summary>
        /// Dohvaća podatke o tipu lijeka iz baze
        /// </summary>
        private void TipComboBox()
        {
            using (var context = new Entities())
            {
                var query = from t in context.Tipovi
                            select t.Tip;

                cbTip.DataSource = query.ToList();
            }
        }

        /// <summary>
        /// Dohvaća sve lijekove iz baze podataka i prikazuje ih u listboxu
        /// </summary>
        private void DohvatiSveLijekove()
        {
            using(var context = new Entities())
            {
                var query = from l in context.Lijek
                            select l;

                DohvaceniLijekovi = query.ToList();
                SviLijekoviListBox.DataSource = null;
                SviLijekoviListBox.DataSource = DohvaceniLijekovi;            }
        }

        /// <summary>
        /// Dohvaća string iz enumeracije Oblik_lijeka 
        /// </summary>
        private void OblikComboBox()
        {
            List<string> oblikList = Enum.GetNames(typeof(Oblik.Oblik_lijeka)).ToList();
            cbOblik.DataSource = oblikList;
        }

        /// <summary>
        /// Dohvaća podatke o proizvođačima iz baze
        /// </summary>
        private void ProizvodaciComboBox()
        {
            using (var context = new Entities())
            {
                var proizvodaci = from p in context.Proizvođač
                                  select p.Proizvođač1;

                List<string> proizvodaciList = proizvodaci.ToList();

                cbProizvođač.DataSource = proizvodaciList;
            }
        }

        /// <summary>
        /// Formira unesene podatke na formi u novi zapis, provjerava postoji li takav lijek već u bazi te dodaje ukoliko ne postoji
        /// </summary>
        private void btnDodajLijek_Click(object sender, EventArgs e)
        {
            if (txtNaziv.Text == "")
            {
                MessageBox.Show("Naziv mora biti unesen!");
                return;
            }
            string naziv = txtNaziv.Text;
            string proizvodac = cbProizvođač.SelectedItem as string;
            if(txtCijena.Text == "")
            {
                MessageBox.Show("Cijena mora biti unesena!");
                return;
            }
            double cijena = double.Parse(txtCijena.Text);
            string dobiveni_oblik = cbOblik.SelectedItem as string;
            int oblik = (int)Enum.Parse(typeof(Oblik.Oblik_lijeka), dobiveni_oblik);
            bool naRecept = checkBoxNaRecept.Checked;
            if(txtNaStanju.Text == "")
            {
                MessageBox.Show("Početno stanje mora biti uneseno!");
                return;
            }
            int naStanju = int.Parse(txtNaStanju.Text);
            if (txtMinimalnaKolicina.Text == "")
            {
                MessageBox.Show("Minimalna količina mora biti unesena!");
                return;
            }
            int minimalnaKolicina = int.Parse(txtMinimalnaKolicina.Text);
            if (txtNabavnaCijena.Text == "")
            {
                MessageBox.Show("Nabavna cijena mora biti unesena!");
                return;
            }
            double nabavnaCijena = double.Parse(txtNabavnaCijena.Text);
            string tip = cbTip.SelectedItem as string;


            Lijek noviLijek = new Lijek
            {
                Naziv = naziv,
                Proizvođač = proizvodac,
                Cijena = cijena,
                Oblik = oblik,
                NaRecept = naRecept,
                NaStanju = naStanju,
                MinimalnaKoličina = minimalnaKolicina,
                NabavnaCijena = nabavnaCijena,
                Tip = tip
            };

            if (ProvjeriNaziv(naziv))
            {
                MessageBox.Show($"Lijek s nazivom {naziv} je već postoji u bazi! Modificirajte naziv kako bi mogli unijeti lijek u bazu!");
                return;
            }

            
            DodajUBazu(noviLijek);
            MessageBox.Show("Lijek je dodan u bazu!");


            // ovdje treba ić i dodavanje u tablicu za interakciju (Nekompatibilni_lijekovi)
            DodajUBazuNekompatibilneParove(noviLijek);

            RefreshGUI();
        }

        /// <summary>
        /// Dodaje novi lijek u bazu
        /// </summary>
        /// <param name="noviLijek"></param>
        private void DodajUBazu(Lijek noviLijek)
        {
            using (var context = new Entities())
            {
                context.Lijek.Add(noviLijek);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// U bazu zapisuje s kojim lijekovima novi lijek nije kompatibilan
        /// </summary>
        /// <param name="noviLijek"></param>
        private void DodajUBazuNekompatibilneParove(Lijek noviLijek)
        {
            int id = noviLijek.LijekID;
            Console.WriteLine($"ovo je dobiveni ID: {id}");
            using (var context = new Entities())
            {
                foreach (var naziv in NekompatibilniLijekovi)
                {
                    context.Nekompatibilni_Lijekovi.Add(new Nekompatibilni_Lijekovi { Lijek_ID_1 = id, Lijek_ID_2 = naziv.LijekID });
                }
                context.SaveChanges();
            }
            NekompatibilniLijekovi.Clear();
        }

        /// <summary>
        /// Provjerava postoji li u bazi lijek s imenom "naziv"
        /// </summary>
        /// <param name="naziv"></param>
        /// <returns>Vraća true ako postoji, inače vraća false</returns>
        private bool ProvjeriNaziv(string naziv)
        {
            List<Lijek> pronadeno = new List<Lijek>();

            using (var context = new Entities())
            {
                var query = from l in context.Lijek
                            where l.Naziv.ToLower() == naziv.ToLower()
                            select l;

                pronadeno = query.ToList();
            }

            if (pronadeno.Count > 0)
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
        /// Dodaje odabrani lijek na listu nekompatibilnih lijekova
        /// </summary>
        private void DodajJedan_Click(object sender, EventArgs e)
        {
            var selektiraniLijek = SviLijekoviListBox.SelectedItem as Lijek;
            NekompatibilniLijekovi.Add(selektiraniLijek);
            OdabraniLijekoviRefresh();
        }

        /// <summary>
        /// Uklanja odabrani lijek iz liste nekompatibilnih lijekova
        /// </summary>
        private void UkloniJedan_Click(object sender, EventArgs e)
        {
            var selektiraniLijek = OdabraniLijekoviListBox.SelectedItem as Lijek;
            NekompatibilniLijekovi.Remove(selektiraniLijek);
            OdabraniLijekoviRefresh();
            UkloniJedan.Enabled = false;
        }

        /// <summary>
        /// Dodaje sve lijekove na listu nekompatibilnih lijekova
        /// </summary>
        private void DodajSve_Click(object sender, EventArgs e)
        {
            OdabraniLijekoviListBox.DataSource = null;
            OdabraniLijekoviListBox.DataSource = DohvaceniLijekovi;
        }

        /// <summary>
        /// Uklanja sve lijekove sa liste nekompatibilnih lijekova
        /// </summary>
        private void UkloniSve_Click(object sender, EventArgs e)
        {
            OdabraniLijekoviRefresh();
        }

        /// <summary>
        /// Omogućava button "<<" kada se odabere stavka iz listboxa nekompatibilnih lijekova
        /// </summary>
        private void OdabraniLijekoviListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UkloniJedan.Enabled = true;
        }
    }
}