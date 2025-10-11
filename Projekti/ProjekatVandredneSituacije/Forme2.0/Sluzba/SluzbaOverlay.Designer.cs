namespace ProjekatVandredneSituacije.Forme2._0.Sluzba
{
    partial class SluzbaOverlay
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
            idSektoraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipSektoraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jMBGPredstavnikaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imePredstavnikaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prezimePredstavnikaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sluzbaGetViewBindingSource = new BindingSource(components);
            sluzbaViewBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sluzbaGetViewBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sluzbaViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(116, 25);
            label1.TabIndex = 8;
            label1.Text = "Lista Sluzbi";
            // 
            // buttonObrisi
            // 
            buttonObrisi.AutoSize = true;
            buttonObrisi.Location = new Point(1022, 11);
            buttonObrisi.Margin = new Padding(3, 2, 3, 2);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new Size(150, 30);
            buttonObrisi.TabIndex = 7;
            buttonObrisi.Text = "Obrisi";
            buttonObrisi.UseVisualStyleBackColor = true;
            buttonObrisi.Click += buttonObrisi_Click;
            // 
            // buttonIzmeni
            // 
            buttonIzmeni.AutoSize = true;
            buttonIzmeni.Location = new Point(866, 11);
            buttonIzmeni.Margin = new Padding(3, 2, 3, 2);
            buttonIzmeni.Name = "buttonIzmeni";
            buttonIzmeni.Size = new Size(150, 30);
            buttonIzmeni.TabIndex = 6;
            buttonIzmeni.Text = "Izmeni";
            buttonIzmeni.UseVisualStyleBackColor = true;
            buttonIzmeni.Click += buttonIzmeni_Click;
            // 
            // buttonDodaj
            // 
            buttonDodaj.AutoSize = true;
            buttonDodaj.Location = new Point(710, 11);
            buttonDodaj.Margin = new Padding(3, 2, 3, 2);
            buttonDodaj.Name = "buttonDodaj";
            buttonDodaj.Size = new Size(150, 30);
            buttonDodaj.TabIndex = 5;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idSektoraDataGridViewTextBoxColumn, tipSektoraDataGridViewTextBoxColumn, jMBGPredstavnikaDataGridViewTextBoxColumn, imePredstavnikaDataGridViewTextBoxColumn, prezimePredstavnikaDataGridViewTextBoxColumn });
            dataGridView1.DataSource = sluzbaGetViewBindingSource;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 605);
            dataGridView1.TabIndex = 10;
            // 
            // idSektoraDataGridViewTextBoxColumn
            // 
            idSektoraDataGridViewTextBoxColumn.DataPropertyName = "Id_Sektora";
            idSektoraDataGridViewTextBoxColumn.HeaderText = "Id_Sektora";
            idSektoraDataGridViewTextBoxColumn.MinimumWidth = 6;
            idSektoraDataGridViewTextBoxColumn.Name = "idSektoraDataGridViewTextBoxColumn";
            // 
            // tipSektoraDataGridViewTextBoxColumn
            // 
            tipSektoraDataGridViewTextBoxColumn.DataPropertyName = "TipSektora";
            tipSektoraDataGridViewTextBoxColumn.HeaderText = "TipSektora";
            tipSektoraDataGridViewTextBoxColumn.MinimumWidth = 6;
            tipSektoraDataGridViewTextBoxColumn.Name = "tipSektoraDataGridViewTextBoxColumn";
            // 
            // jMBGPredstavnikaDataGridViewTextBoxColumn
            // 
            jMBGPredstavnikaDataGridViewTextBoxColumn.DataPropertyName = "JMBGPredstavnika";
            jMBGPredstavnikaDataGridViewTextBoxColumn.HeaderText = "JMBGPredstavnika";
            jMBGPredstavnikaDataGridViewTextBoxColumn.MinimumWidth = 6;
            jMBGPredstavnikaDataGridViewTextBoxColumn.Name = "jMBGPredstavnikaDataGridViewTextBoxColumn";
            // 
            // imePredstavnikaDataGridViewTextBoxColumn
            // 
            imePredstavnikaDataGridViewTextBoxColumn.DataPropertyName = "ImePredstavnika";
            imePredstavnikaDataGridViewTextBoxColumn.HeaderText = "ImePredstavnika";
            imePredstavnikaDataGridViewTextBoxColumn.MinimumWidth = 6;
            imePredstavnikaDataGridViewTextBoxColumn.Name = "imePredstavnikaDataGridViewTextBoxColumn";
            // 
            // prezimePredstavnikaDataGridViewTextBoxColumn
            // 
            prezimePredstavnikaDataGridViewTextBoxColumn.DataPropertyName = "PrezimePredstavnika";
            prezimePredstavnikaDataGridViewTextBoxColumn.HeaderText = "PrezimePredstavnika";
            prezimePredstavnikaDataGridViewTextBoxColumn.MinimumWidth = 6;
            prezimePredstavnikaDataGridViewTextBoxColumn.Name = "prezimePredstavnikaDataGridViewTextBoxColumn";
            // 
            // sluzbaGetViewBindingSource
            // 
            sluzbaGetViewBindingSource.DataSource = typeof(DTOs.SluzbaGetView);
            // 
            // sluzbaViewBindingSource
            // 
            sluzbaViewBindingSource.DataSource = typeof(DTOs.SluzbaView);
            // 
            // SluzbaOverlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(buttonObrisi);
            Controls.Add(buttonIzmeni);
            Controls.Add(buttonDodaj);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SluzbaOverlay";
            Text = "SluzbaOverlay";
            Load += SluzbaOverlay_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sluzbaGetViewBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)sluzbaViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonObrisi;
        private Button buttonIzmeni;
        private Button buttonDodaj;
        private DataGridView dataGridView1;
        private BindingSource sluzbaViewBindingSource;
        private DataGridViewTextBoxColumn idSektoraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipSektoraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jMBGPredstavnikaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imePredstavnikaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prezimePredstavnikaDataGridViewTextBoxColumn;
        private BindingSource sluzbaGetViewBindingSource;
    }
}