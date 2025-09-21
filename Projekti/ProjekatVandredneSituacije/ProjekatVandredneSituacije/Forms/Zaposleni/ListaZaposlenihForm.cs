using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVanredneSituacije.Entiteti;
using ProjekatVanredneSituacije;
using VanrednaSituacijaLibrary;
using ProjekatVanredneSituacije.DTOs;

public class ListaZaposlenihForm : Form
{
    private DataGridView dgvZaposleni;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    public ListaZaposlenihForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaZaposlenihForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Zaposlenih";
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

        dgvZaposleni = new DataGridView();
        dgvZaposleni.Dock = DockStyle.Fill;
        dgvZaposleni.ReadOnly = true;
        dgvZaposleni.AutoGenerateColumns = true;
        dgvZaposleni.AllowUserToAddRows = false;
        dgvZaposleni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvZaposleni);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
    }

    private void ListaZaposlenihForm_Load(object sender, EventArgs e)
    {
        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        try
        {
            Console.WriteLine(DTOManager.VratiSveZaposlene());
            dgvZaposleni.DataSource = DTOManager.VratiSveZaposlene();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Došlo je do greške prilikom učitavanja podataka o zaposlenima: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniZaposlenogDialog();
        if (dialog.ShowDialog() == DialogResult.OK && dialog.Zaposlen != null)
        {
            try
            {
                ZaposleniView? zaposlenBasic = MapToBasic(dialog.Zaposlen);
                if (zaposlenBasic != null)
                {
                    if (zaposlenBasic is AnaliticarView analiticarBasic)
                        DTOManager.DodajAnalitcar(analiticarBasic);
                    else if (zaposlenBasic is KordinatorPregled koordinatorBasic)
                        DTOManager.DodajKordinatora(koordinatorBasic);
                    else if (zaposlenBasic is OperativniRadnikBasic operativniBasic)
                        DTOManager.DodajOperativnogRadnik(operativniBasic);

                    RefreshDataGrid();
                    MessageBox.Show("Zaposleni je uspešno dodat.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom dodavanja zaposlenog: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvZaposleni.SelectedRows.Count > 0)
        {
            try
            {
                var selectedZaposlenBasic = dgvZaposleni.SelectedRows[0].DataBoundItem as ZaposlenBasic;
                if (selectedZaposlenBasic == null) return;

                Zaposlen? zaposlenEntitet = null;

                if (selectedZaposlenBasic is AnaliticarBasic analiticarBasic)
                {
                    var analiticarDto = DTOManager.VratiAnaliticara(analiticarBasic.JMBG);
                    zaposlenEntitet = MapFromBasicToEntity(analiticarDto);
                }
                else if (selectedZaposlenBasic is KordinatorBasic koordinatorBasic)
                {
                    var koordinatorDto = DTOManager.VratiKoordinatora(koordinatorBasic.JMBG);
                    zaposlenEntitet = MapFromBasicToEntity(koordinatorDto);
                }
                else if (selectedZaposlenBasic is OperativniRadnikBasic operativacBasic)
                {
                    var operativacDto = DTOManager.VratiOperativnogRadnika(operativacBasic.JMBG);
                    zaposlenEntitet = MapFromBasicToEntity(operativacDto);
                }

                if (zaposlenEntitet != null)
                {
                    var dialog = new DodajIzmeniZaposlenogDialog(zaposlenEntitet);
                    if (dialog.ShowDialog() == DialogResult.OK && dialog.Zaposlen != null)
                    {
                        ZaposlenBasic? izmenjenBasic = MapToBasic(dialog.Zaposlen);
                        if (izmenjenBasic != null)
                        {
                            if (izmenjenBasic is AnaliticarBasic analitcarBasic)
                                DTOManager.IzmeniAnaliticar(analitcarBasic);
                            else if (izmenjenBasic is KordinatorBasic koordinatorBasic)
                                DTOManager.IzmeniKordinatora(koordinatorBasic);
                            else if (izmenjenBasic is OperativniRadnikBasic operativniBasic)
                                DTOManager.IzmeniOperativnog(operativniBasic);

                            RefreshDataGrid();
                            MessageBox.Show("Podaci o zaposlenom su uspešno izmenjeni.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Došlo je do greške prilikom izmene zaposlenog: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite zaposlenog za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvZaposleni.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranog zaposlenog?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var selectedZaposlenBasic = dgvZaposleni.SelectedRows[0].DataBoundItem as ZaposlenBasic;
                    if (selectedZaposlenBasic != null)
                    {
                        if (selectedZaposlenBasic is AnaliticarBasic)
                            DTOManager.ObrisiAnaliticara(selectedZaposlenBasic.JMBG);
                        else if (selectedZaposlenBasic is KordinatorBasic)
                            DTOManager.ObrisiKordinatora(selectedZaposlenBasic.JMBG);
                        else if (selectedZaposlenBasic is OperativniRadnikBasic)
                            DTOManager.ObrisiOperativnogRadnika(selectedZaposlenBasic.JMBG);
                    }

                    RefreshDataGrid();
                    MessageBox.Show("Zaposleni je uspešno obrisan.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške prilikom brisanja zaposlenog: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite zaposlenog za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
     
    private Zaposlen? MapFromBasicToEntity(ZaposlenBasic basic)
    {
        if (basic is AnaliticarBasic analiticarBasic)
        {
            return new Analiticar
            {
                JMBG = analiticarBasic.JMBG,
                Ime = analiticarBasic.Ime,
                Prezime = analiticarBasic.Prezime,
                Datum_Rodjenja = analiticarBasic.Datum_Rodjenja,
                Pol = analiticarBasic.Pol,
                Kontakt_Telefon = analiticarBasic.Kontakt_Telefon,
                Email = analiticarBasic.Email,
                AdresaStanovanja = analiticarBasic.AdresaStanovanja,
                Datum_Zaposlenja = analiticarBasic.Datum_Zaposlenja
            };
        }
        else if (basic is KordinatorBasic koordinatorBasic)
        {
            return new Kordinator
            {
                JMBG = koordinatorBasic.JMBG,
                Ime = koordinatorBasic.Ime,
                Prezime = koordinatorBasic.Prezime,
                Datum_Rodjenja = koordinatorBasic.Datum_Rodjenja,
                Pol = koordinatorBasic.Pol,
                Kontakt_Telefon = koordinatorBasic.Kontakt_Telefon,
                Email = koordinatorBasic.Email,
                AdresaStanovanja = koordinatorBasic.AdresaStanovanja,
                Datum_Zaposlenja = koordinatorBasic.Datum_Zaposlenja,
                BrojTimova = koordinatorBasic.BrojTimova
            };
        }
        else if (basic is OperativniRadnikBasic operativacBasic)
        { 
            var opstaJedinicaDto = DTOManager.VratiOpstuJedinicu(operativacBasic.IdInterventnaJedinica);
            InterventnaJedinica? interventnaJedinica = null;

            if (opstaJedinicaDto != null)
            {
                interventnaJedinica = MapToInterventnaJedinicaEntity(opstaJedinicaDto);
            }
            else
            {
                var specijalnaJedinicaDto = DTOManager.VratiSpecijalnuJedinicu(operativacBasic.IdInterventnaJedinica);
                if (specijalnaJedinicaDto != null)
                {
                    interventnaJedinica = MapToInterventnaJedinicaEntity(specijalnaJedinicaDto);
                }
            }

            return new OperativniRadnik
            {
                JMBG = operativacBasic.JMBG,
                Ime = operativacBasic.Ime,
                Prezime = operativacBasic.Prezime,
                Datum_Rodjenja = operativacBasic.Datum_Rodjenja,
                Pol = operativacBasic.Pol,
                Kontakt_Telefon = operativacBasic.Kontakt_Telefon,
                Email = operativacBasic.Email,
                AdresaStanovanja = operativacBasic.AdresaStanovanja,
                Datum_Zaposlenja = operativacBasic.Datum_Zaposlenja,
                Broj_Sati = operativacBasic.Broj_Sati,
                Fizicka_Spremnost = operativacBasic.Fizicka_Spremnost,
                InterventnaJedinica = interventnaJedinica
            };
        }
        return null;
    }
     
    private ZaposlenBasic? MapToBasic(Zaposlen entity)
    {
        if (entity is Analiticar analiticar)
        {
            return new AnaliticarBasic(analiticar.JMBG, analiticar.Ime, analiticar.Prezime, analiticar.Datum_Rodjenja, analiticar.Pol, analiticar.Kontakt_Telefon, analiticar.Email, analiticar.AdresaStanovanja, analiticar.Datum_Zaposlenja);
        }
        else if (entity is Kordinator koordinator)
        {
            return new KordinatorBasic(koordinator.JMBG, koordinator.Ime, koordinator.Prezime, koordinator.Datum_Rodjenja, koordinator.Pol, koordinator.Kontakt_Telefon, koordinator.Email, koordinator.AdresaStanovanja, koordinator.Datum_Zaposlenja, koordinator.BrojTimova);
        }
        else if (entity is OperativniRadnik operativac)
        {
            return new OperativniRadnikBasic(operativac.JMBG, operativac.Ime, operativac.Prezime, operativac.Datum_Rodjenja, operativac.Pol, operativac.Kontakt_Telefon, operativac.Email, operativac.AdresaStanovanja, operativac.Datum_Zaposlenja, operativac.Broj_Sati, operativac.Fizicka_Spremnost, operativac.InterventnaJedinica.Jedinstveni_Broj);
        }
        return null;
    }
     
    private InterventnaJedinica? MapToInterventnaJedinicaEntity(InterventnaJedinicaBasic basic)
    {
        if (basic == null) return null;

        if (basic is OpstaInterventnaJedBasic opstaBasic)
        {
            var opstaEntitet = new OpstaIntervetnaJed();
            opstaEntitet.Jedinstveni_Broj = opstaBasic.Jedinstveni_Broj;
            opstaEntitet.Naziv = opstaBasic.Naziv;
            opstaEntitet.BrojClanova = opstaBasic.BrojClanova; 
            var komandirDto = DTOManager.VratiOperativnogRadnika(opstaBasic.Komandir);
            opstaEntitet.Komandir = MapFromBasicToEntity(komandirDto) as OperativniRadnik;

            opstaEntitet.Baza = opstaBasic.Baza;
            return opstaEntitet;
        }
        else if (basic is SpecijalnaInterventnaJedinicaBasic specijalnaBasic)
        {
            var specijalnaEntitet = new SpecijalnaInterventna();
            specijalnaEntitet.Jedinstveni_Broj = specijalnaBasic.Jedinstveni_Broj;
            specijalnaEntitet.Naziv = specijalnaBasic.Naziv;
            specijalnaEntitet.BrojClanova = specijalnaBasic.BrojClanova;
             
            var komandirDto = DTOManager.VratiOperativnogRadnika(specijalnaBasic.Komandir);
            specijalnaEntitet.Komandir = MapFromBasicToEntity(komandirDto) as OperativniRadnik;

            specijalnaEntitet.Baza = specijalnaBasic.Baza;
            specijalnaEntitet.TipSpecijalneJedinice = specijalnaBasic.TipSpecijalneJed;
            return specijalnaEntitet;
        }

        return null;
    }
}