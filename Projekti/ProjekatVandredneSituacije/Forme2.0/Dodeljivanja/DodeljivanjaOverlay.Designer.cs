namespace ProjekatVandredneSituacije.Forme2._0.Dodeljivanja
{
    partial class DodeljivanjaOverlay
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
            button18 = new Button();
            button20 = new Button();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            regVoziloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            JMBGRadnik = new DataGridViewTextBoxColumn();
            punoImeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idJedinicaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nazivJediniceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            datumOdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            datumDoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dodeljujeSeGetViewBindingSource = new BindingSource(components);
            labelDodeljivanja = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dodeljujeSeGetViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button18
            // 
            button18.Location = new Point(1022, 11);
            button18.Margin = new Padding(3, 2, 3, 2);
            button18.Name = "button18";
            button18.Size = new Size(150, 30);
            button18.TabIndex = 29;
            button18.Text = "Obrisi";
            button18.UseVisualStyleBackColor = true;
            button18.Click += button18_Click;
            // 
            // button20
            // 
            button20.Location = new Point(866, 11);
            button20.Margin = new Padding(3, 2, 3, 2);
            button20.Name = "button20";
            button20.Size = new Size(150, 30);
            button20.TabIndex = 27;
            button20.Text = "Dodaj";
            button20.UseVisualStyleBackColor = true;
            button20.Click += button20_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, regVoziloDataGridViewTextBoxColumn, JMBGRadnik, punoImeDataGridViewTextBoxColumn, idJedinicaDataGridViewTextBoxColumn, nazivJediniceDataGridViewTextBoxColumn, datumOdDataGridViewTextBoxColumn, datumDoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = dodeljujeSeGetViewBindingSource;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 605);
            dataGridView1.TabIndex = 30;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // regVoziloDataGridViewTextBoxColumn
            // 
            regVoziloDataGridViewTextBoxColumn.DataPropertyName = "RegVozilo";
            regVoziloDataGridViewTextBoxColumn.HeaderText = "RegVozilo";
            regVoziloDataGridViewTextBoxColumn.MinimumWidth = 6;
            regVoziloDataGridViewTextBoxColumn.Name = "regVoziloDataGridViewTextBoxColumn";
            // 
            // JMBGRadnik
            // 
            JMBGRadnik.DataPropertyName = "JMBGRadnik";
            JMBGRadnik.HeaderText = "JMBGRadnik";
            JMBGRadnik.MinimumWidth = 6;
            JMBGRadnik.Name = "JMBGRadnik";
            // 
            // punoImeDataGridViewTextBoxColumn
            // 
            punoImeDataGridViewTextBoxColumn.DataPropertyName = "PunoIme";
            punoImeDataGridViewTextBoxColumn.HeaderText = "PunoIme";
            punoImeDataGridViewTextBoxColumn.MinimumWidth = 6;
            punoImeDataGridViewTextBoxColumn.Name = "punoImeDataGridViewTextBoxColumn";
            punoImeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idJedinicaDataGridViewTextBoxColumn
            // 
            idJedinicaDataGridViewTextBoxColumn.DataPropertyName = "IdJedinica";
            idJedinicaDataGridViewTextBoxColumn.HeaderText = "IdJedinica";
            idJedinicaDataGridViewTextBoxColumn.MinimumWidth = 6;
            idJedinicaDataGridViewTextBoxColumn.Name = "idJedinicaDataGridViewTextBoxColumn";
            // 
            // nazivJediniceDataGridViewTextBoxColumn
            // 
            nazivJediniceDataGridViewTextBoxColumn.DataPropertyName = "NazivJedinice";
            nazivJediniceDataGridViewTextBoxColumn.HeaderText = "NazivJedinice";
            nazivJediniceDataGridViewTextBoxColumn.MinimumWidth = 6;
            nazivJediniceDataGridViewTextBoxColumn.Name = "nazivJediniceDataGridViewTextBoxColumn";
            // 
            // datumOdDataGridViewTextBoxColumn
            // 
            datumOdDataGridViewTextBoxColumn.DataPropertyName = "DatumOd";
            datumOdDataGridViewTextBoxColumn.HeaderText = "DatumOd";
            datumOdDataGridViewTextBoxColumn.MinimumWidth = 6;
            datumOdDataGridViewTextBoxColumn.Name = "datumOdDataGridViewTextBoxColumn";
            // 
            // datumDoDataGridViewTextBoxColumn
            // 
            datumDoDataGridViewTextBoxColumn.DataPropertyName = "DatumDo";
            datumDoDataGridViewTextBoxColumn.HeaderText = "DatumDo";
            datumDoDataGridViewTextBoxColumn.MinimumWidth = 6;
            datumDoDataGridViewTextBoxColumn.Name = "datumDoDataGridViewTextBoxColumn";
            // 
            // dodeljujeSeGetViewBindingSource
            // 
            dodeljujeSeGetViewBindingSource.DataSource = typeof(DTOs.DodeljujeSeGetView);
            // 
            // labelDodeljivanja
            // 
            labelDodeljivanja.AutoSize = true;
            labelDodeljivanja.Font = new Font("Times New Roman", 16F);
            labelDodeljivanja.Location = new Point(12, 16);
            labelDodeljivanja.Name = "labelDodeljivanja";
            labelDodeljivanja.Size = new Size(125, 25);
            labelDodeljivanja.TabIndex = 31;
            labelDodeljivanja.Text = "Dodeljivanja";
            // 
            // DodeljivanjaOverlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(labelDodeljivanja);
            Controls.Add(dataGridView1);
            Controls.Add(button18);
            Controls.Add(button20);
            Margin = new Padding(3, 2, 3, 2);
            Name = "DodeljivanjaOverlay";
            Text = "DodeljivanjaOverlay";
            Load += DodeljivanjaOverlay_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dodeljujeSeGetViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button18;
        private Button button20;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn regVoziloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn JMBGRadnik;
        private DataGridViewTextBoxColumn punoImeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idJedinicaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nazivJediniceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn datumOdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn datumDoDataGridViewTextBoxColumn;
        private BindingSource dodeljujeSeGetViewBindingSource;
        private Label labelDodeljivanja;
    }
}