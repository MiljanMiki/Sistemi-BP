namespace ProjekatVandredneSituacije.Forme2._0.Oprema
{
    partial class DodajOpremuDijalog
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
            label1 = new Label();
            buttonOdustani = new Button();
            buttonSpec = new Button();
            buttonOpsta = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(61, 9);
            label1.Name = "label1";
            label1.Size = new Size(225, 73);
            label1.TabIndex = 7;
            label1.Text = "Odaberite tip opreme koji hocete da dodate";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonOdustani
            // 
            buttonOdustani.Location = new Point(61, 203);
            buttonOdustani.Name = "buttonOdustani";
            buttonOdustani.Size = new Size(225, 53);
            buttonOdustani.TabIndex = 6;
            buttonOdustani.Text = "Tehnicka Oprema";
            buttonOdustani.UseVisualStyleBackColor = true;
            buttonOdustani.Click += buttonOdustani_Click;
            // 
            // buttonSpec
            // 
            buttonSpec.Location = new Point(61, 144);
            buttonSpec.Name = "buttonSpec";
            buttonSpec.Size = new Size(225, 53);
            buttonSpec.TabIndex = 5;
            buttonSpec.Text = "Medicinska Oprema";
            buttonSpec.UseVisualStyleBackColor = true;
            buttonSpec.Click += buttonSpec_Click;
            // 
            // buttonOpsta
            // 
            buttonOpsta.Location = new Point(61, 85);
            buttonOpsta.Name = "buttonOpsta";
            buttonOpsta.Size = new Size(225, 53);
            buttonOpsta.TabIndex = 4;
            buttonOpsta.Text = "Zalihe";
            buttonOpsta.UseVisualStyleBackColor = true;
            buttonOpsta.Click += buttonOpsta_Click;
            // 
            // button1
            // 
            button1.Location = new Point(61, 321);
            button1.Name = "button1";
            button1.Size = new Size(225, 53);
            button1.TabIndex = 9;
            button1.Text = "Odustani";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(61, 262);
            button2.Name = "button2";
            button2.Size = new Size(225, 53);
            button2.TabIndex = 8;
            button2.Text = "Licna Zastita";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // DodajOpremuDijalog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 421);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(buttonOdustani);
            Controls.Add(buttonSpec);
            Controls.Add(buttonOpsta);
            Name = "DodajOpremuDijalog";
            Text = "DodajOpremuDijalog";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button buttonOdustani;
        private Button buttonSpec;
        private Button buttonOpsta;
        private Button button1;
        private Button button2;
    }
}