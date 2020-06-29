using HelloWorld.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Telegram.Bot;

namespace HelloWorld
{
    class Program
    {
        static readonly ITelegramBotClient botClient = new TelegramBotClient("botToken");

        static async System.Threading.Tasks.Task Main()
        {
            Telegram.Bot.Types.User me = await botClient.GetMeAsync();

            Console.Title = me.Username;

            //this should write Hello World! on console
            Console.WriteLine(me.FirstName);

            botClient.OnUpdate += async (sender, e) =>
            {
                try
                {
                    switch (e)
                    {
                        case { Update: { Message: { Text: { } text } message } }:
                            {
                                if (text == "/groups")
                                {
                                    using(var db = new GpControlContext())
                                    {
                                        var gps = await db.Groups.ToListAsync();

                                        await botClient.SendTextMessageAsync(message.Chat.Id, string.Join('\n', gps.Select(x => x.Title)));
                                    }
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(message.Chat.Id, $"You said {text}");
                                }

                                break;
                            }
                        default:
                            break;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            };

            botClient.StartReceiving();

            Console.ReadLine();
        }
    }
}
