using Store.Application.Interfaces;

namespace Store.Application.Services
{
    public class ValidateService : IValidateService
    {
        public bool ValidateUserLogin(string user, string password)
        {
            if(user.ToLower() == "admin" && password == "1234")
                return true;
            return false;
        }
    }
}