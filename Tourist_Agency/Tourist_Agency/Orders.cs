using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tourist_Agency
{
    public partial class Orders : Form
    {
        string connectionString = @"";
        public Orders()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Orders", con);
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
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int clientId = Int32.Parse(textBox2.Text);
            int excursion = Int32.Parse(textBox3.Text);
            DateTime dateTime = dateTimePicker1.Value;





            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"INSERT INTO Orders ( excursion_id,client_id, order_date) VALUES ( @ex_id,@c_id,@date)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@c_id", clientId);
                    cmd.Parameters.AddWithValue("@ex_id", excursion);
                    cmd.Parameters.AddWithValue("@date", dateTime);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Added Successfully");
                    LoadData();
                    ClearFields();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding order: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ex_id = textBox2.Text;
            string c_id = textBox3.Text;
            DateTime date = dateTimePicker1.Value;
            int id = Int32.Parse(textBox1.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"UPDATE Orders 
                            SET excursion_id=@ex_id, client_id=@c_id, order_date=@date
                            WHERE order_id=@id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ex_id", ex_id);
                    cmd.Parameters.AddWithValue("@c_id", c_id);
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@id", id);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Updated Successfully");
                    LoadData();
                    ClearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating order: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter or select an order id to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this order?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM orders WHERE order_id=@Id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("order Deleted!");
                        LoadData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting order: " + ex.Message);
                    }

                }
            }
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
