namespace YummyProject.API.Dtos.MessegeDtos
{
    public class ResultMessageDto
    {
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; }
    }
}
