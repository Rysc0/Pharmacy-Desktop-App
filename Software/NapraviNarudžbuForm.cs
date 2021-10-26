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
    public partial class NapraviNarudžbuForm : Form
    {

        /*LEGENDA
         
         narudzba -> lista za drugi DGV
         potrebnoNaruciti -> lista za prvi DGV - sadrži popis lijekova kojima je NaStanju < MinimalnaKoličina
         naNarudzbi -> lista koja sadrži lijekove na pojedinoj narudžbi, upisuje se u bazu (1 lijek naNarudzbi = 1 zapis u DetaljiNarudzbe)
         nNarudzba -> služi za prosljeđivanje ID-a narudžbe u DetaljiNarudzbe
         kolicine -> lista sa podacima koliko se kojeg lijeka naručuje (Lijek, Količina)

         */


        // sa binding listom radi
        BindingList<Lijek> narudzba;
        List<Lijek> potrebnoNaruciti;
        List<DetaljiNarudžbe> naNarudzbi = new List<DetaljiNarudžbe>();
        Narudžba nNarudzba = null;

        /// <summary>
        /// Konstruktor forme, inicijalizira formu
        /// </summary>
        public NapraviNarudžbuForm()
        {
            InitializeComponent();
            narudzba = new BindingList<Lijek>();
            potrebnoNaruciti = new List<Lijek>();
        }

        /// <summary>
        /// Postavlja formu na početno stanje prilikom otvaranja
        /// </summary>
        private void NapraviNarudžbuForm_Load(object sender, EventArgs e)
        {
            DohvatiLijekoveZaNarudzbu();
            FillComboBox();
            OsvjeziDGV();
        }

        /// <summary>
        /// Učitava podatke o lijekovima iz baze i postavlja prikaz u DGV-ovima
        /// </summary>
        private void OsvjeziDGV()
        {
            dgvLijekovi.DataSource = null;
            dgvLijekovi.DataSource = potrebnoNaruciti;
            dgvLijekovi.Columns[0].HeaderText = "ID";
            dgvLijekovi.Columns[5].HeaderText = "Na recept";
            dgvLijekovi.Columns[6].HeaderText = "Na stanju";
            dgvLijekovi.Columns[7].HeaderText = "Minimalna količina";
            dgvLijekovi.Columns[8].Visible = false;
            dgvLijekovi.Columns[9].Visible = false;
            dgvLijekovi.Columns[10].Visible = false;
            dgvLijekovi.Columns[11].Visible = false;
            dgvLijekovi.Columns[12].Visible = false;
            dgvLijekovi.Columns[13].Visible = false;
            dgvLijekovi.Columns[14].Visible = false;
            dgvLijekovi.Columns[15].Visible = false;

            dgvNarudzba.DataSource = null;
            dgvNarudzba.DataSource = narudzba;
            dgvNarudzba.Columns[0].HeaderText = "ID";
            dgvNarudzba.Columns[5].HeaderText = "Na recept";
            dgvNarudzba.Columns[6].HeaderText = "Na stanju";
            dgvNarudzba.Columns[7].HeaderText = "Minimalna količina";
            dgvNarudzba.Columns[8].Visible = false;
            dgvNarudzba.Columns[9].Visible = false;
            dgvNarudzba.Columns[10].Visible = false;
            dgvNarudzba.Columns[11].Visible = false;
            dgvNarudzba.Columns[12].Visible = false;
            dgvNarudzba.Columns[13].Visible = false;
            dgvNarudzba.Columns[14].Visible = false;
            dgvNarudzba.Columns[15].Visible = false;
        }

        /// <summary>
        /// Čita podatke o dobavljačima iz baze i popunjava combobox
        /// </summary>
        private void FillComboBox()
        {
            using (var context = new Entities())
            {
                var query = from l in context.Dobavljač
                            select l.Naziv;

                cbDobavljač.DataSource = query.ToList();
            }
        }

        /// <summary>
        /// Dohvaća podatke o lijekovima čija je količina na stanju manja od zadane i prikazuje ih u DGV-u
        /// </summary>
        private void DohvatiLijekoveZaNarudzbu()
        {
            using (var context = new Entities())
            {
                var query = from l in context.Lijek
                            where l.NaStanju <= l.MinimalnaKoličina
                            select l;

                potrebnoNaruciti = query.ToList();
                dgvLijekovi.DataSource = potrebnoNaruciti;
                dgvLijekovi.Columns[8].Visible = false;
                dgvLijekovi.Columns[9].Visible = false;
                dgvLijekovi.Columns[10].Visible = false;
                dgvLijekovi.Columns[11].Visible = false;
                dgvLijekovi.Columns[12].Visible = false;
                dgvLijekovi.Columns[13].Visible = false;
                dgvLijekovi.Columns[14].Visible = false;
                dgvLijekovi.Columns[15].Visible = false;
            }
        }

        /// <summary>
        /// Dodaje odabrani lijek na narudžbu -> prebacuje ga na donji DGV
        /// </summary>
        private void dgvLijekovi_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Lijek selektiraniLijek = dgvLijekovi.CurrentRow.DataBoundItem as Lijek;

            narudzba.Add(selektiraniLijek);
            if (potrebnoNaruciti.Contains(selektiraniLijek))
            {
                potrebnoNaruciti.Remove(selektiraniLijek);
            }

            OsvjeziDGV();
        }

        /// <summary>
        /// Uklanja odabrani lijek sa narudžbe i vraća ga na gornji DGV
        /// </summary>
        private void dgvNarudzba_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Lijek selektiraniLijek = dgvNarudzba.CurrentRow.DataBoundItem as Lijek;

            potrebnoNaruciti.Add(selektiraniLijek);
            if (narudzba.Contains(selektiraniLijek))
            {
                narudzba.Remove(selektiraniLijek);
            }

            OsvjeziDGV();
        }

        /// <summary>
        /// Povlači sve lijekove koje je potrebno naručiti u narudžbu (Svi iz gornjeg DGV-a idu u donji)
        /// </summary>
        private void GenerirajAutomatskuNarudzbu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < potrebnoNaruciti.Count; i++)
            {
                narudzba.Add(potrebnoNaruciti[i]);
            }

            for (int i = 0; i < narudzba.Count; i++)
            {
                if (potrebnoNaruciti.Contains(narudzba[i]))
                {
                    potrebnoNaruciti.Remove(narudzba[i]);
                }
            }

            OsvjeziDGV();
        }

        /// <summary>
        /// Uzima unesene podatke i stvara zapise u bazi
        /// </summary>
        private void btnNaruči_Click(object sender, EventArgs e)
        {
            if (narudzba.Count() < 1)
            {
                MessageBox.Show("Lista za narudžbu je prazna!");
                return;
            }

            // otvaranje forme za određivanje količine narudžbe
            List<KoličinaZaNarudžbu> kolicine = new List<KoličinaZaNarudžbu>();

            using (var form = new KolikoNaručitiForm(narudzba.ToList()))
            {
                var result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    kolicine = form.kolicine;
                }
            }


            // kreiranje narudžbe sa svim podacima i unos u bazu
            KreirajNarudzbu();

            // kreiranje detalja narudzbe
            KreirajDetaljeNarudzbe(kolicine);

            // update stanja na skladištu
            AžurirajStanjeSkladišta(kolicine);
        }
       
        /// <summary>
        /// Kreira narudžbu i zapisuje u bazu
        /// </summary>
        private void KreirajNarudzbu()
        {
            using (var context = new Entities())
            {
                string odabraniDobavljac = cbDobavljač.SelectedItem.ToString();
                int odabraniDobavljacID = 0;

                var dobavljac = from d in context.Dobavljač
                                where d.Naziv == odabraniDobavljac
                                select d.DobavljačID;

                odabraniDobavljacID = dobavljac.Single();


                Narudžba novaNarudzba = new Narudžba()
                {
                    DobavljačID = odabraniDobavljacID,
                    Datum = DateTime.Now
                };

                nNarudzba = novaNarudzba;

                context.Narudžba.Add(novaNarudzba);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Kreira detalje računa i zapisuje u bazu
        /// </summary>
        /// <param name="kolicine"></param>
        private void KreirajDetaljeNarudzbe(List<KoličinaZaNarudžbu> kolicine)
        {
            using (var context = new Entities())
            {
                foreach (var item in narudzba)
                {
                    DetaljiNarudžbe detalji = new DetaljiNarudžbe();
                    detalji.NarudžbaID = nNarudzba.NarudžbaID;
                    detalji.LijekID = item.LijekID;
                    detalji.Cijena = item.NabavnaCijena;

                    foreach (var kolicinu in kolicine)
                    {
                        if (kolicinu.Lijek == item.Naziv)
                        {
                            detalji.Količina = kolicinu.KoličinaZaNaručiti;
                        }
                    }
                    context.DetaljiNarudžbe.Add(detalji);
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Ažurira stanje na skladištu s naručenim količinama i osvježava prikaz
        /// </summary>
        /// <param name="kolicine"></param>
        private void AžurirajStanjeSkladišta(List<KoličinaZaNarudžbu> kolicine)
        {
            using (var context = new Entities())
            {
                var naruceniLijekovi = from n in context.Narudžba
                                       from d in context.DetaljiNarudžbe
                                       where d.NarudžbaID == n.NarudžbaID
                                       select d.LijekID;

                List<int> listLijekID = naruceniLijekovi.ToList();

                foreach (var lijek in context.Lijek)
                {
                    if (listLijekID.Contains(lijek.LijekID))
                    {
                        for (int i = 0; i < kolicine.Count; i++)
                        {
                            if (kolicine[i].Lijek == lijek.Naziv)
                            {
                                lijek.NaStanju += kolicine[i].KoličinaZaNaručiti;
                            }
                        }
                    }
                }
                context.SaveChanges();

                narudzba.Clear();
                DohvatiLijekoveZaNarudzbu();
                OsvjeziDGV();
            }
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