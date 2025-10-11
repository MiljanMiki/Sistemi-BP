namespace ProjekatVandredneSituacije.Forme2._0.Sertifikat
{
    partial class DodajIzmeniSerttifikat
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
            dateIzdavanje = new DateTimePicker();
            label2 = new Label();
            textNaziv = new TextBox();
            textJMBG = new TextBox();
            buttonReset = new Button();
            buttonCancel = new Button();
            buttonSave = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            textInstitucija = new TextBox();
            dateVazenje = new DateTimePicker();
            label1 = new Label();
            SuspendLayout();
            // 
            // dateIzdavanje
            // 
            dateIzdavanje.Location = new Point(157, 137);
            dateIzdavanje.Name = "dateIzdavanje";
            dateIzdavanje.Size = new Size(168, 27);
            dateIzdavanje.TabIndex = 141;
            // 
            // label2
            // 
            label2.Location = new Point(38, 142);
            label2.Name = "label2";
            label2.Size = new Size(123, 22);
            label2.TabIndex = 136;
            label2.Text = "Datum Izdavanja";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textNaziv
            // 
            textNaziv.Location = new Point(158, 64);
            textNaziv.Name = "textNaziv";
            textNaziv.Size = new Size(167, 27);
            textNaziv.TabIndex = 135;
            // 
            // textJMBG
            // 
            textJMBG.Location = new Point(158, 26);
            textJMBG.Name = "textJMBG";
            textJMBG.Size = new Size(167, 27);
            textJMBG.TabIndex = 133;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(131, 215);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(103, 29);
            buttonReset.TabIndex = 132;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(230, 250);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 131;
            buttonCancel.Text = "Odustani";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(38, 250);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 130;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += button1_Click;
            // 
            // label5
            // 
            label5.Location = new Point(38, 109);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 129;
            label5.Text = "Institucija";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(38, 71);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 128;
            label3.Text = "Naziv";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(38, 33);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 127;
            label4.Text = "JMBG";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textInstitucija
            // 
            textInstitucija.Location = new Point(158, 102);
            textInstitucija.Name = "textInstitucija";
            textInstitucija.Size = new Size(167, 27);
            textInstitucija.TabIndex = 142;
            // 
            // dateVazenje
            // 
            dateVazenje.Location = new Point(156, 170);
            dateVazenje.Name = "dateVazenje";
            dateVazenje.Size = new Size(168, 27);
            dateVazenje.TabIndex = 144;
            // 
            // label1
            // 
            label1.Location = new Point(37, 175);
            label1.Name = "label1";
            label1.Size = new Size(123, 22);
            label1.TabIndex = 143;
            label1.Text = "Datum vazenja";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DodajIzmeniSerttifikat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 305);
            Controls.Add(dateVazenje);
            Controls.Add(label1);
            Controls.Add(textInstitucija);
            Controls.Add(dateIzdavanje);
            Controls.Add(label2);
            Controls.Add(textNaziv);
            Controls.Add(textJMBG);
            Controls.Add(buttonReset);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "DodajIzmeniSerttifikat";
            Text = "DodajIzmeniSerttifikat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateIzdavanje;
        private Label label2;
        private TextBox textNaziv;
        private TextBox textJMBG;
        private Button buttonReset;
        private Button buttonCancel;
        private Button buttonSave;
        private Label label5;
        private Label label3;
        private Label label4;
        private TextBox textInstitucija;
        private DateTimePicker dateVazenje;
        private Label label1;
    }
}