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

namespace Phonebook
{
    // 結構 PhoneBookEntry 用來儲存每一筆電話簿資料，包括姓名與電話號碼
    struct PhoneBookEntry
    {
        public string name;   // 姓名
        public string phone;  // 電話號碼
    }

    public partial class Form1 : Form
    {
        // 用來儲存所有電話簿資料的 List
        private List<PhoneBookEntry> phoneList =
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 讀取 PhoneList.txt 檔案內容，並將每一筆資料存入 phoneList
        /// 檔案每一行格式為：姓名,電話號碼
        /// </summary>
        private void ReadFile()
        {
            StreamReader inputFile;
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                inputFile = File.OpenText(openFile.FileName);
                string line;
                while (!inputFile.EndOfStream)
                {
                    // 讀取每一行資料
                    line = inputFile.ReadLine().Trim();
                    string[] parts = line.Split(',');
                    PhoneBookEntry entry;
                    entry.name = parts[0].Trim();
                    entry.phone = parts[1].Trim();
                    phoneList.Add(entry); // 將資料加入 phoneList
                }
                inputFile.Close(); // 關閉檔案
            }
        }

        /// <summary>
        /// 將 phoneList 中所有姓名顯示在 nameListBox 控制項上
        /// </summary>
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name); // 將姓名加入 nameListBox
            }
        }

        /// <summary>
        /// 表單載入時執行，初始化電話簿資料並顯示姓名清單
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();// 讀取電話簿資料

            DisplayNames(); // 顯示姓名清單在 nameListBox 上
        }

        /// <summary>
        /// 當使用者在 nameListBox 選取不同姓名時，顯示對應的電話號碼
        /// </summary>
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex; // 取得選取的索引
            if (index != -1)
            {
                phoneLabel.Text = phoneList[index].phone; // 顯示對應的電話號碼
            }
            else
            {
                phoneLabel.Text = "無資料"; // 如果沒有選取，顯示無資料
            }
        }

        /// <summary>
        /// 當使用者按下「離開」按鈕時，關閉表單並將新的 phoneList 資料寫入原來的檔案
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 檢查是否有開啟的檔案
            if (!string.IsNullOrEmpty(openFile.FileName))
            {
                try
                {
                    // 使用 StreamWriter 將 phoneList 資料寫入檔案
                    using (StreamWriter outputFile = new StreamWriter(openFile.FileName))
                    {
                        foreach (PhoneBookEntry entry in phoneList)
                        {
                            outputFile.WriteLine($"{entry.name},{entry.phone}");
                        }
                    }
                    MessageBox.Show("資料已成功儲存！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"儲存資料時發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("未指定檔案，無法儲存資料。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 關閉表單
            this.Close();
        }

       private void button1_Click(object sender, EventArgs e)
        {
            // 檢查 namebox 和 phonebox 是否有輸入資料  
            if (!string.IsNullOrWhiteSpace(namebox.Text) && !string.IsNullOrWhiteSpace(phonebox.Text))
            {
                // 建立新的 PhoneBookEntry  
                PhoneBookEntry newEntry;
                newEntry.name = namebox.Text.Trim();
                newEntry.phone = phonebox.Text.Trim();

                // 將新資料加入 phoneList  
                phoneList.Add(newEntry);

                // 將新姓名顯示在 nameListBox  
                nameListBox.Items.Add(newEntry.name);

                // 清空輸入框  
                namebox.Clear();
                phonebox.Clear();

                // 顯示成功訊息  
                MessageBox.Show("資料已成功新增！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // 顯示錯誤訊息  
                MessageBox.Show("請輸入完整的姓名和電話號碼！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
