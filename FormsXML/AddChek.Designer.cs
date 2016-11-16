namespace FormsXML
{
    partial class AddChek
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label_nomer = new System.Windows.Forms.Label();
            this.textBox_Tovar = new System.Windows.Forms.TextBox();
            this.textBox_Count = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.label_total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_add_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(449, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // label_nomer
            // 
            this.label_nomer.AutoSize = true;
            this.label_nomer.Location = new System.Drawing.Point(563, 325);
            this.label_nomer.Name = "label_nomer";
            this.label_nomer.Size = new System.Drawing.Size(82, 13);
            this.label_nomer.TabIndex = 3;
            this.label_nomer.Text = "Номер товара:";
            // 
            // textBox_Tovar
            // 
            this.textBox_Tovar.Location = new System.Drawing.Point(665, 322);
            this.textBox_Tovar.Name = "textBox_Tovar";
            this.textBox_Tovar.Size = new System.Drawing.Size(100, 20);
            this.textBox_Tovar.TabIndex = 4;
            // 
            // textBox_Count
            // 
            this.textBox_Count.Location = new System.Drawing.Point(665, 401);
            this.textBox_Count.Name = "textBox_Count";
            this.textBox_Count.Size = new System.Drawing.Size(100, 20);
            this.textBox_Count.TabIndex = 5;
            // 
            // textBox_Price
            // 
            this.textBox_Price.Location = new System.Drawing.Point(665, 365);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(100, 20);
            this.textBox_Price.TabIndex = 6;
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(731, 434);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(34, 13);
            this.label_total.TabIndex = 7;
            this.label_total.Text = "Итог:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Количество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(563, 365);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Цена";
            // 
            // AddChek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 519);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.textBox_Price);
            this.Controls.Add(this.textBox_Count);
            this.Controls.Add(this.textBox_Tovar);
            this.Controls.Add(this.label_nomer);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "AddChek";
            this.Text = "AddChek";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_nomer;
        private System.Windows.Forms.TextBox textBox_Tovar;
        private System.Windows.Forms.TextBox textBox_Count;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}