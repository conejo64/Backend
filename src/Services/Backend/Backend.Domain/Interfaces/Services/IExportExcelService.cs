using Backend.Domain.DTOs.Requests;

namespace Backend.Domain.Interfaces.Services;

public interface IExportExcelService
{
    Task<byte[]?> GenerateExcel(List<CaseEntity> cases);
    Task<byte[]?> GenerateExcelV1(List<CaseEntity> cases);
}