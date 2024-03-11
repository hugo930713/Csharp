using System;
using System.Windows.Forms;

namespace _0304
{
    public partial class 成績陣列 : Form
    {
        public 成績陣列()
        {
            InitializeComponent();
        }

        string[,] name = new string[50, 2];
        int[,] scores = new int[50, 2];
        int Counter = 0, math = 0, chinese = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            this.Text = Counter.ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(textBox3.Text);
                int num2 = Convert.ToInt32(textBox4.Text);

                if (num1 < 0 || num2 < 0)
                    throw new Exception("輸入字串格式不正確");

                math += num1;
                chinese += num2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            name[Counter, 0] = textBox1.Text;
            name[Counter, 1] = textBox2.Text;
            scores[Counter, 0] = Convert.ToInt32(textBox3.Text);
            scores[Counter, 1] = Convert.ToInt32(textBox4.Text);
            Counter++;

            textBox5.Text = "學號\t姓名\t國文\t數學\r\n";
            textBox6.Text = Counter.ToString();
            textBox7.Text = (chinese / Counter).ToString();
            textBox8.Text = (math / Counter).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            for (int i = 0; i < Counter; i++)
            {
                if (textBox1.Text == name[i, 0])
                {
                    textBox5.Text = "搜尋結果:\r\n 學號\t 姓名\t 國文\t 數學\r\n " + name[i, 0] + "\t" + name[i, 1] + "\t" + scores[i, 0] + "\t" + scores[i, 1] + "\r\n";
                    break;
                }
            }
            if (i > counter)  //資料不在資料庫
                MessageBox.Show("資料不存在", "搜尋學號" + textBox1.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox5.Text = "學號\t姓名\t國文\t數學\r\n"; 
            for (int i = 0; i < Counter; i++)
            {
                textBox5.Text += (name[i, 0] + "\t" + name[i, 1] + "\t" + scores[i, 0] + "\t" + scores[i, 1] + "\r\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "成績陣列";
        }
    }
}