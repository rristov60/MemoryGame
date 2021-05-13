using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInScreen
{
    public partial class ThanksForPlaying : Form
    {
        // Форма која се покажува како последна (благодарност за играње) и излева од апликацијата
        public ThanksForPlaying()
        {
            InitializeComponent();
            timerQuit.Start();
        }

        private void timerQuit_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
