namespace NSE.Identity.API.Model
{
    public class UserLoginResponse
    {
        public string AccessToken { get; set; } 
        public double ExpiresIn { get; set; }
        public TokenUser Token { get; set; }
    }
}
