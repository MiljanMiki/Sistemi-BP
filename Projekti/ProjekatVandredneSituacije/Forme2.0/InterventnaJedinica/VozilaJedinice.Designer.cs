namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    partial class VozilaJedinice
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
            registarskaOznakaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            proizvodjacDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lokacijaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            voziloViewBindingSource = new BindingSource(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)voziloViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(1022, 11);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(150, 30);
            button3.TabIndex = 5;
            button3.Text = "Obrisi vozilo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { registarskaOznakaDataGridViewTextBoxColumn, proizvodjacDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, lokacijaDataGridViewTextBoxColumn });
            dataGridView1.DataSource = voziloViewBindingSource;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 596);
            dataGridView1.TabIndex = 6;
            // 
            // registarskaOznakaDataGridViewTextBoxColumn
            // 
            registarskaOznakaDataGridViewTextBoxColumn.DataPropertyName = "Registarska_Oznaka";
            registarskaOznakaDataGridViewTextBoxColumn.HeaderText = "Registracija";
            registarskaOznakaDataGridViewTextBoxColumn.MinimumWidth = 6;
            registarskaOznakaDataGridViewTextBoxColumn.Name = "registarskaOznakaDataGridViewTextBoxColumn";
            // 
            // proizvodjacDataGridViewTextBoxColumn
            // 
            proizvodjacDataGridViewTextBoxColumn.DataPropertyName = "Proizvodjac";
            proizvodjacDataGridViewTextBoxColumn.HeaderText = "Proizvodjac";
            proizvodjacDataGridViewTextBoxColumn.MinimumWidth = 6;
            proizvodjacDataGridViewTextBoxColumn.Name = "proizvodjacDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // lokacijaDataGridViewTextBoxColumn
            // 
            lokacijaDataGridViewTextBoxColumn.DataPropertyName = "Lokacija";
            lokacijaDataGridViewTextBoxColumn.HeaderText = "Lokacija";
            lokacijaDataGridViewTextBoxColumn.MinimumWidth = 6;
            lokacijaDataGridViewTextBoxColumn.Name = "lokacijaDataGridViewTextBoxColumn";
            // 
            // voziloViewBindingSource
            // 
            voziloViewBindingSource.DataSource = typeof(DTOs.VoziloView);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(144, 25);
            label1.TabIndex = 7;
            label1.Text = "Vozila Jedinice";
            // 
            // VozilaJedinice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button3);
            Margin = new Padding(3, 2, 3, 2);
            Name = "VozilaJedinice";
            Text = "VozilaJedinice";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)voziloViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn registarskaOznakaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn proizvodjacDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lokacijaDataGridViewTextBoxColumn;
        private BindingSource voziloViewBindingSource;
        private Label label1;
    }
}