namespace Backend.Application.Commands.DocumentCommands;

public class UploadDocumentCommand : IRequest<EntityResponse<bool>>
{
    public Guid? CaseEntityId { get; set; }
    public string? DocumentNumber { get; set; }
    public string? DocumentString { get; set; }
    public string? DocumentStringName { get; set; }
    public string? DocumentSource { get; set; }
    public string? ContentRootPath { get; set; }

    public UploadDocumentCommand(Guid? caseEntityId, string? documentNumber, string? documentString, string? documentStringName, 
        string? documentSource, string? contentRootPath)
    {
        CaseEntityId = caseEntityId;
        DocumentNumber = documentNumber;
        DocumentString = documentString;
        DocumentStringName = documentStringName;
        DocumentSource = documentSource;
        ContentRootPath = contentRootPath;
    }
    
}