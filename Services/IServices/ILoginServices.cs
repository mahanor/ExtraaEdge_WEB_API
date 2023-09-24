using ExtraaEdge_WEB_API.Model;

namespace ExtraaEdge_WEB_API.Services.IServices
{
    public interface ILoginServices
    {
        object GenerateToken(string storeOwnerName);


        bool Login(LoginModel loginModel);
    }
}
