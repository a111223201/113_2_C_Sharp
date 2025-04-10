using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5; // 定義樂透號碼陣列的大小為5
            int[] lotteryNumbers = new int[SIZE]; // 宣告一個整數陣列來儲存樂透號碼
            Random rand = new Random(); // 建立一個Random物件來產生亂數

            // 使用迴圈產生5個樂透號碼
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                // 產生範圍在1到42之間的亂數，並確認產生的亂數沒有與陣列中德元素重複，再放入陣列中
                int number;
                do
                {
                    number = rand.Next(1, 43); // 產生1到42之間的亂數
                } while (lotteryNumbers.Contains(number)); // 確認產生的號碼不重複
                lotteryNumbers[i] = number; // 將產生的號碼放入陣列中
            }

            //將lotteryNumbers 陣列中的數字由小到大排序
            Array.Sort(lotteryNumbers);


            //firstLabel.Text = lotteryNumbers[0].ToString(); // 顯示第一個樂透號碼
            //secondLabel.Text = lotteryNumbers[1].ToString(); // 顯示第二個樂透號碼
            //thirdLabel.Text = lotteryNumbers[2].ToString(); // 顯示第三個樂透號碼
            //fourthLabel.Text = lotteryNumbers[3].ToString(); // 顯示第四個樂透號碼
            //fifthLabel.Text = lotteryNumbers[4].ToString(); // 顯示第五個樂透號碼

            // 宣告一個Label陣列來儲存顯示樂透號碼的標籤
            Label[] showLabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };

            // 使用迴圈將樂透號碼顯示在對應的標籤上
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                showLabels[i].Text = lotteryNumbers[i].ToString(); // 將樂透號碼轉換成字串並顯示在標籤上
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
