using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Ultra.Web.Core.Common
{
    public class TimeSync
    {
        private static TimeSync _Default = new TimeSync();

        public DateTime StartSync(DateTime initTime)
        {
            this.StopSync();
            this.CurrentSyncTime = initTime;
            this.tSync = new Thread(SyncProc);
            this.tSync.IsBackground = true;
            this.tSync.Start();
            return this.CurrentSyncTime;
        }

        public TimeSync StopSync()
        {
            try
            {
                if ((this.tSync != null) && this.tSync.IsAlive)
                {
                    this.tSync.Abort();
                }
            }
            finally
            {
                this.tSync = null;
            }
            return this;
        }

        protected virtual void SyncProc()
        {
            while (true)
            {
                Thread.Sleep(1000);
                this.CurrentSyncTime = this.CurrentSyncTime.AddSeconds(1.0);
            }
        }

        public virtual DateTime CurrentSyncTime { get; protected set; }

        public static TimeSync Default
        {
            get
            {
                return _Default;
            }
        }

        protected Thread tSync { get; set; }
    }
}

