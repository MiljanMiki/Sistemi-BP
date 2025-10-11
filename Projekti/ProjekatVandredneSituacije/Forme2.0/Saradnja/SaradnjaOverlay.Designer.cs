namespace ProjekatVandredneSituacije.Forme2._0.Saradnja
{
    partial class SaradnjaOverlay
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
            button19 = new Button();
            button20 = new Button();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sektorIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nazivSluzbeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            vanrednaSituacijaIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tipVsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ulogaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            saradjujeGetViewBindingSource = new BindingSource(components);
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saradjujeGetViewBindingSource).BeginInit();
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
            // button19
            // 
            button19.Location = new Point(866, 11);
            button19.Margin = new Padding(3, 2, 3, 2);
            button19.Name = "button19";
            button19.Size = new Size(150, 30);
            button19.TabIndex = 28;
            button19.Text = "Izmeni";
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click;
            // 
            // button20
            // 
            button20.Location = new Point(710, 11);
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, sektorIDDataGridViewTextBoxColumn, nazivSluzbeDataGridViewTextBoxColumn, vanrednaSituacijaIDDataGridViewTextBoxColumn, tipVsDataGridViewTextBoxColumn, ulogaDataGridViewTextBoxColumn });
            dataGridView1.DataSource = saradjujeGetViewBindingSource;
            dataGridView1.Location = new Point(12, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 603);
            dataGridView1.TabIndex = 30;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // sektorIDDataGridViewTextBoxColumn
            // 
            sektorIDDataGridViewTextBoxColumn.DataPropertyName = "SektorID";
            sektorIDDataGridViewTextBoxColumn.HeaderText = "SektorID";
            sektorIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            sektorIDDataGridViewTextBoxColumn.Name = "sektorIDDataGridViewTextBoxColumn";
            // 
            // nazivSluzbeDataGridViewTextBoxColumn
            // 
            nazivSluzbeDataGridViewTextBoxColumn.DataPropertyName = "NazivSluzbe";
            nazivSluzbeDataGridViewTextBoxColumn.HeaderText = "NazivSluzbe";
            nazivSluzbeDataGridViewTextBoxColumn.MinimumWidth = 6;
            nazivSluzbeDataGridViewTextBoxColumn.Name = "nazivSluzbeDataGridViewTextBoxColumn";
            // 
            // vanrednaSituacijaIDDataGridViewTextBoxColumn
            // 
            vanrednaSituacijaIDDataGridViewTextBoxColumn.DataPropertyName = "VanrednaSituacijaID";
            vanrednaSituacijaIDDataGridViewTextBoxColumn.HeaderText = "VanrednaSituacijaID";
            vanrednaSituacijaIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            vanrednaSituacijaIDDataGridViewTextBoxColumn.Name = "vanrednaSituacijaIDDataGridViewTextBoxColumn";
            // 
            // tipVsDataGridViewTextBoxColumn
            // 
            tipVsDataGridViewTextBoxColumn.DataPropertyName = "TipVs";
            tipVsDataGridViewTextBoxColumn.HeaderText = "TipVs";
            tipVsDataGridViewTextBoxColumn.MinimumWidth = 6;
            tipVsDataGridViewTextBoxColumn.Name = "tipVsDataGridViewTextBoxColumn";
            // 
            // ulogaDataGridViewTextBoxColumn
            // 
            ulogaDataGridViewTextBoxColumn.DataPropertyName = "Uloga";
            ulogaDataGridViewTextBoxColumn.HeaderText = "Uloga";
            ulogaDataGridViewTextBoxColumn.MinimumWidth = 6;
            ulogaDataGridViewTextBoxColumn.Name = "ulogaDataGridViewTextBoxColumn";
            // 
            // saradjujeGetViewBindingSource
            // 
            saradjujeGetViewBindingSource.DataSource = typeof(DTOs.SaradjujeGetView);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 31;
            label1.Text = "Saradnje";
            // 
            // SaradnjaOverlay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1184, 661);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button18);
            Controls.Add(button19);
            Controls.Add(button20);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SaradnjaOverlay";
            Text = "SaradnjaOverlay";
            WindowState = FormWindowState.Maximized;
            Load += SaradnjaOverlay_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)saradjujeGetViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button18;
        private Button button19;
        private Button button20;
        private DataGridView dataGridView1;
        private Label label1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sektorIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nazivSluzbeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn vanrednaSituacijaIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tipVsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ulogaDataGridViewTextBoxColumn;
        private BindingSource saradjujeGetViewBindingSource;
    }
}