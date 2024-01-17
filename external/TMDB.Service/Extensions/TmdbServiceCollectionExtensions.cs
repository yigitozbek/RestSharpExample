using Microsoft.Extensions.DependencyInjection;
using TMDB.Service.Models;
using TMDB.Service.Services.Account;

namespace TMDB.Service.Extensions;


/// <summary>
///     Tmdb is a collection of extension methods for IServiceCollection
/// </summary>
public static class TmdbServiceCollectionExtensions
{
    
    /// <summary>
    ///     AddConfigurationTmdb adds a TmdbServiceOption to the service collection.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configureOptions"></param>
    /// <returns></returns>
    public static IServiceCollection AddConfigurationTmdb(
        this IServiceCollection serviceCollection,
        Action<TmdbServiceOption> configureOptions
    )
    {
        // Add the configuration options to the service collection.
        serviceCollection.AddSingleton<TmdbServiceOption>(serviceProvider =>
        {
            var tmdbServiceOption = new TmdbServiceOption();
            configureOptions(tmdbServiceOption);
            return tmdbServiceOption;
        });

        return serviceCollection;
    }

    /// <summary>
    ///     AddTmdbService adds a TmdbAccountService to the service collection.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddTmdbService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<ITmdbAccountService, TmdbAccountService>();
        return serviceCollection;
    }
}