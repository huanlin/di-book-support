using System;
namespace Ch03.Common.Services
{
    public interface IAuthenticationService
    {
        bool TwoFactorLogin(string userId, string pwd);
        bool VerifyToken(string token);
    }
}
