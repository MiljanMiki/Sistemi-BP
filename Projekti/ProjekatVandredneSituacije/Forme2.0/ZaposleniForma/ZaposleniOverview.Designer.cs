namespace ProjekatVandredneSituacije.Forme2._0.ZaposleniForma
{
    partial class ZaposleniOverview
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
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            dataGridView1 = new DataGridView();
            jMBGDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prezimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            datumRodjenjaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            polDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kontaktTelefonDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            adresaStanovanjaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            datumZaposlenjaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            zaposleniViewBindingSource = new BindingSource(components);
            button4 = new Button();
            buttonSert = new Button();
            buttonVozila = new Button();
            buttonSoftver = new Button();
            buttonEkspertiza = new Button();
            buttonSpecijalizacija = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)zaposleniViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteCustomSource.AddRange(new string[] { "Operativni radnici", "Koordinatori", "Analiticari" });
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Svi zaposleni", "Operativni radnici", "Koordinatori", "Analiticari" });
            comboBox1.Location = new Point(12, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 24);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            comboBox1.DropDownStyleChanged += comboBox1_DropDownStyleChanged;
            // 
            // button1
            // 
            button1.Location = new Point(296, 12);
            button1.Name = "button1";
            button1.Size = new Size(120, 30);
            button1.TabIndex = 1;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(422, 12);
            button2.Name = "button2";
            button2.Size = new Size(120, 30);
            button2.TabIndex = 2;
            button2.Text = "Izmeni";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(548, 12);
            button3.Name = "button3";
            button3.Size = new Size(120, 30);
            button3.TabIndex = 3;
            button3.Text = "Izbrisi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { jMBGDataGridViewTextBoxColumn, imeDataGridViewTextBoxColumn, prezimeDataGridViewTextBoxColumn, datumRodjenjaDataGridViewTextBoxColumn, polDataGridViewTextBoxColumn, kontaktTelefonDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, adresaStanovanjaDataGridViewTextBoxColumn, datumZaposlenjaDataGridViewTextBoxColumn });
            dataGridView1.DataSource = zaposleniViewBindingSource;
            dataGridView1.Location = new Point(12, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 601);
            dataGridView1.TabIndex = 4;
            // 
            // jMBGDataGridViewTextBoxColumn
            // 
            jMBGDataGridViewTextBoxColumn.DataPropertyName = "JMBG";
            jMBGDataGridViewTextBoxColumn.HeaderText = "JMBG";
            jMBGDataGridViewTextBoxColumn.MinimumWidth = 6;
            jMBGDataGridViewTextBoxColumn.Name = "jMBGDataGridViewTextBoxColumn";
            // 
            // imeDataGridViewTextBoxColumn
            // 
            imeDataGridViewTextBoxColumn.DataPropertyName = "Ime";
            imeDataGridViewTextBoxColumn.HeaderText = "Ime";
            imeDataGridViewTextBoxColumn.MinimumWidth = 6;
            imeDataGridViewTextBoxColumn.Name = "imeDataGridViewTextBoxColumn";
            // 
            // prezimeDataGridViewTextBoxColumn
            // 
            prezimeDataGridViewTextBoxColumn.DataPropertyName = "Prezime";
            prezimeDataGridViewTextBoxColumn.HeaderText = "Prezime";
            prezimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            prezimeDataGridViewTextBoxColumn.Name = "prezimeDataGridViewTextBoxColumn";
            // 
            // datumRodjenjaDataGridViewTextBoxColumn
            // 
            datumRodjenjaDataGridViewTextBoxColumn.DataPropertyName = "Datum_Rodjenja";
            datumRodjenjaDataGridViewTextBoxColumn.HeaderText = "Datum Rodjenja";
            datumRodjenjaDataGridViewTextBoxColumn.MinimumWidth = 6;
            datumRodjenjaDataGridViewTextBoxColumn.Name = "datumRodjenjaDataGridViewTextBoxColumn";
            // 
            // polDataGridViewTextBoxColumn
            // 
            polDataGridViewTextBoxColumn.DataPropertyName = "Pol";
            polDataGridViewTextBoxColumn.HeaderText = "Pol";
            polDataGridViewTextBoxColumn.MinimumWidth = 6;
            polDataGridViewTextBoxColumn.Name = "polDataGridViewTextBoxColumn";
            // 
            // kontaktTelefonDataGridViewTextBoxColumn
            // 
            kontaktTelefonDataGridViewTextBoxColumn.DataPropertyName = "Kontakt_Telefon";
            kontaktTelefonDataGridViewTextBoxColumn.HeaderText = "Kontakt Telefon";
            kontaktTelefonDataGridViewTextBoxColumn.MinimumWidth = 6;
            kontaktTelefonDataGridViewTextBoxColumn.Name = "kontaktTelefonDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // adresaStanovanjaDataGridViewTextBoxColumn
            // 
            adresaStanovanjaDataGridViewTextBoxColumn.DataPropertyName = "AdresaStanovanja";
            adresaStanovanjaDataGridViewTextBoxColumn.HeaderText = "Adresa";
            adresaStanovanjaDataGridViewTextBoxColumn.MinimumWidth = 6;
            adresaStanovanjaDataGridViewTextBoxColumn.Name = "adresaStanovanjaDataGridViewTextBoxColumn";
            // 
            // datumZaposlenjaDataGridViewTextBoxColumn
            // 
            datumZaposlenjaDataGridViewTextBoxColumn.DataPropertyName = "Datum_Zaposlenja";
            datumZaposlenjaDataGridViewTextBoxColumn.HeaderText = "Datum_Zaposlenja";
            datumZaposlenjaDataGridViewTextBoxColumn.MinimumWidth = 6;
            datumZaposlenjaDataGridViewTextBoxColumn.Name = "datumZaposlenjaDataGridViewTextBoxColumn";
            // 
            // zaposleniViewBindingSource
            // 
            zaposleniViewBindingSource.DataSource = typeof(DTOs.ZaposleniView);
            // 
            // button4
            // 
            button4.Location = new Point(1052, 12);
            button4.Name = "button4";
            button4.Size = new Size(120, 30);
            button4.TabIndex = 5;
            button4.Text = "Istorija";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // buttonSert
            // 
            buttonSert.Location = new Point(800, 12);
            buttonSert.Name = "buttonSert";
            buttonSert.Size = new Size(120, 30);
            buttonSert.TabIndex = 6;
            buttonSert.Text = "Sertifikat";
            buttonSert.UseVisualStyleBackColor = true;
            buttonSert.Visible = false;
            buttonSert.Click += buttonSert_Click;
            // 
            // buttonVozila
            // 
            buttonVozila.Location = new Point(926, 12);
            buttonVozila.Name = "buttonVozila";
            buttonVozila.Size = new Size(120, 30);
            buttonVozila.TabIndex = 7;
            buttonVozila.Text = "Vozila";
            buttonVozila.UseVisualStyleBackColor = true;
            buttonVozila.Click += buttonVozila_Click;
            // 
            // buttonSoftver
            // 
            buttonSoftver.Location = new Point(674, 12);
            buttonSoftver.Name = "buttonSoftver";
            buttonSoftver.Size = new Size(120, 30);
            buttonSoftver.TabIndex = 8;
            buttonSoftver.Text = "Softver";
            buttonSoftver.UseVisualStyleBackColor = true;
            buttonSoftver.Visible = false;
            buttonSoftver.Click += buttonSoftver_Click;
            // 
            // buttonEkspertiza
            // 
            buttonEkspertiza.Location = new Point(800, 12);
            buttonEkspertiza.Name = "buttonEkspertiza";
            buttonEkspertiza.Size = new Size(120, 30);
            buttonEkspertiza.TabIndex = 9;
            buttonEkspertiza.Text = "Ekspertiza";
            buttonEkspertiza.UseVisualStyleBackColor = true;
            buttonEkspertiza.Visible = false;
            buttonEkspertiza.Click += buttonEkspertiza_Click;
            // 
            // buttonSpecijalizacija
            // 
            buttonSpecijalizacija.Location = new Point(800, 12);
            buttonSpecijalizacija.Name = "buttonSpecijalizacija";
            buttonSpecijalizacija.Size = new Size(120, 30);
            buttonSpecijalizacija.TabIndex = 10;
            buttonSpecijalizacija.Text = "Specijalizacija";
            buttonSpecijalizacija.UseVisualStyleBackColor = true;
            buttonSpecijalizacija.Visible = false;
            buttonSpecijalizacija.Click += buttonSpecijalizacija_Click;
            // 
            // ZaposleniOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1184, 661);
            Controls.Add(buttonSpecijalizacija);
            Controls.Add(buttonEkspertiza);
            Controls.Add(buttonSoftver);
            Controls.Add(buttonVozila);
            Controls.Add(buttonSert);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ZaposleniOverview";
            Text = "ZaposleniOverview";
            WindowState = FormWindowState.Maximized;
            Load += ZaposleniOverview_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)zaposleniViewBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn jMBGDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prezimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn datumRodjenjaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn polDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kontaktTelefonDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn adresaStanovanjaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn datumZaposlenjaDataGridViewTextBoxColumn;
        private BindingSource zaposleniViewBindingSource;
        private Button button4;
        private Button buttonSert;
        private Button buttonVozila;
        private Button buttonSoftver;
        private Button buttonEkspertiza;
        private Button buttonSpecijalizacija;
    }
}