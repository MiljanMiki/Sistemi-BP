namespace ProjekatVandredneSituacije.Forme2._0.Prijava
{
    partial class PrijavaAddChange
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
            textIme = new TextBox();
            dateDatumVreme = new DateTimePicker();
            textOpis = new TextBox();
            textLokacija = new TextBox();
            textTip = new TextBox();
            buttonRst = new Button();
            buttonCancel = new Button();
            buttonSave = new Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            textKontakt = new TextBox();
            textDispecer = new TextBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // textIme
            // 
            textIme.Location = new Point(149, 81);
            textIme.Margin = new Padding(3, 2, 3, 2);
            textIme.Name = "textIme";
            textIme.Size = new Size(147, 23);
            textIme.TabIndex = 95;
            textIme.TextChanged += textBox1_TextChanged;
            // 
            // dateDatumVreme
            // 
            dateDatumVreme.Location = new Point(149, 17);
            dateDatumVreme.Margin = new Padding(3, 2, 3, 2);
            dateDatumVreme.Name = "dateDatumVreme";
            dateDatumVreme.Size = new Size(147, 23);
            dateDatumVreme.TabIndex = 94;
            // 
            // textOpis
            // 
            textOpis.Location = new Point(149, 187);
            textOpis.Margin = new Padding(3, 2, 3, 2);
            textOpis.Multiline = true;
            textOpis.Name = "textOpis";
            textOpis.Size = new Size(147, 68);
            textOpis.TabIndex = 92;
            // 
            // textLokacija
            // 
            textLokacija.Location = new Point(149, 151);
            textLokacija.Margin = new Padding(3, 2, 3, 2);
            textLokacija.Name = "textLokacija";
            textLokacija.Size = new Size(147, 23);
            textLokacija.TabIndex = 90;
            // 
            // textTip
            // 
            textTip.Location = new Point(149, 49);
            textTip.Margin = new Padding(3, 2, 3, 2);
            textTip.Name = "textTip";
            textTip.Size = new Size(147, 23);
            textTip.TabIndex = 88;
            // 
            // buttonRst
            // 
            buttonRst.Location = new Point(132, 335);
            buttonRst.Margin = new Padding(3, 2, 3, 2);
            buttonRst.Name = "buttonRst";
            buttonRst.Size = new Size(90, 22);
            buttonRst.TabIndex = 87;
            buttonRst.Text = "Reset";
            buttonRst.UseVisualStyleBackColor = true;
            buttonRst.Click += buttonRst_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(225, 356);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(82, 22);
            buttonCancel.TabIndex = 86;
            buttonCancel.Text = "Odustani";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(45, 356);
            buttonSave.Margin = new Padding(3, 2, 3, 2);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(82, 22);
            buttonSave.TabIndex = 85;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(45, 273);
            label9.Name = "label9";
            label9.Size = new Size(88, 15);
            label9.TabIndex = 84;
            label9.Text = "JMBGDIspecera";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.Location = new Point(45, 187);
            label8.Name = "label8";
            label8.Size = new Size(99, 15);
            label8.TabIndex = 83;
            label8.Text = "Opis";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Location = new Point(45, 153);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 82;
            label7.Text = "Lokacija";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(45, 119);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 80;
            label5.Text = "Kontakt";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(45, 86);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 79;
            label3.Text = "Ime Prijavioca";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(45, 22);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 78;
            label2.Text = "Datum i Vreme:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(45, 54);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 76;
            label4.Text = "Tip:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textKontakt
            // 
            textKontakt.Location = new Point(149, 117);
            textKontakt.Margin = new Padding(3, 2, 3, 2);
            textKontakt.Name = "textKontakt";
            textKontakt.Size = new Size(147, 23);
            textKontakt.TabIndex = 96;
            // 
            // textDispecer
            // 
            textDispecer.Location = new Point(149, 273);
            textDispecer.Margin = new Padding(3, 2, 3, 2);
            textDispecer.MaxLength = 13;
            textDispecer.Name = "textDispecer";
            textDispecer.Size = new Size(147, 23);
            textDispecer.TabIndex = 97;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(149, 310);
            numericUpDown1.Margin = new Padding(3, 2, 3, 2);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(146, 23);
            numericUpDown1.TabIndex = 98;
            // 
            // label1
            // 
            label1.Location = new Point(45, 310);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 99;
            label1.Text = "Prioritet";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PrijavaAddChange
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 397);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(textDispecer);
            Controls.Add(textKontakt);
            Controls.Add(textIme);
            Controls.Add(dateDatumVreme);
            Controls.Add(textOpis);
            Controls.Add(textLokacija);
            Controls.Add(textTip);
            Controls.Add(buttonRst);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PrijavaAddChange";
            Text = "PrijavaAddChange";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textIme;
        private DateTimePicker dateDatumVreme;
        private TextBox textOpis;
        private TextBox textLokacija;
        private TextBox textTip;
        private Button buttonRst;
        private Button buttonCancel;
        private Button buttonSave;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox textKontakt;
        private TextBox textDispecer;
        private NumericUpDown numericUpDown1;
        private Label label1;
    }
}