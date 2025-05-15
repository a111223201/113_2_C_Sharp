using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_List
{
    struct Automobile
    {
        public string make;
        public int year;
        public double mileage;
    }

    public partial class Form1 : Form
    {
        // 建立一個用來儲存汽車資訊的 List，作為類別的欄位。
        private List<Automobile> carList = new List<Automobile>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetData 方法會取得使用者輸入的資料，
        // 並將這些資料指派給傳入參數 auto 的各個欄位。
        private void GetData(ref Automobile auto)
        {
            try
            {
                // 從三個 TextBox 取得使用者輸入的資料，並轉型後存入 auto 結構。
                auto.make = makeTextBox.Text;
                auto.year = int.Parse(yearTextBox.Text);
                auto.mileage = double.Parse(mileageTextBox.Text);
            }
            catch (Exception ex)
            {
                // 若發生例外，顯示錯誤訊息（以繁體中文顯示）。
                MessageBox.Show("輸入資料格式錯誤：" + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 當使用者按下「新增汽車」按鈕時執行此事件處理函式
        private void addButton_Click(object sender, EventArgs e)
        {
            // 建立一個 Automobile 結構的實例，用來存放單一汽車資料。
            Automobile car = new Automobile();

            // 取得使用者輸入的資料，並存入 car 結構。
            GetData(ref car);

            // 將 car 結構加入 carList 清單中，儲存所有汽車資料。
            carList.Add(car);

            // 清空三個 TextBox，方便使用者繼續輸入下一筆資料。
            makeTextBox.Clear();
            yearTextBox.Clear();
            mileageTextBox.Clear();

            // 將游標焦點移回廠牌輸入框，提升使用者體驗。
            makeTextBox.Focus();
        }

        // 當使用者按下「顯示清單」按鈕時執行此事件處理函式
        private void displayButton_Click(object sender, EventArgs e)
        {
            // 宣告一個字串變數 output，用來儲存每一行要顯示的汽車資訊。
            string output;

            // 清除 ListBox 目前的所有內容，避免重複顯示。
            carListBox.Items.Clear();

            // 逐一將 carList 清單中的每一筆汽車資料格式化後顯示在 ListBox。
            foreach (Automobile aCar in carList)
            {
                // 將汽車年份、廠牌與里程數組合成一行字串（以繁體中文顯示）。
                output = aCar.year + " 年 " + aCar.make +
                    "，里程數：" + aCar.mileage + " 英里";

                // 將格式化後的字串加入 ListBox 顯示。
                carListBox.Items.Add(output);
            }
        }
    }
}
