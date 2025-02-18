using FluentValidation;

namespace NTierArchitecture.Business.Features.Roles.CreateRole;

public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Rol adı boş olamaz.");        
        
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Rol adı boş olamaz.");        
        
        RuleFor(x => x.Name)
            .MinimumLength(3)
            .WithMessage("Rol adı 3 karakterden fazla olmalı.");
    }
}