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
        private ICollection<Call> callHistory;

        public GSM(string model, Manufacturer manufacturer)
            : base(model, manufacturer)
        {
        }

        public GSM(string model, Manufacturer manufacturer, decimal? price)
            : this(model, manufacturer, price, null, null, null)
        {
        }

        public GSM(string model, Manufacturer manufacturer, Owner owner)
            : this(model, manufacturer, null, owner, null, null)
        {
        }

        public GSM(string model, Manufacturer manufacturer, decimal? price, Owner owner)
            : this(model, manufacturer, price, owner, null, null)
        {
        }

        public GSM(string model, Manufacturer manufacturer, decimal? price, Battery battery, Display display)
            : this(model, manufacturer, price, null, battery, display)
        {
        }

        public GSM(string model, Manufacturer manufacturer, decimal? price, Owner owner, Battery battery, Display display)
            : base(model, manufacturer, price, owner)
        {
            this.Battery = battery;
            this.Display = display;
            this.CallHistory = new HashSet<Call>();
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

        public virtual ICollection<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }

            private set
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
                sb.AppendLine(this.Battery.ToString());
            }

            if (this.display != null)
            {
                sb.Append(this.Display.ToString());
            }

            return sb.ToString();
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public void RemoveCall(Call call)
        {
            this.CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal CalculateTotalCallPrice(decimal pricePerMinute)
        {
            decimal totalPrice = 0;
            foreach (var call in this.CallHistory)
            {
                totalPrice += (call.Duration / SecondsInOneMinute) * pricePerMinute;
            }

            return totalPrice;
        }
    }
}
