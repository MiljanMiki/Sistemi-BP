namespace ProjekatVandredneSituacije.Forme2._0.VanrednaSituacija
{
    partial class VanrednaOverview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonDodaj = new Button();
            buttonIzmeni = new Button();
            buttonObrisi = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            datumOdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            datumDoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            brojUgrozenihOsobaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nivoOpasnostiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            opstinaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lokacijaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            opisDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            IdPrijave = new DataGridViewTextBoxColumn();
            vanrednaSituacijaAddViewBindingSource = new BindingSource(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vanrednaSituacijaAddViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // buttonDodaj
            // 
            buttonDodaj.Location = new Point(554, 11);
            buttonDodaj.Margin = new Padding(3, 2, 3, 2);
            buttonDodaj.Name = "buttonDodaj";
            buttonDodaj.Size = new Size(150, 30);
            buttonDodaj.TabIndex = 0;
            buttonDodaj.Text = "Dodaj";
            buttonDodaj.UseVisualStyleBackColor = true;
            buttonDodaj.Click += buttonDodaj_Click;
            // 
            // buttonIzmeni
            // 
            buttonIzmeni.Location = new Point(710, 11);
            buttonIzmeni.Margin = new Padding(3, 2, 3, 2);
            buttonIzmeni.Name = "buttonIzmeni";
            buttonIzmeni.Size = new Size(150, 30);
            buttonIzmeni.TabIndex = 1;
            buttonIzmeni.Text = "Izmeni";
            buttonIzmeni.UseVisualStyleBackColor = true;
            buttonIzmeni.Click += buttonIzmeni_Click;
            // 
            // buttonObrisi
            // 
            buttonObrisi.Location = new Point(866, 11);
            buttonObrisi.Margin = new Padding(3, 2, 3, 2);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new Size(150, 30);
            buttonObrisi.TabIndex = 2;
            buttonObrisi.Text = "Obrisi";
            buttonObrisi.UseVisualStyleBackColor = true;
            buttonObrisi.Click += buttonObrisi_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1022, 11);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(150, 30);
            button3.TabIndex = 3;
            button3.Text = "Ucestvovanja ";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { datumOdDataGridViewTextBoxColumn, datumDoDataGridViewTextBoxColumn, tipDataGridViewTextBoxColumn, brojUgrozenihOsobaDataGridViewTextBoxColumn, nivoOpasnostiDataGridViewTextBoxColumn, opstinaDataGridViewTextBoxColumn, lokacijaDataGridViewTextBoxColumn, opisDataGridViewTextBoxColumn, IdPrijave });
            dataGridView1.DataSource = vanrednaSituacijaAddViewBindingSource;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 605);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // datumOdDataGridViewTextBoxColumn
            // 
            datumOdDataGridViewTextBoxColumn.DataPropertyName = "Datum_Od";
            datumOdDataGridViewTextBoxColumn.HeaderText = "Datum Od";
            datumOdDataGridViewTextBoxColumn.MinimumWidth = 6;
            datumOdDataGridViewTextBoxColumn.Name = "datumOdDataGridViewTextBoxColumn";
            // 
            // datumDoDataGridViewTextBoxColumn
            // 
            datumDoDataGridViewTextBoxColumn.DataPropertyName = "Datum_Do";
            datumDoDataGridViewTextBoxColumn.HeaderText = "Datum Do";
            datumDoDataGridViewTextBoxColumn.MinimumWidth = 6;
            datumDoDataGridViewTextBoxColumn.Name = "datumDoDataGridViewTextBoxColumn";
            // 
            // tipDataGridViewTextBoxColumn
            // 
            tipDataGridViewTextBoxColumn.DataPropertyName = "Tip";
            tipDataGridViewTextBoxColumn.HeaderText = "Tip";
            tipDataGridViewTextBoxColumn.MinimumWidth = 6;
            tipDataGridViewTextBoxColumn.Name = "tipDataGridViewTextBoxColumn";
            // 
            // brojUgrozenihOsobaDataGridViewTextBoxColumn
            // 
            brojUgrozenihOsobaDataGridViewTextBoxColumn.DataPropertyName = "Broj_Ugrozenih_Osoba";
            brojUgrozenihOsobaDataGridViewTextBoxColumn.HeaderText = "Broj Ugrozenih";
            brojUgrozenihOsobaDataGridViewTextBoxColumn.MinimumWidth = 6;
            brojUgrozenihOsobaDataGridViewTextBoxColumn.Name = "brojUgrozenihOsobaDataGridViewTextBoxColumn";
            // 
            // nivoOpasnostiDataGridViewTextBoxColumn
            // 
            nivoOpasnostiDataGridViewTextBoxColumn.DataPropertyName = "Nivo_Opasnosti";
            nivoOpasnostiDataGridViewTextBoxColumn.HeaderText = "Opasnost";
            nivoOpasnostiDataGridViewTextBoxColumn.MinimumWidth = 6;
            nivoOpasnostiDataGridViewTextBoxColumn.Name = "nivoOpasnostiDataGridViewTextBoxColumn";
            // 
            // opstinaDataGridViewTextBoxColumn
            // 
            opstinaDataGridViewTextBoxColumn.DataPropertyName = "Opstina";
            opstinaDataGridViewTextBoxColumn.HeaderText = "Opstina";
            opstinaDataGridViewTextBoxColumn.MinimumWidth = 6;
            opstinaDataGridViewTextBoxColumn.Name = "opstinaDataGridViewTextBoxColumn";
            // 
            // lokacijaDataGridViewTextBoxColumn
            // 
            lokacijaDataGridViewTextBoxColumn.DataPropertyName = "Lokacija";
            lokacijaDataGridViewTextBoxColumn.HeaderText = "Lokacija";
            lokacijaDataGridViewTextBoxColumn.MinimumWidth = 6;
            lokacijaDataGridViewTextBoxColumn.Name = "lokacijaDataGridViewTextBoxColumn";
            // 
            // opisDataGridViewTextBoxColumn
            // 
            opisDataGridViewTextBoxColumn.DataPropertyName = "Opis";
            opisDataGridViewTextBoxColumn.HeaderText = "Opis";
            opisDataGridViewTextBoxColumn.MinimumWidth = 6;
            opisDataGridViewTextBoxColumn.Name = "opisDataGridViewTextBoxColumn";
            // 
            // IdPrijave
            // 
            IdPrijave.DataPropertyName = "IdPrijave";
            IdPrijave.HeaderText = "IdPrijave";
            IdPrijave.Name = "IdPrijave";
            // 
            // vanrednaSituacijaAddViewBindingSource
            // 
            vanrednaSituacijaAddViewBindingSource.DataSource = typeof(DTOs.VanrednaSituacijaAddView);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(170, 25);
            label1.TabIndex = 5;
            label1.Text = "VanredneSituacije";
            // 
            // VanrednaOverview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(buttonObrisi);
            Controls.Add(buttonIzmeni);
            Controls.Add(buttonDodaj);
            Margin = new Padding(3, 2, 3, 2);
            Name = "VanrednaOverview";
            Text = "VanrednaOverview";
            Load += VanrednaOverview_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)vanrednaSituacijaAddViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDodaj;
        private Button buttonIzmeni;
        private Button buttonObrisi;
        private Button button3;
        private DataGridView dataGridView1;
        private BindingSource vanrednaSituacijaAddViewBindingSource;
        private DataGridViewTextBoxColumn idPrijaveDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn datumOdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn datumDoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn brojUgrozenihOsobaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nivoOpasnostiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opstinaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lokacijaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opisDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn IdPrijave;
        private Label label1;
    }
}