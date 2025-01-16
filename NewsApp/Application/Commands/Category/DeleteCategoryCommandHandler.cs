using MediatR;
using NewsApp.Application.Interfaces;

namespace NewsApp.Application.Commands;

public class DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetCategoryByIdAsync(request.Id);
        categoryRepository.DeleteCategory(category);
    }
}