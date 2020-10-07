using System.Threading.Tasks;

namespace TRMWinFormUI.Helper
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}