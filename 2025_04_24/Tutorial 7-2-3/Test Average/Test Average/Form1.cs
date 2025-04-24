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

namespace Test_Average
{
    public partial class Form1 : Form
    {
        private List<int> testScores = new List<int>(); // 用於存儲測試分數的列表

        public Form1()
        {
            InitializeComponent();
        }

        // Average 方法接受一個 int 陣列參數
        // 並返回該陣列中所有值的平均值。
        private double Average(int[] scores)
        {
            int total = 0;
            foreach (int score in scores)
            {
                total += score;
            }
            return (double)total / scores.Length;
        }

        // Highest 方法接受一個 int 陣列參數
        // 並返回該陣列中的最高值。
        private int Highest(int[] scores)
        {
            int highest = scores[0];
            foreach (int score in scores)
            {
                if (score > highest)
                {
                    highest = score;
                }
            }
            return highest;
        }

        // Lowest 方法接受一個 int 陣列參數
        // 並返回該陣列中的最低值。
        private int Lowest(int[] scores)
        {
            int lowest = scores[0];
            foreach (int score in scores)
            {
                if (score < lowest)
                {
                    lowest = score;
                }
            }
            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48;
            int[] scoresArray = new int[SIZE];
            int index = 0;
            int highestScore = 0;
            int lowestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 打開文件。
                    inputFile = File.OpenText(openFile.FileName);
                    // 清空 testScoresListBox 和 testScores 列表。
                    testScoresListBox.Items.Clear();
                    testScores.Clear();
                    // 從文件中讀取測試分數。
                    while (!inputFile.EndOfStream && index < SIZE)
                    {
                        int score = int.Parse(inputFile.ReadLine());
                        scoresArray[index] = score;
                        testScores.Add(score);
                        // 將分數添加到 testScoresListBox。
                        testScoresListBox.Items.Add(score);
                        index++;
                    }
                    inputFile.Close();
                    // 計算平均分數、最高分數和最低分數。
                    averageScore = Average(scoresArray);
                    highestScore = Highest(scoresArray);
                    lowestScore = Lowest(scoresArray);
                    // 顯示結果。
                    averageScoreLabel.Text = averageScore.ToString("n1");
                    highScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息。
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            // 確保 testScoresListBox 中有數據
            if (testScores.Count > 0)
            {
                // 將分數排序
                List<int> sortedScores = new List<int>(testScores);
                sortedScores.Sort();

                // 清空 sortedScoresListBox 並顯示排序後的分數
                sortedScoresListBox.Items.Clear();
                foreach (int score in sortedScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }
            }
            else
            {
                MessageBox.Show("請先載入測試分數！", "提示");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // 確保有選中的項目
            if (testScoresListBox.SelectedIndex != -1)
            {
                // 取得選中的索引位置
                int selectedIndex = testScoresListBox.SelectedIndex;

                // 從 testScores 列表中移除該索引位置的分數
                testScores.RemoveAt(selectedIndex);

                // 更新 testScoresListBox
                testScoresListBox.Items.Clear();
                foreach (int score in testScores)
                {
                    testScoresListBox.Items.Add(score);
                }

                // 更新 sortedScoresListBox
                List<int> sortedScores = new List<int>(testScores);
                sortedScores.Sort();
                sortedScoresListBox.Items.Clear();
                foreach (int score in sortedScores)
                {
                    sortedScoresListBox.Items.Add(score);
                }
            }
            else
            {
                // 如果未選擇任何項目，顯示提示訊息。
                MessageBox.Show("請選擇要刪除的分數！", "提示");
            }
        }
    }
}
