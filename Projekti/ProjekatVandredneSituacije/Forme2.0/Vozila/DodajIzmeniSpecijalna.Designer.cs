namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    partial class DodajIzmeniSpecijalna
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
            buttonCancel = new Button();
            buttonSave = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboTip = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // textLokacija
            // 
            textLokacija.Location = new Point(149, 161);
            textLokacija.Name = "textLokacija";
            textLokacija.Size = new Size(167, 27);
            textLokacija.TabIndex = 128;
            // 
            // label1
            // 
            label1.Location = new Point(30, 161);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 127;
            label1.Text = "Lokacija";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textPro
            // 
            textPro.Location = new Point(149, 73);
            textPro.Name = "textPro";
            textPro.Size = new Size(167, 27);
            textPro.TabIndex = 126;
            // 
            // comboStatus
            // 
            comboStatus.FormattingEnabled = true;
            comboStatus.Location = new Point(149, 110);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(167, 28);
            comboStatus.TabIndex = 125;
            comboStatus.SelectedIndexChanged += comboStatus_SelectedIndexChanged;
            // 
            // textReg
            // 
            textReg.Location = new Point(149, 35);
            textReg.Name = "textReg";
            textReg.Size = new Size(167, 27);
            textReg.TabIndex = 124;
            // 
            // buttonRst
            // 
            buttonRst.Location = new Point(123, 261);
            buttonRst.Name = "buttonRst";
            buttonRst.Size = new Size(103, 32);
            buttonRst.TabIndex = 123;
            buttonRst.Text = "Reset";
            buttonRst.UseVisualStyleBackColor = true;
            buttonRst.Click += buttonRst_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(222, 296);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 32);
            buttonCancel.TabIndex = 122;
            buttonCancel.Text = "Odustani";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(30, 296);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 32);
            buttonSave.TabIndex = 121;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label5
            // 
            label5.Location = new Point(30, 118);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 120;
            label5.Text = "Status";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(30, 80);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 119;
            label3.Text = "Proizvodjac";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(30, 42);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 118;
            label4.Text = "Reg. Oznaka:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboTip
            // 
            comboTip.FormattingEnabled = true;
            comboTip.Location = new Point(149, 204);
            comboTip.Name = "comboTip";
            comboTip.Size = new Size(167, 28);
            comboTip.TabIndex = 130;
            // 
            // label2
            // 
            label2.Location = new Point(30, 212);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 129;
            label2.Text = "TIp";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DodajIzmeniSpecijalna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 388);
            Controls.Add(comboTip);
            Controls.Add(label2);
            Controls.Add(textLokacija);
            Controls.Add(label1);
            Controls.Add(textPro);
            Controls.Add(comboStatus);
            Controls.Add(textReg);
            Controls.Add(buttonRst);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "DodajIzmeniSpecijalna";
            Text = "DodajIzmeniSpecijalna";
            Load += DodajIzmeniSpecijalna_Load;
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
        private Button buttonCancel;
        private Button buttonSave;
        private Label label5;
        private Label label3;
        private Label label4;
        private ComboBox comboTip;
        private Label label2;
    }
}