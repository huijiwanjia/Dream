using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dream.Logger
{
    /// <summary>
    /// Log Interface
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// log type: information
        /// </summary>
        /// <param name="msg"></param>
        void Info(string msg);
        /// <summary>
        /// log type: exception
        /// </summary>
        /// <param name="msg"></param>
        void Error(string msg);
        /// <summary>
        /// log type: to database
        /// </summary>
        void WriteToDataBase(LogLevel logLevel, string appName, string requestURL, string clientIP, string userAgent, string errorMessage, string stackTrace, string refererURL);
    }
}
