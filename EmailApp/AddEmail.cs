using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailApp
{
    public partial class AddEmail : Form
    {
        public TextBox emailAppTxtBox;
        public AddEmail()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            bool isEmail = Helper.IsValidMailAddress(email);
            if (isEmail)
            {
                this.emailAppTxtBox.Text = this.emailAppTxtBox.Text + (this.emailAppTxtBox.Text.Length > 0 ? "," : "") + email;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Email Address");
            }
        }
    }
}
