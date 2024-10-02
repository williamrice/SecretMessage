
namespace webapi.Models;

public class Secret
{
    public int Id { get; set; }

    public string UUID { get; set; } = Guid.NewGuid().ToString();

    public string Message { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string IsViewed { get; set; } = string.Empty;

}