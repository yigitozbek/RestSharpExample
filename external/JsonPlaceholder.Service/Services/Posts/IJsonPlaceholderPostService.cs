using JsonPlaceholder.Service.Services.Posts.Models;

namespace JsonPlaceholder.Service.Services.Posts;

/// <summary>
///     JsonPlaceholderPostService is a service that provides access to the JsonPlaceholder API.
/// </summary>
public interface IJsonPlaceholderPostService
{
    /// <summary>
    ///     GetAsync returns a JsonPlaceholderPostResponse.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<JsonPlaceholderPostResponse> GetAsync(JsonPlaceholderPostRequest request);
    
    /// <summary>
    ///     PostAsync returns a JsonPlaceholderPostPostResponse.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<JsonPlaceholderPostPostResponse> PostAsync(JsonPlaceholderPostPostRequest request);
}