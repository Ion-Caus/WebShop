using Microsoft.AspNetCore.Components.Forms;

namespace WebShop.Web.Helpers;

public static class BrowserFileHelper
{
    public static async Task<byte[]> UploadMedia(IBrowserFile file)
    {
        var path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

        await using var fileStream = new FileStream(path, FileMode.Create);

        await file.OpenReadStream(file.Size).CopyToAsync(fileStream);

        var bytes = new byte[file.Size];

        fileStream.Position = 0;

        _ = await fileStream.ReadAsync(bytes);

        fileStream.Close();

        File.Delete(path);

        return bytes;
    }
}