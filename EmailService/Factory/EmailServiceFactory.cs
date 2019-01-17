using EmailService.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Factory
{
    public class EmailServiceFactory : IEmailServiceFactory
    {
        public MailService GetMailServiceInstance()
        {
            return new MailService();
        }
    }
}
