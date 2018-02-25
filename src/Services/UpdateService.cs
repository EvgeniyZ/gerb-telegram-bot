using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.MessageProcessors;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Gerb.Telegram.Bot.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly IBotService _botService;
        private readonly ILogger<UpdateService> _logger;
        private readonly TextMessageProcessor _textMessageProcessor;

        public UpdateService(IBotService botService, TextMessageProcessor textMessageProcessor, ILogger<UpdateService> logger)
        {
            _botService = botService;
            _textMessageProcessor = textMessageProcessor;
            _logger = logger;
        }

        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.MessageUpdate)
            {
                return;
            }
            var message = update.Message;
            switch (message.Type)
            {
                case MessageType.TextMessage:
                    await _botService.Client.SendTextMessageAsync(message.Chat.Id, _textMessageProcessor.Process(message.Text));
                    break;
                case MessageType.PhotoMessage:
                    await _botService.Client.SendTextMessageAsync(message.Chat.Id, "Изображение обработано.");
                    break;
                default:
                    break;
            }
        }
    }
}
