namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    partial class ClanoviForma
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
            button3 = new Button();
            dataGridView1 = new DataGridView();
            jMBGDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prezimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            datumRodjenjaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            polDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            brojSatiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            kontaktTelefonDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            adresaStanovanjaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            datumZaposlenjaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fizickaSpremnostDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            operativniRadnikViewBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)operativniRadnikViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(951, 12);
            button3.Name = "button3";
            button3.Size = new Size(152, 38);
            button3.TabIndex = 3;
            button3.Text = "Obrisi clana";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { jMBGDataGridViewTextBoxColumn, imeDataGridViewTextBoxColumn, prezimeDataGridViewTextBoxColumn, datumRodjenjaDataGridViewTextBoxColumn, polDataGridViewTextBoxColumn, brojSatiDataGridViewTextBoxColumn, kontaktTelefonDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, adresaStanovanjaDataGridViewTextBoxColumn, datumZaposlenjaDataGridViewTextBoxColumn, fizickaSpremnostDataGridViewTextBoxColumn });
            dataGridView1.DataSource = operativniRadnikViewBindingSource;
            dataGridView1.Location = new Point(12, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1091, 458);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            datumRodjenjaDataGridViewTextBoxColumn.HeaderText = "Rodjen";
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
            // brojSatiDataGridViewTextBoxColumn
            // 
            brojSatiDataGridViewTextBoxColumn.DataPropertyName = "Broj_Sati";
            brojSatiDataGridViewTextBoxColumn.HeaderText = "Broj Sati";
            brojSatiDataGridViewTextBoxColumn.MinimumWidth = 6;
            brojSatiDataGridViewTextBoxColumn.Name = "brojSatiDataGridViewTextBoxColumn";
            // 
            // kontaktTelefonDataGridViewTextBoxColumn
            // 
            kontaktTelefonDataGridViewTextBoxColumn.DataPropertyName = "Kontakt_Telefon";
            kontaktTelefonDataGridViewTextBoxColumn.HeaderText = "Kontakt";
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
            datumZaposlenjaDataGridViewTextBoxColumn.HeaderText = "Zaposljen";
            datumZaposlenjaDataGridViewTextBoxColumn.MinimumWidth = 6;
            datumZaposlenjaDataGridViewTextBoxColumn.Name = "datumZaposlenjaDataGridViewTextBoxColumn";
            // 
            // fizickaSpremnostDataGridViewTextBoxColumn
            // 
            fizickaSpremnostDataGridViewTextBoxColumn.DataPropertyName = "Fizicka_Spremnost";
            fizickaSpremnostDataGridViewTextBoxColumn.HeaderText = "Spremnost";
            fizickaSpremnostDataGridViewTextBoxColumn.MinimumWidth = 6;
            fizickaSpremnostDataGridViewTextBoxColumn.Name = "fizickaSpremnostDataGridViewTextBoxColumn";
            // 
            // operativniRadnikViewBindingSource
            // 
            operativniRadnikViewBindingSource.DataSource = typeof(DTOs.OperativniRadnikView);
            // 
            // ClanoviForma
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 533);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Name = "ClanoviForma";
            Text = "ClanoviForma";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)operativniRadnikViewBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button3;
        private DataGridView dataGridView1;
        private BindingSource operativniRadnikViewBindingSource;
        private DataGridViewTextBoxColumn jMBGDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prezimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn datumRodjenjaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn polDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn brojSatiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kontaktTelefonDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn adresaStanovanjaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn datumZaposlenjaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fizickaSpremnostDataGridViewTextBoxColumn;
    }
}