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
                averagesListBox.Items.Clear(); // 清空ListBox內容

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 使用者選擇檔案後，開啟該檔案以供後續讀取
                    inputFile = File.OpenText(openFile.FileName);

                    while (!inputFile.EndOfStream)
                    {
                        // 逐行讀取檔案內容，直到檔案結束
                        line = inputFile.ReadLine();
                        line = line.Trim(); // 去除行首行尾的空白字元

                        if (string.IsNullOrEmpty(line)) continue; // 跳過空行

                        // 以冒號分割姓名與分數
                        string[] parts = line.Split(':');
                        if (parts.Length != 2)
                        {
                            // 格式錯誤時顯示警告
                            MessageBox.Show("資料格式錯誤，請檢查檔案內容。");
                            continue;
                        }

                        string name = parts[0];
                        string[] scoreStrings = parts[1].Split(',');
                        int total = 0;
                        int count = 0;

                        foreach (string scoreStr in scoreStrings)
                        {
                            int score;
                            if (int.TryParse(scoreStr.Trim(), out score))
                            {
                                total += score;
                                count++;
                            }
                            else
                            {
                                // 分數格式錯誤時顯示警告
                                MessageBox.Show($"學生 {name} 的分數格式錯誤。");
                                count = 0;
                                break;
                            }
                        }

                        if (count > 0)
                        {
                            double average = (double)total / count;
                            // 將平均分數加入ListBox中
                            averagesListBox.Items.Add($"{name} 的平均分數為：{average:F2}");
                        }
                    }

                    inputFile.Close();
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
