using MediatR;
using NewsApp.Application.Interfaces;
using NewsApp.Models;

namespace NewsApp.Application.Queries;

public class GetCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryCommand, Category?>
{
    public async Task<Category?> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetCategoryByIdAsync(request.Id);
        return category;
    }
}