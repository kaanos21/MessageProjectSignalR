using MessageProjectSignalR.Entities;
using MessageProjectSignalR.Hubs;
using MessageProjectSignalR.Services.MessageServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessageProjectSignalR.ViewComponents
{
    public class MessageListViewComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        private readonly SignalRHub _signalRHub;

        public MessageListViewComponent(UserManager<AppUser> userManager, IMessageService messageService, SignalRHub signalRHub)
        {
            _userManager = userManager;
            _messageService = messageService;
            _signalRHub = signalRHub;
        }

        public async Task<IViewComponentResult> InvokeAsync(int receiverId)
        {
            var name = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);
            var id = user.Id;

            // receiverId'yi kullanarak mesajları al
            var messages = await _signalRHub.SignalGetMessagesAsync(id, receiverId);

            ViewBag.Name = name;
            return View(messages);
        }
    }
}
