
namespace System
{
    public static class DateTimeExtensions
    {
        public static DateTime UnixTimeToLocalDateTime(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(unixTime).LocalDateTime;
        }
    }
}
