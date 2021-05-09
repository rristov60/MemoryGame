using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLLogic;

namespace CustomWindowsForms
{
    public partial class PleaseWait : Form
    {
        public bool sigupOK;
        private string usrInput;
        private string passInput;
        private string nameInput;
        private string lastNameInput;
        
        public PleaseWait()
        {
            InitializeComponent();
            //SignUP();
            //timerTimeOutConnection.Start();
        }

        public PleaseWait(string _usr, string _pass, string _name, string _lastname)
        {
            InitializeComponent();
            timerTimeOutConnection.Start();
            //SignUP(_usr, _pass, _name, _lastname);
            usrInput = _usr;
            passInput = _pass;
            nameInput = _name;
            lastNameInput = _lastname;
            timerTimeOutConnection.Start();
        }


        private void timerTimeOutConnection_Tick(object sender, EventArgs e)
        {
            timerTimeOutConnection.Stop();
            SignUP(usrInput, passInput, nameInput, lastNameInput);
            //this.DialogResult = DialogResult.OK;
        }

        public void SignUP(string username, string pass, string firstname, string secondname)
        {
            bool sucess  = Connection_and_Queries.signUpUser(username, pass, firstname, secondname);
            if (sucess)
            {
                sigupOK = true;
                DialogResult = DialogResult.OK;
            }
            else
            {
                sigupOK = false;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
