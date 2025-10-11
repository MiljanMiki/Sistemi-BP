namespace ProjekatVandredneSituacije.Forme2._0.Ekspertiza
{
    partial class EkspertizaAddChange
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
            textOblast = new TextBox();
            label1 = new Label();
            buttonReset = new Button();
            buttonAbort = new Button();
            buttonSave = new Button();
            label5 = new Label();
            textJMBG = new TextBox();
            SuspendLayout();
            // 
            // textOblast
            // 
            textOblast.Location = new Point(139, 69);
            textOblast.Name = "textOblast";
            textOblast.Size = new Size(167, 27);
            textOblast.TabIndex = 143;
            // 
            // label1
            // 
            label1.Location = new Point(20, 72);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 142;
            label1.Text = "Oblast";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(113, 123);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(103, 29);
            buttonReset.TabIndex = 140;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // buttonAbort
            // 
            buttonAbort.Location = new Point(212, 158);
            buttonAbort.Name = "buttonAbort";
            buttonAbort.Size = new Size(94, 29);
            buttonAbort.TabIndex = 139;
            buttonAbort.Text = "Odustani";
            buttonAbort.UseVisualStyleBackColor = true;
            buttonAbort.Click += buttonAbort_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(20, 158);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(94, 29);
            buttonSave.TabIndex = 138;
            buttonSave.Text = "Sacuvaj";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += button1_Click;
            // 
            // label5
            // 
            label5.Location = new Point(20, 36);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 137;
            label5.Text = "JMBG";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textJMBG
            // 
            textJMBG.Location = new Point(139, 29);
            textJMBG.Name = "textJMBG";
            textJMBG.Size = new Size(167, 27);
            textJMBG.TabIndex = 144;
            // 
            // EkspertizaAddChange
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 211);
            Controls.Add(textJMBG);
            Controls.Add(textOblast);
            Controls.Add(label1);
            Controls.Add(buttonReset);
            Controls.Add(buttonAbort);
            Controls.Add(buttonSave);
            Controls.Add(label5);
            Name = "EkspertizaAddChange";
            Text = "EkspertizaAddChange";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textOblast;
        private Label label1;
        private Button buttonReset;
        private Button buttonAbort;
        private Button buttonSave;
        private Label label5;
        private TextBox textJMBG;
    }
}