using System;

namespace JwtAuthentication.Models
{
    [Serializable]
    public class Credential
    {
        // we will add more permaeter alter to the credentials
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
