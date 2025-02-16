﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Auth.Login;
using NTierArchitecture.Business.Features.Auth.Register;
using NTierArchitecture.WebApi.Controllers.Abstractions;

namespace NTierArchitecture.WebApi.Controllers;

public class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request,CancellationToken cancellationToken)
    {
        await _mediator.Send(request,cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}

