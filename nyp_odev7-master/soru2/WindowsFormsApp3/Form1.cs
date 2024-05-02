using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        internal double BeverageValue = 0.00;
        internal double AppetizerValue = 0.00;
        internal double Main_CourseValue = 0.00;
        internal double DessertValue = 0.00;
        internal double toplam = 0;

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Soda")
            {
                BeverageValue = 1.95;
            }

            if (comboBox1.Text == "Tea")
            {
                BeverageValue = 1.50;
            }

            if (comboBox1.Text == "Coffee")
            {
                BeverageValue = 1.25;
            }

            if (comboBox1.Text == "Mineral Water")
            {
                BeverageValue = 2.95;
            }

            if (comboBox1.Text == "Juice")
            {
                BeverageValue = 2.50;
            }

            if (comboBox1.Text == "Milk")
            {
                BeverageValue = 1.50;
            }

            if (comboBox1.Text == "No Selection")
            {
                BeverageValue = 0.00;
            }

            label5.Text = "Subtotal: " + "$" + (BeverageValue + AppetizerValue + Main_CourseValue + DessertValue).ToString();
            label6.Text = "Tax: " + "$" + ((BeverageValue + AppetizerValue + Main_CourseValue + DessertValue) / 10).ToString();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Buffalo Wings")
            {
                AppetizerValue = 5.95;
            }

            if (comboBox2.Text == "Buffalo Fingers")
            {
                AppetizerValue = 6.95;
            }

            if (comboBox2.Text == "Potato Skins")
            {
                AppetizerValue = 8.95;
            }

            if (comboBox2.Text == "Nachos")
            {
                AppetizerValue = 8.95;
            }

            if (comboBox2.Text == "Mushroom Caps")
            {
                AppetizerValue = 10.95;
            }

            if (comboBox2.Text == "Shrimp Cocktail")
            {
                AppetizerValue = 12.95;
            }

            if (comboBox2.Text == "Chips and Salsa")
            {
                AppetizerValue = 6.95;
            }

            if (comboBox2.Text == "No Selection")
            {
                AppetizerValue = 0.00;
            }

            label5.Text = "Subtotal: " + "$" + (BeverageValue + AppetizerValue + Main_CourseValue + DessertValue).ToString();
            label6.Text = "Tax: " + "$" + ((BeverageValue + AppetizerValue + Main_CourseValue + DessertValue) / 10).ToString();
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Seafood Alfredo")
            {
                Main_CourseValue = 15.95;
            }

            if (comboBox3.Text == "Chicken Alfredo")
            {
                Main_CourseValue = 13.95;
            }

            if (comboBox3.Text == "Chicken Picatta")
            {
                Main_CourseValue = 13.95;
            }

            if (comboBox3.Text == "Turkey Club")
            {
                Main_CourseValue = 11.95;
            }

            if (comboBox3.Text == "Lobster Pie")
            {
                Main_CourseValue = 19.95;
            }

            if (comboBox3.Text == "Prime Rib")
            {
                Main_CourseValue = 20.95;
            }

            if (comboBox3.Text == "Shrimp Scampi")
            {
                Main_CourseValue = 18.95;
            }

            if (comboBox3.Text == "Turkey Dinner")
            {
                Main_CourseValue = 13.95;
            }

            if (comboBox3.Text == "Stuffed Chicken")
            {
                Main_CourseValue = 14.95;
            }

            if (comboBox3.Text == "No Selection")
            {
                Main_CourseValue = 0.00;
            }

            label5.Text = "Subtotal: " + "$" + (BeverageValue + AppetizerValue + Main_CourseValue + DessertValue).ToString();
            label6.Text = "Tax: " + "$" + ((BeverageValue + AppetizerValue + Main_CourseValue + DessertValue) / 10).ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Apple Pie")
            {
                DessertValue = 5.95;
            }

            if (comboBox4.Text == "Sundae")
            {
                DessertValue = 3.95;
            }

            if (comboBox4.Text == "Carrot Cake")
            {
                DessertValue = 5.95;
            }

            if (comboBox4.Text == "Mud Pie")
            {
                DessertValue = 4.95;
            }

            if (comboBox4.Text == "Apple Crisp")
            {
                DessertValue = 5.95;
            }

            if (comboBox4.Text == "No Selection")
            {
                DessertValue = 0.00;
            }

            label5.Text = "Subtotal: " + "$" + (BeverageValue + AppetizerValue + Main_CourseValue + DessertValue).ToString();
            label6.Text = "Tax: " + "$" + ((BeverageValue + AppetizerValue + Main_CourseValue + DessertValue) / 10).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toplam += BeverageValue + AppetizerValue + Main_CourseValue + DessertValue;
            label7.Text = "Total: " + "$" + (toplam+(toplam/10)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            label5.Text = "Subtotal: " + "$" + "0.00";
            label6.Text = "Tax: " + "$" + "0.00";
            label7.Text = "Total: " + "$" + "0.00";
            BeverageValue = 0.00;
            AppetizerValue = 0.00;
            Main_CourseValue = 0.00;
            DessertValue = 0.00;
            toplam = 0;
        }
    }
}


   
