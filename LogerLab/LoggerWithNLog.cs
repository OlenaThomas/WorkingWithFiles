using NLog;

namespace LogerLab
{
    public class LoggerWithNLog : ILogger
    {
        private static LoggerWithNLog _loggerWithNLog = null;
        private static Logger _logger;

        private LoggerWithNLog(){ }

        public static ILogger GetInstance()
        {
            if (_loggerWithNLog == null)
            {
                _loggerWithNLog = new LoggerWithNLog();
            }

            return _loggerWithNLog;
        }

        private Logger GetLogger(string theLogger)
        {
            if(_logger == null)
            {
                _logger = LogManager.GetLogger(theLogger);
            }
            return _logger;
        }

        public void Debug(string message, string arg = null)
        {
            if(arg == null)
            {
                GetLogger("AppLoggerRules").Debug(message);
            }
            else
            {
                GetLogger("AppLoggerRules").Debug(message, arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("AppLoggerRules").Error(message);
            }
            else
            {
                GetLogger("AppLoggerRules").Error(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("AppLoggerRules").Info(message);
            }
            else
            {
                GetLogger("AppLoggerRules").Info(message, arg);
            }
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("AppLoggerRules").Warn(message);
            }
            else
            {
                GetLogger("AppLoggerRules").Warn(message, arg);
            }
        }

        public void Dispose()
        {
            LogManager.Shutdown();
        }
    }
}
