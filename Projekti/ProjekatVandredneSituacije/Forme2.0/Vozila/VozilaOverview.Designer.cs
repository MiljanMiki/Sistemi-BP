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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 47);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1160, 603);
            dataGridView1.TabIndex = 6;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Sva Vozila", "Sanitetska Vozila", "Specijalna Vozila", "Kamioni", "Dzipovi" });
            comboBox1.Location = new Point(12, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged_2;
            comboBox1.DropDownStyleChanged += comboBox1_DropDownStyleChanged_1;
            // 
            // button1
            // 
            button1.Location = new Point(554, 12);
            button1.Name = "button1";
            button1.Size = new Size(150, 30);
            button1.TabIndex = 7;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_2;
            // 
            // button2
            // 
            button2.Location = new Point(710, 12);
            button2.Name = "button2";
            button2.Size = new Size(150, 30);
            button2.TabIndex = 8;
            button2.Text = "Izmeni";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_2;
            // 
            // button3
            // 
            button3.Location = new Point(866, 12);
            button3.Name = "button3";
            button3.Size = new Size(150, 30);
            button3.TabIndex = 9;
            button3.Text = "Izbrisi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_2;
            // 
            // button4
            // 
            button4.Location = new Point(1022, 11);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(150, 30);
            button4.TabIndex = 10;
            button4.Text = "Intervencije";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // VozilaOverview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Margin = new Padding(3, 2, 3, 2);
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
    }
}