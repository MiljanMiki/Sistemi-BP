namespace ProjekatVandredneSituacije.Forme2._0.Ucestvuje
{
    partial class AddChangeUcestvovanje
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
            comboVs = new ComboBox();
            comboJedinica = new ComboBox();
            label2 = new Label();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            comboIntervencija = new ComboBox();
            SuspendLayout();
            // 
            // comboVs
            // 
            comboVs.FormattingEnabled = true;
            comboVs.Location = new Point(182, 108);
            comboVs.Name = "comboVs";
            comboVs.Size = new Size(170, 28);
            comboVs.TabIndex = 176;
            comboVs.SelectedIndexChanged += comboVs_SelectedIndexChanged;
            // 
            // comboJedinica
            // 
            comboJedinica.FormattingEnabled = true;
            comboJedinica.Location = new Point(182, 26);
            comboJedinica.Name = "comboJedinica";
            comboJedinica.Size = new Size(170, 28);
            comboJedinica.TabIndex = 175;
            comboJedinica.SelectedIndexChanged += comboJedinica_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Location = new Point(44, 110);
            label2.Name = "label2";
            label2.Size = new Size(142, 22);
            label2.TabIndex = 174;
            label2.Text = "Vanredna SItuacija";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            button2.Location = new Point(258, 188);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 171;
            button2.Text = "Odustani";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(66, 188);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 170;
            button1.Text = "Sacuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Location = new Point(63, 67);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 169;
            label3.Text = "Intervencija";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(63, 29);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 168;
            label4.Text = "Jedinica";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboIntervencija
            // 
            comboIntervencija.FormattingEnabled = true;
            comboIntervencija.Location = new Point(182, 67);
            comboIntervencija.Name = "comboIntervencija";
            comboIntervencija.Size = new Size(170, 28);
            comboIntervencija.TabIndex = 177;
            comboIntervencija.SelectedIndexChanged += comboIntervencija_SelectedIndexChanged;
            // 
            // AddChangeUcestvovanje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 261);
            Controls.Add(comboIntervencija);
            Controls.Add(comboVs);
            Controls.Add(comboJedinica);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "AddChangeUcestvovanje";
            Text = "AddChangeUcestvovanje";
            Load += AddChangeUcestvovanje_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboVs;
        private ComboBox comboJedinica;
        private Label label2;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label4;
        private ComboBox comboIntervencija;
    }
}