using MessageProjectSignalR.Concrete;
using MessageProjectSignalR.Services.MessageServices;
using Microsoft.AspNetCore.SignalR;

namespace MessageProjectSignalR.Api.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly IMessageService _messageService;
        public SignalRHub(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
    }
}
