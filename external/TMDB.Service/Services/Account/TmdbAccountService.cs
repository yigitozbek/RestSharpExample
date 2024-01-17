using System.Net;
using System.Text.Json;
using RestSharp;
using TMDB.Service.Common;
using TMDB.Service.Models;
using TMDB.Service.Services.Account.Models;

namespace TMDB.Service.Services.Account;

/// <summary>
///     TmdbAccountService represents a service for interacting with the TMDb API for account details.
/// </summary>
/// <param name="serviceOption"></param>
public class TmdbAccountService(TmdbServiceOption serviceOption) : BaseTmdbService(serviceOption), ITmdbAccountService
{
    /// <summary>
    ///     Details returns account details from the TMDb API.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<TmdbAccountDetailsResponse> Details(TmdbAccountDetailsRequest request)
    {
        var options = GetRestClientOptions("account/" + request.AccountId);

        var client = GetRestClient(options);

        List<(string, string)> header =
        [
            ("session_id", "request.SessionId"),
            ("accept_language", "tr-TR"),
            ("append_to_response", "")
        ];

        var result = Request(header);

        var response = await client.GetAsync(result);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception("Error");
        }

        return JsonSerializer.Deserialize<TmdbAccountDetailsResponse>(response.Content!)!;
    }
}