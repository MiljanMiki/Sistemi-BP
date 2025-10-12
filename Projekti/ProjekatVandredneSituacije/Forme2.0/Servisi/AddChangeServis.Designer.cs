namespace ProjekatVandredneSituacije.Forme2._0.Servisi
{
    partial class AddChangeServis
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
            txtVozilo = new TextBox();
            txtTip = new TextBox();
            label1 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtVozilo
            // 
            txtVozilo.Location = new Point(143, 24);
            txtVozilo.Name = "txtVozilo";
            txtVozilo.Size = new Size(167, 27);
            txtVozilo.TabIndex = 144;
            // 
            // txtTip
            // 
            txtTip.Location = new Point(143, 64);
            txtTip.Name = "txtTip";
            txtTip.Size = new Size(167, 27);
            txtTip.TabIndex = 143;
            // 
            // label1
            // 
            label1.Location = new Point(24, 67);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 142;
            label1.Text = "Tip Servisa";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button3
            // 
            button3.Location = new Point(117, 172);
            button3.Name = "button3";
            button3.Size = new Size(103, 29);
            button3.TabIndex = 141;
            button3.Text = "Reset";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(216, 207);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 140;
            button2.Text = "Odustani";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(24, 207);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 139;
            button1.Text = "Sacuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.Location = new Point(24, 31);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 138;
            label5.Text = "Vozilo";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(143, 116);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(164, 27);
            dateTimePicker1.TabIndex = 145;
            // 
            // label2
            // 
            label2.Location = new Point(24, 116);
            label2.Name = "label2";
            label2.Size = new Size(113, 27);
            label2.TabIndex = 146;
            label2.Text = "Datum";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddChangeServis
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 247);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(txtVozilo);
            Controls.Add(txtTip);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Name = "AddChangeServis";
            Text = "AddChangeServis";
            Load += AddChangeServis_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtVozilo;
        private TextBox txtTip;
        private Label label1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Label label2;
    }
}