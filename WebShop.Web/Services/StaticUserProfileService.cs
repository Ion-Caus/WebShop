using WebShop.Web.Models;

namespace WebShop.Web.Services;

public class StaticUserProfileService : IUserProfileService
{
    public UserSettings GetUserSettings()
    {
        var settings = new UserSettings
        {
            TimeZoneId = "Europe/Chisinau",
            CultureName = "ro-MD",
            CurrencyCode = "MDL"
        };

        return settings;
    }

    public void SaveSettings(UserSettings settings)
    {
        throw new InvalidOperationException("Cannot save settings in a static service.");
    }
}