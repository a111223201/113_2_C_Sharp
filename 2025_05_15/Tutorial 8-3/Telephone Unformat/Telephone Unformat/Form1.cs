using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // `IsValidFormat` 方法接受一個字串參數，並檢查該字串是否符合美國電話號碼的格式。
        private bool IsValidFormat(string str)
        {
            // 檢查字串是否為空或長度不符合
            if (string.IsNullOrEmpty(str) || str.Length != 13)
                return false;

            // 檢查格式是否符合 (XX)XXXX-XXXX
            if (str[0] == '(' && char.IsDigit(str[1]) && char.IsDigit(str[2]) && str[3] == ')' &&
                char.IsDigit(str[4]) && char.IsDigit(str[5]) && char.IsDigit(str[6]) && char.IsDigit(str[7]) &&
                str[8] == '-' && char.IsDigit(str[9]) && char.IsDigit(str[10]) && char.IsDigit(str[11]) && char.IsDigit(str[12]))
            {
                return true;
            }

            return false;
        }

        // `Unformat` 方法接受一個字串參數（以參考方式傳遞），該字串假設為格式化的電話號碼。
        // 格式化的電話號碼形式為：(XX)XXXX-XXXX。
        // 此方法的功能是移除字串中的括號 `()` 和連字號 `-`，將其轉換為純數字的形式。
        // 例如，輸入 "(12)3456-7890" 後，字串將被修改為 "1234567890"。
        private void Unformat(ref string str)
        {
            // 移除括號和連字號
            //str = str.Replace("(", "").Replace(")", "").Replace("-", "");
            str =str.Remove(0, 1); // 移除第一個字元 '('
            str = str.Remove(2, 1); // 移除第三個字元 ')'
            str = str.Remove(6, 1); // 移除第八個字元 '-'
        }

        // `unformatButton_Click` 方法是當使用者按下「去除格式」按鈕時觸發的事件處理程式。
        // 此方法的功能是：
        // 1. 取得使用者在文字框中輸入的電話號碼。
        // 2. 驗證電話號碼是否符合格式要求。
        // 3. 如果格式正確，則移除格式並顯示結果；否則，顯示錯誤訊息。
        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;// 取得使用者輸入的電話號碼
            input = input.Trim(); // 去除前後空白
            if (IsValidFormat(input)) // 驗證格式
            {
                Unformat(ref input); // 移除格式
                MessageBox.Show("去除格式後的電話號碼是：" + input); // 顯示結果
            }
            else
            {
                MessageBox.Show("請輸入正確的電話號碼格式：(XX)XXXX-XXXX"); // 顯示錯誤訊息
                                                               // 清空文字框
                numberTextBox.Text = string.Empty;
                // 將焦點設置在文字框上
                numberTextBox.Focus();
            }
        }

        // `exitButton_Click` 方法是當使用者按下「離開」按鈕時觸發的事件處理程式。
        // 此方法的功能是關閉目前的表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
