namespace ProjekatVandredneSituacije.Forme2._0.Sluzba
{
    partial class SluzbaAddChange
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
            textSektor = new TextBox();
            label1 = new Label();
            buttonReset = new Button();
            buttonAbort = new Button();
            buttonSave = new Button();
            label5 = new Label();
            comboPredstavnici = new ComboBox();
            SuspendLayout();
            // 
            // textSektor
            // 
            textSektor.Location = new Point(157, 33);
            textSektor.Name = "textSektor";
            textSektor.Size = new Size(167, 27);
            textSektor.TabIndex = 151;
            // 
            // label1
            // 
            label1.Location = new Point(38, 81);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 149;
            label1.Text = "Predstavnik";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(131, 127);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(103, 29);
            buttonReset.TabIndex = 148;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonAbort
            // 
            buttonAbort.Location = new Point(230, 162);
            buttonAbort.Name = "buttonAbort";
            buttonAbort.Size = new Size(94, 29);
            buttonAbort.TabIndex = 147;
            buttonAbort.Text = "Odustani";
            buttonAbort.UseVisualStyleBackColor = true;
            buttonAbort.Click += buttonAbort_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(38, 162);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 146;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label5
            // 
            label5.Location = new Point(38, 40);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 145;
            label5.Text = "TIp sektora ";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboPredstavnici
            // 
            comboPredstavnici.FormattingEnabled = true;
            comboPredstavnici.Location = new Point(157, 73);
            comboPredstavnici.Name = "comboPredstavnici";
            comboPredstavnici.Size = new Size(167, 28);
            comboPredstavnici.TabIndex = 152;
            // 
            // SluzbaAddChange
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 213);
            Controls.Add(comboPredstavnici);
            Controls.Add(textSektor);
            Controls.Add(label1);
            Controls.Add(buttonReset);
            Controls.Add(buttonAbort);
            Controls.Add(buttonSave);
            Controls.Add(label5);
            Name = "SluzbaAddChange";
            Text = "SluzbaAddChange";
            Load += SluzbaAddChange_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textSektor;
        private Label label1;
        private Button buttonReset;
        private Button buttonAbort;
        private Button buttonSave;
        private Label label5;
        private ComboBox comboPredstavnici;
    }
}