using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Factory.Interface
{
    public interface IEmailServiceFactory
    {
        MailService GetMailServiceInstance();
    }
}
