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
        /// 當使用者按下「離開」按鈕時，關閉表單
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
