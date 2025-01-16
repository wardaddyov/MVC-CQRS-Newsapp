using MediatR;
using NewsApp.Application.Interfaces;
using NewsApp.Models;

namespace NewsApp.Application.Queries.NewsQueries;

public class GetAllNewsCommandHandler(INewsRepository newsRepository): IRequestHandler<GetAllNewsCommand, ICollection<News?>>
{
    public async Task<ICollection<News?>> Handle(GetAllNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await newsRepository.GetAllNews();
        return news;
    }
}