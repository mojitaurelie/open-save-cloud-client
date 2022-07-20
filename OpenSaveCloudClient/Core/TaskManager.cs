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
        private static LogManager logManager;
        private readonly System.Timers.Timer timer;

        private readonly Dictionary<string, AsyncTaskInformation> _tasks;
        private readonly Mutex mut;

        public List<AsyncTaskInformation> TasksInformation { get { return _tasks.Values.ToList();  } }

        private TaskManager()
        {
            logManager = LogManager.GetInstance();
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
            mut.WaitOne();
            try
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
            catch (Exception ex)
            {
                logManager.AddError(ex);
                throw;
            }
            finally
            {
                mut.ReleaseMutex();
            }

        }

        public void UpdateTaskProgress(string uuid, int progress)
        {
            mut.WaitOne();
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
            catch(Exception ex)
            {
                logManager.AddError(ex);
            }
            finally
            {
                mut.ReleaseMutex();
            }
        }

        public void UpdateTaskStatus(string uuid, AsyncTaskStatus status)
        {
            mut.WaitOne();
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
            catch (Exception ex)
            {
                logManager.AddError(ex);
            }
            finally
            {
                mut.ReleaseMutex();
            }
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            mut.WaitOne();
            try
            {
                var ended = _tasks.Where(t => t.Value.Status != AsyncTaskStatus.Running).ToArray();
                foreach (var task in ended)
                {
                    _tasks.Remove(task.Key);
                }
                OnTaskCleared(new TaskClearedEventArgs());
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
