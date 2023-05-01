using Backend.Application.DTOs.Responses.CaseResponses;
using Backend.Application.Queries.BrandQueries;
using Backend.Application.Specifications.BrandSpecs;
using Backend.Application.Specifications.CaseSpecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.Services;

namespace Backend.Application.Queries.CaseQueries
{
    public class ReadCasesToExcelQueryHandler : IRequestHandler<ReadCasesToExcelQuery,
        EntityResponse<byte[]>>
    {
        #region Constructor & Properties

        private readonly IReadRepository<CaseEntity> _repository;
        private readonly IExportExcelService _exportExcelService;

        public ReadCasesToExcelQueryHandler(IReadRepository<CaseEntity> repository, IExportExcelService exportExcelService)
        {
            _repository = repository;
            _exportExcelService = exportExcelService;
        }

        #endregion

        public async Task<EntityResponse<byte[]>> Handle(ReadCasesToExcelQuery query,
            CancellationToken cancellationToken)
        {
            var spec = new CaseSpec(query.BrandId, query.CaseStatusId, query.DepartmentId, query.InitialDate, query.FinalDate, query.IsPagingEnabled, query.Page, Int32.MaxValue);
            //Get entity list
            var entityCollection = await _repository.ListAsync(spec, cancellationToken);

            var result = await _exportExcelService.GenerateExcel(entityCollection);

            return result;
        }
    }
}
