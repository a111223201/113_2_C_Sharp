using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            // 定義座位的行數與列數
            const int ROWS = 6;
            const int COLS = 4;

            // 宣告變數以儲存使用者輸入的行與列
            int row;
            int col;

            // 定義座位價格的二維陣列，每個元素代表對應座位的價格
            decimal[,] seatPrices = { {450m, 450m, 450m, 450m},
                                          {425m, 425m, 425m, 425m},
                                          {400m, 400m, 400m, 400m},
                                          {375m, 375m, 375m, 375m},
                                          {375m, 375m, 375m, 375m},
                                          {350m, 350m, 350m, 350m}
                                        };

            // 嘗試將 rowTextBox 的文字轉換為整數，並檢查是否成功
            if (int.TryParse(rowTextBox.Text, out row))
            {
                // 嘗試將 colTextBox 的文字轉換為整數，並檢查是否成功
                if (int.TryParse(colTextBox.Text, out col))
                {
                    // 檢查行號是否在有效範圍內
                    if (row >= 0 && row < ROWS)
                    {
                        // 檢查列號是否在有效範圍內
                        if (col >= 0 && col < COLS)
                        {
                            // 顯示選定座位的價格，格式化為貨幣格式
                            priceLabel.Text = seatPrices[row, col].ToString("C");

                            // 清空列與行的文字框，並將焦點設置到列文字框
                            colTextBox.Clear();
                            rowTextBox.Clear();
                            colTextBox.Focus();
                        }
                        else
                        {
                            // 如果列號無效，顯示錯誤訊息並將焦點設置到列文字框
                            MessageBox.Show("請輸入有效的列號。");
                            colTextBox.Focus();
                            return;
                        }
                    }
                    else
                    {
                        // 如果行號無效，顯示錯誤訊息並將焦點設置到行文字框
                        MessageBox.Show("請輸入有效的行號。");
                        rowTextBox.Focus();
                        return;
                    }
                }
                else
                {
                    // 如果列文字框的輸入無法轉換為整數，顯示錯誤訊息
                    MessageBox.Show("請輸入有效的列號。");
                    colTextBox.Focus();
                    return;
                }
            }
            else
            {
                // 如果行文字框的輸入無法轉換為整數，顯示錯誤訊息
                MessageBox.Show("請輸入有效的行號。");
                rowTextBox.Focus();
                return;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
