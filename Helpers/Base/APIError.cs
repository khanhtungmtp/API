using System.Text.Json;

namespace API.Helpers.Base;

public class APIError(int errorCode, string errorMessage, string errorDetails)
{
    public int ErrorCode { get; set; } = errorCode;
    public string ErrorMessage { get; set; } = errorMessage;
    public string ErrorDetails { get; set; } = errorDetails;

    // Cache the JsonSerializerOptions instance at the class level
    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public override string ToString()
    {
        // Reuse the cached JsonSerializerOptions instance
        return JsonSerializer.Serialize(this, jsonSerializerOptions);
    }
}
