using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetByIdAsync(p => p.Id == request.id, cancellationToken);

        if (category is null)
        {
            throw new ArgumentException("Category not found");
        }

        if (category.Name != request.Name)
        {
            var isCategoryNameExist = await _categoryRepository.AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (isCategoryNameExist)
            {
                throw new ArgumentException("Category name is exist.");
            }

            category.Name = request.Name;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
