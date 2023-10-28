namespace Store.Application.Interfaces
{
    public interface IValidateService
    {
        bool ValidateUserLogin(string user, string password);
    }
}