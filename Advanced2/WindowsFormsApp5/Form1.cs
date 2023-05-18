using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        int num_log = 1;
        Thread thread;

        public Form1()
        {
            InitializeComponent();
            button1.Click += button_Chain;
        }

        private void button_Chain(object sender, EventArgs e)
        {
            (sender as Button).BackColor = System.Drawing.Color.Red;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
