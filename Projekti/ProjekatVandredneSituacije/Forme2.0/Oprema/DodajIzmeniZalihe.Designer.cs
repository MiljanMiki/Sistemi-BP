namespace ProjekatVandredneSituacije.Forme2._0.Oprema
{
    partial class DodajIzmeniZalihe
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
            textNaziv = new TextBox();
            comboStatus = new ComboBox();
            textSb = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboJed = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label6 = new Label();
            dateDatumNabavke = new DateTimePicker();
            comboTip = new ComboBox();
            label7 = new Label();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // textNaziv
            // 
            textNaziv.Location = new Point(133, 75);
            textNaziv.Name = "textNaziv";
            textNaziv.Size = new Size(167, 27);
            textNaziv.TabIndex = 104;
            // 
            // comboStatus
            // 
            comboStatus.FormattingEnabled = true;
            comboStatus.Location = new Point(133, 111);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(167, 28);
            comboStatus.TabIndex = 103;
            // 
            // textSb
            // 
            textSb.Location = new Point(133, 37);
            textSb.Name = "textSb";
            textSb.Size = new Size(167, 27);
            textSb.TabIndex = 102;
            // 
            // button3
            // 
            button3.Location = new Point(113, 311);
            button3.Name = "button3";
            button3.Size = new Size(95, 29);
            button3.TabIndex = 101;
            button3.Text = "Reset";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(205, 345);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 100;
            button2.Text = "Odustani";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(13, 345);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 99;
            button1.Text = "Sacuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.Location = new Point(14, 120);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 98;
            label5.Text = "Status";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(14, 82);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 97;
            label3.Text = "Naziv";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(14, 44);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 96;
            label4.Text = "Serijski Broj:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboJed
            // 
            comboJed.FormattingEnabled = true;
            comboJed.Location = new Point(132, 188);
            comboJed.Name = "comboJed";
            comboJed.Size = new Size(167, 28);
            comboJed.TabIndex = 107;
            // 
            // label1
            // 
            label1.Location = new Point(14, 191);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 106;
            label1.Text = "Jedinica";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(14, 153);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 105;
            label2.Text = "Datum Nabavke";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Location = new Point(14, 280);
            label6.Name = "label6";
            label6.Size = new Size(113, 20);
            label6.TabIndex = 109;
            label6.Text = "Kolicina";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateDatumNabavke
            // 
            dateDatumNabavke.Location = new Point(132, 148);
            dateDatumNabavke.Name = "dateDatumNabavke";
            dateDatumNabavke.Size = new Size(168, 27);
            dateDatumNabavke.TabIndex = 111;
            // 
            // comboTip
            // 
            comboTip.FormattingEnabled = true;
            comboTip.Location = new Point(132, 232);
            comboTip.Name = "comboTip";
            comboTip.Size = new Size(167, 28);
            comboTip.TabIndex = 113;
            comboTip.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.Location = new Point(14, 240);
            label7.Name = "label7";
            label7.Size = new Size(113, 20);
            label7.TabIndex = 114;
            label7.Text = "Tip";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(132, 278);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(168, 27);
            numericUpDown1.TabIndex = 115;
            // 
            // DodajIzmeniZalihe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 386);
            Controls.Add(numericUpDown1);
            Controls.Add(label7);
            Controls.Add(comboTip);
            Controls.Add(dateDatumNabavke);
            Controls.Add(label6);
            Controls.Add(comboJed);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textNaziv);
            Controls.Add(comboStatus);
            Controls.Add(textSb);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "DodajIzmeniZalihe";
            Text = "DodajIzmeniZalihe";
            Load += DodajIzmeniZalihe_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textNaziv;
        private ComboBox comboStatus;
        private TextBox textSb;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label5;
        private Label label3;
        private Label label4;
        private ComboBox comboJed;
        private Label label1;
        private Label label2;
        private Label label6;
        private DateTimePicker dateDatumNabavke;
        private ComboBox comboTip;
        private Label label7;
        private NumericUpDown numericUpDown1;
    }
}