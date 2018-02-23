using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Gerb.Telegram.Bot.Services
{
    public interface IUpdateService
    {
        Task EchoAsync(Update update);
    }
}
