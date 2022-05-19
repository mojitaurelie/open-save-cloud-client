using OpenSaveCloudClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Core
{
    public class TaskManager
    {

        private static TaskManager instance;
        private readonly System.Timers.Timer timer;

        private readonly Dictionary<string, AsyncTaskInformation> _tasks;
        private readonly Mutex mut;

        private TaskManager()
        {
            _tasks = new Dictionary<string, AsyncTaskInformation>();
            mut = new Mutex();
            timer = new System.Timers.Timer
            {
                Interval = 2000
            };
            timer.Elapsed += timer_Tick;
            timer.Start();
        }

        public static TaskManager GetInstance()
        {
            if (instance == null)
            {
                instance = new TaskManager();
            }
            return instance;
        }

        public string StartTask(string label, int progressMax)
        {
            string uuid = Guid.NewGuid().ToString();
            _tasks.Add(uuid, new AsyncTaskInformation(label, progressMax));
            return uuid;
        }

        public AsyncTaskInformation GetTask(string uuid)
        {
            return _tasks[uuid];
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            mut.WaitOne();
            try
            {
                List<string> toDelete = new();
                foreach (KeyValuePair<string, AsyncTaskInformation> task in _tasks)
                {
                    if (task.Value.Status == AsyncTaskStatus.Ended)
                    {
                        toDelete.Add(task.Key);
                    }
                }
                foreach (string uuid in toDelete)
                {
                    _tasks.Remove(uuid);
                }
            }
            finally
            {
                mut.ReleaseMutex();
            }
        }

    }
}
