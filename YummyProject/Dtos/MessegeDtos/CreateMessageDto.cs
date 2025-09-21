namespace YummyProject.API.Dtos.MessegeDtos
{
    public class CreateMessageDto
    {
        
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
    }
}
