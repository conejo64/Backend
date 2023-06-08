using Ardalis.Specification;
using Shared.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Specifications.CaseSpecs;

public sealed class CaseReminderSpec : Ardalis.Specification.Specification<CaseEntity>, ISingleResultSpecification
{
    public CaseReminderSpec()
    {
        var today = DateTime.Now;
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
                        && x.CaseStatus!.Description == "ABIERTO"
            )
            .OrderByDescending(x => x.ReceptionDate);

    }
}