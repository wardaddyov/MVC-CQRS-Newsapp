using MediatR;

namespace NewsApp.Application.Queries.Category;

public record GetCategoryQuery(int Id) : IRequest<Models.Category?>;