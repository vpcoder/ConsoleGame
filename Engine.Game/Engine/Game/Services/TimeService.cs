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

        private static readonly DateTime START_DATE = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public double Time
        {
            get
            {
                return DateTime.Now.ToUniversalTime().Subtract(START_DATE).TotalMilliseconds;
            }
        }

    }

}
