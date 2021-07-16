using System;

namespace Engine
{

    public class TimeService
    {

        #region Singleton

        private static Lazy<TimeService> instance = new Lazy<TimeService>(() => new TimeService());

        public static TimeService Instance { get { return instance.Value; } }

        private TimeService() { }

        #endregion

        public long Time
        {
            get
            {
                return DateTime.Now.Ticks;
            }
        }

        public long GetMills(long time)
        {
            return time / 1000;
        }

    }

}
