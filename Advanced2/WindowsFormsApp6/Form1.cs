using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        async private void button1_Click(object sender, EventArgs e)
        {
            ulong t1 = await Task<ulong>.Factory.StartNew(() =>
            {
                ulong acc = 0;
                ulong n = 10001;
                for(ulong i=0; i<n; i++)
                {
                    for(ulong j=0; j<n; j++) {
                        acc += i * j + 1;
                    }
                    label1.Invoke((MethodInvoker)(() => label1.Text = string.Format("{0:N0}", acc)));
                    progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = Convert.ToInt32(i * 100.0 / n)));
                }
                return acc;
            });

            label1.Text = string.Format("{0:N0}", t1);

        }
    }
}
