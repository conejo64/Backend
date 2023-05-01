﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shared.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class BaseController : ControllerBase
{
    #region Contructor && Properties

    public IMediator Mediator { get; }

    public BaseController(IMediator mediator)
    {
        Mediator = mediator;
    }

    #endregion
}