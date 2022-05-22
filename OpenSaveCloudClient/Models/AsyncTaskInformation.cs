using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Models
{
    public class AsyncTaskInformation
    {

        private readonly string label;
        private readonly int max;
        private int progress;
        private AsyncTaskStatus status;
        private readonly string uuid;
        private bool undefined;

        public string Label { get { return label; } }
        public int Max { get { return max; } }
        public int Progress { get { return progress; } set { progress = value; } }
        public AsyncTaskStatus Status { get { return status; } set { status = value; } }

        public bool Undefined { get { return undefined; } set { undefined = value; } }

        public string Uuid { get { return uuid; } }

        public AsyncTaskInformation(string uuid, string label, bool undefined, int max)
        {
            this.uuid = uuid;
            this.label = label;
            this.undefined = undefined;
            this.max = max;
            this.progress = 0;
            status = AsyncTaskStatus.Running;
        }

        public int Add(int progress)
        {
            this.progress += progress;
            return progress;
        }

    }
}
