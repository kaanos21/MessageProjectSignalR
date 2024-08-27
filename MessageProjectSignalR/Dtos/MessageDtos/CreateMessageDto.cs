namespace MessageProjectSignalR.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}
