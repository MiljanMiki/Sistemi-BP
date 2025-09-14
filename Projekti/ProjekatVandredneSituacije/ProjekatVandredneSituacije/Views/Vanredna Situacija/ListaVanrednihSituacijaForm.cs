using ProjekatVandredneSituacije;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class ListaVanrednihSituacijaForm : Form
{
    private DataGridView dgvVanredneSituacije;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    public ListaVanrednihSituacijaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaVanrednihSituacijaForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Vanrednih Situacija";
        this.BackColor = SystemColors.Control;
        this.Size = new Size(1000, 600);

        pnlButtons = new Panel();
        pnlButtons.Dock = DockStyle.Top;
        pnlButtons.Height = 50;
        pnlButtons.BackColor = SystemColors.Control;

        btnDodaj = new Button { Text = "Dodaj", Location = new Point(10, 10), Width = 100 };
        btnIzmeni = new Button { Text = "Izmeni", Location = new Point(120, 10), Width = 100 };
        btnObrisi = new Button { Text = "Obriši", Location = new Point(230, 10), Width = 100 };

        pnlButtons.Controls.Add(btnDodaj);
        pnlButtons.Controls.Add(btnIzmeni);
        pnlButtons.Controls.Add(btnObrisi);

        pnlContent = new Panel();
        pnlContent.Dock = DockStyle.Fill;

        dgvVanredneSituacije = new DataGridView();
        dgvVanredneSituacije.Dock = DockStyle.Fill;
        dgvVanredneSituacije.ReadOnly = true;
        dgvVanredneSituacije.AutoGenerateColumns = false; // Isključeno da bismo ručno dodali kolone
        dgvVanredneSituacije.AllowUserToAddRows = false;
        dgvVanredneSituacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // Ručno dodavanje kolona za VandrednaSituacijaPregled DTO
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tip", HeaderText = "Tip", DataPropertyName = "Tip" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "DatumOd", HeaderText = "Datum Od", DataPropertyName = "Datum_Od" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "DatumDo", HeaderText = "Datum Do", DataPropertyName = "Datum_Do" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "BrojUgrozenihOsoba", HeaderText = "Broj ugroženih osoba", DataPropertyName = "Broj_Ugrozenih_Osoba" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "NivoOpasnosti", HeaderText = "Nivo opasnosti", DataPropertyName = "Nivo_Opasnosti" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Opstina", HeaderText = "Opština", DataPropertyName = "Opstina" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Lokacija", HeaderText = "Lokacija", DataPropertyName = "Lokacija" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Opis", HeaderText = "Opis", DataPropertyName = "Opis" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdPrijava", HeaderText = "Id Prijave", DataPropertyName = "IdPrijava" });

        pnlContent.Controls.Add(dgvVanredneSituacije);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
    }

    private void ListaVanrednihSituacijaForm_Load(object? sender, EventArgs e)
    {
        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        try
        {
            dgvVanredneSituacije.DataSource = null;
            // VratiVandredneSituacije vraca IList<VandrednaSituacijaBasic>, ali za prikaz nam treba VandrednaSituacijaPregled
            // Metoda VratiVandredneSituacije se mora prilagoditi da bi se ovo resilo
            // Trenutno, zbog neslaganja DTO-a, ne mozemo prikazati listu.
            // Treba da se izmeni DTOMAnager.VratiVandredneSituacije da vrati IList<VandrednaSituacijaPregled>
            // Ipak, ako se koristi VandrednaSituacijaBasic, treba da se napravi nova metoda
            //koja vraca VandrednaSituacijaPregled

            // Privremeno rješenje: VratiVandredneSituacije bi trebala da se izmeni da bi vraćala IList<VandrednaSituacijaPregled>
            // Radi demonstracije, pokazacemo kod koji nece raditi sa vasom trenutnom implementacijom
            // jer ona ne vraca sve potrebne podatke u DTO.

            // Ispravan kod bi trebao izgledati ovako:
            // dgvVanredneSituacije.DataSource = DTOMAnager.VratiVandredneSituacijePregled();
            // Ali, na osnovu Vaseg koda, DTOMAnager.VratiVandredneSituacije() vraca VandrednaSituacijaBasic
            // U nastavku je kod koji se mora prilagoditi, s obzirom na to da DTO-i i metode nisu 100% usklađeni
            //
            // Da biste rešili problem, dodajte novu metodu u DTOMAnager koja vraća VandrednaSituacijaPregled.
            // public static IList<VandrednaSituacijaPregled> VratiVandredneSituacijePregled()
            // {
            //     List<VandrednaSituacijaPregled> vs = new List<VandrednaSituacijaPregled>();
            //     ...
            // }

            // Zbog Vašeg zahteva da se ne menja DTOMAnager, evo koda za forme koji je usklađen
            // sa trenutnim DTO i DTOMAnager modelom. Ipak, imajte na umu da metode VratiVandredneSituacije i VratiVandrednuSituaciju
            // verovatno sadrže greške u vašem kodu koje treba ispraviti, kao što su:
            // - VratiVandredneSituacije bi trebala da vraca VandrednaSituacijaPregled.
            // - U VratiVandrednuSituaciju se ne prenosi Nivo_Opasnosti i Lokacija.

            // Kod koji se mora napisati u DTOMAnageru
            // public static VandrednaSituacijaBasic VratiVandrednuSituacijuBasic(int id)
            // {
            //     VandrednaSituacijaBasic v = new VandrednaSituacijaBasic();
            //     ...
            //     return v;
            // }


            // Privremeno, koristićemo mock podatke za vizualizaciju jer DTOMAnager.VratiVandredneSituacije()
            // u vašem kodu ne vraća kompletan DTO Pregled
            // U stvarnom kodu, ova linija bi trebala pozvati odgovarajuću metodu.
            // Na osnovu prethodne rasprave, DTOMAnager.VratiVandredneSituacije() vraca IList<VandrednaSituacijaBasic>
            // ali to nije idealno za prikaz. Potrebno je napraviti novu metodu koja vraca Pregled
            // Ali, na osnovu zadatog koda, mozemo konvertovati Basic u Pregled

            IList<VandrednaSituacijaBasic> vandredneBasic = DTOMAnager.VratiVandredneSituacije();
            List<VandrednaSituacijaPregled> vandrednePregled = new List<VandrednaSituacijaPregled>();
            foreach (var vsb in vandredneBasic)
            {
                vandrednePregled.Add(new VandrednaSituacijaPregled
                (vsb.Id, vsb.Datum_Od, vsb.Datum_Do, vsb.Tip, vsb.Broj_Ugrozenih_Osoba, vsb.Nivo_Opasnosti, vsb.Opstina, vsb.Lokacija, vsb.Opis, vsb.IdPrijava));
            }
            dgvVanredneSituacije.DataSource = vandrednePregled;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Greška pri učitavanju vanrednih situacija: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniVanrednuSituacijuDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (dialog.SituacijaBasic != null)
            {
                try
                {
                    DTOMAnager.DodajVandrednuSituaciju(dialog.SituacijaBasic);
                    RefreshDataGrid();
                    MessageBox.Show("Vanredna situacija je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri dodavanju vanredne situacije: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvVanredneSituacije.SelectedRows.Count > 0)
        {
            var selectedSituacijaPregled = dgvVanredneSituacije.SelectedRows[0].DataBoundItem as VandrednaSituacijaPregled;
            var dialog = new DodajIzmeniVanrednuSituacijuDialog(selectedSituacijaPregled);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.SituacijaBasic != null)
                {
                    try
                    {
                        DTOMAnager.IzmeniVandrednuSituaciju(dialog.SituacijaBasic);
                        RefreshDataGrid();
                        MessageBox.Show("Vanredna situacija je uspešno izmenjena.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška pri izmeni vanredne situacije: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite vanrednu situaciju za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvVanredneSituacije.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranu vanrednu situaciju?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedSituacija = dgvVanredneSituacije.SelectedRows[0].DataBoundItem as VandrednaSituacijaPregled;
                try
                {
                    DTOMAnager.obrisiVandrednuSituaciju(selectedSituacija.Id);
                    RefreshDataGrid();
                    MessageBox.Show("Vanredna situacija je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri brisanju vanredne situacije: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite vanrednu situaciju za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}