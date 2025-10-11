namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    partial class AddIntervencijaDIjalog
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
            buttonOpsta = new Button();
            buttonSpec = new Button();
            buttonOdustani = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonOpsta
            // 
            buttonOpsta.Location = new Point(81, 103);
            buttonOpsta.Name = "buttonOpsta";
            buttonOpsta.Size = new Size(225, 53);
            buttonOpsta.TabIndex = 0;
            buttonOpsta.Text = "Opsta Jedinica";
            buttonOpsta.UseVisualStyleBackColor = true;
            buttonOpsta.Click += buttonOpsta_Click;
            // 
            // buttonSpec
            // 
            buttonSpec.Location = new Point(81, 187);
            buttonSpec.Name = "buttonSpec";
            buttonSpec.Size = new Size(225, 53);
            buttonSpec.TabIndex = 1;
            buttonSpec.Text = "Specijalna Jedinica";
            buttonSpec.UseVisualStyleBackColor = true;
            buttonSpec.Click += buttonSpec_Click;
            // 
            // buttonOdustani
            // 
            buttonOdustani.Location = new Point(81, 272);
            buttonOdustani.Name = "buttonOdustani";
            buttonOdustani.Size = new Size(225, 53);
            buttonOdustani.TabIndex = 2;
            buttonOdustani.Text = "Odustani";
            buttonOdustani.UseVisualStyleBackColor = true;
            buttonOdustani.Click += buttonOdustani_Click;
            // 
            // label1
            // 
            label1.Location = new Point(81, 27);
            label1.Name = "label1";
            label1.Size = new Size(225, 73);
            label1.TabIndex = 3;
            label1.Text = "Odaberite tip Jedinice koji hocete da dodate";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddIntervencijaDIjalog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 392);
            Controls.Add(label1);
            Controls.Add(buttonOdustani);
            Controls.Add(buttonSpec);
            Controls.Add(buttonOpsta);
            Name = "AddIntervencijaDIjalog";
            Text = "AddIntervencijaDIjalog";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonOpsta;
        private Button buttonSpec;
        private Button buttonOdustani;
        private Label label1;
    }
}