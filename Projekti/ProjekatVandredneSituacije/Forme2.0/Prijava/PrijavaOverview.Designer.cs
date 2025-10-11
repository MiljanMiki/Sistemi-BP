namespace ProjekatVandredneSituacije.Forme2._0.Prijava
{
    partial class PrijavaOverview
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
            label1 = new Label();
            buttonObrisi = new Button();
            buttonIzmeni = new Button();
            buttonDodaj = new Button();
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            datumIVremeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imePrijaviocaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kontaktDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lokacijaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            opisDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jMBGDispecerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prioritetDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prijavaViewBindingSource = new BindingSource(components);
            prijavaAddViewBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prijavaViewBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)prijavaAddViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F);
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 3;
            label1.Text = "Lista Prijava";
            // 
            // buttonObrisi
            // 
            buttonObrisi.AutoSize = true;
            buttonObrisi.Location = new Point(1022, 12);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new Size(150, 30);
            buttonObrisi.TabIndex = 2;
            buttonObrisi.Text = "Obrisi";
            buttonObrisi.UseVisualStyleBackColor = true;
            buttonObrisi.Click += buttonObrisi_Click;
            // 
            // buttonIzmeni
            // 
            buttonIzmeni.AutoSize = true;
            buttonIzmeni.Location = new Point(866, 12);
            buttonIzmeni.Name = "buttonIzmeni";
            buttonIzmeni.Size = new Size(150, 30);
            buttonIzmeni.TabIndex = 1;
            buttonIzmeni.Text = "Izmeni";
            buttonIzmeni.UseVisualStyleBackColor = true;
            buttonIzmeni.Click += buttonIzmeni_Click;
            // 
            // buttonDodaj
            // 
            buttonDodaj.AutoSize = true;
            buttonDodaj.Location = new Point(710, 12);
            buttonDodaj.Name = "buttonDodaj";
            buttonDodaj.Size = new Size(150, 30);
            buttonDodaj.TabIndex = 0;
            buttonDodaj.Text = "Dodaj";
            buttonDodaj.UseVisualStyleBackColor = true;
            buttonDodaj.Click += buttonDodaj_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, datumIVremeDataGridViewTextBoxColumn, tipDataGridViewTextBoxColumn, imePrijaviocaDataGridViewTextBoxColumn, kontaktDataGridViewTextBoxColumn, lokacijaDataGridViewTextBoxColumn, opisDataGridViewTextBoxColumn, jMBGDispecerDataGridViewTextBoxColumn, prioritetDataGridViewTextBoxColumn });
            dataGridView1.DataSource = prijavaViewBindingSource;
            dataGridView1.Location = new Point(12, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 601);
            dataGridView1.TabIndex = 1;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            // 
            // datumIVremeDataGridViewTextBoxColumn
            // 
            datumIVremeDataGridViewTextBoxColumn.DataPropertyName = "Datum_I_Vreme";
            datumIVremeDataGridViewTextBoxColumn.HeaderText = "Datum";
            datumIVremeDataGridViewTextBoxColumn.MinimumWidth = 6;
            datumIVremeDataGridViewTextBoxColumn.Name = "datumIVremeDataGridViewTextBoxColumn";
            // 
            // tipDataGridViewTextBoxColumn
            // 
            tipDataGridViewTextBoxColumn.DataPropertyName = "Tip";
            tipDataGridViewTextBoxColumn.HeaderText = "Tip";
            tipDataGridViewTextBoxColumn.MinimumWidth = 6;
            tipDataGridViewTextBoxColumn.Name = "tipDataGridViewTextBoxColumn";
            // 
            // imePrijaviocaDataGridViewTextBoxColumn
            // 
            imePrijaviocaDataGridViewTextBoxColumn.DataPropertyName = "Ime_Prijavioca";
            imePrijaviocaDataGridViewTextBoxColumn.HeaderText = "Prijavioc";
            imePrijaviocaDataGridViewTextBoxColumn.MinimumWidth = 6;
            imePrijaviocaDataGridViewTextBoxColumn.Name = "imePrijaviocaDataGridViewTextBoxColumn";
            // 
            // kontaktDataGridViewTextBoxColumn
            // 
            kontaktDataGridViewTextBoxColumn.DataPropertyName = "Kontakt";
            kontaktDataGridViewTextBoxColumn.HeaderText = "Kontakt";
            kontaktDataGridViewTextBoxColumn.MinimumWidth = 6;
            kontaktDataGridViewTextBoxColumn.Name = "kontaktDataGridViewTextBoxColumn";
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
            // jMBGDispecerDataGridViewTextBoxColumn
            // 
            jMBGDispecerDataGridViewTextBoxColumn.DataPropertyName = "JMBG_Dispecer";
            jMBGDispecerDataGridViewTextBoxColumn.HeaderText = "JMBG Dispecera";
            jMBGDispecerDataGridViewTextBoxColumn.MinimumWidth = 6;
            jMBGDispecerDataGridViewTextBoxColumn.Name = "jMBGDispecerDataGridViewTextBoxColumn";
            // 
            // prioritetDataGridViewTextBoxColumn
            // 
            prioritetDataGridViewTextBoxColumn.DataPropertyName = "Prioritet";
            prioritetDataGridViewTextBoxColumn.HeaderText = "Prioritet";
            prioritetDataGridViewTextBoxColumn.MinimumWidth = 6;
            prioritetDataGridViewTextBoxColumn.Name = "prioritetDataGridViewTextBoxColumn";
            // 
            // prijavaViewBindingSource
            // 
            prijavaViewBindingSource.DataSource = typeof(DTOs.PrijavaView);
            // 
            // prijavaAddViewBindingSource
            // 
            prijavaAddViewBindingSource.DataSource = typeof(DTOs.PrijavaAddView);
            // 
            // PrijavaOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1184, 661);
            Controls.Add(buttonObrisi);
            Controls.Add(label1);
            Controls.Add(buttonIzmeni);
            Controls.Add(dataGridView1);
            Controls.Add(buttonDodaj);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PrijavaOverview";
            Text = "PrijavaOverview";
            Load += PrijavaOverview_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)prijavaViewBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)prijavaAddViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonObrisi;
        private Button buttonIzmeni;
        private Button buttonDodaj;
        private DataGridView dataGridView1;
        private Label label1;
        private BindingSource prijavaAddViewBindingSource;
        private BindingSource prijavaViewBindingSource;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn datumIVremeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imePrijaviocaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kontaktDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lokacijaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opisDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jMBGDispecerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prioritetDataGridViewTextBoxColumn;
    }
}