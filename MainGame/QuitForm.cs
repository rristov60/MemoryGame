using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogInScreen;

namespace MainGame
{
    public partial class QuitForm : Form
    {
        public QuitForm()
        {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {

            //Application.Exit();
            //this.Hide();
            ThanksForPlaying P = new ThanksForPlaying();
            P.Show();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
