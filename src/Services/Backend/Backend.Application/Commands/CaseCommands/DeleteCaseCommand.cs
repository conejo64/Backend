using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Commands.CaseCommands;

public class DeleteCaseCommand : IRequest<EntityResponse<bool>>
{
    public Guid Id { get; }

    public DeleteCaseCommand(Guid id)
    {
        Id = id;
    }
}