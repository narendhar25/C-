using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    [Serializable]
    public class EmailConfiguration
    {
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string From { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string EmailBody { get; set; }
        public bool ReadFromGoogleSheet { get; set; }
        public string GoogleSheetURL { get; set; }
    }
}
