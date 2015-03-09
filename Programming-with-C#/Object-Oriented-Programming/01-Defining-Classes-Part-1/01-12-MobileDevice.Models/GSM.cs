namespace MobileDevice.Models
{
    using System.Collections.Generic;
    using System.Text;

    using MobileDevice.Models.Contracts;

    public class GSM : Phone, IGSM
    {
        private const int SecondsInOneMinute = 60;

        private static readonly GSM Iphone4S = new GSM("IPhone 4S", new Manufacturer("Apple", "USA"), 500, new Battery(BatteryType.LiIon, 500, 200), new Display(4.5, 256));

        private Battery battery;
        private Display display;
        private IList<Call> callHistory;

        public GSM(string model, Manufacturer manufacturer)
            : this(model, manufacturer, null, null, null)
        {
        }

        public GSM(string model, Manufacturer manufacturer, decimal? price)
            : this(model, manufacturer, price, null, null)
        {
        }

        public GSM(string model, Manufacturer manufacturer, decimal? price, Battery battery, Display display)
            : this(model, manufacturer, price, battery, display, new List<Call>())
        {
        }

        public GSM(string model, Manufacturer manufacturer, decimal? price, Battery battery, Display display, IList<Call> callHistory)
            : base(model, manufacturer, price)
        {
            this.Battery = battery;
            this.Display = display;
            this.CallHistory = callHistory;
        }

        public static GSM IPhone4S
        {
            get
            {
                return Iphone4S;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }

            private set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }

            private set
            {
                this.display = value;
            }
        }

        public virtual IList<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }

            set
            {
                this.callHistory = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ToString());

            if (this.battery != null)
            {
                sb.AppendFormat("Battery: {0} | Hours idle: {1} | Hours talk: {2}", this.battery.BatteryType, this.battery.HoursIdle, this.battery.HoursTalk);
                sb.AppendLine();
            }

            if (this.display != null)
            {
                sb.AppendFormat("Display Size: {0} | Number of colors: {1}", this.display.Size, this.display.NumberOfColors);
            }

            return sb.ToString();
        }

        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void RemoveCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal CalculateTotalCallPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0;
            foreach (var call in this.callHistory)
            {
                totalPrice += (call.Duration / SecondsInOneMinute) * pricePerMinute;
            }

            return totalPrice;
        }
    }
}
