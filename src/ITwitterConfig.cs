namespace Twitter;

public interface ITwitterConfig
{
  public string GetApiKey();
  public string GetApiSecretKey();
  public string GetAccessToken();
  public string GetAccessTokenSecret();
  public string GetBearer();
}