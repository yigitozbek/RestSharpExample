using JsonPlaceholder.Service.Models;
using RestSharp;

namespace JsonPlaceholder.Service.Common;

/// <summary>
///     JsonPlaceholder Service Base
/// </summary>
public class BaseJsonPlaceholderService
{
    /// <summary>
    ///     JsonPlaceholder Service Base
    /// </summary>
    private readonly JsonPlaceholderOption _serviceOption;

    /// <summary>
    ///     JsonPlaceholder Service Base
    /// </summary>
    /// <param name="serviceOption"></param>
    protected BaseJsonPlaceholderService(JsonPlaceholderOption serviceOption)
    {
        _serviceOption = serviceOption;
    }

    /// <summary>
    ///     GetRestClientOptions returns a RestClientOptions.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    protected RestClientOptions GetRestClientOptions(string path)
    {
        return new RestClientOptions($"{_serviceOption.URL}/{path}");
    }

    /// <summary>
    ///     GetRestClient returns a RestClient.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    protected static RestClient GetRestClient(RestClientOptions options)
    {
        return new RestClient(options);
    }

    /// <summary>
    ///     Request returns a RestRequest.
    /// </summary>
    /// <param name="header"></param>
    /// <param name="json"></param>
    /// <param name="resource"></param>
    /// <param name="method"></param>
    /// <returns></returns>
    protected static RestRequest Request(List<(string, string)>? header = null, string? json = null, string? resource = null,
        Method method = Method.Get)
    {
        var request = new RestRequest(resource, method);
        request.RequestFormat = DataFormat.Json;

        if (json is not null)
        {
            request.AddJsonBody(json);
        }

        request.AddHeader("accept", "application/json");
        request.AddHeader("Content-Type", "application/json");

        if (header is not null)
        {
            foreach (var (key, value) in header)
            {
                request.AddHeader(key, value);
            }
        }


        return request;
    }
}