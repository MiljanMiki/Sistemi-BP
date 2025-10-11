namespace ProjekatVandredneSituacije.Forme2._0.Saradnja
{
    partial class DodajIzmeniSaradnju
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
            label2 = new Label();
            textBox1 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Location = new Point(12, 117);
            label2.Name = "label2";
            label2.Size = new Size(142, 22);
            label2.TabIndex = 165;
            label2.Text = "Vanredna SItuacija";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(150, 71);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(167, 27);
            textBox1.TabIndex = 164;
            // 
            // button3
            // 
            button3.Location = new Point(127, 160);
            button3.Name = "button3";
            button3.Size = new Size(103, 29);
            button3.TabIndex = 162;
            button3.Text = "Reset";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(226, 195);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 161;
            button2.Text = "Odustani";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(34, 195);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 160;
            button1.Text = "Sacuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Location = new Point(31, 74);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 159;
            label3.Text = "Uloga";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(31, 36);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 158;
            label4.Text = "Sluzba";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(150, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(170, 28);
            comboBox1.TabIndex = 166;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(150, 115);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(170, 28);
            comboBox2.TabIndex = 167;
            // 
            // DodajIzmeniSaradnju
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 256);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "DodajIzmeniSaradnju";
            Text = "DodajIzmeniSaradnju";
            Load += DodajIzmeniSaradnju_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox textBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label4;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}