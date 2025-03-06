using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program5_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader inputFile; //宣告SteamReader物件
            int sum = 0; //宣告變數sum，用來存放總和
            int count = 0;
            int temp;
            try
            {
                inputFile = File.OpenText("NUMBER.txt"); //開啟檔案
                while (!inputFile.EndOfStream)//當沒有讀到檔案結尾時(代表檔案還有資料)
                {
                    count++;
                    temp=int.Parse(inputFile.ReadLine());
                    sum += temp;
                    listBox1.Items.Add(temp);
                }
                listBox1.Items.Add("總共有" + count + "個數字\n總和:" + sum);
                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
