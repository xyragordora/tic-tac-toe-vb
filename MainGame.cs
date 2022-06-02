using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class MainGame : Form
    {
        bool turn = true; // true = X turn and false = Y turn
        int turn_count = 0; 
        public MainGame()
        {
            InitializeComponent();
        }

        private void MainGame_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e) //the button that is pressed is passed on this method
        {
            Button b = (Button)sender;

            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turn_count++;

            checkTheWinner();
        }

        private void checkTheWinner() //to automaticallly check the winner
        {
            bool there_is_a_winner = false;

            //horizontal
            if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled))
                there_is_a_winner = true;
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
                there_is_a_winner = true;
            else if ((c1.Text == c2.Text) && (c2.Text == b3.Text) && (!c1.Enabled))
                there_is_a_winner = true;

            //vertical
            if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
                there_is_a_winner = true;
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
                there_is_a_winner = true;
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
                there_is_a_winner = true;

            //diagonal
            if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
                there_is_a_winner = true;
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!c1.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner) 
            {
                disableButtons();

                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " wins! " + "Congratulations!");
                buttonnew.Enabled = true;
                buttonexit.Enabled = true;
                buttonhelp.Enabled = true;
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Draw!");
                buttonnew.Enabled = true;
                buttonexit.Enabled = true;
                buttonhelp.Enabled = true;
            }

        }
            private void disableButtons() //to disable the button after checking the winner
        {
            try
            {
                foreach (Control x in Controls)
                {
                    Button b = (Button)x;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e) //for the button exit, to exit the application
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e) //for new game 
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }

        private void buttonhelp_Click(object sender, EventArgs e) //instruction for the game
        {
            MessageBox.Show("1. The first player are X, the next player is O.\n" + "Players take turns putting their marks in empty squares.\n" +
                "2. The first player to get 3 of her marks in a row (up, down, across, or diagonally) is the winner. "); 
        }
    }
}
