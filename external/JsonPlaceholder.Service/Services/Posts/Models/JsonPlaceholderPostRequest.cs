using System.Text.Json.Serialization;

namespace JsonPlaceholder.Service.Services.Posts.Models;

/// <summary>
///     Represents a request to create a new post.
/// </summary>
public class JsonPlaceholderPostRequest
{

    [JsonPropertyName("id")]
    public int Id { get; set; }
}