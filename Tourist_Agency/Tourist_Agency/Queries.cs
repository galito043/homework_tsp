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

namespace Tourist_Agency
{
    public partial class Queries : Form
    {
        string connectionString = @"";
        public Queries()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "SELECT c.client_id, c.full_name, c.personal_id,  e.destination_country, e.destination_city FROM dbo.Orders o INNER JOIN dbo.Clients c ON o.client_id = c.client_id " +
                            "INNER JOIN dbo.Excursions e ON o.excursion_id = e.excursion_id WHERE e.excursion_start_date >= @StartDate AND e.excursion_end_date <= @EndDate";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@StartDate", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@EndDate", dateTimePicker2.Value);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "SELECT e.destination_country, e.destination_city, e.transport_price, e.food_accommodation_price, e.additional_package_price, c.insurance_id FROM dbo.Orders o " +
                            "INNER JOIN dbo.Clients c ON o.client_id = c.client_id INNER JOIN dbo.Excursions e ON o.excursion_id = e.excursion_id WHERE c.personal_id = @ClientEGN";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ClientEGN", textBox1.Text);


                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            else if (comboBox1.SelectedIndex == 2)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "SELECT o.order_number, c.full_name, c.personal_id, c.insurance_id, o.order_date, e.destination_country FROM dbo.Orders o " +
                            "INNER JOIN dbo.Clients c ON o.client_id = c.client_id INNER JOIN dbo.Excursions e ON o.excursion_id = e.excursion_id " +
                            "WHERE c.personal_id LIKE @SearchText";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SearchText", textBox1.Text);


                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            else if (comboBox1.SelectedIndex == 3)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "SELECT o.order_number, c.full_name, c.personal_id, c.insurance_id, o.order_date, e.destination_country FROM dbo.Orders o " +
                            "INNER JOIN dbo.Clients c ON o.client_id = c.client_id INNER JOIN dbo.Excursions e ON o.excursion_id = e.excursion_id " +
                            "WHERE c.insurance_id LIKE @SearchText";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SearchText", textBox1.Text);


                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            else if (comboBox1.SelectedIndex == 4)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "SELECT o.order_number, c.full_name, c.personal_id, c.insurance_id, o.order_date, e.destination_country FROM dbo.Orders o " +
                            "INNER JOIN dbo.Clients c ON o.client_id = c.client_id INNER JOIN dbo.Excursions e ON o.excursion_id = e.excursion_id " +
                            "WHERE o.order_date = @SearchDate";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@SearchDate", dateTimePicker1.Value.Date);


                        SqlDataAdapter da = new SqlDataAdapter(cmd);
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
        }

        private void Queries_Load(object sender, EventArgs e)
        {

        }
    }
}
