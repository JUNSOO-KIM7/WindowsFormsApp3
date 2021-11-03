using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Gaming();
        }

        Button[,] buttons = new Button[3, 3];

        private void Gaming()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(45, 45);
                    buttons[i, j].Location = new Point(i * 45, j * 45);
                    buttons[i, j].FlatStyle = FlatStyle.Flat;
                    buttons[i, j].Font = new System.Drawing.Font(DefaultFont.FontFamily, 20, FontStyle.Bold);

                    buttons[i, j].Click += new EventHandler(button_Click);

                    panel1.Controls.Add(buttons[i, j]);
                }
            }
        }

        void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button.Text != "")
            {
                return;
            }

            button.Text = button1.Text;

            ABAB();
        }

        private void ABAB()
        {
            GameEnd();

            if (button1.Text == "A")
            {
                button1.Text = "B";
            }
            else
            {
                button1.Text = "A";
            }
        }

        private void GameEnd()
        {
            List<Button> wButtons = new List<Button>();

            //가로
            for (int i = 0; i < 3; i++)
            {
                wButtons = new List<Button>();
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[j, i].Text != button1.Text)
                    {
                        break;
                    }

                    wButtons.Add(buttons[j, i]);
                    if (j == 2)
                    {
                        ShowWinner(wButtons);
                        return;
                    }
                }
            }

            //세로
            for (int i = 0; i < 3; i++)
            {
                wButtons = new List<Button>();
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[i, j].Text != button1.Text)
                    {
                        break;
                    }

                    wButtons.Add(buttons[i, j]);
                    if (j == 2)
                    {
                        ShowWinner(wButtons);
                        return;
                    }
                }
            }
                        
            // 대각선
            wButtons = new List<Button>();
            for (int i = 0, j = 0; i < 3; i++, j++)
            {
                if (buttons[i, j].Text != button1.Text)
                {
                    break;
                }

                wButtons.Add(buttons[i, j]);
                if (j == 2)
                {
                    ShowWinner(wButtons);
                    return;
                }
            }
            
            
            //대각선2
            wButtons = new List<Button>();
            for (int i = 2, j = 0; j < 3; i--, j++)
            {
                if (buttons[i, j].Text != button1.Text)
                {
                    break;
                }

                wButtons.Add(buttons[i, j]);
                if (j == 2)
                {
                    ShowWinner(wButtons);
                    return;
                }
            }
            

            foreach (var button in buttons)
            {
                if (button.Text == "")
                    return;
            }

            MessageBox.Show("무승부 입니다 !!!!!");

            Application.Restart();
        }

        private void ShowWinner(List<Button> wButtons)
        {
            foreach (var button in wButtons)
            {
                //이긴 버튼 색깔 골드로

                button.BackColor = Color.Gold;
            }

            MessageBox.Show(button1.Text + " 가 이겼습니다!!!!!!");
            Application.Restart();
        }
    }
}
