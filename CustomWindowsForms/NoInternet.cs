using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomWindowsForms
{
    public partial class NoInternet : Form
    {
        public NoInternet()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Затворање на овој прозорец. Ова е направено на овој начин поради тоа што секогаш е повикуван како дијалог прозорец
            this.DialogResult = DialogResult.OK;
        }
    }
}
