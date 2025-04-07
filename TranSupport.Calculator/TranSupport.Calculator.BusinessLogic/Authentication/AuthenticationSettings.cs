namespace TranSupport.Calculator.BusinessLogic.Authentication;

public class AuthenticationSettings
{
    public const string Authentication = "Authentication";

    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
}
