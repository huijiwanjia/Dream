using NLog;
using System;

namespace Dream.Logger
{
    /// <summary>
    /// third log util: nlog
    /// </summary>
    public class Log : ILog
    {
        public void Info(string msg)
        {
            try { NLog.LogManager.GetLogger("info").Info(msg); }
            catch { }
        }

        public void Error(string msg)
        {
            try { NLog.LogManager.GetLogger("error").Error(msg); }
            catch { }
        }
        public void WriteToDataBase(LogLevel logLevel, string appName, string requestURL, string clientIP, string userAgent, string errorMessage, string stackTrace, string refererURL)
        {
            LogEventInfo ei = new LogEventInfo(logLevel, "", "");
            ei.Properties["logLevel"] = logLevel.ToString().ToUpper();
            ei.Properties["appName"] = appName;
            ei.Properties["requestURL"] = requestURL;
            ei.Properties["clientIP"] = clientIP;
            ei.Properties["userAgent"] = userAgent;
            ei.Properties["errorMessage"] = errorMessage;
            ei.Properties["stackTrace"] = stackTrace;
            ei.Properties["refererURL"] = refererURL;
            NLog.LogManager.GetLogger("writeToDatabase").Log(ei);
        }
    }
}
