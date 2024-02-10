using System.Globalization;

namespace WebShop.Web.Models;

public record UserSettings
{
    public required string TimeZoneId { get; init; }
    public required string CultureName { get; init; }
    public required string CurrencyCode { get; init; }
    
    public TimeZoneInfo GetTimeZoneInfo() => TimeZoneInfo.FindSystemTimeZoneById(TimeZoneId);
    public CultureInfo GetCultureInfo() => CultureInfo.GetCultureInfo(CultureName);
}