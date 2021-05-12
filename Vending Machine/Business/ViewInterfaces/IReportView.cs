using System;

namespace Business.ViewInterfaces
{
    public interface IReportView
    {
        Tuple<DateTime, DateTime> AskDateTimes();
    }
}