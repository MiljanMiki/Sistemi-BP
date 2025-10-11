namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    partial class DodajVoziloDijalog
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
            buttonOdustani = new Button();
            label1 = new Label();
            buttonDzip = new Button();
            buttonSpec = new Button();
            buttonSanitet = new Button();
            buttonKamion = new Button();
            SuspendLayout();
            // 
            // buttonOdustani
            // 
            buttonOdustani.Location = new Point(59, 434);
            buttonOdustani.Name = "buttonOdustani";
            buttonOdustani.Size = new Size(225, 53);
            buttonOdustani.TabIndex = 14;
            buttonOdustani.Text = "Odustani";
            buttonOdustani.UseVisualStyleBackColor = true;
            buttonOdustani.Click += button2_Click;
            // 
            // label1
            // 
            label1.Location = new Point(59, 9);
            label1.Name = "label1";
            label1.Size = new Size(225, 73);
            label1.TabIndex = 13;
            label1.Text = "Odaberite tip vozila koji hocete da dodate";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonDzip
            // 
            buttonDzip.Location = new Point(59, 261);
            buttonDzip.Name = "buttonDzip";
            buttonDzip.Size = new Size(225, 53);
            buttonDzip.TabIndex = 12;
            buttonDzip.Text = "Dzip";
            buttonDzip.UseVisualStyleBackColor = true;
            buttonDzip.Click += buttonOdustani_Click_1;
            // 
            // buttonSpec
            // 
            buttonSpec.Location = new Point(59, 169);
            buttonSpec.Name = "buttonSpec";
            buttonSpec.Size = new Size(225, 53);
            buttonSpec.TabIndex = 11;
            buttonSpec.Text = "Specijalno vozilo";
            buttonSpec.UseVisualStyleBackColor = true;
            buttonSpec.Click += buttonSpec_Click_1;
            // 
            // buttonSanitet
            // 
            buttonSanitet.Location = new Point(59, 85);
            buttonSanitet.Name = "buttonSanitet";
            buttonSanitet.Size = new Size(225, 53);
            buttonSanitet.TabIndex = 10;
            buttonSanitet.Text = "Sanitetsko vozilo";
            buttonSanitet.UseVisualStyleBackColor = true;
            buttonSanitet.Click += buttonOpsta_Click_1;
            // 
            // buttonKamion
            // 
            buttonKamion.Location = new Point(59, 344);
            buttonKamion.Name = "buttonKamion";
            buttonKamion.Size = new Size(225, 53);
            buttonKamion.TabIndex = 15;
            buttonKamion.Text = "Kamion";
            buttonKamion.UseVisualStyleBackColor = true;
            buttonKamion.Click += button1_Click;
            // 
            // DodajVoziloDijalog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(343, 512);
            Controls.Add(buttonKamion);
            Controls.Add(buttonOdustani);
            Controls.Add(label1);
            Controls.Add(buttonDzip);
            Controls.Add(buttonSpec);
            Controls.Add(buttonSanitet);
            Name = "DodajVoziloDijalog";
            Text = "DodajVoziloDijalog";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOdustani;
        private Label label1;
        private Button buttonDzip;
        private Button buttonSpec;
        private Button buttonSanitet;
        private Button buttonKamion;
    }
}