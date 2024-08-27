using MessageProjectSignalR.Concrete;
using MessageProjectSignalR.Dtos.MessageDtos;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace MessageProjectSignalR.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly Context _context;

        public SignalRHub(Context context)
        {
            _context = context;
        }

        public async Task<List<MessageDto>> SignalGetMessagesAsync(int id, int id2)
        {
            var messages = await _context.Messages
        .Where(m => (m.SenderId == id && m.ReceiverId == id2) || (m.SenderId == id2 && m.ReceiverId == id))
        .Select(m => new MessageDto
        {
            SenderId = m.SenderId,
            Content = m.Content,
            Time = m.Time,
            ReceiverId = m.ReceiverId,
        })
        .ToListAsync();
            return messages;
        }
    }
}
