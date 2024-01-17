using System.Text.Json.Serialization;

namespace JsonPlaceholder.Service.Services.Posts.Models;

/// <summary>
///     Represents a request to create a new post.
/// </summary>
public class JsonPlaceholderPostPostRequest
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("title")] 
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("body")] 
    public string Body { get; set; } = string.Empty;

}