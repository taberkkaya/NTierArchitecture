using AutoMapper;
using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Products.CreateProduct;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var isProductNameExist = await _productRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);
        if (isProductNameExist) {
            throw new ArgumentException("Product name is exist.");
        }

        Product product = _mapper.Map<Product>(request);

        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}