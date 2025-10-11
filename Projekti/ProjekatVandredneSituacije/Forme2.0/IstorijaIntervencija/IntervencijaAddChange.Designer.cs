namespace ProjekatVandredneSituacije.Forme2._0.IstorijaIntervencija
{
    partial class IntervencijaAddChange
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
            label1 = new Label();
            numericPovredjeni = new NumericUpDown();
            dateDatumVreme = new DateTimePicker();
            textResursi = new TextBox();
            textLokacija = new TextBox();
            buttonRst = new Button();
            buttonCancel = new Button();
            buttonSave = new Button();
            label9 = new Label();
            label8 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            comboStatus = new ComboBox();
            numericSpaseni = new NumericUpDown();
            numericUspesnost = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericPovredjeni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSpaseni).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUspesnost).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(22, 222);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 118;
            label1.Text = "Broj Povredjenih";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericPovredjeni
            // 
            numericPovredjeni.Location = new Point(137, 223);
            numericPovredjeni.Margin = new Padding(3, 2, 3, 2);
            numericPovredjeni.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericPovredjeni.Name = "numericPovredjeni";
            numericPovredjeni.Size = new Size(146, 23);
            numericPovredjeni.TabIndex = 117;
            // 
            // dateDatumVreme
            // 
            dateDatumVreme.Location = new Point(137, 9);
            dateDatumVreme.Margin = new Padding(3, 2, 3, 2);
            dateDatumVreme.Name = "dateDatumVreme";
            dateDatumVreme.Size = new Size(147, 23);
            dateDatumVreme.TabIndex = 113;
            // 
            // textResursi
            // 
            textResursi.Location = new Point(137, 112);
            textResursi.Margin = new Padding(3, 2, 3, 2);
            textResursi.Multiline = true;
            textResursi.Name = "textResursi";
            textResursi.Size = new Size(147, 68);
            textResursi.TabIndex = 112;
            // 
            // textLokacija
            // 
            textLokacija.Location = new Point(137, 40);
            textLokacija.Margin = new Padding(3, 2, 3, 2);
            textLokacija.Name = "textLokacija";
            textLokacija.Size = new Size(147, 23);
            textLokacija.TabIndex = 110;
            // 
            // buttonRst
            // 
            buttonRst.Location = new Point(110, 287);
            buttonRst.Margin = new Padding(3, 2, 3, 2);
            buttonRst.Name = "buttonRst";
            buttonRst.Size = new Size(90, 22);
            buttonRst.TabIndex = 109;
            buttonRst.Text = "Reset";
            buttonRst.UseVisualStyleBackColor = true;
            buttonRst.Click += buttonRst_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(201, 306);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(82, 22);
            buttonCancel.TabIndex = 108;
            buttonCancel.Text = "Odustani";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(22, 306);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(82, 22);
            buttonSave.TabIndex = 107;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click_1;
            // 
            // label9
            // 
            label9.Location = new Point(22, 191);
            label9.Name = "label9";
            label9.Size = new Size(108, 15);
            label9.TabIndex = 106;
            label9.Text = "Broj Spasenih";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Location = new Point(22, 114);
            label8.Name = "label8";
            label8.Size = new Size(109, 15);
            label8.TabIndex = 105;
            label8.Text = "Resursi";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(22, 256);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 103;
            label5.Text = "Uspesnost";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(22, 74);
            label3.Name = "label3";
            label3.Size = new Size(110, 19);
            label3.TabIndex = 102;
            label3.Text = "Status";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(22, 14);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 101;
            label2.Text = "Datum i Vreme:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(22, 46);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 100;
            label4.Text = "Lokacija";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboStatus
            // 
            comboStatus.FormattingEnabled = true;
            comboStatus.Items.AddRange(new object[] { "U_toku", "Zavrsena" });
            comboStatus.Location = new Point(137, 72);
            comboStatus.Margin = new Padding(3, 2, 3, 2);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(147, 23);
            comboStatus.TabIndex = 119;
            // 
            // numericSpaseni
            // 
            numericSpaseni.Location = new Point(137, 191);
            numericSpaseni.Margin = new Padding(3, 2, 3, 2);
            numericSpaseni.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericSpaseni.Name = "numericSpaseni";
            numericSpaseni.Size = new Size(146, 23);
            numericSpaseni.TabIndex = 124;
            // 
            // numericUspesnost
            // 
            numericUspesnost.Location = new Point(137, 251);
            numericUspesnost.Margin = new Padding(3, 2, 3, 2);
            numericUspesnost.Name = "numericUspesnost";
            numericUspesnost.Size = new Size(146, 23);
            numericUspesnost.TabIndex = 125;
            // 
            // IntervencijaAddChange
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 347);
            Controls.Add(numericUspesnost);
            Controls.Add(numericSpaseni);
            Controls.Add(comboStatus);
            Controls.Add(label1);
            Controls.Add(numericPovredjeni);
            Controls.Add(dateDatumVreme);
            Controls.Add(textResursi);
            Controls.Add(textLokacija);
            Controls.Add(buttonRst);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Margin = new Padding(3, 2, 3, 2);
            Name = "IntervencijaAddChange";
            Text = "IntervencijaAddChange";
            Load += IntervencijaAddChange_Load;
            ((System.ComponentModel.ISupportInitialize)numericPovredjeni).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSpaseni).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUspesnost).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numericPovredjeni;
        private DateTimePicker dateDatumVreme;
        private TextBox textResursi;
        private TextBox textLokacija;
        private Button buttonRst;
        private Button buttonCancel;
        private Button buttonSave;
        private Label label9;
        private Label label8;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label4;
        private ComboBox comboStatus;
        private NumericUpDown numericSpaseni;
        private NumericUpDown numericUspesnost;
    }
}