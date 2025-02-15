using MediatR;

namespace NTierArchitecture.Business.Features.Products.UpdateCategory;

public sealed record UpdateCategoryCommand(
    Guid Id,
    string Name,
    decimal Price,
    int Quantity,
    Guid CategoryId) : IRequest;
