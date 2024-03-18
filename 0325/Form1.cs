using System;
using System.IO;
using System.Windows.Forms;

namespace _0325
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "二元檔案(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                int cn = br.ReadInt32();            // 候選人數量
                int bn = br.ReadInt32();            // 有效選票數量
                int[,] ballot = new int[bn, cn];    // 儲存bn張選票的選擇順序
                int[] count = new int[cn + 1];      // 儲存每個候選人的得票數
                bool[] remove = new bool[cn + 1];   // 儲存候選人是否被淘汰
                int i, j, k, min, temp = cn, round = 1;

                for (i = 0; i < bn; i++)
                    for (j = 0; j < cn; j++)
                        ballot[i, j] = br.ReadInt32();

                for (i = 0; i <= cn; i++)
                    remove[i] = false;

                while (true)
                {
                    for (i = 0; i <= cn; i++)
                        count[i] = 0;

                    if (temp <= 0)
                    {
                        textBox1.Text += "無法決定當選者";
                        break;
                    }

                    for (i = 0; i < bn; i++)
                        for (j = 0; j < cn; j++)
                            if (remove[ballot[i, j]] == false)
                            {
                                count[ballot[i, j]]++;
                                break;
                            }
                    textBox1.Text = "第" + round + "回合:\r\n";
                    round++;

                    min = bn;
                    for (i = 1; i <= cn; i++)
                    {
                        if (count[i] < min && remove[i] == false)
                            min = count[i];
                    }

                    for (i = 1; i <= cn; i++)
                    {
                        if (count[i] == min)
                        {
                            remove[i] = true;
                            textBox1.Text += "號碼" + i + "候選人";
                        }
                    }
                    textBox1.Text += "本回合最低票被淘汰";

                    for (i = 1; i <= temp; i++)
                    {
                        if (count[i] > (bn / 2))
                        {
                            textBox1.Text += "號碼" + i + "候選人過半數當選";
                            break;
                        }
                    }
                }
                fs.Close();
                br.Close();
            }
        }
    }
}