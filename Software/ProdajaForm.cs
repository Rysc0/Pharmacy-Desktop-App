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
    public partial class ProdajaForm : Form
    {

        List<Lijek> lijekoviUBazi;
        BindingList<StavkaRačuna> lijekoviNaRacun;
        Račun noviRacun = null;

        /// <summary>
        /// Inicijalizacija forme i potrebnih listi
        /// </summary>
        public ProdajaForm()
        {
            InitializeComponent();
            lijekoviUBazi = new List<Lijek>();
            lijekoviNaRacun = new BindingList<StavkaRačuna>();
        }

        /// <summary>
        /// Pokretanje svih potrebnih radnji prilikom pokretanja forme
        /// </summary>
        private void ProdajaForm_Load(object sender, EventArgs e)
        {
            RefreshGUI();
        }

        /// <summary>
        /// Refresh grafičkog sučelja, potrebni podaci se dohvaćaju iz baze
        /// </summary>
        private void RefreshGUI()
        {
            DohvatiLijekove();
            DohvatiKupce();
            DohvatiZaposlenika();
        }

        /// <summary>
        /// Dohvaćaju se svi zaposlenici iz baze podataka
        /// </summary>
        private void DohvatiZaposlenika()
        {
            using (var context = new Entities())
            {
                var query = from z in context.Zaposlenik
                            select z.Ime + " " + z.Prezime;

                cbZaposlenik.DataSource = null;
                cbZaposlenik.DataSource = query.ToList();
                cbZaposlenik.Enabled = false;
            }
        }

        /// <summary>
        /// Dohvaćaju se svi kupci iz baze podataka
        /// </summary>
        private void DohvatiKupce()
        {
            using (var context = new Entities())
            {
                var kupci = from k in context.Kupac
                            select k.ImeIPrezime;

                cbKupac.DataSource = null;
                cbKupac.DataSource = kupci.ToList();
            }
        }

        /// <summary>
        /// Dohvaćaju se svi lijekovi iz baze podataka i postavlja se prikaz podataka u DGV-ovima
        /// </summary>
        private void DohvatiLijekove()
        {
            using (var context = new Entities())
            {
                var lijekovi = from l in context.Lijek
                               select l;

                lijekoviUBazi = lijekovi.ToList();
                dgvLijekovi.DataSource = null;
                dgvLijekovi.DataSource = lijekoviUBazi;
                dgvLijekovi.Columns[0].HeaderText = "ID";
                dgvLijekovi.Columns[5].HeaderText = "Na recept";
                dgvLijekovi.Columns[6].HeaderText = "Na stanju";
                dgvLijekovi.Columns[7].HeaderText = "Minimalna količina";
                dgvLijekovi.Columns[8].Visible = false;
                dgvLijekovi.Columns[10].Visible = false;
                dgvLijekovi.Columns[11].Visible = false;
                dgvLijekovi.Columns[12].Visible = false;
                dgvLijekovi.Columns[13].Visible = false;
                dgvLijekovi.Columns[14].Visible = false;
                dgvLijekovi.Columns[15].Visible = false;
            }

            // Racun binding list
            dgvRačun.DataSource = null;
            dgvRačun.DataSource = lijekoviNaRacun;
            dgvRačun.Columns[0].Visible = false;
            dgvRačun.Columns[1].HeaderText = "Naziv";
        }

        /// <summary>
        /// Filter metoda, prilikom unosa teksta iz baze se dohvaćaju odgovarajući zapisi
        /// </summary>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string input = txtFilter.Text;
            using (var context = new Entities())
            {
                var query = from l in context.Lijek
                            where l.Naziv.Contains(input)
                            select l;

                dgvLijekovi.DataSource = null;
                dgvLijekovi.DataSource = query.ToList();
            }
        }
        
        /// <summary>
        /// Uzima odabrani lijek iz DGV-a i dodaje ga u listu za račun!
        /// </summary>
        private void dgvLijekovi_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Lijek selektiraniLijek = dgvLijekovi.CurrentRow.DataBoundItem as Lijek;
            int kolicina = 0;

            // forma za dodavanje količine za pojedini lijek
            using (var form = new KoličinaZaRačunForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    kolicina = form.Kolicina;
                }
            }

            // očisti filter
            txtFilter.Text = "";

            // dodavanje na listu za račun
            StavkaRačuna novaStavka = new StavkaRačuna
            {
                Lijek = selektiraniLijek,
                Količina = kolicina
            };

            lijekoviNaRacun.Add(novaStavka);
        }

        /// <summary>
        /// Radi provjeru kompatibilnosti i provjeru tipa lijekova na računu prije kreiranja računa
        /// </summary>
        private void btnIzdajRacun_Click(object sender, EventArgs e)
        {
            // OVDJE PROVJERU KOMPATIBILNOSTI
            if (!Kompatibilnost())
            {
                lijekoviNaRacun.Clear();
                RefreshGUI();
                return;
            }

            // MJESTO ZA PROVJERU TIPA LIJEKA 
            if (!ProvjeraTipa())
            {
                return;
            }

            if (!ProvjeraKolicine(lijekoviNaRacun.ToList()))
            {
                lijekoviNaRacun.Clear();
                RefreshGUI();
                return;
            }
            
            KreirajRačun(lijekoviNaRacun.ToList());
            lijekoviNaRacun.Clear();
            RefreshGUI();
        }

        /// <summary>
        /// Provjerava ima li na skladištu dovoljno traženog lijeka. Vraća true ako ima, inače vraća false.
        /// </summary>
        /// <param name="lijekoviNaRacun"></param>
        /// <returns></returns>
        private bool ProvjeraKolicine(List<StavkaRačuna> lijekoviNaRacun)
        {
            foreach (var item in lijekoviNaRacun)
            {
                if(item.Lijek.NaStanju < item.Količina)
                {
                    MessageBox.Show($"Lijeka {item.Naziv} više nema na zalihama!");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Radi provjeru tipa lijekova na listi za račun
        /// </summary>
        /// <returns>Ako su lijekovi kompatibilni vraća true, inače vraća false</returns>
        private bool ProvjeraTipa()
        {
            for (int i = 0; i < lijekoviNaRacun.Count(); i++)
            {
                for (int j = i + 1; j < lijekoviNaRacun.Count(); j++)
                {
                    if (lijekoviNaRacun[i].Lijek.Tip == lijekoviNaRacun[j].Lijek.Tip)
                    {
                        MessageBox.Show($"{lijekoviNaRacun[i].Naziv} i {lijekoviNaRacun[j].Naziv} ne mogu biti na računu jer imaju isti tip: {lijekoviNaRacun[i].Lijek.Tip} = {lijekoviNaRacun[j].Lijek.Tip}"
                                        + " Uklonite jedan od lijekova sa računa!");
                        lijekoviNaRacun.Clear();
                        RefreshGUI();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Provjerava kompatibilnost lijekova (mogu li lijekovi biti na istom računu)
        /// </summary>
        /// <returns>Vraća true ako su kompatibilni, inače vraća false</returns>
        private bool Kompatibilnost()
        {
            using (var context = new Entities())
            {
                List<int> id_lijekova = new List<int>();
                List<Nekompatibilni_Lijekovi> nekompatibilni = new List<Nekompatibilni_Lijekovi>();
                foreach (var item in lijekoviNaRacun)
                {
                    int trazeniID = item.Lijek.LijekID;

                    id_lijekova.Add(trazeniID);

                    // zapisi iz tablice Nekompatibilni_Lijekovi
                    var query = from n in context.Nekompatibilni_Lijekovi
                                where trazeniID == n.Lijek_ID_1 || trazeniID == n.Lijek_ID_2
                                select n;

                    nekompatibilni.AddRange(query.ToList());
                }

                // provjera kompatibilnosti
                foreach (var lek in nekompatibilni)
                {
                    if(id_lijekova.Contains(lek.Lijek_ID_1) && id_lijekova.Contains(lek.Lijek_ID_2))
                    {
                        MessageBox.Show($"Lijek {lek.Lijek.Naziv} nije kompatibilan sa lijekom {lek.Lijek1.Naziv}");
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Kreira račun i zapisuje ga u bazu. Kreira detalje računa i zapisuje ih u bazu te radi update stanja količina prodanih lijekova
        /// </summary>
        /// <param name="lijekoviNaRacun"></param>
        private void KreirajRačun(List<StavkaRačuna> lijekoviNaRacun)
        {
            string kupacIme = cbKupac.SelectedItem.ToString();
            string zaposlenikImeIPrezime = cbZaposlenik.SelectedItem.ToString();

            int kupacID = 0;
            int zaposlenikID = 0;

            using (var context = new Entities())
            {
                var kupac = from k in context.Kupac
                            where kupacIme == k.ImeIPrezime
                            select k.KupacID;

                var zaposlenik = from z in context.Zaposlenik
                                 where zaposlenikImeIPrezime == z.Ime + " " + z.Prezime
                                 select z.ZaposlenikID;

                kupacID = int.Parse(kupac.Single().ToString());
                zaposlenikID = int.Parse(zaposlenik.Single().ToString());


                // Kreiranje računa i zapis u bazu
                Račun racun = new Račun
                {
                    KupacID = kupacID,
                    ZaposlenikID = zaposlenikID,
                    Datum = DateTime.Now
                };

                noviRacun = racun;
                context.Račun.Add(racun);
                context.SaveChanges();
            }

            // Kreiranje detalja računa
            int dodano = 0;
            using (var context = new Entities())
            {
                foreach (var item in lijekoviNaRacun)
                {
                    DetaljiRačuna detalji = new DetaljiRačuna();
                    detalji.RačunID = noviRacun.RačunID;
                    detalji.LijekID = item.Lijek.LijekID;
                    detalji.Količina = item.Količina;
                    detalji.Iznos = item.Lijek.Cijena * detalji.Količina;

                    context.DetaljiRačuna.Add(detalji);
                    dodano++;
                }
                

                if(dodano > 0)
                {
                    MessageBox.Show("Račun je izdan!");
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Račun nije kreiran, nema dodanih stavki.");
                    var query = from r in context.Račun
                                where r.RačunID == noviRacun.RačunID
                                select r;

                    context.Račun.Remove(query.Single());
                    context.SaveChanges();
                }
            }
            UpdateStanja(lijekoviNaRacun);
        }

        /// <summary>
        /// Update stanje količine prodanih lijekova
        /// </summary>
        private void UpdateStanja(List<StavkaRačuna> lijekoviNaRacun)
        {                              
            using (var context = new Entities())
            {
                foreach (var lijek in context.Lijek)
                {
                    foreach (var update in lijekoviNaRacun)
                    {
                        if (lijek.LijekID == update.Lijek.LijekID)
                        {
                            lijek.NaStanju -= update.Količina;
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Zatvara formu
        /// </summary>
        private void btnOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Dohvaća string iz enumeracije Oblik_lijeka za svaki lijek i prikazuje ga u DGV-u umjesto integera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvLijekovi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(dgvLijekovi.Columns[e.ColumnIndex].DataPropertyName == "Oblik")
            {
                int value = (int)e.Value;
                e.Value = Enum.GetName(typeof(Oblik.Oblik_lijeka), value);
                e.FormattingApplied = true;
            }
        }
    }
}
