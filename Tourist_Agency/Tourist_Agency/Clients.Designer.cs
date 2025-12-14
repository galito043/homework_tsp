namespace Tourist_Agency
{
    partial class Clients
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
            txtId = new TextBox();
            txtName = new TextBox();
            txtCountry = new TextBox();
            cmbGender = new ComboBox();
            dateTimePicker1 = new DateTimePicker();
            txtInsurance = new TextBox();
            txtEGN = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(360, 225);
            dataGridView1.TabIndex = 0;
            
            // 
            // txtId
            // 
            txtId.Location = new Point(483, 27);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 31);
            txtId.TabIndex = 1;
            
            // 
            // txtName
            // 
            txtName.Location = new Point(483, 117);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 31);
            txtName.TabIndex = 2;
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(483, 154);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(150, 31);
            txtCountry.TabIndex = 3;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Male", "Female" });
            cmbGender.Location = new Point(472, 191);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(182, 33);
            cmbGender.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(434, 256);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 5;
            // 
            // txtInsurance
            // 
            txtInsurance.Location = new Point(483, 319);
            txtInsurance.Name = "txtInsurance";
            txtInsurance.Size = new Size(150, 31);
            txtInsurance.TabIndex = 6;
            // 
            // txtEGN
            // 
            txtEGN.Location = new Point(483, 67);
            txtEGN.Name = "txtEGN";
            txtEGN.Size = new Size(150, 31);
            txtEGN.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 304);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "buttonAdd";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(155, 304);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "btnUpdate";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(303, 304);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "btnDelete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // Clients
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtEGN);
            Controls.Add(txtInsurance);
            Controls.Add(dateTimePicker1);
            Controls.Add(cmbGender);
            Controls.Add(txtCountry);
            Controls.Add(txtName);
            Controls.Add(txtId);
            Controls.Add(dataGridView1);
            Name = "Clients";
            Text = "Clients";
            Load += Clients_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtCountry;
        private ComboBox cmbGender;
        private DateTimePicker dateTimePicker1;
        private TextBox txtInsurance;
        private TextBox txtEGN;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
    }
}