using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace Tourist_Agency
{
    public partial class Clients : Form
    {

        string connectionString = @"";

        public Clients()
        {
            InitializeComponent();
        }


        private void Clients_Load(object sender, EventArgs e)
        {
            LoadData(); 
        }


        private void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM clients", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


        private void ClearFields()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtCountry.Text = "";
            txtInsurance.Text = "";
            txtEGN.Text = "";
            cmbGender.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["client_id"].Value.ToString();
                txtName.Text = row.Cells["full_name"].Value.ToString();
                txtCountry.Text = row.Cells["country"].Value.ToString();
                cmbGender.Text = row.Cells["gender"].Value.ToString();
                txtInsurance.Text = row.Cells["insurance_id"].Value.ToString();
                txtEGN.Text = row.Cells["personal_id"].Value.ToString();

                if (row.Cells["date_of_birth"].Value != DBNull.Value)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(row.Cells["date_of_birth"].Value);
                }
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"INSERT INTO clients 
                                   (full_name, country, gender, date_of_birth, insurance_id, personal_id) 
                                   VALUES 
                                   (@Name, @Country, @Gender, @Dob, @Ins, @Egn)";

                    SqlCommand cmd = new SqlCommand(query, con);


                    cmd.Parameters.AddWithValue("@Name", txtName.Text);       
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text); 
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);   
                    cmd.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Ins", txtInsurance.Text);   
                    cmd.Parameters.AddWithValue("@Egn", txtEGN.Text);         

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client Added Successfully");
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding client: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"UPDATE clients 
                                   SET full_name=@Name, country=@Country, gender=@Gender, 
                                       date_of_birth=@Dob, insurance_id=@Ins, personal_id=@Egn
                                   WHERE client_id=@Id";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text)); 
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                    cmd.Parameters.AddWithValue("@Dob", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Ins", txtInsurance.Text);
                    cmd.Parameters.AddWithValue("@Egn", txtEGN.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client Updated Successfully!");
                    LoadData();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating client: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please enter or select a Client ID to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this client?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM clients WHERE client_id=@Id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Client Deleted!");
                        LoadData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting client: " + ex.Message);
                    }

                }
            }
        }


    }
}
    