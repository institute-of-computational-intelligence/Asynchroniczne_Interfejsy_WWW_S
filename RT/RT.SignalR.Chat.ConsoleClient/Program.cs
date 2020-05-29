using System;
using RT.SignalR.Chat.ConsoleClient.Communication;

namespace RT.SignalR.Chat.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to connect.");
            Console.ReadKey();
            IConnector connector = new SignalRConnector("https://localhost:44309/chatHub");
            connector.Connect().Wait();
            Console.WriteLine("Type message and press enter.");
            var newMessage = new MessageVm
            {
                Author = "Console client",
                Content = Console.ReadLine(),
                RecipientName = "All"
            };
            connector.SendMessage(newMessage);
        }
    }
}
