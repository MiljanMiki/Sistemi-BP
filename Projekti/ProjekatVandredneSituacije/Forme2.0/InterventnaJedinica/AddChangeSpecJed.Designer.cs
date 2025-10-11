namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    partial class AddChangeSpecJed
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
            textBaza = new TextBox();
            comboKomandir = new ComboBox();
            textNaziv = new TextBox();
            buttonRst = new Button();
            buttonCnc = new Button();
            buttonSave = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            textTip = new TextBox();
            SuspendLayout();
            // 
            // textBaza
            // 
            textBaza.Location = new Point(162, 79);
            textBaza.Name = "textBaza";
            textBaza.Size = new Size(167, 27);
            textBaza.TabIndex = 104;
            // 
            // comboKomandir
            // 
            comboKomandir.FormattingEnabled = true;
            comboKomandir.Location = new Point(162, 116);
            comboKomandir.Name = "comboKomandir";
            comboKomandir.Size = new Size(167, 28);
            comboKomandir.TabIndex = 103;
            comboKomandir.SelectedIndexChanged += comboKomandir_SelectedIndexChanged;
            // 
            // textNaziv
            // 
            textNaziv.Location = new Point(162, 41);
            textNaziv.Name = "textNaziv";
            textNaziv.Size = new Size(167, 27);
            textNaziv.TabIndex = 102;
            // 
            // buttonRst
            // 
            buttonRst.Location = new Point(131, 219);
            buttonRst.Name = "buttonRst";
            buttonRst.Size = new Size(103, 32);
            buttonRst.TabIndex = 101;
            buttonRst.Text = "Reset";
            buttonRst.UseVisualStyleBackColor = true;
            buttonRst.Click += buttonRst_Click;
            // 
            // buttonCnc
            // 
            buttonCnc.Location = new Point(230, 253);
            buttonCnc.Name = "buttonCnc";
            buttonCnc.Size = new Size(94, 32);
            buttonCnc.TabIndex = 100;
            buttonCnc.Text = "Odustani";
            buttonCnc.UseVisualStyleBackColor = true;
            buttonCnc.Click += buttonCnc_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(38, 253);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 32);
            buttonSave.TabIndex = 99;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label5
            // 
            label5.Location = new Point(43, 124);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 98;
            label5.Text = "Komandir";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(43, 85);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 97;
            label3.Text = "Baza";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(43, 48);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 96;
            label4.Text = "Naziv:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Location = new Point(43, 160);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 105;
            label1.Text = "Tip";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textTip
            // 
            textTip.Location = new Point(162, 156);
            textTip.Name = "textTip";
            textTip.Size = new Size(167, 27);
            textTip.TabIndex = 106;
            // 
            // AddChangeSpecJed
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 324);
            Controls.Add(textTip);
            Controls.Add(label1);
            Controls.Add(textBaza);
            Controls.Add(comboKomandir);
            Controls.Add(textNaziv);
            Controls.Add(buttonRst);
            Controls.Add(buttonCnc);
            Controls.Add(buttonSave);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "AddChangeSpecJed";
            Text = "AddChangeSpecJed";
            Load += AddChangeSpecJed_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBaza;
        private ComboBox comboKomandir;
        private TextBox textNaziv;
        private Button buttonRst;
        private Button buttonCnc;
        private Button buttonSave;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label1;
        private TextBox textTip;
    }
}