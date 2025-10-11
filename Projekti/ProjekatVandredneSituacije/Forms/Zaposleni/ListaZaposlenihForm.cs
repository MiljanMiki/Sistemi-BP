using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVanredneSituacije;
using ProjekatVandredneSituacije;
using ProjekatVandredneSituacije.DTOs;

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
            Console.WriteLine(DataProvider.VratiSveZaposlene());
            dgvZaposleni.DataSource = DataProvider.VratiSveZaposlene();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Došlo je do greške prilikom učitavanja podataka o zaposlenima: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnDodaj_Click(object? sender, EventArgs e)
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
                        await DataProvider.DodajAnalitcar(analiticarBasic);
                    else if (zaposlenBasic is KordinatorView koordinatorBasic)
                        await DataProvider.DodajKordinatora(koordinatorBasic);
                    else if (zaposlenBasic is OperativniRadnikAddView operativniBasic)
                        await DataProvider.DodajOperativnogRadnik(operativniBasic);

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

    private async void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvZaposleni.SelectedRows.Count > 0)
        {
            try
            {
                var selectedZaposlenBasic = dgvZaposleni.SelectedRows[0].DataBoundItem as ZaposleniView;
                if (selectedZaposlenBasic == null) return;

                ZaposleniView? zaposlenEntitet = null;

                if (selectedZaposlenBasic is AnaliticarView analiticarBasic)
                {
                    var analiticarDto = await DataProvider.VratiAnaliticara(analiticarBasic.JMBG);
                    zaposlenEntitet = MapFromBasicToEntity(analiticarDto);
                }
                else if (selectedZaposlenBasic is KordinatorView koordinatorBasic)
                {
                    var koordinatorDto = await DataProvider.VratiKordinatora(koordinatorBasic.JMBG);
                    zaposlenEntitet = MapFromBasicToEntity(koordinatorDto);
                }
                else if (selectedZaposlenBasic is OperativniRadnikBasic operativacBasic)
                {
                    var operativacDto = DataProvider.VratiOperativnogRadnika(operativacBasic.JMBG);
                    zaposlenEntitet = MapFromBasicToEntity(operativacDto);
                }

                if (zaposlenEntitet != null)
                {
                    var dialog = new DodajIzmeniZaposlenogDialog(zaposlenEntitet);
                    if (dialog.ShowDialog() == DialogResult.OK && dialog.Zaposlen != null)
                    {
                        ZaposleniView? izmenjenBasic = dialog.Zaposlen;
                        if (izmenjenBasic != null)
                        {
                            if (izmenjenBasic is AnaliticarView analitcarBasic)
                                await DataProvider.IzmeniAnaliticar(analitcarBasic);
                            else if (izmenjenBasic is KordinatorView koordinatorBasic)
                                await DataProvider.IzmeniKordinatora(koordinatorBasic);
                            else if (izmenjenBasic is OperativniRadnikView operativniBasic)
                                await DataProvider.IzmeniOperativnog(operativniBasic, operativniBasic.JMBG);

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
                    var selectedZaposlenBasic = dgvZaposleni.SelectedRows[0].DataBoundItem as ZaposleniView;
                    if (selectedZaposlenBasic != null)
                    {
                        if (selectedZaposlenBasic is AnaliticarView)
                            DataProvider.ObrisiAnaliticara(selectedZaposlenBasic.JMBG);
                        else if (selectedZaposlenBasic is KordinatorView)
                            DataProvider.ObrisiKordinatora(selectedZaposlenBasic.JMBG);
                        else if (selectedZaposlenBasic is OperativniRadnikView)
                            DataProvider.ObrisiOperativnogRadnika(selectedZaposlenBasic.JMBG);
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
}