using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法接受一個字串作為參數，
        // 並檢查該字串是否包含 10 個數字。
        // 如果字串包含 10 個數字，則回傳 true；
        // 否則回傳 false。
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10;
            // 檢查字串長度是否為 10。
            if(str.Length ==VALID_LENGTH)
            {
                // 檢查字串中的每個字元是否為數字。
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        // TelephoneFormat 方法接受一個字串參數（以引用方式傳遞），
        // 並將該字串格式化為電話號碼的形式。
        // 格式化後的電話號碼形式為 (XX) XXXX-XXXX。
        private void TelephoneFormat(ref string str)
        {
            if(str.Length == 10)
            {
                // 將字串格式化為電話號碼的形式。
                str = "(" + str.Substring(0, 2) + ") " + str.Substring(2, 4) + "-" + str.Substring(6, 4);
            }
        }

        // 當使用者按下「格式化」按鈕時，執行此事件處理方法。
        // 該方法會檢查輸入的字串是否有效，並嘗試將其格式化為電話號碼。
        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;
            if (IsValidNumber(input))
            {
                TelephoneFormat(ref input);
                MessageBox.Show("格式化後的電話號碼為：" + input, "格式化結果");
            }
            else
            {
                MessageBox.Show("請輸入 10 位數字。", "錯誤");
            }
        }

        // 當使用者按下「退出」按鈕時，執行此事件處理方法。
        // 該方法會關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
