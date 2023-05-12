using Ardalis.Specification;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Specifications.CaseSpecs
{
    public sealed class CaseSpec : Ardalis.Specification.Specification<CaseEntity>, ISingleResultSpecification
    {
        public CaseSpec(Guid id)
        {
            Query
                .Include(x => x.OriginDocument)
                .Include(x => x.Brand)
                .Include(x => x.Department)
                .Include(x => x.User)
                .Include(x => x.Reminder)
                .Include(x => x.Province)
                .Include(x => x.CaseStatus)
                .Include(x => x.CaseStatusSecretary)
                .Where(x => x.Status != CatalogsStatus.Deleted && x.Id == id);
        }

        //filtrar por originDocument
        public CaseSpec(Guid? originDocumentId, Guid? caseStatusId, Guid? departmentId, DateTime? initialDate, DateTime? finalDate, bool isPagingEnabled, int page, int pageSize)
        {
            Query
                .Include(x => x.OriginDocument)
                .Include(x => x.Brand)
                .Include(x => x.Department)
                .Include(x => x.User)
                .Include(x => x.Reminder)
                .Include(x => x.Province)
                .Include(x => x.CaseStatus)
                .Include(x => x.CaseStatusSecretary)
                .Where(x => x.Status != CatalogsStatus.Deleted);

            if (originDocumentId != null)
                Query.Where(x => x.OriginDocumentId.Equals(originDocumentId));
            if (caseStatusId != null)
                Query.Where(x => x.CaseStatusId.Equals(caseStatusId));
            if (departmentId != null)
                Query.Where(x => x.DepartmentId.Equals(departmentId));
            if (initialDate != null)
                Query.Where(x => x.ReceptionDate >= initialDate);
            if (finalDate != null)
                Query.Where(x => x.ReceptionDate <= finalDate);
            if (isPagingEnabled)
                Query
                    .OrderByDescending(x => x.ReceptionDate)
                    .Skip(PaginationHelper.CalculateSkip(pageSize, page))
                    .Take(PaginationHelper.CalculateTake(pageSize));
            else
                Query
                    .OrderByDescending(x => x.ReceptionDate);
        }

        public CaseSpec(Guid userId, Guid? originDocumentId, Guid? caseStatusId, Guid? departmentId, DateTime? initialDate, DateTime? finalDate, bool isPagingEnabled, int page, int pageSize)
        {
            Query
                .Include(x => x.OriginDocument)
                .Include(x => x.Brand)
                .Include(x => x.Department)
                .Include(x => x.User)
                .Include(x => x.Reminder)
                .Include(x => x.Province)
                .Include(x => x.CaseStatus)
                .Include(x => x.CaseStatusSecretary)
                .Where(x => x.Status != CatalogsStatus.Deleted);

            Query.Where(x => x.UserId == userId);
            if (originDocumentId != null)
                Query.Where(x => x.OriginDocumentId.Equals(originDocumentId));
            if (caseStatusId != null)
                Query.Where(x => x.CaseStatusId.Equals(caseStatusId));
            if (departmentId != null)
                Query.Where(x => x.DepartmentId.Equals(departmentId));
            if (initialDate != null)
                Query.Where(x => x.ReceptionDate >= initialDate);
            if (finalDate != null)
                Query.Where(x => x.ReceptionDate <= finalDate);
            if (isPagingEnabled)
                Query
                    .OrderByDescending(x => x.ReceptionDate)
                    .Skip(PaginationHelper.CalculateSkip(pageSize, page))
                    .Take(PaginationHelper.CalculateTake(pageSize));
            else
                Query
                    .OrderByDescending(x => x.ReceptionDate);
        }
        public CaseSpec()
        {
            Query
                .Include(x => x.OriginDocument)
                .Include(x => x.Brand)
                .Include(x => x.Department)
                .Include(x => x.User)
                .Include(x => x.Reminder)
                .Include(x => x.Province)
                .Include(x => x.CaseStatus)
                .Include(x => x.CaseStatusSecretary)
                .Where(x => x.Status != CatalogsStatus.Deleted)
                .OrderByDescending(x => x.ReceptionDate);

        }
        
        }

    }
}
