using NLog;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Targets;
using System;
using System.IO;
using System.Windows.Forms;
using Ultra.Log.Interface;

namespace Ultra.Log
{
    [Serializable]
    public class ApplicationLog : IApplicationBaseLog
    {
        private Logger _NLoger;

        public ApplicationLog()
        {
            this.InitLog();
        }

        public ApplicationLog(string logfileName)
        {
            this.InitLog(logfileName);
        }

        protected virtual void AddLayOut(string layoutChr, Type t)
        {
        }

        protected virtual void AddNewLineLayOut()
        {
            this.AddLayOut("newline", typeof(NewLineLayoutRenderer));
        }

        public void DebugException(Exception exception)
        {
            if (this.NLoger != null)
            {
                this.NLoger.Debug(exception,exception.Message);
            }
        }

        public virtual Logger InitLog()
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            LoggingConfiguration configuration = new LoggingConfiguration();
            FileTarget target = new FileTarget();
            configuration.RemoveTarget("file");
            configuration.AddTarget("file", target);
            target.FileName = string.Format(@"${{basedir}}\{0}.txt", fileNameWithoutExtension);
            target.Layout = @"${date:format=yyyy-MM-dd HH\:mm\:ss}${newline}stacktrace:${newline}${stacktrace}${newline}exception:${newline}${exception}${newline}message:${newline}${message}";
            LoggingRule item = new LoggingRule("*", NLog.LogLevel.Trace, target);
            configuration.LoggingRules.Clear();
            configuration.LoggingRules.Add(item);
            LogManager.Configuration = configuration;
            Logger logger = this._NLoger = LogManager.GetLogger(fileNameWithoutExtension);
            this.AddNewLineLayOut();
            return logger;
        }

        public virtual Logger InitLog(string logfileName)
        {
            LoggingConfiguration configuration = new LoggingConfiguration();
            FileTarget target = new FileTarget();
            configuration.RemoveTarget("file");
            configuration.AddTarget("file", target);
            target.FileName = string.Format("{0}.txt", Path.Combine(Path.GetDirectoryName(logfileName), Path.GetFileNameWithoutExtension(logfileName)));
            target.Layout = @"${date:format=yyyy-MM-dd HH\:mm\:ss}${newline}${message}";
            LoggingRule item = new LoggingRule("*", NLog.LogLevel.Trace, target);
            configuration.LoggingRules.Clear();
            configuration.LoggingRules.Add(item);
            LogManager.Configuration = configuration;
            Logger logger = this._NLoger = LogManager.GetLogger(logfileName);
            this.AddNewLineLayOut();
            return (this._NLoger = logger);
        }

        public virtual Logger InitLog(string logfileName, string logLayoutFormat)
        {
            if (string.IsNullOrEmpty(logLayoutFormat))
            {
                return this.InitLog(logfileName);
            }
            LoggingConfiguration configuration = new LoggingConfiguration();
            FileTarget target = new FileTarget();
            configuration.RemoveTarget("file");
            configuration.AddTarget("file", target);
            target.FileName = string.Format("{0}.txt", Path.Combine(Path.GetDirectoryName(logfileName), Path.GetFileNameWithoutExtension(logfileName)));
            target.Layout = logLayoutFormat;
            LoggingRule item = new LoggingRule("*", NLog.LogLevel.Trace, target);
            configuration.LoggingRules.Clear();
            configuration.LoggingRules.Add(item);
            LogManager.Configuration = configuration;
            Logger logger = this._NLoger = LogManager.GetLogger(logfileName);
            this.AddNewLineLayOut();
            return (this._NLoger = logger);
        }

        public Logger NLoger
        {
            get
            {
                return this._NLoger;
            }
            set
            {
                this._NLoger = value;
            }
        }
    }
}

