using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands;

public class UpdateInformationCaseCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }
    //Screen Department
    public string? Comments { get; set; }

    public UpdateInformationCaseCommand(Guid id, string? comments)
    {
        Id = id;
        Comments = comments;
    }
}