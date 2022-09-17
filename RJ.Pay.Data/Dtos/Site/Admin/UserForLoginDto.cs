namespace RJ.Pay.Data.Dtos.Site.Admin
{
    public class UserForLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
    }
}
