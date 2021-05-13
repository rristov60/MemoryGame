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
namespace StartUpScreen
{
    public partial class Loader : Form
    {
        // Loading screen имплементиран со едноставен тајмер
        public Loader()
        {
            InitializeComponent();
            timerLoadingScreen.Start();
        }

        private void timerLoadingScreen_Tick(object sender, EventArgs e)
        {
            timerLoadingScreen.Stop();
            LogInForm L = new LogInForm();
            this.Hide();
            L.Show();
        }
    }
}
