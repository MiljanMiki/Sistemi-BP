namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    partial class AddChangeOpstu
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
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            textBox3 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(151, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(167, 27);
            textBox1.TabIndex = 95;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(151, 137);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(167, 28);
            comboBox1.TabIndex = 93;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(151, 62);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(167, 27);
            textBox3.TabIndex = 88;
            // 
            // button3
            // 
            button3.Location = new Point(125, 183);
            button3.Name = "button3";
            button3.Size = new Size(103, 29);
            button3.TabIndex = 87;
            button3.Text = "Reset";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(224, 218);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 86;
            button2.Text = "Odustani";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(32, 218);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 85;
            button1.Text = "Sacuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.Location = new Point(32, 145);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 80;
            label5.Text = "Komandir";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(32, 107);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 79;
            label3.Text = "Baza";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(32, 69);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 76;
            label4.Text = "Naziv:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AddChangeOpstu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 283);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "AddChangeOpstu";
            Text = "AddChangeOpstu";
            Load += AddChangeOpstu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label5;
        private Label label3;
        private Label label4;
    }
}