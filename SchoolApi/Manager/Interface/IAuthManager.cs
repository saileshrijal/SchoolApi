using SchoolApi.Result;

namespace SchoolApi.Manager.Interface
{
    public interface IAuthManager
    {
        Task<AuthResult> Login(string username, string password);
    }
}
