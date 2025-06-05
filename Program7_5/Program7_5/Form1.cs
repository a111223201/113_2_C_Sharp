using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] team;
        string[] winner;

        private void Form1_Load(object sender, EventArgs e)
        {
            readTeams();
            readWinner();
        }

        private void readTeams()
        {
            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("Teams.txt");

                int num_of_lines = 0;
                while (!inputFile.EndOfStream)
                {
                    listBox1.Items.Add(inputFile.ReadLine());
                    num_of_lines++;
                }

                team = new string[num_of_lines];

                inputFile = File.OpenText("Teams.txt");
                int index = 0;
                while (index < team.Length && !inputFile.EndOfStream)
                {
                    team[index] = inputFile.ReadLine();
                    index++;
                }

                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readWinner()
        {
            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText("WorldSeries.txt");

                int num_of_lines = 0;
                while (!inputFile.EndOfStream)
                {
                    inputFile.ReadLine();
                    num_of_lines++;
                }

                winner = new string[num_of_lines];

                inputFile = File.OpenText("WorldSeries.txt");
                int index = 0;
                while (index < winner.Length && !inputFile.EndOfStream)
                {
                    winner[index] = inputFile.ReadLine();
                    index++;
                }
                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            int numWin = 0;
            for (int i = 0; i < winner.Length; i++)
            {
                if ( str == winner[i])
                {
                    numWin++;
                }
            }
            label1.Text = str + " has won " + numWin + " times from 1903 through 2009.";
        }
    }
}
