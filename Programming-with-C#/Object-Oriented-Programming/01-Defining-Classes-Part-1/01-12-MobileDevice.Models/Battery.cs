namespace MobileDevice.Models
{
    using System;

    public class Battery
    {
        private const string HoursNegativeExceptionMessage = "Hours cannot be negative.";

        private double hoursIdle;
        private double hoursTalk;
        private BatteryType batteryType;

        public Battery()
        {
        }

        public Battery(BatteryType batteryType, double hoursIdle, double hoursTalk)
        {
            this.BatteryType = batteryType;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }

        public double HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(HoursNegativeExceptionMessage);
                }

                this.hoursIdle = value;
            }
        }

        public double HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(HoursNegativeExceptionMessage);
                }

                this.hoursTalk = value;
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }

            set
            {
                this.batteryType = value;
            }
        }
    }
}
