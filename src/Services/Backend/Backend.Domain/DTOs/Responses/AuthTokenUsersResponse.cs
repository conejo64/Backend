using Newtonsoft.Json;

namespace Backend.Domain.DTOs.Responses;

public class AuthTokenUsersResponse
{
    [JsonProperty(PropertyName = "token_type")]
    public string? TokenType { get; set; }

    [JsonProperty(PropertyName = "expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty(PropertyName = "ex_expires_in")]
    public int ExtExpiresIn { get; set; }

    [JsonProperty(PropertyName = "access_token")]
    public string? AccessToken { get; set; }
}