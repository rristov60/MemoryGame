using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainGame
{
    public partial class BetterLuck : Form
    {
        public BetterLuck()
        {
            InitializeComponent();
            timer1.Start();
        }

        // Прозорецот се затвора по завршување на овој тајмер, за да може корисникот да продолжи со нова игра доколку тоа го сака
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            DialogResult = DialogResult.OK;
        }
    }
}
