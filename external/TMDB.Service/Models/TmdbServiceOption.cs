namespace TMDB.Service.Models;

/// <summary>
///     Tmdb service option class.
/// </summary>
/// <param name="url"></param>
/// <param name="apiKey"></param>
/// <param name="apiVersion"></param>
public class TmdbServiceOption(string url = "", string apiKey = "", string apiVersion = "")
{
    /// <summary>
    ///     URL
    /// </summary>
    public string URL { get; set; } = url;
    
    /// <summary>
    ///     APIKey
    /// </summary>
    public string APIKey { get; set; } = apiKey;
    
    /// <summary>
    ///     APIVersion
    /// </summary>
    public string APIVersion { get; set; } = apiVersion;
}