using MediatR;

namespace NewsApp.Application.Queries.CategoryQueries;

public record CategoryNameQuery(string Name) : IRequest<bool>;