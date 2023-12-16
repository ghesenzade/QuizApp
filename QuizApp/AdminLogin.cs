using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp
{
    public partial class AdminLogin : Form
    {
        public static string fk_ad;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                pwdText.PasswordChar = '\0';
                checkBox1.Text = "Hide Password";
            }
            else
            {
                pwdText.PasswordChar = '*';
                checkBox1.Text = "Show Password";
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string user = txtName.Text;
            string password = pwdText.Text;
            string userdb, passworddb;

            returnclass rc = new returnclass();
            userdb = rc.scalarReturn("select count(ad_id) from admin_auth where ad_user = '" +user+ "'");

            if (userdb.Equals("0"))
            {
                MessageBox.Show("Invalid user name");
            }
            else
            {
                passworddb = rc.scalarReturn("select ad_password from admin_auth where ad_user='"+user+"'");
                
                if (passworddb.Equals(password))
                {
                    fk_ad = rc.scalarReturn("select ad_id from admin_auth where ad_user = '"+user+"'");
                    Form2 f = new Form2();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                }
            }
        }

        private void clearLabel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            pwdText.Clear();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
          Application.Exit();
        }
    }
}
