using MediatR;
using NewsApp.Application.Interfaces;

namespace NewsApp.Application.Commands.NewsCommands;

public class CreateNewsCommandHandler(INewsRepository newsRepository, ICategoryRepository categoryRepository)
    : IRequestHandler<CreateNewsCommand>
{
    public async Task Handle(CreateNewsCommand request, CancellationToken cancellationToken)
    {
        foreach (var id in request.CategoryIds)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(id);
            if (category != null)
                request.News.Categories.Add(category);
        }

        newsRepository.CreateNews(request.News);
    }
}