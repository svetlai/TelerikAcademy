namespace Delegates
{
    using System;
    using System.Threading;

    public delegate void TimerDelegate(string param);

    public class Timer
    {
        private const string NegativeIntervalExceptionMsg = "Time interval cannot be negative.";

        private Action<string> action;
        private TimerDelegate timerDelegate;
        private int timeInterval;

        public Timer()
        {
        }

        public Timer(int timeInterval)
        {
            this.TimeInterval = timeInterval;
        }

        public Timer(TimerDelegate timerDelegate, int timeInterval)
            : this(timeInterval)
        {
            this.TimerDelegate = timerDelegate;
        }

        public Timer(Action<string> action, int timeInterval)
            : this(timeInterval)
        {
            this.Action = action;
        }

        public Action<string> Action 
        {
            get
            {
                return this.action;
            }

            set
            {
                this.action = value;
            }
        }

        public TimerDelegate TimerDelegate
        {
            get
            {
                return this.timerDelegate;
            }

            set
            {
                this.timerDelegate = value;
            }
        }

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

        public void RunAction(string param)
        {
            while (true)
            {              
                this.Action(param);
                Thread.Sleep(this.TimeInterval);
            }
        }

        public void RunDelegate(string param)
        {
            while (true)
            {
                this.TimerDelegate(param);
                Thread.Sleep(this.TimeInterval);
            }
        }
    }
}
