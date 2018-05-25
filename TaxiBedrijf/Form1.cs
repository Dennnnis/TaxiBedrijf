using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxiBedrijf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private int Verhoging(DateTime datum, int time)
        {
            switch(datum.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    if (time >= (22 * 60))
                        return 1;
                    break;
                case DayOfWeek.Saturday:
                    return 1;
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    if (time < 7 * 60)
                        return 1;
                    break;
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int over(int an, int am, int bn, int bm) => (Math.Min(am, bm) - Math.Max(an, bn));

            int rit_start = Convert.ToInt32(textBox1.Text) * 60 + Convert.ToInt32(textBox2.Text);
            int rit_stop = Convert.ToInt32(textBox3.Text) * 60 + Convert.ToInt32(textBox4.Text);

            int ov = Math.Max(0,over(rit_start, rit_stop, 8 * 60, 18 * 60));
            int ul = ((rit_stop - rit_start) - ov);

            float prijs = ov * 0.25f + ul * 0.45f;
            prijs = (prijs * Math.Max(1,Verhoging(dateTimePicker1.Value, rit_start) * 1.15f)) + Convert.ToInt32(textBox5.Text);

            label5.Text = "€ " + Convert.ToString(Math.Round(Math.Round(Math.Max(0,prijs),2)*20)/20);
            label7.Text = "€ " + Convert.ToString(Math.Max(0, prijs));
        }
    }
}
