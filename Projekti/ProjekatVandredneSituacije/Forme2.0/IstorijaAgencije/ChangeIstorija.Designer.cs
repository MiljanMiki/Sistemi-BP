namespace ProjekatVandredneSituacije.Forme2._0.IstorijaAgencije
{
    partial class ChangeIstorija
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
            dateDatumDo = new DateTimePicker();
            label1 = new Label();
            dateDatumOf = new DateTimePicker();
            label2 = new Label();
            textJmbg = new TextBox();
            buttonReset = new Button();
            buttonOdustani = new Button();
            buttonSacuvaj = new Button();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // dateDatumDo
            // 
            dateDatumDo.CustomFormat = "";
            dateDatumDo.Format = DateTimePickerFormat.Short;
            dateDatumDo.Location = new Point(164, 140);
            dateDatumDo.Name = "dateDatumDo";
            dateDatumDo.Size = new Size(168, 27);
            dateDatumDo.TabIndex = 157;
            // 
            // label1
            // 
            label1.Location = new Point(45, 145);
            label1.Name = "label1";
            label1.Size = new Size(123, 22);
            label1.TabIndex = 156;
            label1.Text = "Datum Do";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateDatumOf
            // 
            dateDatumOf.Format = DateTimePickerFormat.Short;
            dateDatumOf.Location = new Point(164, 97);
            dateDatumOf.Name = "dateDatumOf";
            dateDatumOf.Size = new Size(168, 27);
            dateDatumOf.TabIndex = 154;
            // 
            // label2
            // 
            label2.Location = new Point(45, 102);
            label2.Name = "label2";
            label2.Size = new Size(123, 22);
            label2.TabIndex = 153;
            label2.Text = "Datum Od";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textJmbg
            // 
            textJmbg.Location = new Point(165, 14);
            textJmbg.Name = "textJmbg";
            textJmbg.Size = new Size(167, 27);
            textJmbg.TabIndex = 151;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(136, 187);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(103, 29);
            buttonReset.TabIndex = 150;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonOdustani
            // 
            buttonOdustani.Location = new Point(235, 222);
            buttonOdustani.Name = "buttonOdustani";
            buttonOdustani.Size = new Size(94, 29);
            buttonOdustani.TabIndex = 149;
            buttonOdustani.Text = "Odustani";
            buttonOdustani.UseVisualStyleBackColor = true;
            buttonOdustani.Click += buttonOdustani_Click;
            // 
            // buttonSacuvaj
            // 
            buttonSacuvaj.Location = new Point(43, 222);
            buttonSacuvaj.Name = "buttonSacuvaj";
            buttonSacuvaj.Size = new Size(94, 29);
            buttonSacuvaj.TabIndex = 148;
            buttonSacuvaj.Text = "Sacuvaj";
            buttonSacuvaj.UseVisualStyleBackColor = true;
            buttonSacuvaj.Click += buttonSacuvaj_Click;
            // 
            // label3
            // 
            label3.Location = new Point(45, 59);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 146;
            label3.Text = "Uloga";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(45, 21);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 145;
            label4.Text = "JMBG";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Operativni Radnik", "Koordinator", "Analiticar" });
            comboBox1.Location = new Point(164, 56);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(168, 28);
            comboBox1.TabIndex = 158;
            // 
            // ChangeIstorija
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 292);
            Controls.Add(comboBox1);
            Controls.Add(dateDatumDo);
            Controls.Add(label1);
            Controls.Add(dateDatumOf);
            Controls.Add(label2);
            Controls.Add(textJmbg);
            Controls.Add(buttonReset);
            Controls.Add(buttonOdustani);
            Controls.Add(buttonSacuvaj);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "ChangeIstorija";
            Text = "ChangeIstorija";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateDatumDo;
        private Label label1;
        private DateTimePicker dateDatumOf;
        private Label label2;
        private TextBox textJmbg;
        private Button buttonReset;
        private Button buttonOdustani;
        private Button buttonSacuvaj;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
    }
}