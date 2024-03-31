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
                using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    int cn = br.ReadInt32();           // 候選人數量
                    int bn = br.ReadInt32();           // 有效選票數量
                    int[,] ballot = new int[bn, cn];   // 儲存bn張選票的選擇順序
                    int[] count = new int[cn + 1];     // 儲存每個候選人的得票數
                    bool[] remove = new bool[cn + 1];  // 儲存候選人是否被淘汰
                    int i, j, round = 1, temp = 0;     // 目前回合數

                    for (i = 0; i < bn; i++)
                        for (j = 0; j < cn; j++)
                            ballot[i, j] = br.ReadInt32();

                    for (i = 0; i <= cn; i++)
                        remove[i] = false; // 手動初始化 remove 數組

                    textBox1.Text = "";

                    while (true)
                    {
                        for (i = 0; i <= cn; i++)
                            count[i] = 0;

                        for (i = 0; i < bn; i++)
                            for (j = 0; j < cn; j++)
                                if (!remove[ballot[i, j]])
                                {
                                    count[ballot[i, j]]++;
                                    break;
                                }

                        // 若該回合沒有候選人，顯示無法決定當選者
                        temp = 0;
                        for (i = 1; i <= cn; i++)
                            if (!remove[i])
                                temp++;

                        if (temp == 0)
                        {
                            textBox1.Text += "第" + round + "回合:\r\n無法決定當選者\r\n";
                            break;
                        }

                        temp = 0;
                        for (i = 1; i <= cn; i++)
                            if (count[i] > bn / 2)
                            {
                                textBox1.Text += "第" + round + "回合:\r\n號碼" + i + "候選人過半數當選\r\n";
                                temp++;
                                break;
                            }

                        if (temp != 0)
                            break;

                        int min = int.MaxValue;
                        for (i = 1; i <= cn; i++)
                            if (!remove[i] && count[i] < min)
                                min = count[i];

                        textBox1.Text += "第" + round + "回合:\r\n";
                        for (i = 1; i <= cn; i++)
                            if (!remove[i] && count[i] == min)
                            {
                                remove[i] = true;
                                textBox1.Text += "號碼" + i + "候選人 ";
                            }
                        textBox1.Text += "本回合最低票被淘汰\r\n";

                        round++;
                        if (round > cn) // 避免無限迴圈
                            break;
                    }
                }
            }
        }
    }
}