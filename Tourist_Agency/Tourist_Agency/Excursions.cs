using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Xml.Linq;

namespace Tourist_Agency
{
    public partial class Excursions : Form
    {
        string connectionString = @"";

        public Excursions()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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

                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Excursions", con);
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
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string destination_country = textBox2.Text;
            string destination_city = textBox3.Text;
            DateTime start_date = dateTimePicker1.Value;
            DateTime end_date = dateTimePicker2.Value;
            double transport_price = Double.Parse(textBox4.Text);
            double excursion_price = Double.Parse(textBox5.Text);
            double additional_price = Double.Parse(textBox6.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"INSERT INTO EXCURSIONS (destination_country, destination_city,excursion_start_date,
excursion_end_date, transport_price, food_accommodation_price, additional_package_price) VALUES (@destination_country, @destination_city, @start_date, @end_date, @t_price, @f_price, @add_price)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@destination_country", destination_country);
                    cmd.Parameters.AddWithValue("@destination_city", destination_city);
                    cmd.Parameters.AddWithValue("@start_date", start_date);
                    cmd.Parameters.AddWithValue("@end_date", end_date);
                    cmd.Parameters.AddWithValue("@t_price", transport_price);
                    cmd.Parameters.AddWithValue("@f_price", excursion_price);
                    cmd.Parameters.AddWithValue("@add_price", additional_price);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Excursion Added Successfully");
                    LoadData();
                    ClearFields();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding excursion: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)

        {
            string destination_country = textBox2.Text;
            string destination_city = textBox3.Text;
            DateTime start_date = dateTimePicker1.Value;
            DateTime end_date = dateTimePicker2.Value;
            double transport_price = Double.Parse(textBox4.Text);
            double excursion_price = Double.Parse(textBox5.Text);
            double additional_price = Double.Parse(textBox6.Text);
            int id = Int32.Parse(textBox1.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = @"UPDATE EXCURSIONS 
                                   SET destination_country=@d_country, destination_city=@d_city, excursion_start_date=@s_date,
                                        excursion_end_date=@e_date, transport_price=@t_price, food_accommodation_price=@f_price, additional_package_price=@add_price
                                   WHERE excursion_id=@id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@d_country", destination_country);
                    cmd.Parameters.AddWithValue("@d_city", destination_city);
                    cmd.Parameters.AddWithValue("@s_date", start_date);
                    cmd.Parameters.AddWithValue("@e_date", end_date);
                    cmd.Parameters.AddWithValue("@t_price", transport_price);
                    cmd.Parameters.AddWithValue("@f_price", excursion_price);
                    cmd.Parameters.AddWithValue("@add_price", additional_price);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Excursion Updated Successfully");
                    LoadData();
                    ClearFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating excursion: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter or select an excursion id to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this excursion?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        string query = "DELETE FROM excursions WHERE excursion_id=@Id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("excursion Deleted!");
                        LoadData();
                        ClearFields();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting excursion: " + ex.Message);
                    }

                }
            }
        }
    }
}
