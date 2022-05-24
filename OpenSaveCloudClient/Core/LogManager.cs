using OpenSaveCloudClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Core
{
    public class LogManager
    {

        private static LogManager? instance;

        private readonly List<Log> messages;

        public List<Log> Messages { get { return messages; } }

        private LogManager() {
            messages = new List<Log>();
        }

        public static LogManager GetInstance()
        {
            if (instance == null) { instance = new LogManager(); }
            return instance;
        }

        public void AddError(Exception ex)
        {
            AddError(ex.Message);
        }

        public void AddError(string message)
        {
            Log log = new()
            {
                Message = message,
                Severity = LogSeverity.Error,
            };
            messages.Add(log);
            NewMessageEventArgs args = new()
            {
                Message = message,
                Severity = LogSeverity.Error,
            };
            OnNewMessage(args);
        }

        public void AddInformation(string message)
        {
            Log log = new()
            {
                Message = message,
                Severity = LogSeverity.Information,
            };
            messages.Add(log);
            NewMessageEventArgs args = new()
            {
                Message = message,
                Severity = LogSeverity.Information,
            };
            OnNewMessage(args);
        }

        public void AddWarning(string message)
        {
            Log log = new()
            {
                Message = message,
                Severity = LogSeverity.Warning,
            };
            messages.Add(log);
            NewMessageEventArgs args = new()
            {
                Message = message,
                Severity = LogSeverity.Warning,
            };
            OnNewMessage(args);
        }

        public void Clear()
        {
            messages.Clear();
            OnClear(new ClearEventArgs());
        }

        protected virtual void OnNewMessage(NewMessageEventArgs e)
        {
            EventHandler<NewMessageEventArgs> handler = NewMessage;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnClear(ClearEventArgs e)
        {
            EventHandler<ClearEventArgs> handler = Cleared;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<NewMessageEventArgs> NewMessage;
        public event EventHandler<ClearEventArgs> Cleared;

    }

    public class NewMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public LogSeverity Severity { get; set; }
    }

    public class ClearEventArgs : EventArgs
    {

    }
}
