using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int[] numbers = new int[30];
            for(int i = 0; i < 30; i++)
            {
                numbers[i] = rand.Next(50);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = numbers[i] * 3;

            }
            listBox1.Items.AddRange(numbers.Select( n => n.ToString()).ToArray());
        }
    }
}
