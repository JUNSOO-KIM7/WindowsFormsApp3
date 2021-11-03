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
                    buttons[i, j].Size = new Size(50, 50);
                    buttons[i, j].Location = new Point(i * 50, j * 50);
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

            TogglePlayer();
        }

        private void TogglePlayer()
        {
            GameEnd();

            if (button1.Text == "X")
            {
                button1.Text = "O";
            }
            else
            {
                button1.Text = "X";
            }
        }

        private void GameEnd()
        {
            List<Button> winnerButtons = new List<Button>();

            #region // vertically
            for (int i = 0; i < 3; i++)
            {
                winnerButtons = new List<Button>();
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[i, j].Text != button1.Text)
                    {
                        break;
                    }

                    winnerButtons.Add(buttons[i, j]);
                    if (j == 2)
                    {
                        ShowWinner(winnerButtons);
                        return;
                    }
                }
            }
            #endregion            
            #region // horizontally
            for (int i = 0; i < 3; i++)
            {
                winnerButtons = new List<Button>();
                for (int j = 0; j < 3; j++)
                {
                    if (buttons[j, i].Text != button1.Text)
                    {
                        break;
                    }

                    winnerButtons.Add(buttons[j, i]);
                    if (j == 2)
                    {
                        ShowWinner(winnerButtons);
                        return;
                    }
                }
            }
            #endregion            
            #region// diagonally 1 (top-left to bottom-right)
            winnerButtons = new List<Button>();
            for (int i = 0, j = 0; i < 3; i++, j++)
            {
                if (buttons[i, j].Text != button1.Text)
                {
                    break;
                }

                winnerButtons.Add(buttons[i, j]);
                if (j == 2)
                {
                    ShowWinner(winnerButtons);
                    return;
                }
            }
            #endregion
            #region// diagonally 2 (bottom-left to top-right)
            winnerButtons = new List<Button>();
            for (int i = 2, j = 0; j < 3; i--, j++)
            {
                if (buttons[i, j].Text != button1.Text)
                {
                    break;
                }

                winnerButtons.Add(buttons[i, j]);
                if (j == 2)
                {
                    ShowWinner(winnerButtons);
                    return;
                }
            }
            #endregion

            foreach (var button in buttons)
            {
                if (button.Text == "")
                    return;
            }

            MessageBox.Show("무승부");
            Application.Restart();
        }

        private void ShowWinner(List<Button> winnerButtons)
        {
            foreach (var button in winnerButtons)
            {
                button.BackColor = Color.Gold;
            }

            MessageBox.Show(button1.Text + " 가 이김!!!!!!");
            Application.Restart();
        }


    }
}
