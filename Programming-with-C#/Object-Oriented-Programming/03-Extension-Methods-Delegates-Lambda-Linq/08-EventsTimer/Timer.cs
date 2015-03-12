namespace EventsTimer
{
    using System;
    using System.Threading;

    public delegate void TimeChangeEventHandler(object sender, EventArgs e);

    public class Timer
    {
        private const string NegativeIntervalExceptionMsg = "Time interval cannot be negative.";

        private int timeInterval;

        public Timer()
        {
        }

        public Timer(int timeInterval)
        {
            this.TimeInterval = timeInterval;
        }

        public event TimeChangeEventHandler TimeChanged;

        public int TimeInterval
        {
            get
            {
                return this.timeInterval;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeIntervalExceptionMsg);
                }

                this.timeInterval = value;
            }
        }

        public virtual void OnTimeChange(EventArgs e)
        {
            if (this.TimeChanged != null)
            {
                this.TimeChanged(this, e);
            }
        }

        public void Start(EventArgs e)
        {
            while (true)
            {              
                Thread.Sleep(this.TimeInterval);
                this.OnTimeChange(e);
            }
        }
    }
}
