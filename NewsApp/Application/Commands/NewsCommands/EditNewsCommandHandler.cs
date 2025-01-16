using MediatR;
using NewsApp.Application.Interfaces;

namespace NewsApp.Application.Commands.NewsCommands;

public class EditNewsCommandHandler(INewsRepository newsRepository, ICategoryRepository categoryRepository) : IRequestHandler<EditNewsCommand>
{
    public async Task Handle(EditNewsCommand request, CancellationToken cancellationToken)
    {

        var news = request.News;
        
        news.Categories.Clear();

        foreach (var id in request.CategoryIds)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(id);
            if (category != null)
                request.News.Categories.Add(category);
        }

        newsRepository.UpdateNews(news);
    }
}