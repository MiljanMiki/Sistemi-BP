namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    partial class DodajIzmeniSanitetska
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
            textLokacija = new TextBox();
            label1 = new Label();
            textPro = new TextBox();
            comboStatus = new ComboBox();
            textReg = new TextBox();
            buttonRst = new Button();
            buttonCnc = new Button();
            buttonSv = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textLokacija
            // 
            textLokacija.Location = new Point(160, 155);
            textLokacija.Name = "textLokacija";
            textLokacija.Size = new Size(167, 27);
            textLokacija.TabIndex = 117;
            // 
            // label1
            // 
            label1.Location = new Point(41, 155);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 116;
            label1.Text = "Lokacija";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textPro
            // 
            textPro.Location = new Point(160, 67);
            textPro.Name = "textPro";
            textPro.Size = new Size(167, 27);
            textPro.TabIndex = 115;
            // 
            // comboStatus
            // 
            comboStatus.FormattingEnabled = true;
            comboStatus.Location = new Point(160, 104);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(167, 28);
            comboStatus.TabIndex = 114;
            // 
            // textReg
            // 
            textReg.Location = new Point(160, 29);
            textReg.Name = "textReg";
            textReg.Size = new Size(167, 27);
            textReg.TabIndex = 113;
            // 
            // buttonRst
            // 
            buttonRst.Location = new Point(134, 209);
            buttonRst.Name = "buttonRst";
            buttonRst.Size = new Size(103, 32);
            buttonRst.TabIndex = 112;
            buttonRst.Text = "Reset";
            buttonRst.UseVisualStyleBackColor = true;
            // 
            // buttonCnc
            // 
            buttonCnc.Location = new Point(233, 244);
            buttonCnc.Name = "buttonCnc";
            buttonCnc.Size = new Size(94, 32);
            buttonCnc.TabIndex = 111;
            buttonCnc.Text = "Odustani";
            buttonCnc.UseVisualStyleBackColor = true;
            // 
            // buttonSv
            // 
            buttonSv.Location = new Point(41, 244);
            buttonSv.Name = "buttonSv";
            buttonSv.Size = new Size(94, 32);
            buttonSv.TabIndex = 110;
            buttonSv.Text = "Sacuvaj";
            buttonSv.UseVisualStyleBackColor = true;
            buttonSv.Click += buttonSv_Click;
            // 
            // label5
            // 
            label5.Location = new Point(41, 112);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 109;
            label5.Text = "Status";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(41, 74);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 108;
            label3.Text = "Proizvodjac";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(41, 36);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 107;
            label4.Text = "Reg. Oznaka:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DodajIzmeniSanitetska
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 319);
            Controls.Add(textLokacija);
            Controls.Add(label1);
            Controls.Add(textPro);
            Controls.Add(comboStatus);
            Controls.Add(textReg);
            Controls.Add(buttonRst);
            Controls.Add(buttonCnc);
            Controls.Add(buttonSv);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "DodajIzmeniSanitetska";
            Text = "DodajIzmeniSanitetska";
            Load += DodajIzmeniSanitetska_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textLokacija;
        private Label label1;
        private TextBox textPro;
        private ComboBox comboStatus;
        private TextBox textReg;
        private Button buttonRst;
        private Button buttonCnc;
        private Button buttonSv;
        private Label label5;
        private Label label3;
        private Label label4;
    }
}