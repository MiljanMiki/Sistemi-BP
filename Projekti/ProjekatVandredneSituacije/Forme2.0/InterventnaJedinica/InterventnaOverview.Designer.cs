namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    partial class InterventnaOverview
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
            comboBox2 = new ComboBox();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 605);
            dataGridView1.TabIndex = 20;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Sve Jedinice", "Opste Jedinice", "Specijalne Jedinice" });
            comboBox2.Location = new Point(12, 16);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(150, 23);
            comboBox2.TabIndex = 19;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged_1;
            comboBox2.SelectionChangeCommitted += comboBox2_SelectedIndexChanged;
            comboBox2.DropDownStyleChanged += comboBox2_DropDownStyleChanged;
            // 
            // button9
            // 
            button9.Location = new Point(866, 11);
            button9.Margin = new Padding(3, 2, 3, 2);
            button9.Name = "button9";
            button9.Size = new Size(150, 30);
            button9.TabIndex = 18;
            button9.Text = "Vozila";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(1022, 11);
            button10.Margin = new Padding(3, 2, 3, 2);
            button10.Name = "button10";
            button10.Size = new Size(150, 30);
            button10.TabIndex = 17;
            button10.Text = "Clanovi";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(710, 11);
            button11.Margin = new Padding(3, 2, 3, 2);
            button11.Name = "button11";
            button11.Size = new Size(150, 30);
            button11.TabIndex = 16;
            button11.Text = "Obrisi";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(554, 11);
            button12.Margin = new Padding(3, 2, 3, 2);
            button12.Name = "button12";
            button12.Size = new Size(150, 30);
            button12.TabIndex = 15;
            button12.Text = "Izmeni";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(398, 11);
            button13.Margin = new Padding(3, 2, 3, 2);
            button13.Name = "button13";
            button13.Size = new Size(150, 30);
            button13.TabIndex = 14;
            button13.Text = "Dodaj";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // InterventnaOverview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox2);
            Controls.Add(button10);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button9);
            Margin = new Padding(3, 2, 3, 2);
            Name = "InterventnaOverview";
            Text = "InterventnaOverview";
            Load += InterventnaOverview_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private ComboBox comboBox2;
        private DataGridView dataGridView1;
    }
}