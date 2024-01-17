using System.Text.Json.Serialization;

namespace JsonPlaceholder.Service.Services.Posts.Models;

/// <summary>
///     Represents a response from creating a new post.
/// </summary>
public class JsonPlaceholderPostResponse
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")] 
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("body")] 
    public string Body { get; set; } = string.Empty;
}