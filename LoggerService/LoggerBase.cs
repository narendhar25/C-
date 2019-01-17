using System;
using System.Collections.Generic;

namespace LoggerService
{
    public abstract class LoggerBase
    {
        public abstract void Log(Exception exception);
        public ConfigBase Config { get; set; }
    }
}
