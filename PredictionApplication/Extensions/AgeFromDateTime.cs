using System.Diagnostics.CodeAnalysis;

namespace PredictionApplication.Extensions
{
    public static class AgeFromDateTime
    {
        public static int Age(this DateTime dateTime)
        {
            var now = DateTime.Now;
            int age = now.Year - dateTime.Year;
            if (dateTime.AddYears(age) > now)
                age--;
            return age;
        }
    }
}
