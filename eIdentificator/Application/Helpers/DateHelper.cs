using eIdentificator.Domain.Interfaces;
using System;

namespace eIdentificator.Application.Helpers
{
    public class DateHelper : IDateHelper
    {
        public string ParseDateToString(DateTime date)
        {
            return (date.Month < 10 ? "0" : "") +
                date.Month.ToString() +
                "-" +
                (date.Day < 10 ? "0" : "") +
                date.Day.ToString() +
                "-" +
                date.Year.ToString();
        }
    }
}
