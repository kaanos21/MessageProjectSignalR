using MessageProjectSignalR.Concrete;
using MessageProjectSignalR.Dtos.MessageDtos;
using MessageProjectSignalR.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace MessageProjectSignalR.Services.MessageServices
{
    public class MessageManager : IMessageService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Context _context; // Context nesnesi private readonly olarak tanımlandı

        public MessageManager(UserManager<AppUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context; // Dependency Injection ile context nesnesi alınıyor
        }

        public async Task<List<MessageDto>> GetMessagesAsync(int id,int id2)
        {
            var messages = await _context.Messages
            .Where(m => m.SenderId == id && m.ReceiverId == id2)
            .Select(m => new MessageDto
            {
                SenderId = m.SenderId,   // Gönderen ID'si int türünde
                Content = m.Content,
                Time = m.Time,
                ReceiverId = m.ReceiverId,
            })
            .ToListAsync();
            return messages;
        }

        public async Task<List<MessageDto>> GetMessagesWithSenderAndReceiver(int receiver, int sender)
        {
            var value=await _context.Messages.Where(x=>x.ReceiverId==receiver || x.SenderId==sender)
            .Select(m=>new MessageDto
            {
                SenderId=m.SenderId,
                Content=m.Content,
                Time = m.Time,
                ReceiverId = m.ReceiverId,
            }).ToListAsync();
            return value;  
        }

        public async Task SendMessageAsync(CreateMessageDto message)
        {
            var newMessage = new Message
            {
                Content = message.Content,
                SenderId = message.SenderId, // Kullanıcının ID'si mesajın göndereni olarak ayarlanıyor
                ReceiverId = message.ReceiverId, // Alıcının ID'si
                Time = message.Time // Mesaj gönderim tarihi
            };
            await _context.AddAsync(newMessage);
            await _context.SaveChangesAsync();
        }
    }
}
