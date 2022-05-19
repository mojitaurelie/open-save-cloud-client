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

        public string Label { get { return label; } }
        public int Max { get { return max; } }
        public int Progress { get { return progress; } set { progress = value; } }
        public AsyncTaskStatus Status { get { return status; } set { status = value; } }

        public AsyncTaskInformation(string label, int max)
        {
            this.label = label;
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
