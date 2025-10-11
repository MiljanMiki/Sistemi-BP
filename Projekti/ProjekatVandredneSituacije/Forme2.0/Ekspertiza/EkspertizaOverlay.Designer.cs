namespace ProjekatVandredneSituacije.Forme2._0.Ekspertiza
{
    partial class EkspertizaOverlay
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
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            imeAnaliticaraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prezimeAnaliticaraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jMBGAnaliticaraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            oblastDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ekspertizaViewBindingSource = new BindingSource(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ekspertizaViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // buttonObrisiO
            // 
            buttonObrisiO.Location = new Point(1022, 11);
            buttonObrisiO.Margin = new Padding(3, 2, 3, 2);
            buttonObrisiO.Name = "buttonObrisiO";
            buttonObrisiO.Size = new Size(150, 30);
            buttonObrisiO.TabIndex = 20;
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
            buttonIzmeniO.TabIndex = 19;
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
            buttonDodajOp.TabIndex = 18;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, imeAnaliticaraDataGridViewTextBoxColumn, prezimeAnaliticaraDataGridViewTextBoxColumn, jMBGAnaliticaraDataGridViewTextBoxColumn, oblastDataGridViewTextBoxColumn });
            dataGridView1.DataSource = ekspertizaViewBindingSource;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 605);
            dataGridView1.TabIndex = 21;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // imeAnaliticaraDataGridViewTextBoxColumn
            // 
            imeAnaliticaraDataGridViewTextBoxColumn.DataPropertyName = "ImeAnaliticara";
            imeAnaliticaraDataGridViewTextBoxColumn.HeaderText = "ImeAnaliticara";
            imeAnaliticaraDataGridViewTextBoxColumn.MinimumWidth = 6;
            imeAnaliticaraDataGridViewTextBoxColumn.Name = "imeAnaliticaraDataGridViewTextBoxColumn";
            // 
            // prezimeAnaliticaraDataGridViewTextBoxColumn
            // 
            prezimeAnaliticaraDataGridViewTextBoxColumn.DataPropertyName = "PrezimeAnaliticara";
            prezimeAnaliticaraDataGridViewTextBoxColumn.HeaderText = "PrezimeAnaliticara";
            prezimeAnaliticaraDataGridViewTextBoxColumn.MinimumWidth = 6;
            prezimeAnaliticaraDataGridViewTextBoxColumn.Name = "prezimeAnaliticaraDataGridViewTextBoxColumn";
            // 
            // jMBGAnaliticaraDataGridViewTextBoxColumn
            // 
            jMBGAnaliticaraDataGridViewTextBoxColumn.DataPropertyName = "JMBGAnaliticara";
            jMBGAnaliticaraDataGridViewTextBoxColumn.HeaderText = "JMBGAnaliticara";
            jMBGAnaliticaraDataGridViewTextBoxColumn.MinimumWidth = 6;
            jMBGAnaliticaraDataGridViewTextBoxColumn.Name = "jMBGAnaliticaraDataGridViewTextBoxColumn";
            // 
            // oblastDataGridViewTextBoxColumn
            // 
            oblastDataGridViewTextBoxColumn.DataPropertyName = "Oblast";
            oblastDataGridViewTextBoxColumn.HeaderText = "Oblast";
            oblastDataGridViewTextBoxColumn.MinimumWidth = 6;
            oblastDataGridViewTextBoxColumn.Name = "oblastDataGridViewTextBoxColumn";
            // 
            // ekspertizaViewBindingSource
            // 
            ekspertizaViewBindingSource.DataSource = typeof(DTOs.EkspertizaView);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 22;
            label1.Text = "Ekspertize";
            // 
            // EkspertizaOverlay
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
            Name = "EkspertizaOverlay";
            Text = "EkspertizaOverlay";
            Load += EkspertizaOverlay_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ekspertizaViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonObrisiO;
        private Button buttonIzmeniO;
        private Button buttonDodajOp;
        private DataGridView dataGridView1;
        private BindingSource ekspertizaViewBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn imeAnaliticaraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prezimeAnaliticaraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jMBGAnaliticaraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn oblastDataGridViewTextBoxColumn;
        private Label label1;
    }
}