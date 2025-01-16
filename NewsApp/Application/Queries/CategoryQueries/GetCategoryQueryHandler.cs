using MediatR;
using NewsApp.Application.Interfaces;
using NewsApp.Application.Queries.Category;

namespace NewsApp.Application.Queries.CategoryQueries;

public class GetCategoryQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryQuery, Models.Category?>
{
    public async Task<Models.Category?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetCategoryByIdAsync(request.Id);
        return category;
    }
}