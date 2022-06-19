using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Firebase.Auth;
using Twitter;
using Tweetinvi;
using Tweetinvi.Parameters.V2;

namespace app.Controllers;

[ApiController]
[Route("twitter")]
public class SearchController
{
  static HttpClient client = new HttpClient();
  private readonly ILogger<WeatherForecastController> _logger;
  private ITwitterConfig ApiSecret;

  public SearchController(ILogger<WeatherForecastController> logger, ITwitterConfig twitterConfig)
  {
    _logger = logger;
    ApiSecret = twitterConfig;
  }

  [HttpGet("search")]
  public async Task<Tweetinvi.Models.V2.SearchTweetsV2Response> GetSearchResult(string token, string word, int max_tweets)
  {
    string firebaseApiKey = "AIzaSyBGQP6wT48S0eTSd5SlN_wwGKTZM0aCb-Y";
    var auth = new FirebaseAuthProvider(new FirebaseConfig(firebaseApiKey));

    var userClient = new TwitterClient(
      this.ApiSecret.GetApiKey(),
      this.ApiSecret.GetApiSecretKey(),
      this.ApiSecret.GetAccessToken(),
      this.ApiSecret.GetAccessTokenSecret()
    );

    var parameters = new SearchTweetsV2Parameters(word);
    parameters.TweetFields.Add("created_at");
    parameters.MediaFields.Add("url");
    parameters.PageSize = max_tweets;

    var result = await userClient.SearchV2.SearchTweetsAsync(parameters);
    return result;
  }
}