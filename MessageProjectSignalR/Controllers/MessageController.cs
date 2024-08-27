using MessageProjectSignalR.Dtos.MessageDtos;
using MessageProjectSignalR.Entities;
using MessageProjectSignalR.Services.MessageServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace MessageProjectSignalR.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public MessageController(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }
        [HttpGet]
        public IActionResult SelectReceiver()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectReceiver(int receiverId)
        {
            // Kullanıcıdan alınan ReceiverId değerini Message sayfasına yönlendirin
            return RedirectToAction("Message", new { receiverId });
        }
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Message(int receiverId)
        {
            ViewBag.ReceiverId = receiverId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Message(CreateMessageDto createMessageDto)
        {
            var name = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(name);
            createMessageDto.Time = DateTime.UtcNow;
            createMessageDto.SenderId = user.Id;
            // DTO'nun kullanımına uygun şekilde güncellenmiş mesajı oluşturun
            await _messageService.SendMessageAsync(createMessageDto);
            ViewBag.ReceiverId = createMessageDto.ReceiverId;
            return View();
        }
    }
}
