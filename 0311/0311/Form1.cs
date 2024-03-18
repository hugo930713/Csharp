using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0311
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool start = false;
        bool[] card = new bool[52];
        int[] dealer = new int[5];
        int[] player = new int[5];
        Random ran = new Random();
        int N1, N2, d, p, dn, pn;

        string GenerateColor(int a)
        {
            string color;
            if (a <= 12)
                color = "\u2660\r\n";
            else if (a <= 25)
                color = "\u2665\r\n";
            else if (a <= 38)
                color = "\u2666\r\n";
            else
                color = "\u2663\r\n";

            if (a % 13 == 0)
                color += "A";
            else if (a % 13 == 12)
                color += "K";
            else if (a % 13 == 11)
                color += "Q";
            else if (a % 13 == 10)
                color += "J";
            else
                color += (a % 13 + 1);

            return color;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (start == false)
                {
                    d = 2; p = 2; dn = 0; pn = 0;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                    button8.Visible = false;
                    button9.Visible = false;
                    button10.Visible = false;
                    N1 = Convert.ToInt32(textBox1.Text);
                    N2 = Convert.ToInt32(textBox2.Text);
                    if (N2 > N1) throw new Exception("籌碼不足");
                    if (N2 <= 0) throw new Exception("下注籌碼不可為0");
                    textBox2.ReadOnly = true;
                    int i;
                    for (i = 0; i < 52; i++)
                        card[i] = false;
                    for (i = 0; i < 5; i++)
                    {
                        dealer[i] = -1;
                        player[i] = -1;
                    }
                    dealer[0] = ran.Next(52);
                    card[dealer[0]] = true;
                    button1.Text = "";

                    do
                    {
                        dealer[1] = ran.Next(52);
                    } while (card[dealer[1]] == true);
                    card[dealer[1]] = true;
                    button2.Text = GenerateColor(dealer[1]);

                    do
                    {
                        player[0] = ran.Next(52);
                    } while (card[player[0]] == true);
                    card[player[0]] = true;
                    button6.Text = GenerateColor(player[0]);

                    do
                    {
                        player[1] = ran.Next(52);
                    } while (card[player[1]] == true);
                    card[player[1]] = true;
                    button7.Text = GenerateColor(player[1]);

                    if (dealer[0] % 13 == 0 && dealer[1] % 13 >= 9 || dealer[0] % 13 >= 9 && dealer[1] % 13 == 0)
                        if (player[0] % 13 == 0 && player[1] % 13 >= 9 || player[0] % 13 >= 9 && player[1] % 13 == 0)
                        {
                            button1.Text = GenerateColor(dealer[0]);
                            MessageBox.Show("雙方都是Black Jack，平手!!", "和局");
                            textBox2.ReadOnly = false;
                            return;
                        }
                        else
                        {
                            button1.Text = GenerateColor(dealer[0]);
                            textBox1.Text = "" + (N1 - N2);
                            MessageBox.Show("莊家 Black Jack，你輸了" + N2 + "籌碼");
                            textBox2.ReadOnly = false;
                            return;
                        }
                    else if (player[0] % 13 == 0 && player[1] % 13 >= 9 || player[0] % 13 >= 9 && player[1] % 13 == 0)
                    {
                        button1.Text = GenerateColor(dealer[0]);
                        textBox1.Text = "" + (N1 + N2);
                        MessageBox.Show("玩家 Black Jack，你贏了" + N2 + "籌碼");
                        textBox2.ReadOnly = false;
                        return;
                    }
                    start = true;
                    if (dealer[0] % 13 < 9) dn += dealer[0] % 13 + 1; else dn += 10;
                    if (dealer[1] % 13 < 9) dn += dealer[1] % 13 + 1; else dn += 10;
                    if (player[0] % 13 < 9) pn += player[0] % 13 + 1; else pn += 10;
                    if (player[1] % 13 < 9) pn += player[1] % 13 + 1; else pn += 10;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (start == true)
                {
                    if (p == 2)
                    {
                        button8.Visible = true;
                        do
                        {
                            player[2] = ran.Next(52);
                        } while (card[player[2]] == true);
                        card[player[2]] = true;
                        button8.Text = GenerateColor(player[2]);

                        if (player[2] % 13 < 9) pn += player[2] % 13 + 1; else pn += 10;
                    }
                    if (p == 3)
                    {
                        button9.Visible = true;
                        do
                        {
                            player[3] = ran.Next(52);
                        } while (card[player[3]] == true);
                        card[player[3]] = true;
                        button9.Text = GenerateColor(player[3]);

                        if (player[3] % 13 < 9) pn += player[3] % 13 + 1; else pn += 10;
                    }
                    if (p == 4)
                    {
                        button10.Visible = true;
                        do
                        {
                            player[4] = ran.Next(52);
                        } while (card[player[4]] == true);
                        card[player[4]] = true;
                        button10.Text = GenerateColor(player[4]);
                        if (player[4] % 13 < 9) pn += player[4] % 13 + 1; else pn += 10;
                    }

                    if (pn > 21)
                    {
                        button1.Text = GenerateColor(dealer[0]);
                        MessageBox.Show("玩家爆掉，你輸了" + textBox2.Text + "籌碼", "好可惜", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "" + (N1 - N2);
                        textBox2.ReadOnly = false;
                        start = false;
                    }
                    p++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (start == true)
                {
                    button1.Text = GenerateColor(dealer[0]);
                    while (dn < 17 && dn < pn && d <= 4)
                    {
                        if (d == 2)
                        {
                            button3.Visible = true;
                            do
                            {
                                dealer[2] = ran.Next(52);
                            } while (card[dealer[2]] == true);
                            card[dealer[2]] = true;
                            button3.Text = GenerateColor(dealer[2]);
                            if (dn < pn)
                                d++;
                        }
                        else if (d == 3)
                        {
                            button4.Visible = true;
                            do
                            {
                                dealer[3] = ran.Next(52);
                            } while (card[dealer[3]] == true);
                            card[dealer[3]] = true;
                            button4.Text = GenerateColor(dealer[3]);
                            if (dn < pn)
                                d++;
                        }
                        else if (d == 4)
                        {
                            button5.Visible = true;
                            do
                            {
                                dealer[4] = ran.Next(52);
                            } while (card[dealer[4]] == true);
                            card[dealer[4]] = true;
                            button5.Text = GenerateColor(dealer[4]);
                            d++;
                        }

                        if (dealer[2] % 13 < 9) dn += dealer[2] % 13 + 1; else dn += 10;
                        if (dealer[3] % 13 < 9) dn += dealer[3] % 13 + 1; else dn += 10;
                        if (dealer[4] % 13 < 9) dn += dealer[4] % 13 + 1; else dn += 10;

                        if (dn > 21)
                        {
                            button1.Text = GenerateColor(dealer[0]);
                            MessageBox.Show("莊家爆掉，你贏了" + textBox2.Text + "籌碼", "恭喜你", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textBox1.Text = "" + (N1 + N2);
                            textBox2.ReadOnly = false;
                            start = false;
                            return; // 如果莊家爆掉，直接返回，不再执行后面的代码
                        }
                    }

                    if (dn > pn)
                    {
                        button1.Text = GenerateColor(dealer[0]);
                        MessageBox.Show("莊家點數較高，你輸了" + textBox2.Text + "籌碼", "好可惜", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox1.Text = "" + (N1 - N2);
                        textBox2.ReadOnly = false;
                        start = false;
                    }
                    else if (dn == pn)
                    {
                        button1.Text = GenerateColor(dealer[0]);
                        MessageBox.Show("雙方點數相等，平手!!", "好可惜", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBox2.ReadOnly = false;
                        start = false;
                    }
                    d++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}