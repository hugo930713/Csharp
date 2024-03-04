using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0226
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public Form2 preForm;

        int total = 0;
        private void UpdateTotal()
        {
            textBox1.Text = "NT$" + total.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.preForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.preForm.preForm.Close();
            this.preForm.Close();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                total += 69;
            else
                total -= 69;
            UpdateTotal();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                total += 49;
            else
                total -= 49;
            UpdateTotal();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                total += 59;
            else
                total -= 59;
            UpdateTotal();
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                total += 79;
            else
                total -= 79;
            UpdateTotal();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
            }
           else
            {
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                total += 25;
            }
            else
            {
                total -= 25;
            }
            UpdateTotal();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                total += 35;
            }
            else
            {
                total -= 35;
            }
            UpdateTotal();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                total += 25;
            }
            else
            {
                total -= 25;
            }
            UpdateTotal();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                total += 30;
            }
            else
            {
                total -= 30;
            }
            UpdateTotal();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                total += 20;
            }
            else
            {
                total -= 20;
            }
            UpdateTotal();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "NT$" + total.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Text = "點餐系統";
        }
    }
}
