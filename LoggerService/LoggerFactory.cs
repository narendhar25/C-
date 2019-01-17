using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerService
{
    public static class LoggerFactory<T> where T : LoggerBase
    {
        public static LoggerBase GetInstance(ConfigBase type)
        {
            switch (type)
            {
                case FileConfigBase r when (r is FileConfigBase):
                    return new FileLogger() { Config = type };
                    //case DBLogger logger when (logger is DBLogger):
                    //    return new FileLogger();
                    //case LoggerType.Email:
                    //    return new EmailLogger();
            }
            return null;
        }
    }
}
