using EmailService;
using EmailService.Factory;
using EmailService.Factory.Interface;
using LoggerService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        #region Private Varaibles
        private MailService mailService;
        private LoggerBase logger;
        #endregion
        public EmailApp()
        {
            
            InitializeComponent();
            IEmailServiceFactory emailServiceFactory = new EmailServiceFactory();
            mailService = emailServiceFactory.GetMailServiceInstance();
            logger = LoggerFactory<FileLogger>.GetInstance(new FileConfigBase() { filePath = ConfigurationManager.AppSettings["LoggerFolderPath"].ToString() });
            ReBindValues();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if (mailService.SendMail(dteDate.Text))
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
            try
            {
                EmailConfiguration emailConfiguration = null; //mailService.GetEmailConfiguration();
                //if (emailConfiguration != null)
                //{
                    txtFrom.Text = emailConfiguration.From;
                    txtTo.Text = string.Join(",", emailConfiguration.To);
                    txtCC.Text = string.Join(",", emailConfiguration.CC);
                    txtBCC.Text = string.Join(",", emailConfiguration.BCC);
                    txtSubject.Text = emailConfiguration.Subject;
                    webBody.DocumentText = mailService.GetEmailBody(dteDate.Value.ToShortDateString());

                    btnSendMail.Visible = true;
                //}
                //else
                //{
                //    btnSendMail.Visible = false;
                //}

            }
            catch (Exception ex)
            {
                logger.Log(ex);
                throw;
            }
        }
    }
}
