using System;
using Telegram.Bot;

namespace HelloWorld
{
    class Program
    {
        public static ITelegramBotClient botClient;

        static void Main(string[] args)
        {

            botClient = new TelegramBotClient("");
            
            //this should write Hello World! on console
            Console.WriteLine("Hello World!");
        }
    }
}
