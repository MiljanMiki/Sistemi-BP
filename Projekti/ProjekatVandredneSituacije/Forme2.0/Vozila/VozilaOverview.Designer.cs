namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    partial class VozilaOverview
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
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            buttonServisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1326, 804);
            dataGridView1.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Sva Vozila", "Sanitetska Vozila", "Specijalna Vozila", "Kamioni", "Dzipovi" });
            comboBox1.Location = new Point(14, 25);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 28);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_2;
            comboBox1.DropDownStyleChanged += comboBox1_DropDownStyleChanged_1;
            // 
            // button1
            // 
            button1.Location = new Point(444, 13);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(171, 40);
            button1.TabIndex = 7;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_2;
            // 
            // button2
            // 
            button2.Location = new Point(622, 13);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(171, 40);
            button2.TabIndex = 8;
            button2.Text = "Izmeni";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_2;
            // 
            // button3
            // 
            button3.Location = new Point(801, 13);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(171, 40);
            button3.TabIndex = 9;
            button3.Text = "Izbrisi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_2;
            // 
            // button4
            // 
            button4.Location = new Point(979, 12);
            button4.Name = "button4";
            button4.Size = new Size(171, 40);
            button4.TabIndex = 10;
            button4.Text = "Intervencije";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // buttonServisi
            // 
            buttonServisi.Location = new Point(1156, 13);
            buttonServisi.Margin = new Padding(3, 4, 3, 4);
            buttonServisi.Name = "buttonServisi";
            buttonServisi.Size = new Size(170, 40);
            buttonServisi.TabIndex = 11;
            buttonServisi.Text = "Servisi";
            buttonServisi.UseVisualStyleBackColor = true;
            buttonServisi.Click += buttonServisi_Click;
            // 
            // VozilaOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 881);
            Controls.Add(buttonServisi);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Name = "VozilaOverview";
            Text = "VozilaOverview";
            WindowState = FormWindowState.Maximized;
            Load += VozilaOverview_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button buttonServisi;
    }
}