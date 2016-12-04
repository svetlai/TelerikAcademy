namespace WcfServiceDay.Web
{
    using System;

    public class ServiceDay : IServiceDay
    {
        public string GetDay(DateTime date)
        {
            var culture = new System.Globalization.CultureInfo("bg-BG");
            var day = culture.DateTimeFormat.GetDayName(date.DayOfWeek);

            return day;
        }
    }
}
