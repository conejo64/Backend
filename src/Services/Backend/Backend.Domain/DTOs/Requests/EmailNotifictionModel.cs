namespace Backend.Domain.DTOs.Requests;

public class EmailNotifictionModel
{
    public string To { get; set; }
    public string Cc { get; set; }
    public string Cco { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<string> Attachment { get; set; } = new();
    public List<string> AttachmentNames { get; set; } = new();

}

