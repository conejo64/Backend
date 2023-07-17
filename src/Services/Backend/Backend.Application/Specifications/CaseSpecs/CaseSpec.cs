using Ardalis.Specification;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Specifications.CaseSpecs;

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
            .Include(x => x.TypeRequirement)
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
            .Include(x => x.TypeRequirement)
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
        {
            finalDate = finalDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
            Query.Where(x => x.ReceptionDate <= finalDate);
        }
            
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
            .Include(x => x.TypeRequirement)
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
            .Include(x => x.TypeRequirement)
            .Where(x => x.Status != CatalogsStatus.Deleted)
            .OrderByDescending(x => x.ReceptionDate);

    }
        
    public CaseSpec(DateTime today)
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
            .Include(x => x.TypeRequirement)
            .Where(x => x.Status != CatalogsStatus.Deleted
                        && x.Deadline!.Value.Year == today.Year
                        && x.Deadline.Value.Month == today.Month
                        && x.Deadline.Value.Day == today.Day
                        && x.CaseStatus!.Description!.Equals("ABIERTO"))
            .OrderByDescending(x => x.ReceptionDate);

    }
        
    public CaseSpec(string stage, DateTime today)
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
            .Include(x => x.TypeRequirement)
            .Where(x => x.Status != CatalogsStatus.Deleted
                        && x.CaseStage == StageEnum.Others
                        && x.ReminderDate!.Value.Year == today.Year
                        && x.ReminderDate.Value.Month == today.Month
                        && x.ReminderDate.Value.Day == today.Day
                        && x.ReminderDate.Value.Hour == today.Hour
                        && x.CaseStatus!.Description!.Equals("ABIERTO"))
            .OrderByDescending(x => x.ReceptionDate);

    }
}