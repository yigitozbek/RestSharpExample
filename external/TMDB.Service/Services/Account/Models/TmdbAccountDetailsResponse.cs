using System.Text.Json.Serialization;

namespace TMDB.Service.Services.Account.Models;

/// <summary>
///     TmdbAccountDetailsResponse represents a response from the TMDb API for an account details request.
/// </summary>
public class TmdbAccountDetailsResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("iso_639_1")] 
    public string Iso6391 { get; set; } = string.Empty;

    [JsonPropertyName("iso_3166_1")] 
    public string Iso3166 { get; set; } = string.Empty;
    
    [JsonPropertyName("name")] 
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("include_adult")] 
    public string IncludeAdult { get; set; } = string.Empty;
    
    [JsonPropertyName("username")] 
    public string Username { get; set; } = string.Empty;
}