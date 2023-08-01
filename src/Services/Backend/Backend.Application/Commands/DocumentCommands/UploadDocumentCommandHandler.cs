using Backend.Application.Specifications.CaseStatusSpecs;
using Backend.Domain.DTOs.Requests;
using Backend.Domain.Interfaces.Services;

namespace Backend.Application.Commands.DocumentCommands;

public class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentCommand, EntityResponse<bool>>
{
    private readonly IRepository<DocumentEntity> _documentRepository;

    public UploadDocumentCommandHandler(IRepository<DocumentEntity> documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<EntityResponse<bool>> Handle(UploadDocumentCommand command, CancellationToken cancellationToken)
    {
        //Save Documents
        if (!string.IsNullOrEmpty(command.DocumentString) && !string.IsNullOrEmpty(command.DocumentStringName))
        {
            var documentSplit = command.DocumentString.Split(',');
            var contentTypeSplit = documentSplit[0].Split(':');
            // if (saved)
            // {
                var document = new DocumentEntity
                {
                    CaseEntityId = command.CaseEntityId,
                    DocumentSource = command.DocumentSource,
                    Document64 = String.Empty,
                    Document64Name = command.DocumentStringName,
                    ContextType = contentTypeSplit[1].Split(';')[0],
                };
                await _documentRepository.AddAsync(document, cancellationToken);
                byte[] bytes = Convert.FromBase64String(documentSplit[1]);
                var stream = new MemoryStream(bytes);
                var fileName = command.DocumentStringName;
                var path = $"Cases/{command.DocumentNumber}";

                var saved =await SaveFile(stream, fileName, command.ContentRootPath!, path, cancellationToken);
                // await _documentRepository.SaveChangesAsync(cancellationToken); 
                 return EntityResponse.Success(true);
            // }
        }
        return EntityResponse.Success(false);
        
    }
    
    #region Files

    public string GetSavePath(string fileName, string prefix, string contentRootPath)
    {
        var dir = $"{contentRootPath}/AppFiles";
        if (prefix != null)
            dir = Path.Combine(dir, prefix);

        return Path.Combine(dir, fileName);
    }

    private async Task<bool> SaveFile(Stream fileStream, string fileName, string contentRootPath, string prefix = default,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var savePath = GetSavePath(fileName, prefix, contentRootPath);
            var dir = $"{contentRootPath}/AppFiles";
            if (prefix != null)
                dir = Path.Combine(dir, prefix);

            var exist = Directory.Exists(dir);
            if (!exist)
            {
                Directory.CreateDirectory(dir);
            }

            await using var stream = File.Create(savePath);
            await fileStream.CopyToAsync(stream, cancellationToken);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    #endregion
}