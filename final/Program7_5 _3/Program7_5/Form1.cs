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

        // 定義 TeamData 結構，包含球隊名稱、獲勝次數、獲勝年份清單
        struct TeamData
        {
            public string Name;           // 球隊名稱
            public int WinCount;          // 獲勝次數
            public List<int> WinYears;    // 獲勝年份清單
        }

        List<string> teamList = new List<string>();
        List<string> winnerList = new List<string>();
        List<TeamData> teamDataList = new List<TeamData>(); // 儲存所有球隊與冠軍資料的清單

        // 表單載入時執行，呼叫讀取球隊與冠軍資料的方法
        private void Form1_Load(object sender, EventArgs e)
        {
            readTeams();
            readWinner();
            buildTeamDataList();
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

        // 建立 teamDataList，計算每支球隊的獲勝次數與年份
        private void buildTeamDataList()
        {
            teamDataList.Clear();
            foreach (string team in teamList)
            {
                TeamData data = new TeamData();
                data.Name = team;
                data.WinCount = 0;
                data.WinYears = new List<int>();

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
                    if (team == winnerList[winnerIndex])
                    {
                        data.WinCount++;
                        data.WinYears.Add(year);
                    }
                    year++;
                    winnerIndex++;
                }
                teamDataList.Add(data);
            }
        }

        // 當使用者在 listBox1 選取球隊時，顯示該隊伍的獲勝次數與年份（資料來源為 teamDataList）
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            // 從 teamDataList 找到對應球隊的 TeamData
            TeamData? found = null;
            foreach (var data in teamDataList)
            {
                if (data.Name == str)
                {
                    found = data;
                    break;
                }
            }
            if (found.HasValue)
            {
                if (found.Value.WinCount > 0)
                {
                    label1.Text = str + " 從 1903 年到 2009 年共獲得 " + found.Value.WinCount + " 次世界大賽冠軍。\n奪冠年份：\n" + string.Join("、", found.Value.WinYears);
                }
                else
                {
                    label1.Text = str + " 從 1903 年到 2009 年未曾獲得世界大賽冠軍。";
                }
            }
            else
            {
                label1.Text = "查無此球隊資料。";
            }
        }
    }
}
