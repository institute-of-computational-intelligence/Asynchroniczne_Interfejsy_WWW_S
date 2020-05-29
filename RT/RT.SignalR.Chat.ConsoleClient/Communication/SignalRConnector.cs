using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace RT.SignalR.Chat.ConsoleClient.Communication
{
    public class SignalRConnector : IConnector, IDisposable
    {
        private readonly HubConnection _hubConnection;

        public SignalRConnector(string webhostUrl)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(webhostUrl)
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                })
                .Build();
            _hubConnection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _hubConnection.StartAsync();
            };
        }
        public async Task Connect()
        {
            try
            {
                _hubConnection.On<MessageVm>("ReceiveMessage", (message) =>
                {
                    var newMessage = $"Author: {message.Author}: {message.Content}";
                    Console.WriteLine($"Message: {newMessage}");
                });
                Console.WriteLine("Connecting to hub....");
                await _hubConnection.StartAsync();
                Console.WriteLine("Connected!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public async Task SendMessage(MessageVm message)
        {
            try
            {
                await _hubConnection.InvokeAsync("SendMessageAll", message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public async void Dispose()
        {
            await _hubConnection.DisposeAsync();
        }
    }
}
