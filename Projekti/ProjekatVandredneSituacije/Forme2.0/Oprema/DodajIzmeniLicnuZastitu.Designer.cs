namespace ProjekatVandredneSituacije.Forme2._0.Oprema
{
    partial class DodajIzmeniLicnuZastitu
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
            dateNabavka = new DateTimePicker();
            comboTip = new ComboBox();
            label6 = new Label();
            comboJedinica = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textNaziv = new TextBox();
            comboStatus = new ComboBox();
            textSb = new TextBox();
            buttonRst = new Button();
            buttonCancel = new Button();
            buttonSave = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // dateNabavka
            // 
            dateNabavka.Location = new Point(136, 132);
            dateNabavka.Name = "dateNabavka";
            dateNabavka.Size = new Size(168, 27);
            dateNabavka.TabIndex = 126;
            // 
            // comboTip
            // 
            comboTip.FormattingEnabled = true;
            comboTip.Location = new Point(136, 215);
            comboTip.Name = "comboTip";
            comboTip.Size = new Size(167, 28);
            comboTip.TabIndex = 125;
            // 
            // label6
            // 
            label6.Location = new Point(18, 218);
            label6.Name = "label6";
            label6.Size = new Size(113, 20);
            label6.TabIndex = 124;
            label6.Text = "Tip";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboJedinica
            // 
            comboJedinica.FormattingEnabled = true;
            comboJedinica.Location = new Point(136, 172);
            comboJedinica.Name = "comboJedinica";
            comboJedinica.Size = new Size(167, 28);
            comboJedinica.TabIndex = 123;
            // 
            // label1
            // 
            label1.Location = new Point(18, 175);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 122;
            label1.Text = "Jedinica";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(18, 137);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 121;
            label2.Text = "Datum Nabavke";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textNaziv
            // 
            textNaziv.Location = new Point(137, 59);
            textNaziv.Name = "textNaziv";
            textNaziv.Size = new Size(167, 27);
            textNaziv.TabIndex = 120;
            // 
            // comboStatus
            // 
            comboStatus.FormattingEnabled = true;
            comboStatus.Location = new Point(137, 96);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(167, 28);
            comboStatus.TabIndex = 119;
            // 
            // textSb
            // 
            textSb.Location = new Point(137, 21);
            textSb.Name = "textSb";
            textSb.Size = new Size(167, 27);
            textSb.TabIndex = 118;
            // 
            // buttonRst
            // 
            buttonRst.Location = new Point(110, 273);
            buttonRst.Name = "buttonRst";
            buttonRst.Size = new Size(103, 29);
            buttonRst.TabIndex = 117;
            buttonRst.Text = "Reset";
            buttonRst.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(209, 308);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 116;
            buttonCancel.Text = "Odustani";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(17, 308);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 115;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label5
            // 
            label5.Location = new Point(18, 104);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 114;
            label5.Text = "Status";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(18, 66);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 113;
            label3.Text = "Naziv";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(18, 28);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 112;
            label4.Text = "Serijski Broj:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DodajIzmeniLicnuZastitu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 368);
            Controls.Add(dateNabavka);
            Controls.Add(comboTip);
            Controls.Add(label6);
            Controls.Add(comboJedinica);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textNaziv);
            Controls.Add(comboStatus);
            Controls.Add(textSb);
            Controls.Add(buttonRst);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "DodajIzmeniLicnuZastitu";
            Text = "DodajIzmeniLicnuZastitu";
            Load += DodajIzmeniLicnuZastitu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateNabavka;
        private ComboBox comboTip;
        private Label label6;
        private ComboBox comboJedinica;
        private Label label1;
        private Label label2;
        private TextBox textNaziv;
        private ComboBox comboStatus;
        private TextBox textSb;
        private Button buttonRst;
        private Button buttonCancel;
        private Button buttonSave;
        private Label label5;
        private Label label3;
        private Label label4;
    }
}