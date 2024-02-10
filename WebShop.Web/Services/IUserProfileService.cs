using WebShop.Web.Models;

namespace WebShop.Web.Services;

public interface IUserProfileService
{
    UserSettings GetUserSettings();
    void SaveSettings(UserSettings settings);
}