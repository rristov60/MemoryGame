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
        // Доколку играчот сака да ја исклучи играта
        private void btnYes_Click(object sender, EventArgs e)
        {
            // Форма благодарност за играње
            ThanksForPlaying P = new ThanksForPlaying();
            P.Show();
        }

        // Доколку се предомисли со исклучување на играта
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
