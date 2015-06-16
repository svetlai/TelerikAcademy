namespace Events
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private const string EmptyTitleExcMsg = "Title cannot be empty.";
        private const string EmptyLocationExcMsg = "Location cannot be empty.";

        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            private set
            {
                this.date = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyTitleExcMsg);
                }

                this.title = value;
            }
        }

        public string Location 
        {
            get
            {
                return this.location;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyLocationExcMsg);
                }

                this.location = value;
            }
        }

        public int CompareTo(object objToCompareTo)
        {
            Event other = objToCompareTo as Event;
            int dateComparison = this.Date.CompareTo(other.Date);
            int titileComparison = this.Title.CompareTo(other.Title);
            int locationComparison = this.Location.CompareTo(other.Location);

            if (dateComparison == 0)
            {
                if (titileComparison == 0)
                {
                    return locationComparison;
                }
                else
                {
                    return titileComparison;
                }
            }
            else
            {
                return dateComparison;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.Title);

            if (this.Location != null && this.Location != string.Empty)
            {
                toString.Append(" | " + this.Location);
            }

            return toString.ToString();
        }
    }
}