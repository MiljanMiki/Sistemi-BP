//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Windows.Forms;
//using ProjekatVanredneSituacije;
//using ProjekatVandredneSituacije;
//using ProjekatVandredneSituacije.DTOs;

//public class ListaOpremeForm : Form
//{
//	private DataGridView dgvOprema;
//	private Button btnDodaj, btnIzmeni, btnObrisi;
//	private Panel pnlButtons;

//	public ListaOpremeForm()
//	{
//		InitializeComponent();
//		this.Load += ListaOpremeForm_Load;
//	}

//	private void InitializeComponent()
//	{
//		this.Text = "Lista Opreme";
//		this.Size = new Size(1000, 600);
//		this.BackColor = SystemColors.Control;

//		pnlButtons = new Panel { Dock = DockStyle.Top, Height = 50, BackColor = SystemColors.Control };
//		btnDodaj = new Button { Text = "Dodaj", Location = new Point(10, 10), Width = 100 };
//		btnIzmeni = new Button { Text = "Izmeni", Location = new Point(120, 10), Width = 100 };
//		btnObrisi = new Button { Text = "Obriši", Location = new Point(230, 10), Width = 100 };
//		pnlButtons.Controls.Add(btnDodaj);
//		pnlButtons.Controls.Add(btnIzmeni);
//		pnlButtons.Controls.Add(btnObrisi);

//		dgvOprema = new DataGridView
//		{
//			Dock = DockStyle.Fill,
//			ReadOnly = true,
//			AutoGenerateColumns = true,
//			AllowUserToAddRows = false,
//			SelectionMode = DataGridViewSelectionMode.FullRowSelect
//		};

//		this.Controls.Add(dgvOprema);
//		this.Controls.Add(pnlButtons);

//		btnDodaj.Click += BtnDodaj_Click;
//		btnIzmeni.Click += BtnIzmeni_Click;
//		btnObrisi.Click += BtnObrisi_Click;
//	}

//	private async void ListaOpremeForm_Load(object? sender, EventArgs e)
//	{
//		await RefreshDataGrid();
//	}

//	private async Task RefreshDataGrid()
//	{
//		try
//		{
//			var svaOprema = await DataProvider.VratiSvuOpremu();
//			dgvOprema.DataSource = svaOprema;
//		}
//		catch (Exception ex)
//		{
//			MessageBox.Show("Došlo je do greške prilikom učitavanja opreme: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
//		}
//	}

//	private async void BtnDodaj_Click(object? sender, EventArgs e)
//	{
//		var dialog = new DodajIzmeniOpremuDialog();
//		if (dialog.ShowDialog() == DialogResult.OK && dialog.OpremaBasic != null)
//		{
//			try
//			{
//				if (dialog.OpremaBasic is LicnaZastitaView liz)
//					await DataProvider.DodajLicnuZastitu(MapFromBasicToView(liz));
//				else if (dialog.OpremaBasic is MedicinskaOpremaAddView med)
//					await DataProvider.DodajMedicinskuOpremu(MapFromBasicToAddView(med));
//				else if (dialog.OpremaBasic is TehnickaOpremaAddView tech)
//					await DataProvider.DodajTehnickuOpremu(MapFromBasicToAddView(tech));
//				else if (dialog.OpremaBasic is ZaliheBasic zalihe)
//					await DataProvider.DodajZalihe(MapFromBasicToAddView(zalihe));

//				MessageBox.Show("Oprema je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
//				await RefreshDataGrid();
//			}
//			catch (Exception ex)
//			{
//				MessageBox.Show("Greška pri dodavanju opreme: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
//			}
//		}
//	}

//	private async void BtnIzmeni_Click(object? sender, EventArgs e)
//	{
//		if (dgvOprema.SelectedRows.Count == 0)
//		{
//			MessageBox.Show("Molimo odaberite opremu za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//			return;
//		}

//		var selectedOprema = dgvOprema.SelectedRows[0].DataBoundItem as OpremaView;
//		if (selectedOprema == null) return;

//		try
//		{
//			OpremaBasic? opremaBasic = null;

//			if (selectedOprema is LicnaZastitaView licna)
//			{
//				opremaBasic = await DataProvider.VratiLicnuZastitu(licna.Serijski_Broj);
//			}
//			else if (selectedOprema is MedicinskaOpremaView medicinska)
//			{
//				opremaBasic = await DataProvider.VratiMedicinskuOpremu(medicinska.Serijski_Broj);
//			}
//			else if (selectedOprema is TehnickaOpremaView tehnicka)
//			{
//				opremaBasic = await DataProvider.VratiTehnickuOpremu(tehnicka.Serijski_Broj);
//			}
//			else if (selectedOprema is ZaliheView zalihe)
//			{
//				opremaBasic = await DataProvider.VratiZalihe(zalihe.Serijski_Broj);
//			}

//			if (opremaBasic == null)
//			{
//				MessageBox.Show("Odabrana oprema nije pronađena.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
//				return;
//			}

//			var dialog = new DodajIzmeniOpremuDialog(opremaBasic);
//			if (dialog.ShowDialog() == DialogResult.OK && dialog.OpremaBasic != null)
//			{
//				if (dialog.OpremaBasic is LicnaZastitaBasic liz)
//					await DataProvider.IzmeniLicnuZastitu(MapFromBasicToView(liz));
//				else if (dialog.OpremaBasic is MedicinskaOpremaBasic med)
//					await DataProvider.IzmeniMedicinskuOpremu(med.Serijski_Broj.ToString(), MapFromBasicToAddView(med));
//				else if (dialog.OpremaBasic is TehnickaOpremaBasic tech)
//					await DataProvider.IzmeniTehnickuOpremu(MapFromBasicToAddView(tech), tech.Serijski_Broj.ToString());
//				else if (dialog.OpremaBasic is ZaliheBasic zalihe)
//					await DataProvider.IzmeniZalihe(MapFromBasicToAddView(zalihe), zalihe.Serijski_Broj.ToString());

//				MessageBox.Show("Oprema je uspešno izmenjena.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
//				await RefreshDataGrid();
//			}
//		}
//		catch (Exception ex)
//		{
//			MessageBox.Show("Greška pri izmeni opreme: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
//		}
//	}

//	private async void BtnObrisi_Click(object? sender, EventArgs e)
//	{
//		if (dgvOprema.SelectedRows.Count == 0)
//		{
//			MessageBox.Show("Molimo odaberite opremu za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//			return;
//		}

//		var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranu opremu?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//		if (result == DialogResult.Yes)
//		{
//			var selectedOprema = dgvOprema.SelectedRows[0].DataBoundItem as OpremaView;
//			if (selectedOprema == null) return;

//			try
//			{
//				if (selectedOprema is LicnaZastitaView)
//					await DataProvider.ObrisiLicnuZastitu(selectedOprema.Serijski_Broj.ToString());
//				else if (selectedOprema is MedicinskaOpremaView)
//					await DataProvider.ObrisiMedicinskuOpremu(selectedOprema.Serijski_Broj.ToString());
//				else if (selectedOprema is TehnickaOpremaView)
//					await DataProvider.ObrisiTehnickuOpremu(selectedOprema.Serijski_Broj.ToString());
//				else if (selectedOprema is ZaliheView)
//					await DataProvider.ObrisiZalihe(selectedOprema.Serijski_Broj.ToString());

//				MessageBox.Show("Oprema je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
//				await RefreshDataGrid();
//			}
//			catch (Exception ex)
//			{
//				MessageBox.Show("Greška pri brisanju opreme: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
//			}
//		}
//	}
	 
//	private LicnaZastitaView MapFromBasicToView(LicnaZastitaBasic basic)
//	{
//		return new LicnaZastitaView
//		{
//			Serijski_Broj = basic.Serijski_Broj,
//			Naziv = basic.Naziv,
//			Status = basic.Status,
//			DatumNabavke = basic.DatumNabavke,
//			IdJedinica = basic.IdJedinica
//		};
//	}
//	private MedicinskaOpremaAddView MapFromBasicToAddView(MedicinskaOpremaBasic basic)
//	{
//		return new MedicinskaOpremaAddView
//		{
//			Naziv = basic.Naziv,
//			Status = basic.Status,
//			DatumNabavke = basic.DatumNabavke,
//			JedinicaID = basic.IdJedinica
//		};
//	}
//	private TehnickaOpremaAddView MapFromBasicToAddView(TehnickaOpremaBasic basic)
//	{
//		return new TehnickaOpremaAddView
//		{
//			Naziv = basic.Naziv,
//			Status = basic.Status,
//			DatumNabavke = basic.DatumNabavke,
//			JedinicaID = basic.IdJedinica
//		};
//	}
//	private ZaliheAddView MapFromBasicToAddView(ZaliheBasic basic)
//	{
//		return new ZaliheAddView
//		{
//			Naziv = basic.Naziv,
//			Status = basic.Status,
//			DatumNabavke = basic.DatumNabavke,
//			JedinicaID = basic.IdJedinica,
//			Kolicina = basic.Kolicina,
//			Tip = basic.Tip
//		};
//	}
//}