using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            decimal totalSales;
            decimal bookSales;
            decimal periodicalSales;
            decimal foodSales;

            try
            {
                bookSales = Decimal.Parse(booksTB.Text);
                try
                {
                    periodicalSales = Decimal.Parse(periodicalsTB.Text);
                    try
                    {
                        foodSales = Decimal.Parse(foodsTB.Text);
                        totalSales = bookSales + periodicalSales + foodSales;

                        SolidBrush bookBr = new SolidBrush(Color.Blue);
                        SolidBrush periodicalBr = new SolidBrush(Color.Yellow);
                        SolidBrush foodBr = new SolidBrush(Color.Red);

                        if(totalSales != 0)
                        {
                            int endBook = (int)(bookSales / totalSales * 360);
                            g.FillPie(bookBr, 200, 160, 100, 100, 0, endBook);
                            int endPeriodical = (int)(periodicalSales / totalSales * 360);
                            g.FillPie(periodicalBr, 200, 160, 100, 100, endBook, endPeriodical);
                            int endFood = (int)(foodSales / totalSales * 360);
                            g.FillPie(foodBr, 200, 160, 100, 100, endBook + endPeriodical, endFood);
                        }
                    }
                    catch {
                        MessageBox.Show("invalid");
                    }
                }
                catch
                {
                    MessageBox.Show("invalid2");

                }
            }
            catch
            {
                MessageBox.Show("invalid3");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SolidBrush clearBrush = new SolidBrush(Form1.DefaultBackColor);
            Graphics g = this.CreateGraphics();

            booksTB.Clear();
            periodicalsTB.Clear();
            foodsTB.Clear();

            booksTB.Focus();

            g.FillEllipse(clearBrush, 130, 110, 100, 100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
