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

            // 2. Show it to the user
            clientsWindow.Show();
        }
    }
}
