using EmailService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailApp
{
    public partial class EmailApp : Form
    {
        public EmailApp()
        {
            InitializeComponent();
            ReBindValues();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            EmailService.MailService mailService = new MailService();
            if (mailService.SendMail())
            {
                MessageBox.Show("Email sent successfully");
            }
            else
            {
                MessageBox.Show("Email sending failed");
            }
        }
        private void configureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configure configure = new Configure();
            configure.frmEmail = this;
            configure.ShowDialog();
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {

        }
        public void ReBindValues()
        {
            EmailService.MailService mailService = new MailService();
            EmailConfiguration emailConfiguration = mailService.GetEmailConfiguration();
            if (emailConfiguration != null)
            {
                txtFrom.Text = emailConfiguration.From;
                txtTo.Text = string.Join(",", emailConfiguration.To);
                txtCC.Text = string.Join(",", emailConfiguration.CC);
                txtBCC.Text = string.Join(",", emailConfiguration.BCC);
                txtSubject.Text = emailConfiguration.Subject;
                webBody.DocumentText = mailService.GetEmailBody();
                btnSendMail.Visible = true;
            }
            else
            {
                btnSendMail.Visible = false;
            }
        }
    }
}
