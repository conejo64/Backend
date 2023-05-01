namespace Backend.Application.DTOs.Responses.OriginDocumentResponses;
public class OriginDocumentResponse
{
    public Guid Id { get; }
    public string Description { get; set; }
    public string Status { get; set; }

    public OriginDocumentResponse(Guid id, string description, string status)
    {
        Id = id;
        Description = description;
        Status = status;
    }

    public static OriginDocumentResponse FromEntity(OriginDocument originDocument)
    {
        return new OriginDocumentResponse(originDocument.Id, originDocument.Description, originDocument.Status);
    }
}

