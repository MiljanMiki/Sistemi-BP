namespace ProjekatVandredneSituacije.Forme2._0.ZaposleniForma
{
    partial class IstorijaForma
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
            dataGridView1 = new DataGridView();
            buttonObrisi = new Button();
            buttonIzmeni = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 605);
            dataGridView1.TabIndex = 0;
            // 
            // buttonObrisi
            // 
            buttonObrisi.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonObrisi.Location = new Point(1022, 11);
            buttonObrisi.Margin = new Padding(3, 2, 3, 2);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new Size(150, 30);
            buttonObrisi.TabIndex = 3;
            buttonObrisi.Text = "Obrisi";
            buttonObrisi.UseVisualStyleBackColor = true;
            // 
            // buttonIzmeni
            // 
            buttonIzmeni.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonIzmeni.Location = new Point(866, 11);
            buttonIzmeni.Margin = new Padding(3, 2, 3, 2);
            buttonIzmeni.Name = "buttonIzmeni";
            buttonIzmeni.Size = new Size(150, 30);
            buttonIzmeni.TabIndex = 2;
            buttonIzmeni.Text = "Izmeni";
            buttonIzmeni.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F);
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(174, 25);
            label1.TabIndex = 4;
            label1.Text = "Istorija Zaposlenih";
            // 
            // IstorijaForma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(label1);
            Controls.Add(buttonObrisi);
            Controls.Add(buttonIzmeni);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "IstorijaForma";
            Text = "IstorijaForma";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonObrisi;
        private Button buttonIzmeni;
        private Label label1;
    }
}