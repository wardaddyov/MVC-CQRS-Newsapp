using MediatR;
using NewsApp.Application.Interfaces;
using NewsApp.Models;

namespace NewsApp.Application.Commands;

public class EditCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<EditCategoryCommand, Category>
{
    public Task<Category> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        categoryRepository.UpdateCategory(request.Category);
        return Task.FromResult(request.Category);
    }
}