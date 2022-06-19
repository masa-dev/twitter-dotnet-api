namespace Twitter;

public class TwitterConfigSample : ITwitterConfig
{
  private string apiKey = "dummy api key";
  private string apiSecretKey = "dummy api secret key";
  private string accessToken = "dummy access token";
  private string accessTokenSecret = "dummy access token secret";
  private string bearer = "dummy bearer";

  public string GetApiKey()
  {
    return this.apiKey;
  }

  public string GetApiSecretKey()
  {
    return this.apiSecretKey;
  }

  public string GetAccessToken()
  {
    return this.accessToken;
  }

  public string GetAccessTokenSecret()
  {
    return this.accessTokenSecret;
  }

  public string GetBearer()
  {
    return this.bearer;
  }
}