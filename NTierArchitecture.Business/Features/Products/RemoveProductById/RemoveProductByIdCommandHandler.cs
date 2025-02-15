using MediatR;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Products.RemoveProductById;

public sealed class RemoveProductByIdCommandHandler : IRequestHandler<RemoveProductByIdCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveProductByIdCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveProductByIdCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(x => x.Id == request.Id, cancellationToken);
        if(product is null)
        {
            throw new ArgumentException("Product not found!");
        }

        _productRepository.Remove(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}