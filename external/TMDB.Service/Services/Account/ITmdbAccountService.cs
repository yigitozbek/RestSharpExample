using TMDB.Service.Services.Account.Models;

namespace TMDB.Service.Services.Account;

/// <summary>
///     ITmdbAccountService represents a service for interacting with the TMDb API for account details.
/// </summary>
public interface ITmdbAccountService
{
    /// <summary>
    ///     Details returns account details from the TMDb API.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<TmdbAccountDetailsResponse> Details(TmdbAccountDetailsRequest request);
}