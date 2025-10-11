namespace ProjekatVandredneSituacije.Forme2._0.Sluzba
{
    partial class PredstavniciOverlay
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
            buttonObrisiO = new Button();
            buttonIzmeniO = new Button();
            buttonDodajOp = new Button();
            dataGridView1 = new DataGridView();
            jMBGDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prezimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pozicijaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefonDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            predstavnikViewBindingSource = new BindingSource(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)predstavnikViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // buttonObrisiO
            // 
            buttonObrisiO.Location = new Point(1022, 11);
            buttonObrisiO.Margin = new Padding(3, 2, 3, 2);
            buttonObrisiO.Name = "buttonObrisiO";
            buttonObrisiO.Size = new Size(150, 30);
            buttonObrisiO.TabIndex = 23;
            buttonObrisiO.Text = "Obrisi";
            buttonObrisiO.UseVisualStyleBackColor = true;
            buttonObrisiO.Click += buttonObrisiO_Click;
            // 
            // buttonIzmeniO
            // 
            buttonIzmeniO.Location = new Point(866, 11);
            buttonIzmeniO.Margin = new Padding(3, 2, 3, 2);
            buttonIzmeniO.Name = "buttonIzmeniO";
            buttonIzmeniO.Size = new Size(150, 30);
            buttonIzmeniO.TabIndex = 22;
            buttonIzmeniO.Text = "Izmeni";
            buttonIzmeniO.UseVisualStyleBackColor = true;
            buttonIzmeniO.Click += buttonIzmeniO_Click;
            // 
            // buttonDodajOp
            // 
            buttonDodajOp.Location = new Point(710, 11);
            buttonDodajOp.Margin = new Padding(3, 2, 3, 2);
            buttonDodajOp.Name = "buttonDodajOp";
            buttonDodajOp.Size = new Size(150, 30);
            buttonDodajOp.TabIndex = 21;
            buttonDodajOp.Text = "Dodaj";
            buttonDodajOp.UseVisualStyleBackColor = true;
            buttonDodajOp.Click += buttonDodajOp_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { jMBGDataGridViewTextBoxColumn, imeDataGridViewTextBoxColumn, prezimeDataGridViewTextBoxColumn, pozicijaDataGridViewTextBoxColumn, telefonDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn });
            dataGridView1.DataSource = predstavnikViewBindingSource;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 605);
            dataGridView1.TabIndex = 24;
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
            // pozicijaDataGridViewTextBoxColumn
            // 
            pozicijaDataGridViewTextBoxColumn.DataPropertyName = "Pozicija";
            pozicijaDataGridViewTextBoxColumn.HeaderText = "Pozicija";
            pozicijaDataGridViewTextBoxColumn.MinimumWidth = 6;
            pozicijaDataGridViewTextBoxColumn.Name = "pozicijaDataGridViewTextBoxColumn";
            // 
            // telefonDataGridViewTextBoxColumn
            // 
            telefonDataGridViewTextBoxColumn.DataPropertyName = "Telefon";
            telefonDataGridViewTextBoxColumn.HeaderText = "Telefon";
            telefonDataGridViewTextBoxColumn.MinimumWidth = 6;
            telefonDataGridViewTextBoxColumn.Name = "telefonDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // predstavnikViewBindingSource
            // 
            predstavnikViewBindingSource.DataSource = typeof(DTOs.PredstavnikView);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(128, 30);
            label1.TabIndex = 25;
            label1.Text = "Predstavnici";
            // 
            // PredstavniciOverlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(buttonObrisiO);
            Controls.Add(buttonIzmeniO);
            Controls.Add(buttonDodajOp);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PredstavniciOverlay";
            Text = "PredstavnicOverlay";
            Load += PredstavniciOverlay_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)predstavnikViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonObrisiO;
        private Button buttonIzmeniO;
        private Button buttonDodajOp;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn jMBGDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prezimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pozicijaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefonDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private BindingSource predstavnikViewBindingSource;
        private Label label1;
    }
}