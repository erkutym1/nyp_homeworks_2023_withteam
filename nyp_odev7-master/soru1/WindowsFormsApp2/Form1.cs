using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        Pen kalem;
        bool ciziyor = false;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            kalem = new Pen(Color.Black, 7);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ciziyor = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(ciziyor && x!=-1 && y!=-1)
            {
                g.DrawLine(kalem, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            ciziyor &= false;
            x = -1;
            y = -1;
        }

        private void Red_CheckedChanged(object sender, EventArgs e)
        {
            kalem.Color = Color.Red;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            kalem.Color = Color.Blue;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            kalem.Color = Color.Green;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            kalem.Color = Color.Black;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            kalem.Width = 2;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            kalem.Width = 7;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            kalem.Width = 12;
        }
    }
}
