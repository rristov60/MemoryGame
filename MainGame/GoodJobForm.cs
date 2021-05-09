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
            if (User.newHighScore)
            {
                lblFinishedGame.Text = "CONGRATS !! THAT IS NEW PERSONAL BEST";
            }else
            {
                lblFinishedGame.Text = "NICE JOB, YOUR FINAL RESULT IS: " + User.getBestScore().ToString();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // show thank you for playing and then Application.Exit()
            this.Hide();
            ThanksForPlaying P = new ThanksForPlaying();
            P.Show();
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
