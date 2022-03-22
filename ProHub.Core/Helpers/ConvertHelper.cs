using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProHub.Core.Helpers
{
    public class ConvertHelper
    {
        public static string GetUsDateTimeString(DateTime dateTime)
        {
            CultureInfo ci = new CultureInfo("en-US");
            return dateTime.ToString("dd/MM/yyyy HH:mm", ci);
        }

        public static DateTime GetUsDateTimeFromString(string dateTime)
        {
            CultureInfo ci = new CultureInfo("en-US");
            return DateTime.Parse(dateTime, ci);
        }

        public static string GenerateKey()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString().ToUpper();
        }

        public static string GetRandomAvatarImage()
        {
            const int avatarCount = 8;
            Random randNum = new Random();
            int aRandomPos = randNum.Next(1, avatarCount);
            return $"avatar{aRandomPos}.png";
        }

        public static string GetDateTimeUs(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm", new CultureInfo("en-US"));
        }


        public static DateTime EndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        public static DateTime StartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime StartOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1, 0, 0, 0, 0);
        }



        public static string GetDayString(DateTime dateValue)
        {
            return dateValue.ToString("ddd");
        }


    }
}
