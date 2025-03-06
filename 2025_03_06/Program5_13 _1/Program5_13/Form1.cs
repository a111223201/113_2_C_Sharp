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
            Random rand = new Random();
            StringWriter outputFile; //宣告StreamWriter物件
            int count;

            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    outputFile = File.CreateText("number.txt");
                    if (int.TryParse(textBox1.Text, out count))
                    {
                        for (int i = 0; i < count; i++)
                        {
                            outputFile.WriteLine(rand.Next(100) + 1);
                        }
                        outputFile.Close();
                        MessageBox.Show("檔案已建立");
                    }
                    else
                    {
                        MessageBox.Show("請輸入數字");
                    }

                }
                else
                {
                    MessageBox.Show("你按下取消");
                }
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); //顯示錯誤訊息
            }
        }
    }
}
