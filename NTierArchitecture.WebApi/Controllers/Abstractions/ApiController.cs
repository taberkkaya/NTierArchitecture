﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NTierArchitecture.WebApi.Controllers.Abstractions;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    public readonly IMediator _mediator;

    protected ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
