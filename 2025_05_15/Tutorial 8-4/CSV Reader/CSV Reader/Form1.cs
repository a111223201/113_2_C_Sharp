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

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile;
                // 顯示檔案選擇對話方塊，讓使用者選擇要開啟的CSV檔案
                string line; // 儲存讀取的每一行資料
                int count = 0;
                int total = 0;
                double average;

                char[] delim = { ',',' ' }; // 定義分隔符號為逗號
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 使用者選擇檔案後，開啟該檔案以供後續讀取
                    inputFile = File.OpenText(openFile.FileName);

                    while(!inputFile.EndOfStream)
                    {
                        // 逐行讀取檔案內容，直到檔案結束
                        line = inputFile.ReadLine();
                        line = line.Trim(); // 去除行首行尾的空白字元
                        string[] tokens = line.Split(delim); // 使用分隔符號將行內容分割成字串陣列
                        total = 0; // 重置總和為0
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            // 將字串陣列中的每個元素轉換為整數，並累加計算總和與計數
                            total += int.Parse(tokens[i]);
                        }
                        average =(double)total / tokens.Length; // 計算平均值
                        //將平均分數加入Listbox中
                        averagesListBox.Items.Add("第" + (++count) + "位同學的平均分數為：" + average);
                    }
                }
                else
                {
                    // 使用者未選擇任何檔案時，顯示提示訊息
                    MessageBox.Show("未選擇任何檔案。");
                }
            }
            catch (Exception ex)
            {
                // 發生例外狀況時，顯示錯誤訊息與詳細內容
                MessageBox.Show("發生錯誤：" + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的視窗，結束程式
            this.Close();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // 此事件於檔案選擇對話方塊按下「確定」時觸發
            // 目前未實作任何功能
        }
    }
}
