using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Users_and_Security;
using SQLLogic;
using CustomWindowsForms;

namespace SignUpScreen
{
    public partial class SignUpForm : Form
    {
        string password;
        public SignUpForm()
        {
            InitializeComponent();
            passValidPicBox.Visible = false;
            repeatPassPicBox.Visible = false;
            userValidPicBox.Visible = false;
            txtConfirmPassword.Enabled = false;
            btnSingUpVerify.Enabled = false;
        }

        private void btnSingUpVerify_Click(object sender, EventArgs e)
        {
            this.Hide();
            //bool success = Connection_and_Queries.signUpUser(txtUsernameSignUp.Text.Trim(), PasswordHashing.hashPassword(txtPasswrodSignUp.Text), txtFirstName.Text.Trim(), txtLastName.Text.Trim());
            //W.DialogResult = DialogResult.OK;
            PleaseWait W = new PleaseWait(txtUsernameSignUp.Text.Trim(), PasswordHashing.hashPassword(txtPasswrodSignUp.Text), txtFirstName.Text.Trim(), txtLastName.Text.Trim());
            W.ShowDialog();
            //bool success = W.SignUP(txtUsernameSignUp.Text.Trim(), PasswordHashing.hashPassword(txtPasswrodSignUp.Text), txtFirstName.Text.Trim(), txtLastName.Text.Trim());
            //W.Hide();
            bool success = W.sigupOK;
            W.Dispose();
            if (success)
            {
                MessageBox.Show("Succesfull registration !"); 
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //W.DialogResult = DialogResult.OK;
                //MessageBox.Show("Something went wrong, please try again later !"); // Replace with custom one
                TryAgain N = new TryAgain();
                N.ShowDialog();
                this.Show();
                N.Dispose();
                
            }
        }

        private void txtFirstName_Enter(object sender, EventArgs e)
        {
            if(txtFirstName.Text == "First Name")
            {
                txtFirstName.Text = "";
                txtFirstName.ForeColor = Color.LightGray;
            }
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            if(txtFirstName.Text == "")
            {
                txtFirstName.Text = "First Name";
                txtFirstName.ForeColor = Color.DimGray;
            }
        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            if(txtLastName.Text == "Last Name")
            {
                txtLastName.Text = "";
                txtLastName.ForeColor = Color.LightGray;
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if(txtLastName.Text == "")
            {
                txtLastName.Text = "Last Name";
                txtLastName.ForeColor = Color.DimGray;
            }
        }

        private void txtUsernameSignUp_Enter(object sender, EventArgs e)
        {
            if(txtUsernameSignUp.Text == "Username")
            {
                txtUsernameSignUp.Text = "";
                txtUsernameSignUp.ForeColor = Color.LightGray;
            }
        }

        private void txtUsernameSignUp_Leave(object sender, EventArgs e)
        {
            if(txtUsernameSignUp.Text == "")
            {
                txtUsernameSignUp.Text = "Username";
                txtUsernameSignUp.ForeColor = Color.DimGray;
                userValidPicBox.Visible = false;
            }
            else
            {
                if (Connection_and_Queries.UserExists(txtUsernameSignUp.Text.Trim()))
                {
                    userValidPicBox.Visible = true;
                    userValidPicBox.Image = Properties.Resources.X2;
                    userValidPicBox.Tag = 1;
                }
                else
                {
                    userValidPicBox.Visible = true;
                    userValidPicBox.Image = Properties.Resources.OK2;
                    userValidPicBox.Tag = 0;
                }
            }

        }

        private void txtPasswrodSignUp_Enter(object sender, EventArgs e)
        {
            if(txtPasswrodSignUp.Text == "Password")
            {
                txtPasswrodSignUp.Text = "";
                txtPasswrodSignUp.ForeColor = Color.LightGray;
                txtPasswrodSignUp.UseSystemPasswordChar = true;
                txtConfirmPassword.Enabled = false;
            }
        }

        private void txtPasswrodSignUp_Leave(object sender, EventArgs e)
        {
            if(txtPasswrodSignUp.Text == "")
            {
                txtPasswrodSignUp.Text = "Password";
                txtConfirmPassword.Text = "Confirm Password";
                txtConfirmPassword.UseSystemPasswordChar = false;
                repeatPassPicBox.Visible = false;
                txtPasswrodSignUp.UseSystemPasswordChar = false;
                txtPasswrodSignUp.ForeColor = Color.DimGray;
                passValidPicBox.Visible = false;
                txtConfirmPassword.Enabled = false;
            }else
            {
                txtConfirmPassword.Enabled = true;
                passValidPicBox.Visible = true;
                password = txtPasswrodSignUp.Text;
                if (PasswordCheck.valid(password))
                {
                    passValidPicBox.Image = Properties.Resources.OK2;
                    passValidPicBox.Tag = 0;
                }
                else
                {
                    passValidPicBox.Image = Properties.Resources.X2;
                    passValidPicBox.Tag = 1;
                }
            }

        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            if(txtConfirmPassword.Text == "Confirm Password")
            {
                txtConfirmPassword.Text = "";
                txtConfirmPassword.UseSystemPasswordChar = true;
                txtConfirmPassword.ForeColor = Color.LightGray;
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if(txtConfirmPassword.Text == "")
            {
                txtConfirmPassword.Text = "Confirm Password";
                txtConfirmPassword.UseSystemPasswordChar = false;
                txtConfirmPassword.ForeColor = Color.DimGray;
                repeatPassPicBox.Visible = false;
            }
            else
            {
                repeatPassPicBox.Visible = true;
                if (txtConfirmPassword.Text == password)
                {
                    repeatPassPicBox.Image = Properties.Resources.OK2;
                    repeatPassPicBox.Tag = 0;
                }
                else
                {
                    repeatPassPicBox.Image = Properties.Resources.X2;
                    repeatPassPicBox.Tag = 1;
                }
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtPasswrodSignUp_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.Enabled = true;
            passValidPicBox.Visible = true;
            password = txtPasswrodSignUp.Text;
            if (PasswordCheck.valid(password))
            {
                passValidPicBox.Image = Properties.Resources.OK2;
                passValidPicBox.Tag = 0;
            }
            else
            {
                passValidPicBox.Image = Properties.Resources.X2;
                passValidPicBox.Tag = 1;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            repeatPassPicBox.Visible = true;
            if (txtConfirmPassword.Text == password)
            {
                repeatPassPicBox.Image = Properties.Resources.OK2;
                repeatPassPicBox.Tag = 0;
            }
            else
            {
                repeatPassPicBox.Image = Properties.Resources.X2;
                repeatPassPicBox.Tag = 1;
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            //if (checkBox1.Checked == true)
            //{
            //    if((userValidPicBox.Image == Properties.Resources.OK2) && (passValidPicBox.Image == Properties.Resources.OK2) && (repeatPassPicBox.Image == Properties.Resources.OK2) && 
            //        (txtFirstName.Text != "") && (txtFirstName.Text != "First Name") &&
            //        (txtLastName.Text != "") && (txtLastName.Text != "Last Name") &&
            //        (txtUsernameSignUp.Text != "") && (txtUsernameSignUp.Text != "Username") &&
            //        (txtPasswrodSignUp.Text != "") && (txtPasswrodSignUp.Text != "Password") && 
            //        (txtConfirmPassword.Text != "") && (txtConfirmPassword.Text != "Confirm Password"))
            //    {
            //        btnSingUpVerify.Enabled = true;
            //    }
            //}
            //else
            //{
            //    btnSingUpVerify.Enabled = false;
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if((int.Parse(userValidPicBox.Tag.ToString()) == 0) && (int.Parse(passValidPicBox.Tag.ToString()) == 0) && (int.Parse(repeatPassPicBox.Tag.ToString()) == 0) && 
                (txtFirstName.Text != "") && (txtFirstName.Text != "First Name") &&
                (txtLastName.Text != "") && (txtLastName.Text != "Last Name") &&
                (txtUsernameSignUp.Text != "") && (txtUsernameSignUp.Text != "Username") &&
                (txtPasswrodSignUp.Text != "") && (txtPasswrodSignUp.Text != "Password") && 
                (txtConfirmPassword.Text != "") && (txtConfirmPassword.Text != "Confirm Password") && (checkBox1.Checked))
            {
                btnSingUpVerify.Enabled = true;
            }
            else
            {
                btnSingUpVerify.Enabled = false;
            }

        }
    }
}
