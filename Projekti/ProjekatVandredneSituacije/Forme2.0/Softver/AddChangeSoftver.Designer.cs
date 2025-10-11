namespace ProjekatVandredneSituacije.Forme2._0.Softver
{
    partial class AddChangeSoftver
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
            textNaziv = new TextBox();
            label1 = new Label();
            buttonReset = new Button();
            buttonCancel = new Button();
            ave = new Button();
            label5 = new Label();
            textJMBG = new TextBox();
            SuspendLayout();
            // 
            // textNaziv
            // 
            textNaziv.Location = new Point(132, 64);
            textNaziv.Name = "textNaziv";
            textNaziv.Size = new Size(167, 27);
            textNaziv.TabIndex = 150;
            // 
            // label1
            // 
            label1.Location = new Point(13, 67);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 149;
            label1.Text = "Naziv";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(106, 118);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(103, 29);
            buttonReset.TabIndex = 147;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(205, 153);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 29);
            buttonCancel.TabIndex = 146;
            buttonCancel.Text = "Odustani";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ave
            // 
            ave.Location = new Point(13, 153);
            ave.Name = "ave";
            ave.Size = new Size(94, 29);
            ave.TabIndex = 145;
            ave.Text = "Sacuvaj";
            ave.UseVisualStyleBackColor = true;
            ave.Click += ave_Click;
            // 
            // label5
            // 
            label5.Location = new Point(13, 31);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 144;
            label5.Text = "JMBG";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textJMBG
            // 
            textJMBG.Location = new Point(132, 24);
            textJMBG.Name = "textJMBG";
            textJMBG.Size = new Size(167, 27);
            textJMBG.TabIndex = 151;
            // 
            // AddChangeSoftver
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 218);
            Controls.Add(textJMBG);
            Controls.Add(textNaziv);
            Controls.Add(label1);
            Controls.Add(buttonReset);
            Controls.Add(buttonCancel);
            Controls.Add(ave);
            Controls.Add(label5);
            Name = "AddChangeSoftver";
            Text = "AddChangeSoftver";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textNaziv;
        private Label label1;
        private Button buttonReset;
        private Button buttonCancel;
        private Button ave;
        private Label label5;
        private TextBox textJMBG;
    }
}