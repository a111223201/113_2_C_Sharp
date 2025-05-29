using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GetPhoneData 方法會接收一個 CellPhone 物件作為參數，
        /// 並將使用者輸入的資料指派給該物件的屬性。
        /// </summary>
        /// <param name="phone">要設定資料的 CellPhone 物件</param>
        private void GetPhoneData(CellPhone phone)
        {
            decimal price;
            phone.Brand = brandTextBox.Text; // 從文字框取得品牌
            phone.Model = modelTextBox.Text; // 從文字框取得型號
            // 嘗試將價格從文字框轉換為 decimal，若失敗則顯示錯誤訊息
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price; // 設定價格
            }
            else
            {
                MessageBox.Show("請輸入有效的價格。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // 如果價格無效，則不繼續執行
            }

        }

        /// <summary>
        /// 當使用者按下「建立物件」按鈕時執行此事件處理方法。
        /// 會建立一個新的 CellPhone 物件。
        /// </summary>
        private void createObjectButton_Click(object sender, EventArgs e)
        {
            CellPhone myphone = new CellPhone();
            // 呼叫 GetPhoneData 方法來設定 myphone 的屬性。
            GetPhoneData(myphone);
            // 將 myphone 的資料顯示在標籤中。
            brandLabel.Text = myphone.Brand;
            modelLabel.Text = myphone.Model;
            priceLabel.Text = myphone.Price.ToString("C2"); // 格式化為貨幣格式
        }

        /// <summary>
        /// 當使用者按下「離開」按鈕時執行此事件處理方法。
        /// 會關閉目前的表單，結束程式。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束應用程式。
            this.Close();
        }
    }
}
