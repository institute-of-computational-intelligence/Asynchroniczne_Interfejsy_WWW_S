using System.Threading.Tasks;

namespace RT.SignalR.Chat.ConsoleClient.Communication
{
   public interface IConnector
   {
       Task Connect();
       Task SendMessage(MessageVm message);

   }
}
