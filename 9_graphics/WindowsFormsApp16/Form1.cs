﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int X = pictureBox1.Left;
            int Y = pictureBox1.Top;
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            X -= 10;

            if(X <= -pictureBox1.Width)
            {
                X = this.Width;
            }

            pictureBox1.SetBounds(X, Y, width, height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
