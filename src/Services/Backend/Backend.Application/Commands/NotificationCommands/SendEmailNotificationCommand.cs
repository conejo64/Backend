namespace Backend.Application.Commands.NotificationCommands
{
    public class SendEmailNotificationCommand : IRequest<EntityResponse<bool>>
    {
        public string To { get; set; }
        public string Cc { get; set; }
        public string Cco { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Attachment { get; set; }
        public List<string> AttachmentNames { get; set; }

        public SendEmailNotificationCommand(string to, string cc, string cco, 
            string subject, string body, List<string> attachment, List<string> attachmentNames)
        {
            To = to;
            Cc = cc;
            Cco = cco;
            Subject = subject;
            Body = body;
            Attachment = attachment;
            AttachmentNames = attachmentNames;
        }
    }
}