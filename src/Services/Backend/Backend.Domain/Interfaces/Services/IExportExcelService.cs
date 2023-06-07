using Backend.Domain.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Interfaces.Services
{
    public interface IExportExcelService
    {
        Task<byte[]?> GenerateExcel(List<CaseEntity> cases);
        Task<byte[]?> GenerateExcelV1(List<CaseEntity> cases);
    }
}
