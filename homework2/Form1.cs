using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework2
{

    public static class AgeCalculator
    {
        public static string ToAgeString(this DateTime bday)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - bday.Month;
            int years = today.Year - bday.Year;

            if (today.Day < bday.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - bday.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                                 years, (years == 1) ? "" : "s",
                                 months, (months == 1) ? "" : "s",
                                 days, (days == 1) ? "" : "s");
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int year = Int32.Parse(textBox1.Text.Trim());
            int month = Int32.Parse(textBox2.Text.Trim());
            int day = Int32.Parse(textBox3.Text.Trim());


            try
            {
                DateTime birthday = new DateTime(year, month, day);
                String age = AgeCalculator.ToAgeString(birthday);


                MessageBox.Show($"You are " + age);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}


        
            



            

            
            

            

 
