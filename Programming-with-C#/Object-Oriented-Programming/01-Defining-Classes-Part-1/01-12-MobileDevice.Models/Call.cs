namespace MobileDevice.Models
{
    using System;

    public class Call
    {
        private const string DailedNumberNullExceptionMessage = "Dailed number cannot be empty.";
        private const string DurationNullOrNegativeExceptionMessage = "Duration cannot be null or negative.";

        private DateTime time;
        private string dailedNumber;
        private uint duration;

        public Call(string dailedNumber, uint duration)
            : this(DateTime.Now, dailedNumber, duration)
        {
        }

        public Call(DateTime time, string dailedNumber, uint duration)
        {
            this.Time = time;
            this.DailedNumber = dailedNumber;
            this.Duration = duration;
        }

        public DateTime Time
        {
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
            }
        }

        public string DailedNumber
        {
            get
            {
                return this.dailedNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(DailedNumberNullExceptionMessage);
                }

                this.dailedNumber = value;
            }
        }

        public uint Duration
        {
            get
            {
                return this.duration;
            }

            set
            {
                if (value < 0 || value == null)
                {
                    throw new ArgumentNullException(DurationNullOrNegativeExceptionMessage);
                }

                this.duration = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Time of call: {0} | Dailed number: {1} | Duration: {2}s", this.time, this.dailedNumber, this.duration);
        }
    }
}
