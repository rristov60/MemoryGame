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
        public bool sigupOK; // Променлива која покажува дали корисникот е успешно регистриран
        private string usrInput; // Променлива која ја чува внесената вредност за username
        private string passInput; // Променлива која ја чува внесената вредност за password
        private string nameInput; // Променлива која ја чува внесената вредност за First Name
        private string lastNameInput; // Променлива која ја чува внесената вредност за Second Name
        
        public PleaseWait()
        {
            InitializeComponent();
        }
        // Преоптоварен конструктор
        public PleaseWait(string _usr, string _pass, string _name, string _lastname)
        {
            InitializeComponent();
            timerTimeOutConnection.Start();
            usrInput = _usr;
            passInput = _pass;
            nameInput = _name;
            lastNameInput = _lastname;
            timerTimeOutConnection.Start();
        }

        // Време на timeout на конекција
        private void timerTimeOutConnection_Tick(object sender, EventArgs e)
        {
            timerTimeOutConnection.Stop();
            SignUP(usrInput, passInput, nameInput, lastNameInput);
        }

        // Функција која ја користиме за да даде резултат дали е успешна регистрацијата на корисникот
        public void SignUP(string username, string pass, string firstname, string secondname)
        {
            bool sucess  = Connection_and_Queries.signUpUser(username, pass, firstname, secondname); // Самата функција која ја врши регистрацијата на корисникот
            // Ако е успешно регистриран
            if (sucess)
            {
                sigupOK = true;
                DialogResult = DialogResult.OK;
            }
            else // Ако е појавена грешка (timeout или no internet connection)
            {
                sigupOK = false;
                DialogResult = DialogResult.OK;
            }
        }

        private void PleaseWait_Load(object sender, EventArgs e)
        {

        }
    }
}
