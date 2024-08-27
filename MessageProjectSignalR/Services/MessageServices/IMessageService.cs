using MessageProjectSignalR.Dtos.MessageDtos;

namespace MessageProjectSignalR.Services.MessageServices
{
    public interface IMessageService
    {
        Task SendMessageAsync(CreateMessageDto message);
        Task<List<MessageDto>> GetMessagesAsync(int id,int id2);
        Task<List<MessageDto>> GetMessagesWithSenderAndReceiver(int receiver,int sender);
    }
}
