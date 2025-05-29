using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法會接收一個 CellPhone 物件作為參數，
        // 並將使用者於表單輸入的資料指派給該物件的屬性。
        private void GetPhoneData(CellPhone phone)
        {
            // 暫存變數：用來儲存價格的十進位數值
            decimal price;

            // 取得使用者輸入的手機品牌，並指派給 CellPhone 物件的 Brand 屬性
            phone.Brand = brandTextBox.Text;

            // 取得使用者輸入的手機型號，並指派給 CellPhone 物件的 Model 屬性
            phone.Model = modelTextBox.Text;

            // 取得使用者輸入的手機價格，若格式正確則指派給 CellPhone 物件的 Price 屬性
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 顯示錯誤訊息，提醒使用者價格輸入格式錯誤
                MessageBox.Show("價格格式無效，請輸入正確的數字。");
            }
        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone(); // 建立新的 CellPhone 物件

            GetPhoneData(myPhone); // 呼叫 GetPhoneData 方法，將使用者輸入的資料指派給 myPhone 物件

            phoneList.Add(myPhone); // 將 myPhone 物件加入到 phoneList 清單中

            // 將新手機的品牌和型號組合成字串，並加入到 phoneListBox 中
            phoneListBox.Items.Add(myPhone.Brand + " " + myPhone.Model);
            // 清空輸入欄位，準備下一次輸入
            brandTextBox.Text="";
            modelTextBox.Text = "";
            priceTextBox.Text = "";

            brandTextBox.Focus(); // 將焦點設回品牌輸入欄位
        }

        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex;

            MessageBox.Show(phoneList[index].Price.ToString("C"));// 顯示選中手機的價格，格式化為貨幣形式
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束程式
            this.Close();
        }
    }
}
