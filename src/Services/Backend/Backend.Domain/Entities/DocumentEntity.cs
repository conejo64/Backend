using Backend.Domain.SeedWork;

namespace Backend.Domain.Entities;

public class DocumentEntity : BaseEntity
{
    public string Status { get; set; } = CatalogsStatus.Active;
    public Guid? CaseEntityId { get; set; }
    public CaseEntity? CaseEntity { get; set; }
    public string? Document64 { get; set; }
    public string? Document64Name { get; set; }
    public string? DocumentSource { get; set; }
    public string? ContextType { get; set; }
}