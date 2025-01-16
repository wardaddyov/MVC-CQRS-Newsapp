using MediatR;
using NewsApp.Models;

namespace NewsApp.Application.Queries.NewsQueries;

public record GetSingleNewsQuery(int Id) : IRequest<News?>;