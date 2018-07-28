using System.Threading.Tasks;

namespace XamMessaging.Service
{
    public interface IConfirmationService
    {
        Task<bool> AskConfirmation(string message);
    }
}
