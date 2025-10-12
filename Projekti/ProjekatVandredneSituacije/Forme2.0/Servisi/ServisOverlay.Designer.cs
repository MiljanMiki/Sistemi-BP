namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    partial class ServisOverlay
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
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            registarskaOznakaVozilaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipServisaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            datumDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            servisiViewBindingSource = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)servisiViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(86, 31);
            label1.TabIndex = 5;
            label1.Text = "Servisi\r\n";
            // 
            // buttonObrisi
            // 
            buttonObrisi.Location = new Point(1166, 3);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new Size(171, 40);
            buttonObrisi.TabIndex = 4;
            buttonObrisi.Text = "Obrisi";
            buttonObrisi.UseVisualStyleBackColor = true;
            buttonObrisi.Click += buttonObrisi_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, registarskaOznakaVozilaDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, tipServisaDataGridViewTextBoxColumn, datumDataGridViewTextBoxColumn });
            dataGridView1.DataSource = servisiViewBindingSource;
            dataGridView1.Location = new Point(11, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1326, 597);
            dataGridView1.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // registarskaOznakaVozilaDataGridViewTextBoxColumn
            // 
            registarskaOznakaVozilaDataGridViewTextBoxColumn.DataPropertyName = "RegistarskaOznakaVozila";
            registarskaOznakaVozilaDataGridViewTextBoxColumn.HeaderText = "RegistarskaOznakaVozila";
            registarskaOznakaVozilaDataGridViewTextBoxColumn.MinimumWidth = 6;
            registarskaOznakaVozilaDataGridViewTextBoxColumn.Name = "registarskaOznakaVozilaDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // tipServisaDataGridViewTextBoxColumn
            // 
            tipServisaDataGridViewTextBoxColumn.DataPropertyName = "TipServisa";
            tipServisaDataGridViewTextBoxColumn.HeaderText = "TipServisa";
            tipServisaDataGridViewTextBoxColumn.MinimumWidth = 6;
            tipServisaDataGridViewTextBoxColumn.Name = "tipServisaDataGridViewTextBoxColumn";
            // 
            // datumDataGridViewTextBoxColumn
            // 
            datumDataGridViewTextBoxColumn.DataPropertyName = "Datum";
            datumDataGridViewTextBoxColumn.HeaderText = "Datum";
            datumDataGridViewTextBoxColumn.MinimumWidth = 6;
            datumDataGridViewTextBoxColumn.Name = "datumDataGridViewTextBoxColumn";
            // 
            // servisiViewBindingSource
            // 
            servisiViewBindingSource.DataSource = typeof(DTOs.ServisiView);
            // 
            // button1
            // 
            button1.Location = new Point(989, 3);
            button1.Name = "button1";
            button1.Size = new Size(171, 40);
            button1.TabIndex = 6;
            button1.Text = "Izmeni";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(812, 3);
            button2.Name = "button2";
            button2.Size = new Size(171, 40);
            button2.TabIndex = 7;
            button2.Text = "Dodaj";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ServisOverlay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 653);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(buttonObrisi);
            Controls.Add(dataGridView1);
            Name = "ServisOverlay";
            Text = "ServisOverlay";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)servisiViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonObrisi;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn registarskaOznakaVozilaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipServisaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn datumDataGridViewTextBoxColumn;
        private BindingSource servisiViewBindingSource;
        private Button button1;
        private Button button2;
    }
}