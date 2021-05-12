using Business.ViewInterfaces;
using iQuest.Business.Exceptions;
using System;
using System.Globalization;

namespace iQuest.Presentation.Views
{
    public class ReportView : IReportView
    {
        public Tuple<DateTime, DateTime> AskDateTimes()
        {
            DateTime startTime = AskStartTime();
            DateTime endTime = AskEndTime();

            return new Tuple<DateTime, DateTime>(startTime, endTime);
        }

        private DateTime AskStartTime()
        {
            Console.WriteLine("Start time (MM dd yyyy HH:mm) : ");
            string dateString = GetConsoleLine();

            DateTime startTime;
            while (!DateTime.TryParseExact(dateString, "MM dd yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out startTime))
            {
                Console.WriteLine("Invalid start time, please input again");
                dateString = GetConsoleLine();
            }
            return startTime;
        }

        private DateTime AskEndTime()
        {
            Console.WriteLine("End time (MM dd yyyy HH:mm) : ");
            string dateString = GetConsoleLine();

            DateTime endTime;
            while (!DateTime.TryParseExact(dateString, "MM dd yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out endTime))
            {
                Console.WriteLine("Invalid end time, please input again");
                dateString = GetConsoleLine();
            }
            return endTime;
        }

        private string GetConsoleLine()
        {
            string dateString = Console.ReadLine();
            if (dateString == "cancel")
                throw new CancelException();

            return dateString;
        }
    }
}