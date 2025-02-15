using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;


namespace NTierArchitecture.Business.Features.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    private readonly IUnitOfWork _unitOfWork;
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {

        var isCategoryNameExist = await _categoryRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);

        if (isCategoryNameExist)
        {
            throw new ArgumentException("Category name is exist.");
        }

        Category category = new()
        {
            Name = request.Name
        };

        await _categoryRepository.AddAsync(category,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}