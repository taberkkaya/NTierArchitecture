using MediatR;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Products.RemoveProductById;

public sealed record RemoveProductByIdCommand(Guid Id) : IRequest;
