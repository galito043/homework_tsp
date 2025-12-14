using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tourist_Agency
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void customers_Click(object sender, EventArgs e)
        {
            Clients clientsWindow = new Clients();


            clientsWindow.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excursions excursions = new Excursions();
            excursions.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Queries queries = new Queries();
            queries.Show();
        }
    }
}
