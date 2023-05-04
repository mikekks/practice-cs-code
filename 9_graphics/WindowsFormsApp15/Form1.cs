using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        private Random rand;
        private int x;
        private int y;

        Pen whitePen = new Pen(Color.White, 2);


        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x = (int)this.Width / 2;
            y = (int)this.Height - 140;

            DateTime currentTime = DateTime.Now;
            rand = new Random(currentTime.Millisecond);

            timer1.Interval = 2000;
            timer1.Enabled= true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen redPen = new Pen(Color.IndianRed);
            SolidBrush redBr = new SolidBrush(Color.IndianRed);
            SolidBrush whiteBr = new SolidBrush(Color.White);

            g.FillEllipse(whiteBr, x, y, 100, 100);
            y -= 80;
            x += 10;

            g.FillEllipse(whiteBr, x, y, 80, 80);
            y -= 60;
            x += 10;
            g.FillEllipse(whiteBr, x, y, 60, 60);

            g.DrawLine(redPen, x - 10, y, x + 70, y);
            g.FillRectangle(redBr, x + 10, y - 40, 40, 40);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();

            for(int i=0; i<400; i++)
            {
                x = rand.Next(1, this.Width);
                y = rand.Next(1, this.Height);
                g.DrawLine(whitePen, x, y, x + 1, y + 1);
            }
        }
    }
}
