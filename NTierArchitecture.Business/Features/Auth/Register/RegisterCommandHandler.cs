using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArchitecture.Entities.Events.Users;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Auth.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMediator _mediator;
    public RegisterCommandHandler(UserManager<AppUser> userManager, IMediator mediator)
    {
        _userManager = userManager;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUserNameExist = await _userManager.FindByNameAsync(request.UserName);
        if (checkUserNameExist is not null)
        {
            throw new ArgumentException("Bu kullanıcı adı daha önceden alınmış.");
        }

        var checkEmailNameExist = await _userManager.FindByEmailAsync(request.Email);
        if (checkEmailNameExist is not null)
        {
            throw new ArgumentException("Bu email adresi ile kayıtlı kullanıcı zaten mevcut.");
        }

        AppUser appUser = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            UserName = request.UserName,
            Name = request.Name,
            LastName = request.Lastname
        };

        await _userManager.CreateAsync(appUser,request.Password);

        await _mediator.Publish(new UserDomainEvent(appUser));

        return Unit.Value;
    }
}