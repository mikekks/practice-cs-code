using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        int num_log = 1;
        Thread thread;

        public delegate void DelegatePlus();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(LabelPlus));
            thread.Start();
        }

        private void LabelPlus()
        {
            while (num_log < 1000) 
            {
                label1.Invoke((DelegatePlus)(lblLogPlus), new object[] {});
            }
        }

        public void lblLogPlus()
        {
            label1.Text = (++num_log).ToString();
        }
    
    }
}
