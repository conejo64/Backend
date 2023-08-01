using Backend.Application.Commands.CaseCommands;
using Backend.Application.Commands.DocumentCommands;

namespace Backend.API.DTOs.Requests.DocumentRequests
{
    public class UploadDocumentRequest
    {
        public Guid? CaseEntityId { get; set; }
        public string? DocumentNumber { get; set; }
        public string? DocumentString { get; set; }
        public string? DocumentStringName { get; set; }
        public string? DocumentSource { get; set; }

        public UploadDocumentRequest(Guid? caseEntityId, string? documentNumber, string? documentString, 
            string? documentStringName, string? documentSource)
        {
            CaseEntityId = caseEntityId;
            DocumentNumber = documentNumber;
            DocumentString = documentString;
            DocumentStringName = documentStringName;
            DocumentSource = documentSource;
        }

        public UploadDocumentCommand ToApplicationRequest(string contentRootPath)
        {
            return new UploadDocumentCommand(CaseEntityId, DocumentNumber, 
                DocumentString, DocumentStringName, DocumentSource, contentRootPath);
        }
    }
}
