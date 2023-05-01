using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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