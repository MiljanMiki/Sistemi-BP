namespace ProjekatVandredneSituacije.Forme2._0.Oprema
{
    partial class DodajIzmeniMedicinsku
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
            dateNabavke = new DateTimePicker();
            comboTip = new ComboBox();
            label6 = new Label();
            comboJedinice = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textNaziv = new TextBox();
            comboStatus = new ComboBox();
            textSb = new TextBox();
            buttonRst = new Button();
            buttonCnc = new Button();
            buttonSave = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // dateNabavke
            // 
            dateNabavke.Location = new Point(126, 153);
            dateNabavke.Name = "dateNabavke";
            dateNabavke.Size = new Size(168, 27);
            dateNabavke.TabIndex = 126;
            // 
            // comboTip
            // 
            comboTip.FormattingEnabled = true;
            comboTip.Location = new Point(126, 236);
            comboTip.Name = "comboTip";
            comboTip.Size = new Size(167, 28);
            comboTip.TabIndex = 125;
            // 
            // label6
            // 
            label6.Location = new Point(8, 239);
            label6.Name = "label6";
            label6.Size = new Size(113, 20);
            label6.TabIndex = 124;
            label6.Text = "Tip";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboJedinice
            // 
            comboJedinice.FormattingEnabled = true;
            comboJedinice.Location = new Point(126, 193);
            comboJedinice.Name = "comboJedinice";
            comboJedinice.Size = new Size(167, 28);
            comboJedinice.TabIndex = 123;
            // 
            // label1
            // 
            label1.Location = new Point(8, 196);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 122;
            label1.Text = "Jedinica";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(8, 158);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 121;
            label2.Text = "Datum Nabavke";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textNaziv
            // 
            textNaziv.Location = new Point(127, 80);
            textNaziv.Name = "textNaziv";
            textNaziv.Size = new Size(167, 27);
            textNaziv.TabIndex = 120;
            // 
            // comboStatus
            // 
            comboStatus.FormattingEnabled = true;
            comboStatus.Location = new Point(127, 117);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(167, 28);
            comboStatus.TabIndex = 119;
            // 
            // textSb
            // 
            textSb.Location = new Point(127, 42);
            textSb.Name = "textSb";
            textSb.Size = new Size(167, 27);
            textSb.TabIndex = 118;
            // 
            // buttonRst
            // 
            buttonRst.Location = new Point(100, 294);
            buttonRst.Name = "buttonRst";
            buttonRst.Size = new Size(103, 29);
            buttonRst.TabIndex = 117;
            buttonRst.Text = "Reset";
            buttonRst.UseVisualStyleBackColor = true;
            buttonRst.Click += buttonRst_Click;
            // 
            // buttonCnc
            // 
            buttonCnc.Location = new Point(199, 329);
            buttonCnc.Name = "buttonCnc";
            buttonCnc.Size = new Size(94, 29);
            buttonCnc.TabIndex = 116;
            buttonCnc.Text = "Odustani";
            buttonCnc.UseVisualStyleBackColor = true;
            buttonCnc.Click += buttonCnc_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(7, 329);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 115;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label5
            // 
            label5.Location = new Point(8, 125);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 114;
            label5.Text = "Status";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(8, 87);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 113;
            label3.Text = "Naziv";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(8, 49);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 112;
            label4.Text = "Serijski Broj:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DodajIzmeniMedicinsku
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 378);
            Controls.Add(dateNabavke);
            Controls.Add(comboTip);
            Controls.Add(label6);
            Controls.Add(comboJedinice);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(textNaziv);
            Controls.Add(comboStatus);
            Controls.Add(textSb);
            Controls.Add(buttonRst);
            Controls.Add(buttonCnc);
            Controls.Add(buttonSave);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "DodajIzmeniMedicinsku";
            Text = "DodajIzmeniMedicinsku";
            Load += DodajIzmeniMedicinsku_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateNabavke;
        private ComboBox comboTip;
        private Label label6;
        private ComboBox comboJedinice;
        private Label label1;
        private Label label2;
        private TextBox textNaziv;
        private ComboBox comboStatus;
        private TextBox textSb;
        private Button buttonRst;
        private Button buttonCnc;
        private Button buttonSave;
        private Label label5;
        private Label label3;
        private Label label4;
    }
}