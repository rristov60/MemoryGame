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
    public partial class StopForm : Form
    {
        public bool stop = true;
        public StopForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Доколку корисникот сака да ја стопира играта
        private void btnYES_Click(object sender, EventArgs e)
        {
            MainGame.score = 0;
            this.DialogResult = DialogResult.OK;
        }
        // Доколку не сака да ја стопира само си продолжува
        private void btnNO_Click(object sender, EventArgs e)
        {
            stop = false;
            this.DialogResult = DialogResult.OK;
        }
    }
}
