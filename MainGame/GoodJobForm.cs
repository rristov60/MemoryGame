using LogInScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Users_and_Security;

namespace MainGame
{
    public partial class GoodJobForm : Form
    {
        public GoodJobForm()
        {
            InitializeComponent();
            // Проверуваме дали играчот има нов Personal Best
            if (User.newHighScore)
            {
                // Дколку има
                lblFinishedGame.Text = "CONGRATS !! THAT IS NEW PERSONAL BEST";
            }else
            {
                // Доколку нема
                lblFinishedGame.Text = "NICE JOB, YOUR FINAL RESULT IS: " + User.getBestScore().ToString();
            }
        }

        // Корисникот може да изелзе од играта доколку сака после ова
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThanksForPlaying P = new ThanksForPlaying(); // Gateway прозорец за излез од играта
            P.Show();
        }

        // Доколку сака играчот повторно да игра
        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
