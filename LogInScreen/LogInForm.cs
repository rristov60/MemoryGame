using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignUpScreen;
using MainGame;
using Users_and_Security;
using SQLLogic;
using CustomWindowsForms;

namespace LogInScreen
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        
        // На event Enter проверува дали има внесено текст, ако нема т.е. има
        // default вредност Username, тогаш го брише тој дел за корисникот да може да внесе текст
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if(txtUser.Text == "Username")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        // На event Leave проверува дали корсникот има венесо текст
        // ако нема се враќа default вредноста Username
        private void txtUser_Leave(object sender, EventArgs e)
        {
            if(txtUser.Text == "")
            {
                txtUser.Text = "Username";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        // На event Enter проверува дали има внесено текст, ако нема т.е. има
        // default вредност Password, тогаш го брише тој дел за корисникот да може да внесе текст
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        // На event Leave проверува дали корсникот има венесо текст
        // ако нема се враќа default вредноста Password
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if(txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            // Минимизирање на самата форма
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Затворање на апликацијата
            Application.Exit();
        }

        // Креирање на нов корисник (играч)
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUp = new SignUpForm(); // Нова инстанца на SignUp формата
            this.Hide();
            signUp.ShowDialog();
            signUp.Dispose();
            this.Show();
        }

        // Селекција да се игра како Guest
        private void linkLblGuest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User.guestUser(); // Функција која сетира вредности соодветни за Guest играч
            MainGame.MainGame game = new MainGame.MainGame(); // Старт на играта
            game.Show();
            this.Hide();
        }

        // Log In
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            bool success = Connection_and_Queries.logIn(txtUser.Text.Trim(), PasswordHashing.hashPassword(txtPassword.Text)); // Логирање и праќање на токените за афтентикација на Azure Cloud Server
            // Ако постои совпаѓање
            if (success)
            {
                MainGame.MainGame game = new MainGame.MainGame();
                game.Show();
                this.Hide();
            }
            else
            {
                // Доколку корисникот не е поврзан на интернет, а сепак сакал да се поврзе со серверот
                if(!(User.connected)) 
                {
                    NoInternet N = new NoInternet();
                    N.ShowDialog();
                    N.Dispose();
                }
                // Доколку нема совпаѓање
                else
                {
                    WrongUserOrPass N = new WrongUserOrPass();
                    N.ShowDialog();
                    N.Dispose();
                }
            }
        }
    }
}
