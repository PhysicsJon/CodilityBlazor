using CodilityLogin.Models;

namespace CodilityLogin.Interfaces
{
    public interface ILoginService
    {
        (string ClassNames, string AlertText) CheckCredentials(User user);
    }
}
