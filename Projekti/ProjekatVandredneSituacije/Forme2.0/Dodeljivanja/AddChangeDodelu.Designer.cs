namespace ProjekatVandredneSituacije.Forme2._0.Dodeljivanja
{
    partial class AddChangeDodelu
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
            dateDo = new DateTimePicker();
            label1 = new Label();
            dateOd = new DateTimePicker();
            label2 = new Label();
            btnCancel = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboJedinica = new ComboBox();
            comboRadnik = new ComboBox();
            comboVozilo = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // dateDo
            // 
            dateDo.Format = DateTimePickerFormat.Short;
            dateDo.Location = new Point(174, 193);
            dateDo.Margin = new Padding(3, 2, 3, 2);
            dateDo.Name = "dateDo";
            dateDo.Size = new Size(148, 23);
            dateDo.TabIndex = 168;
            // 
            // label1
            // 
            label1.Location = new Point(70, 196);
            label1.Name = "label1";
            label1.Size = new Size(108, 16);
            label1.TabIndex = 167;
            label1.Text = "Datum Do";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateOd
            // 
            dateOd.Format = DateTimePickerFormat.Short;
            dateOd.Location = new Point(174, 160);
            dateOd.Margin = new Padding(3, 2, 3, 2);
            dateOd.Name = "dateOd";
            dateOd.Size = new Size(148, 23);
            dateOd.TabIndex = 166;
            // 
            // label2
            // 
            label2.Location = new Point(70, 164);
            label2.Name = "label2";
            label2.Size = new Size(108, 16);
            label2.TabIndex = 165;
            label2.Text = "Datum Od";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(233, 254);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 22);
            btnCancel.TabIndex = 161;
            btnCancel.Text = "Odustani";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label3
            // 
            label3.Location = new Point(68, 88);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 159;
            label3.Text = "Radnik";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(70, 124);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 158;
            label4.Text = "Jediica";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(68, 55);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 169;
            label5.Text = "Vozilo";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboJedinica
            // 
            comboJedinica.FormattingEnabled = true;
            comboJedinica.Location = new Point(174, 124);
            comboJedinica.Margin = new Padding(3, 2, 3, 2);
            comboJedinica.Name = "comboJedinica";
            comboJedinica.Size = new Size(148, 23);
            comboJedinica.TabIndex = 170;
            comboJedinica.SelectedIndexChanged += comboJedinica_SelectedIndexChanged;
            // 
            // comboRadnik
            // 
            comboRadnik.FormattingEnabled = true;
            comboRadnik.Location = new Point(174, 88);
            comboRadnik.Margin = new Padding(3, 2, 3, 2);
            comboRadnik.Name = "comboRadnik";
            comboRadnik.Size = new Size(148, 23);
            comboRadnik.TabIndex = 171;
            comboRadnik.SelectedIndexChanged += comboRadnik_SelectedIndexChanged;
            // 
            // comboVozilo
            // 
            comboVozilo.FormattingEnabled = true;
            comboVozilo.Location = new Point(174, 49);
            comboVozilo.Margin = new Padding(3, 2, 3, 2);
            comboVozilo.Name = "comboVozilo";
            comboVozilo.Size = new Size(148, 23);
            comboVozilo.TabIndex = 172;
            comboVozilo.SelectedIndexChanged += comboVozilo_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(50, 254);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 173;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSave_Click;
            // 
            // button2
            // 
            button2.Location = new Point(143, 234);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 174;
            button2.Text = "Reset";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnRst_Click;
            // 
            // AddChangeDodelu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 304);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboVozilo);
            Controls.Add(comboRadnik);
            Controls.Add(comboJedinica);
            Controls.Add(label5);
            Controls.Add(dateDo);
            Controls.Add(label1);
            Controls.Add(dateOd);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(label3);
            Controls.Add(label4);
            Margin = new Padding(3, 2, 3, 2);
            Name = "AddChangeDodelu";
            Text = "AddChangeDodelu";
            Load += AddChangeDodelu_Load;
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dateDo;
        private Label label1;
        private DateTimePicker dateOd;
        private Label label2;
        private Button btnCancel;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox comboJedinica;
        private ComboBox comboRadnik;
        private ComboBox comboVozilo;
        private Button button1;
        private Button button2;
    }
}