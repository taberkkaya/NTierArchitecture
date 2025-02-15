using MediatR;

namespace NTierArchitecture.Business.Features.Categories.RemoveCategory;

public sealed record RemoveCategoryByIdCommand(Guid Id) : IRequest;
