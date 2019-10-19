# gerb-telegram-bot
Telegram бот @gerbdiet_bot, который отвечает на вопросы по рекомендуемой диете людям с язвенной болезнью желудка
и двенадцатиперстной кишки в стадии обострения.

@gerbdiet_bot выложен на Heroku.

Настройка:
0) ngrok для тестирования чат бота
1) db.env с настройками для базы данных (POSTGRES_DB, POSTGRES_USER, POSTGRES_PASSWORD)
2) appsettings.Development.json и appsettings.Production.json со строкой подключения к бд и бот токеном