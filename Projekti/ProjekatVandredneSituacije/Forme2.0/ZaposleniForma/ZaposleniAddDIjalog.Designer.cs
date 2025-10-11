namespace ProjekatVandredneSituacije.Forme2._0.ZaposleniForma
{
    partial class ZaposleniAddDIjalog
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
            buttonAnaliticar = new Button();
            buttonKoordinator = new Button();
            buttonDodajO = new Button();
            labelOdabir = new Label();
            SuspendLayout();
            // 
            // buttonOdustani
            // 
            buttonOdustani.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonOdustani.Location = new Point(46, 194);
            buttonOdustani.Margin = new Padding(3, 2, 3, 2);
            buttonOdustani.Name = "buttonOdustani";
            buttonOdustani.Size = new Size(169, 25);
            buttonOdustani.TabIndex = 3;
            buttonOdustani.Text = "Odustani";
            buttonOdustani.UseVisualStyleBackColor = true;
            buttonOdustani.Click += buttonOdustani_Click;
            // 
            // buttonAnaliticar
            // 
            buttonAnaliticar.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAnaliticar.Location = new Point(46, 144);
            buttonAnaliticar.Margin = new Padding(3, 2, 3, 2);
            buttonAnaliticar.Name = "buttonAnaliticar";
            buttonAnaliticar.Size = new Size(169, 25);
            buttonAnaliticar.TabIndex = 4;
            buttonAnaliticar.Text = "Analiticar";
            buttonAnaliticar.UseVisualStyleBackColor = true;
            buttonAnaliticar.Click += buttonAnaliticar_Click_1;
            // 
            // buttonKoordinator
            // 
            buttonKoordinator.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonKoordinator.Location = new Point(46, 92);
            buttonKoordinator.Margin = new Padding(3, 2, 3, 2);
            buttonKoordinator.Name = "buttonKoordinator";
            buttonKoordinator.Size = new Size(169, 25);
            buttonKoordinator.TabIndex = 5;
            buttonKoordinator.Text = "Koordinator";
            buttonKoordinator.UseVisualStyleBackColor = true;
            buttonKoordinator.Click += buttonKoordinator_Click;
            // 
            // buttonDodajO
            // 
            buttonDodajO.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDodajO.Location = new Point(46, 44);
            buttonDodajO.Margin = new Padding(3, 2, 3, 2);
            buttonDodajO.Name = "buttonDodajO";
            buttonDodajO.Size = new Size(169, 25);
            buttonDodajO.TabIndex = 6;
            buttonDodajO.Text = "Operativni Radnik";
            buttonDodajO.UseVisualStyleBackColor = true;
            buttonDodajO.Click += buttonDodajO_Click;
            // 
            // labelOdabir
            // 
            labelOdabir.AutoSize = true;
            labelOdabir.Location = new Point(47, 7);
            labelOdabir.Name = "labelOdabir";
            labelOdabir.Size = new Size(148, 15);
            labelOdabir.TabIndex = 7;
            labelOdabir.Text = "Odaberite tip zaposlenog   ";
            labelOdabir.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ZaposleniAddDIjalog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(260, 242);
            Controls.Add(labelOdabir);
            Controls.Add(buttonDodajO);
            Controls.Add(buttonKoordinator);
            Controls.Add(buttonAnaliticar);
            Controls.Add(buttonOdustani);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ZaposleniAddDIjalog";
            Text = "ZaposleniAddDIjalog";
            Load += ZaposleniAddDIjalog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonOdustani;
        private Button buttonAnaliticar;
        private Button buttonKoordinator;
        private Button buttonDodajO;
        private Label labelOdabir;
    }
}