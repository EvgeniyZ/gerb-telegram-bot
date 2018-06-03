using System;
using System.Threading.Tasks;
using Gerb.Telegram.Bot.Domain;
using Gerb.Telegram.Bot.Domain.Entities;
using Gerb.Telegram.Bot.Infrastructure;

namespace Gerb.Telegram.Bot.Services
{
    public class QuestionKeywordsHandler : IDisposable
    {
        private readonly IDisposable _questionKeywordRxSubscription;
        private readonly DietContext _dietContext;

        public QuestionKeywordsHandler(QuestionKeywordRx questionKeywordRx, DietContext dietContext)
        {
            //_questionKeywordRxSubscription = questionKeywordRx.ObserveQuestionKeywords.Subscribe(this.OnReceive);
            _dietContext = dietContext;
        }
        public void Dispose()
        {
            _questionKeywordRxSubscription.Dispose();
        }
        private async Task OnReceive(QuestionKeyword questionKeyword)
        {
            await _dietContext.QuestionKeywords.AddAsync(questionKeyword);
        }
    }
}