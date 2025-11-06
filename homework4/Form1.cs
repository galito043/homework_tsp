using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string textToCheck = textBox1.Text;

            if (radioButton1.Checked)
            {
                if (Regex.IsMatch(textToCheck, "^\\d{2}(0[1-9]|1[0-2]|4[1-9]|5[0-2])(0[1-9]|[12]\\d|3[01])\\d{4}$"))
                {
                    MessageBox.Show("ЕГН е валидно");
                }
                else
                {
                    MessageBox.Show("ЕГН не е валидно!");
                }
            }
            else if (radioButton2.Checked) {
                if (Regex.IsMatch(textToCheck, "^[789]\\d{9}$"))
                {
                    MessageBox.Show("ЛНЧ е валиден");
                }
                else
                {
                    MessageBox.Show("ЛНЧ не е валиден!");
                }
            }
            else if (radioButton3.Checked) {
                if (Regex.IsMatch(textToCheck, "^\\d{9}(\\d{4})?$"))
                {
                    MessageBox.Show("Булстатът е валиден ");
                }
                else
                {
                    MessageBox.Show("Булстат не е валиден!");
                }
            }

            
        }
    }
}
