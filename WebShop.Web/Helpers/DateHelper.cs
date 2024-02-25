namespace WebShop.Web.Helpers;

public static class DateHelper
{
    public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime, TimeZoneInfo timezone)
    {
        var offset = timezone.GetUtcOffset(dateTime);
        
        return new DateTimeOffset(dateTime.Ticks, offset);
    }
    
    public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime)
    {
        return new DateTimeOffset(dateTime.Ticks, TimeSpan.Zero);
    }
}