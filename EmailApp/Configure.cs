using EmailService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailApp
{
    public partial class Configure : Form
    {
        public EmailApp frmEmail = null;
        public Configure()
        {
            InitializeComponent();
            EmailService.MailService mailService = new MailService();
            EmailConfiguration emailConfiguration = mailService.GetEmailConfiguration();
            if (emailConfiguration != null)
            {
                txtFrom.Text = emailConfiguration.From;
                txtTo.Text = string.Join(",", emailConfiguration.To);
                txtCC.Text = string.Join(",", emailConfiguration.CC);
                txtBCC.Text = string.Join(",", emailConfiguration.BCC);
                txtBody.Text = emailConfiguration.EmailBody.Replace("<br>", Environment.NewLine);
                txtGoogleSheetURL.Text = emailConfiguration.GoogleSheetURL;
                txtSubject.Text = emailConfiguration.Subject;
                txtPassword.Text = emailConfiguration.Password;
                if (emailConfiguration.ReadFromGoogleSheet)
                {
                    rdoReadFromGoogleSheetYes.Checked = true;
                    lblGoogleSheetURL.Visible = true;
                    txtGoogleSheetURL.Visible = true;
                    lblPassword.Visible = true;
                    txtPassword.Visible = true;
                }
                else
                {
                    lblGoogleSheetURL.Visible = false;
                    txtGoogleSheetURL.Visible = false;
                    lblPassword.Visible = false;
                    txtPassword.Visible = false;
                    rdoReadFromGoogleSheetNo.Checked = true;
                }
            }
            txtPassword.PasswordChar = '*';
        }
        private void rdoReadFromGoogleSheetYes_CheckedChanged(object sender, EventArgs e)
        {
            lblGoogleSheetURL.Visible = true;
            txtGoogleSheetURL.Visible = true;
            lblPassword.Visible = true;
            txtPassword.Visible = true;
        }

        private void rdoReadFromGoogleSheetNo_CheckedChanged(object sender, EventArgs e)
        {
            lblGoogleSheetURL.Visible = false;
            txtGoogleSheetURL.Visible = false;
            lblPassword.Visible = false;
            txtPassword.Visible = false;
        }

        private void btbToAdd_Click(object sender, EventArgs e)
        {
            AddEmail addEmail = new AddEmail();
            addEmail.emailAppTxtBox = this.txtTo;
            addEmail.Show();
        }

        private void btnCCAdd_Click(object sender, EventArgs e)
        {
            AddEmail addEmail = new AddEmail();
            addEmail.emailAppTxtBox = this.txtCC;
            addEmail.Show();
        }


        private void btnBCCAdd_Click(object sender, EventArgs e)
        {
            AddEmail addEmail = new AddEmail();
            addEmail.emailAppTxtBox = this.txtBCC;
            addEmail.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                string fromEmail = txtFrom.Text;
                string toEmail = txtTo.Text;
                string ccEmail = txtCC.Text;
                string bccEmail = txtBCC.Text;
                string subject = txtSubject.Text;
                string body = txtBody.Text;
                bool readFromGoogleSheet = rdoReadFromGoogleSheetYes.Checked;
                string googleSheetUrl = txtGoogleSheetURL.Text;
                string password = txtPassword.Text;
                List<string> Errors = new List<string>();
                if (fromEmail.Length == 0 || !Helper.IsValidMailAddress(fromEmail))
                {
                    Errors.Add("Invalid From Email Address");
                }
                if (toEmail.Length == 0)
                {
                    Errors.Add("Invalid To Email Address");
                }
                //if (ccEmail.Length == 0)
                //{
                //    Errors.Add("Invalid CC Email Address");
                //}
                if (subject.Length == 0)
                {
                    Errors.Add("Invalid Email Subject");
                }
                if (body.Length == 0)
                {
                    Errors.Add("Invalid Email Body");
                }
                if (readFromGoogleSheet && password.Length == 0)
                {
                    Errors.Add("Invalid Password");
                }
                if (readFromGoogleSheet && googleSheetUrl.Length == 0)
                {
                    Errors.Add("Invalid GoogleSheet URL");
                }
                if (Errors.Count > 0)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, Errors), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    body = body.Replace(Environment.NewLine, "<br>");
                    body = body.Replace("\n", "<br>");
                    EmailConfiguration emailConfiguration = new EmailConfiguration();
                    emailConfiguration.CC = string.IsNullOrWhiteSpace(ccEmail) ? null : ccEmail.Split(',').ToList();
                    emailConfiguration.BCC = string.IsNullOrWhiteSpace(ccEmail) ? null : bccEmail.Split(',').ToList();
                    emailConfiguration.EmailBody = body;
                    emailConfiguration.From = fromEmail;
                    emailConfiguration.GoogleSheetURL = googleSheetUrl;
                    emailConfiguration.ReadFromGoogleSheet = readFromGoogleSheet;
                    emailConfiguration.Subject = subject;
                    emailConfiguration.Password = password;
                    emailConfiguration.To = toEmail.Split(',').ToList();
                    EmailService.MailService a = new MailService();
                    if (a.SaveConfig(emailConfiguration))
                    {
                        MessageBox.Show("Email Configuaration saved successfully");
                        this.Close();
                        this.frmEmail.ReBindValues();
                    }
                    else
                    {
                        MessageBox.Show("Email Configuaration saved failed");
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void btnToClear_Click(object sender, EventArgs e)
        {
            txtTo.Clear();
        }

        private void btnCCClear_Click(object sender, EventArgs e)
        {
            txtCC.Clear();
        }

        private void btnBCCClear_Click(object sender, EventArgs e)
        {
            txtBCC.Clear();
        }
    }
}
