namespace ProjekatVandredneSituacije.Forme2._0.Specijalizacija
{
    partial class AddChangeSpecijalizacija
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
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label5 = new Label();
            label1 = new Label();
            txtTip = new TextBox();
            txtKoordinator = new TextBox();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Location = new Point(128, 153);
            button3.Name = "button3";
            button3.Size = new Size(103, 29);
            button3.TabIndex = 132;
            button3.Text = "Reset";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(227, 188);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 131;
            button2.Text = "Odustani";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(35, 188);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 130;
            button1.Text = "Sacuvaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.Location = new Point(35, 66);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 129;
            label5.Text = "Koordinator";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Location = new Point(35, 102);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 135;
            label1.Text = "Tip";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTip
            // 
            txtTip.Location = new Point(154, 99);
            txtTip.Name = "txtTip";
            txtTip.Size = new Size(167, 27);
            txtTip.TabIndex = 136;
            // 
            // txtKoordinator
            // 
            txtKoordinator.Location = new Point(154, 59);
            txtKoordinator.Name = "txtKoordinator";
            txtKoordinator.Size = new Size(167, 27);
            txtKoordinator.TabIndex = 137;
            // 
            // AddChangeSpecijalizacija
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 244);
            Controls.Add(txtKoordinator);
            Controls.Add(txtTip);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Name = "AddChangeSpecijalizacija";
            Text = "AddChangeSpecijalizacija";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label5;
        private Label label1;
        private TextBox txtTip;
        private TextBox txtKoordinator;
    }
}