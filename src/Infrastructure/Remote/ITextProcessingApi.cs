using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gerb.Telegram.Bot.Infrastructure.Remote
{
    public interface ITextProcessingApi
    {
        Task<List<string>> GetKeywords(string question);
    }
}