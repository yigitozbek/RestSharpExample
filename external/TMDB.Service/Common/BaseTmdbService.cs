using RestSharp;
using TMDB.Service.Models;

namespace TMDB.Service.Common;

/// <summary>
///     BaseTmdbService
/// </summary>
public class BaseTmdbService
{
    /// <summary>
    ///     ServiceOption
    /// </summary>
    private readonly TmdbServiceOption _serviceOption;

    /// <summary>
    ///     BaseTmdbService
    /// </summary>
    /// <param name="serviceOption"></param>
    protected BaseTmdbService(TmdbServiceOption serviceOption)
    {
        _serviceOption = serviceOption;
    }

    /// <summary>
    ///     GetRestClientOptions
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    protected RestClientOptions GetRestClientOptions(string path)
    {
        return new RestClientOptions($"{_serviceOption.URL}/{path}");
    }

    protected static RestClient GetRestClient(RestClientOptions options)
    {
        return new RestClient(options);
    }
    
    /// <summary>
    ///     Request
    /// </summary>
    /// <param name="header"></param>
    /// <param name="resource"></param>
    /// <param name="method"></param>
    /// <returns></returns>
    protected RestRequest Request(List<(string ,string)>? header = null, string? resource = null, Method method = Method.Get)
    {
        var request = new RestRequest(resource, method);
        
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer " + _serviceOption.APIKey);
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