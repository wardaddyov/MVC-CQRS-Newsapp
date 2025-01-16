using MediatR;

namespace NewsApp.Application.Queries.CategoryQueries;

public class GetCategoriesQuery : IRequest<ICollection<Models.Category?>>
{
    
}