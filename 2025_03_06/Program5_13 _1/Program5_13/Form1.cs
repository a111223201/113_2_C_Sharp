using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program5_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter outputFile = new StreamWriter(saveFileDialog1.FileName)) // 使用 SaveFileDialog 指定的檔案
                    {
                        if (int.TryParse(textBox1.Text, out int count)) // 直接在此宣告 count
                        {
                            Random rand = new Random(); // 確保 rand 已宣告
                            for (int i = 0; i < count; i++)
                            {
                                outputFile.WriteLine(rand.Next(100) + 1);
                            }
                            MessageBox.Show("檔案已建立");
                        }
                        else
                        {
                            MessageBox.Show("請輸入有效的數字");
                        }
                    } // using 會自動關閉檔案
                }
                else
                {
                    MessageBox.Show("你按下取消");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤：" + ex.Message); // 顯示更友善的錯誤訊息
            }

        }
    }
    }
