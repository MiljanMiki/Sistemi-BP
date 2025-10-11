namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    partial class KamioniAddChange
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
            textLok = new TextBox();
            label1 = new Label();
            textPro = new TextBox();
            comboStatus = new ComboBox();
            textReg = new TextBox();
            buttonReset = new Button();
            buttonCancel = new Button();
            buttonSave = new Button();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // textLok
            // 
            textLok.Location = new Point(136, 165);
            textLok.Name = "textLok";
            textLok.Size = new Size(167, 27);
            textLok.TabIndex = 128;
            // 
            // label1
            // 
            label1.Location = new Point(17, 165);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 127;
            label1.Text = "Lokacija";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textPro
            // 
            textPro.Location = new Point(136, 77);
            textPro.Name = "textPro";
            textPro.Size = new Size(167, 27);
            textPro.TabIndex = 126;
            // 
            // comboStatus
            // 
            comboStatus.FormattingEnabled = true;
            comboStatus.Location = new Point(136, 114);
            comboStatus.Name = "comboStatus";
            comboStatus.Size = new Size(167, 28);
            comboStatus.TabIndex = 125;
            // 
            // textReg
            // 
            textReg.Location = new Point(136, 39);
            textReg.Name = "textReg";
            textReg.Size = new Size(167, 27);
            textReg.TabIndex = 124;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(110, 219);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(103, 32);
            buttonReset.TabIndex = 123;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(209, 254);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(94, 32);
            buttonCancel.TabIndex = 122;
            buttonCancel.Text = "Odustani";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(17, 254);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 32);
            buttonSave.TabIndex = 121;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // label5
            // 
            label5.Location = new Point(17, 122);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 120;
            label5.Text = "Status";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(17, 84);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 119;
            label3.Text = "Proizvodjac";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(17, 46);
            label4.Name = "label4";
            label4.Size = new Size(113, 20);
            label4.TabIndex = 118;
            label4.Text = "Reg. Oznaka:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // KamioniAddChange
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 305);
            Controls.Add(textLok);
            Controls.Add(label1);
            Controls.Add(textPro);
            Controls.Add(comboStatus);
            Controls.Add(textReg);
            Controls.Add(buttonReset);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Name = "KamioniAddChange";
            Text = "KamioniAddChange";
            Load += KamioniAddChange_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textLok;
        private Label label1;
        private TextBox textPro;
        private ComboBox comboStatus;
        private TextBox textReg;
        private Button buttonReset;
        private Button buttonCancel;
        private Button buttonSave;
        private Label label5;
        private Label label3;
        private Label label4;
    }
}