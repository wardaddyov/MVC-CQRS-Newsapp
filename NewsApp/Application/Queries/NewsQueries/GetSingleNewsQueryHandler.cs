using MediatR;
using NewsApp.Application.Interfaces;
using NewsApp.Models;

namespace NewsApp.Application.Queries.NewsQueries;

public class GetSingleNewsQueryHandler(INewsRepository newsRepository): IRequestHandler<GetSingleNewsQuery, News?>
{
    public async Task<News?> Handle(GetSingleNewsQuery request, CancellationToken cancellationToken)
    {
        var news = await newsRepository.GetNewsDetailsById(request.Id);
        return news;
    }
}