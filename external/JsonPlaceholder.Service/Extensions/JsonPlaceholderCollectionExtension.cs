using JsonPlaceholder.Service.Models;
using JsonPlaceholder.Service.Services.Posts;
using Microsoft.Extensions.DependencyInjection;

namespace JsonPlaceholder.Service.Extensions;

/// <summary>
///     JsonPlaceholderCollectionExtension is a collection of extension methods for IServiceCollection.
/// </summary>
public static class JsonPlaceholderCollectionExtension
{
    /// <summary>
    ///     AddConfigurationJsonPlaceholder adds a JsonPlaceholderOption to the service collection.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="configureOptions"></param>
    /// <returns></returns>
    public static IServiceCollection AddConfigurationJsonPlaceholder(
        this IServiceCollection serviceCollection,
        Action<JsonPlaceholderOption> configureOptions
    )
    {
        // Add the configuration options to the service collection.
        serviceCollection.AddSingleton<JsonPlaceholderOption>(serviceProvider =>
        {
            var jsonPlaceholderServiceOption = new JsonPlaceholderOption();
            configureOptions(jsonPlaceholderServiceOption);
            return jsonPlaceholderServiceOption;
        });

        return serviceCollection;
    }
    
    
    /// <summary>
    ///     AddJsonPlaceholderService adds a JsonPlaceholderPostService to the service collection.
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddJsonPlaceholderService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IJsonPlaceholderPostService, JsonPlaceholderPostService>();
        return serviceCollection;
    }
    
}