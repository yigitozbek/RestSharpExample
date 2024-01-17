using System.Net;
using System.Text.Json;
using JsonPlaceholder.Service.Common;
using JsonPlaceholder.Service.Models;
using JsonPlaceholder.Service.Services.Posts.Models;
using RestSharp;

namespace JsonPlaceholder.Service.Services.Posts;

/// <summary>
///     JsonPlaceholderPostService is a service that provides access to the JsonPlaceholder API.
/// </summary>
public class JsonPlaceholderPostService(JsonPlaceholderOption serviceOption) : BaseJsonPlaceholderService(serviceOption), IJsonPlaceholderPostService
{
    /// <summary>
    ///     GetAsync returns a JsonPlaceholderPostResponse.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<JsonPlaceholderPostResponse> GetAsync(JsonPlaceholderPostRequest request)
    {
        var options = GetRestClientOptions("posts/" + request.Id);

        var client = GetRestClient(options);

        var result = Request();

        var response = await client.GetAsync(result);

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            throw new Exception("Error");
        }

        return JsonSerializer.Deserialize<JsonPlaceholderPostResponse>(response.Content!)!;

    }

    /// <summary>
    ///     PostAsync returns a JsonPlaceholderPostPostResponse.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<JsonPlaceholderPostPostResponse> PostAsync(JsonPlaceholderPostPostRequest request)
    {
        var options = GetRestClientOptions("posts");

        var client = GetRestClient(options);

        var result = Request(null, JsonSerializer.Serialize(request), null, Method.Post);

        var response = await client.PostAsync(result);

        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            throw new Exception("Error");
        }

        return JsonSerializer.Deserialize<JsonPlaceholderPostPostResponse>(response.Content!)!;
        
    }

}