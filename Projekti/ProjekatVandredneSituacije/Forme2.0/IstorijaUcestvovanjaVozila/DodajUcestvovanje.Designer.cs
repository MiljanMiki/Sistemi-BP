namespace ProjekatVandredneSituacije.Forme2._0.IstorijaUcestvovanjaVozila
{
    partial class DodajUcestvovanje
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
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            buttonRst = new Button();
            buttonCnc = new Button();
            buttonSave = new Button();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(141, 158);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(168, 27);
            dateTimePicker2.TabIndex = 168;
            // 
            // label1
            // 
            label1.Location = new Point(22, 163);
            label1.Name = "label1";
            label1.Size = new Size(123, 22);
            label1.TabIndex = 167;
            label1.Text = "Datum Do";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(141, 115);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(168, 27);
            dateTimePicker1.TabIndex = 166;
            // 
            // label2
            // 
            label2.Location = new Point(22, 120);
            label2.Name = "label2";
            label2.Size = new Size(123, 22);
            label2.TabIndex = 165;
            label2.Text = "Datum Od";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonRst
            // 
            buttonRst.Location = new Point(113, 205);
            buttonRst.Name = "buttonRst";
            buttonRst.Size = new Size(103, 29);
            buttonRst.TabIndex = 162;
            buttonRst.Text = "Reset";
            buttonRst.UseVisualStyleBackColor = true;
            buttonRst.Click += buttonRst_Click;
            // 
            // buttonCnc
            // 
            buttonCnc.Location = new Point(212, 240);
            buttonCnc.Name = "buttonCnc";
            buttonCnc.Size = new Size(94, 29);
            buttonCnc.TabIndex = 161;
            buttonCnc.Text = "Odustani";
            buttonCnc.UseVisualStyleBackColor = true;
            buttonCnc.Click += buttonCnc_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(20, 240);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 160;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label3
            // 
            label3.Location = new Point(22, 77);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 159;
            label3.Text = "Vozilo";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(22, 39);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 158;
            label4.Text = "Intervencija";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(141, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(165, 28);
            comboBox1.TabIndex = 169;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(141, 74);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(168, 28);
            comboBox2.TabIndex = 170;
            // 
            // DodajUcestvovanje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 300);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(buttonRst);
            Controls.Add(buttonCnc);
            Controls.Add(buttonSave);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "DodajUcestvovanje";
            Text = "DodajUcestvovanje";
            Load += DodajUcestvovanje_Load;
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateTimePicker2;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Button buttonRst;
        private Button buttonCnc;
        private Button buttonSave;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}