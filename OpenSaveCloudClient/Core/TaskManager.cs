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

        public List<AsyncTaskInformation> TasksInformation { get { return _tasks.Values.ToList();  } }

        private TaskManager()
        {
            _tasks = new Dictionary<string, AsyncTaskInformation>();
            mut = new Mutex();
            timer = new System.Timers.Timer
            {
                Interval = 10000
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

        public string StartTask(string label, bool undefined, int progressMax)
        {
            string uuid = Guid.NewGuid().ToString();
            AsyncTaskInformation ati = new(uuid, label, undefined, progressMax);
            _tasks.Add(uuid, ati);
            TaskChangedEventArgs args = new()
            {
                TaskInformation = ati
            };
            OnTaskChanged(args);
            return uuid;
        }

        public void UpdateTaskProgress(string uuid, int progress)
        {
            try
            {
                AsyncTaskInformation task = _tasks[uuid];
                task.Add(progress);
                task.Undefined = false;
                TaskChangedEventArgs args = new()
                {
                    TaskInformation = task
                };
                OnTaskChanged(args);
            }
            catch(Exception)
            {

            }
        }

        public void UpdateTaskStatus(string uuid, AsyncTaskStatus status)
        {
            try
            {
                AsyncTaskInformation task = _tasks[uuid];
                if (status != AsyncTaskStatus.Running)
                {
                    task.Progress = task.Max;
                    task.Undefined = false;
                }
                task.Status = status;
                TaskChangedEventArgs args = new()
                {
                    TaskInformation = task
                };
                OnTaskChanged(args);
            }
            catch (Exception)
            {

            }
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
                if (toDelete.Count > 0)
                {
                    OnTaskCleared(new TaskClearedEventArgs());
                }
            }
            finally
            {
                mut.ReleaseMutex();
            }
        }

        protected virtual void OnTaskChanged(TaskChangedEventArgs e)
        {
            EventHandler<TaskChangedEventArgs> handler = TaskChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnTaskCleared(TaskClearedEventArgs e)
        {
            EventHandler<TaskClearedEventArgs> handler = TaskCleared;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<TaskChangedEventArgs> TaskChanged;
        public event EventHandler<TaskClearedEventArgs> TaskCleared;

    }

    public class TaskChangedEventArgs : EventArgs
    {
        public AsyncTaskInformation TaskInformation { get; set; }
    }

    public class TaskClearedEventArgs : EventArgs
    {
    }
}
