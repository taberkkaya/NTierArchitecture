using MediatR;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Features.Products.GetProducts;

public sealed record GetProductsQuery() : IRequest<List<Product>>;
