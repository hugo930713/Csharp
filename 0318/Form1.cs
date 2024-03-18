using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace _0318
{
    public partial class Form1 : Form
    {
        int numTotal = 0;
        double distanceTotal = 0;
        string[] name = new string[100];
        int[] num = new int[100];
        double[,] coordinate = new double[100, 2];
        int Counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Excel檔案(*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
                // Encoding.Default設定中文Unicode
                String[] input = new string[4];
                // excel檔案中每一個列有4個欄位，每列存到4個字串
                double x = Convert.ToDouble(textBox2.Text);
                double y = Convert.ToDouble(textBox3.Text);
                int count = 0;
                while (sr.Peek() >= 0)
                {
                    input = sr.ReadLine().Split(',');
                    name[Counter] = input[0];
                    num[Counter] = Convert.ToInt32(input[1]);
                    coordinate[Counter, 0] = Convert.ToDouble(input[2]);
                    coordinate[Counter, 1] = Convert.ToDouble(input[3]);
                    numTotal += num[Counter];
                    distanceTotal += Math.Sqrt(Math.Pow(x - coordinate[Counter, 0], 2) + Math.Pow(y - coordinate[Counter, 1], 2));
                    Counter++;
                }
                ShowData();
                sr.Close();
            }
        }

        void ShowData()
        {
            textBox1.Text = "姓名\t需求量\tX座標\t\tY座標\r\n";
            for (int i = 0; i < Counter; i++)
                textBox1.Text += name[i] + "\t" + num[i] + "\t" + coordinate[i, 0] + "\t" + coordinate[i, 1] + "\r\n";

            textBox4.Text = "" + Counter;
            textBox5.Text = "" + numTotal;
            textBox6.Text = "" + distanceTotal / Counter;
        }
    }
}