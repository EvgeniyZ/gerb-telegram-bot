using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Gerb.Telegram.Bot.Domain.Entities;

namespace Gerb.Telegram.Bot.Infrastructure
{
    public class QuestionKeywordRx
    {
        private readonly Subject<QuestionKeyword> _questionKeywordsReceived = new Subject<QuestionKeyword>();

        public IObservable<QuestionKeyword> ObserveQuestionKeywords => _questionKeywordsReceived.AsObservable();

        public void Receive(QuestionKeyword questionKeyword)
        {
            _questionKeywordsReceived.OnNext(questionKeyword);
        }
    }
}

