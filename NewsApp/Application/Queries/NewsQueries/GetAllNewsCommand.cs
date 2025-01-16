using MediatR;
using NewsApp.Models;

namespace NewsApp.Application.Queries.NewsQueries;

public record GetAllNewsCommand() : IRequest<ICollection<News?>>;
