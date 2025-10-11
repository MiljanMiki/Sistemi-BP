namespace ProjekatVandredneSituacije.Forme2._0.Sertifikat
{
    partial class SertifikatOverlay
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
            dataGridView1 = new DataGridView();
            sertifikatIdAddViewBindingSource = new BindingSource(components);
            sertifikatViewBindingSource = new BindingSource(components);
            buttonObrisiO = new Button();
            buttonIzmeniO = new Button();
            buttonDodajOp = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sertifikatIdAddViewBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sertifikatViewBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 605);
            dataGridView1.TabIndex = 17;
            // 
            // sertifikatIdAddViewBindingSource
            // 
            sertifikatIdAddViewBindingSource.DataSource = typeof(DTOs.SertifikatIdAddView);
            // 
            // sertifikatViewBindingSource
            // 
            sertifikatViewBindingSource.DataSource = typeof(DTOs.SertifikatView);
            // 
            // buttonObrisiO
            // 
            buttonObrisiO.Location = new Point(1022, 11);
            buttonObrisiO.Margin = new Padding(3, 2, 3, 2);
            buttonObrisiO.Name = "buttonObrisiO";
            buttonObrisiO.Size = new Size(150, 30);
            buttonObrisiO.TabIndex = 16;
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
            buttonIzmeniO.TabIndex = 15;
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
            buttonDodajOp.TabIndex = 14;
            buttonDodajOp.Text = "Dodaj";
            buttonDodajOp.UseVisualStyleBackColor = true;
            buttonDodajOp.Click += buttonDodajOp_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(99, 25);
            label1.TabIndex = 18;
            label1.Text = "Sertifikati";
            // 
            // SertifikatOverlay
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
            Name = "SertifikatOverlay";
            Text = "SertifikatOverlay";
            Load += SertifikatOverlay_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)sertifikatIdAddViewBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)sertifikatViewBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonObrisiO;
        private Button buttonIzmeniO;
        private Button buttonDodajOp;
        private BindingSource sertifikatViewBindingSource;
        private Label label1;
        private BindingSource sertifikatIdAddViewBindingSource;
    }
}