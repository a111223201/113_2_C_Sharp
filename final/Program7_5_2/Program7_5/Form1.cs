using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 使用 List 來存放球隊與冠軍資料
        List<string> teamList = new List<string>();
        List<string> winnerList = new List<string>();

        // 表單載入時執行，呼叫讀取球隊與冠軍資料的方法
        private void Form1_Load(object sender, EventArgs e)
        {
            readTeams();
            readWinner();
        }

        // 讀取 Teams.txt 檔案，將所有球隊名稱加入 listBox1 並存入 teamList
        private void readTeams()
        {
            MessageBox.Show("請開啟隊伍檔案");
            try
            {
                StreamReader inputFile;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);

                    teamList.Clear();
                    listBox1.Items.Clear();

                    // 逐行讀取檔案，並將每一行加入 listBox1 及 teamList
                    string line;
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        listBox1.Items.Add(line);
                        teamList.Add(line);
                    }

                    inputFile.Close();
                }
            }
            catch (Exception ex)
            {
                // 若發生例外，顯示錯誤訊息（以繁體中文顯示）
                MessageBox.Show("發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 讀取 WorldSeries.txt 檔案，將所有冠軍球隊名稱存入 winnerList
        private void readWinner()
        {
            MessageBox.Show("請開啟世界大賽冠軍隊伍檔案");
            try
            {
                StreamReader inputFile;
                if (openFile2.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile2.FileName);

                    winnerList.Clear();

                    // 逐行讀取 WorldSeries.txt，將每一行（冠軍球隊名稱）存入 winnerList  
                    string line;
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine().Trim();
                        winnerList.Add(line);
                    }
                    inputFile.Close(); // 關閉檔案  
                }
            }
            catch (Exception ex)
            {
                // 若發生例外，顯示錯誤訊息（以繁體中文顯示）  
                MessageBox.Show("發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 當使用者在 listBox1 選取球隊時，計算該球隊奪冠次數並顯示於 label1，並列出奪冠年份
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            int numWin = 0;
            List<int> years = new List<int>();
            // 逐一比對 winnerList，計算選取球隊的奪冠次數，並記錄年份
            // WorldSeries.txt 第一行代表1903年，依序往後，跳過1904與1994年（這兩年未舉辦）
            int year = 1903;
            int winnerIndex = 0;
            while (winnerIndex < winnerList.Count)
            {
                // 1904年與1994年未舉辦世界大賽，需跳過
                if (year == 1904 || year == 1994)
                {
                    year++;
                    continue;
                }
                if (str == winnerList[winnerIndex])
                {
                    numWin++;
                    years.Add(year);
                }
                year++;
                winnerIndex++;
            }
            // 以繁體中文顯示該球隊奪冠次數與年份
            if (numWin > 0)
            {
                label1.Text = str + " 從 1903 年到 2009 年共獲得 " + numWin + " 次世界大賽冠軍。\n奪冠年份：\n" + string.Join("、", years);
            }
            else
            {
                label1.Text = str + " 從 1903 年到 2009 年未曾獲得世界大賽冠軍。";
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請開啟2010年以後的MLB冠軍隊伍檔案");
            try
            {
                StreamReader inputFile;
                if (openFile3.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile3.FileName);

                    // 讀取2010年以後的冠軍隊伍資料，並加入 winnerList
                    List<string> newWinners = new List<string>();
                    string line;
                    while ((line = inputFile.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (!string.IsNullOrEmpty(line))
                        {
                            newWinners.Add(line);
                            winnerList.Add(line);
                        }
                    }
                    inputFile.Close();

                    // 將新隊伍名稱加入 teamList（若尚未存在）
                    foreach (string team in newWinners)
                    {
                        if (!teamList.Contains(team))
                        {
                            teamList.Add(team);
                        }
                    }

                    // 重新整理 listBox1 顯示所有球隊名稱
                    listBox1.Items.Clear();
                    foreach (string team in teamList)
                    {
                        listBox1.Items.Add(team);
                    }

                    MessageBox.Show("資料已成功更新！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // 若發生例外，顯示錯誤訊息（以繁體中文顯示）  
                MessageBox.Show("發生錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            // 儲存 teamList 到 openFile  
            if (!string.IsNullOrEmpty(openFile.FileName))
            {
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(openFile.FileName))
                    {
                        foreach (string team in teamList)
                        {
                            outputFile.WriteLine(team);
                        }
                    }
                    MessageBox.Show("隊伍資料已成功儲存！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"儲存隊伍資料時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("未指定隊伍檔案，無法儲存資料。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 儲存 winnerList 到 openFile2  
            if (!string.IsNullOrEmpty(openFile2.FileName))
            {
                try
                {
                    using (StreamWriter outputFile = new StreamWriter(openFile2.FileName))
                    {
                        foreach (string winner in winnerList)
                        {
                            outputFile.WriteLine(winner);
                        }
                    }
                    MessageBox.Show("冠軍資料已成功儲存！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"儲存冠軍資料時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("未指定冠軍檔案，無法儲存資料。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 關閉表單  
            this.Close();
        }
    }
}
