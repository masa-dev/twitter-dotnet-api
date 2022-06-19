using Microsoft.AspNetCore.Mvc;
using Firebase.Auth;

namespace app.Controllers;

[ApiController]
[Route("auth")]
public class LoginController : ControllerBase
{
  private readonly ILogger<WeatherForecastController> _logger;
  private readonly string firebaseApiKey;

  public LoginController(ILogger<WeatherForecastController> logger)
  {
    _logger = logger;
    firebaseApiKey = "AIzaSyBGQP6wT48S0eTSd5SlN_wwGKTZM0aCb-Y";
  }

  [HttpPost("login")]
  public async Task<FirebaseAuthLink> PostLoginController(string email, string password)
  {
    if (email != "mytwitterapi@masa-dev.com")
    {
      throw new Exception("メールアドレスが正しくありません");
    }

    var auth = new FirebaseAuthProvider(new FirebaseConfig(this.firebaseApiKey));
    var result = await auth.SignInWithEmailAndPasswordAsync(email, password);
    return result;
  }

  [HttpPost("checkuser")]
  public async Task<User> PostUserController(string token)
  {
    var auth = new FirebaseAuthProvider(new FirebaseConfig(this.firebaseApiKey));
    var result = await auth.GetUserAsync(token);
    return result;
  }

}
