using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace File_To_Array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getValuesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 建立一個常數來定義陣列的大小
                const int SIZE = 5;
                // 建立一個整數陣列來存放從檔案中讀取的數值
                int[] numbers = new int[SIZE];

                // 用於迴圈的計數變數，初始化為0
                int index = 0;

                // 宣告一個 StreamReader 變數，用於讀取檔案
                StreamReader inputFile;

                // 開啟檔案並取得 StreamReader 物件，檔案名稱為 "Values.txt"
                inputFile = File.OpenText("Values.txt");

                // 使用迴圈將檔案的內容讀取到陣列中
                // 當前索引小於陣列長度且未到達檔案結尾時繼續迴圈
                while (index < numbers.Length && !inputFile.EndOfStream)
                {
                    // 讀取檔案中的一行文字，將其轉換為整數並存入陣列中
                    numbers[index] = int.Parse(inputFile.ReadLine());
                    // 將索引值加1
                    index++;
                }

                // 讀取完畢後關閉檔案
                inputFile.Close();

                // 將陣列中的數值顯示在列表框中
                foreach (int value in numbers)
                {
                    outputListBox.Items.Add(value);
                }
            }
            catch (Exception ex)
            {
                // 如果發生例外，顯示錯誤訊息
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
