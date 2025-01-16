using MediatR;
using NewsApp.Application.Interfaces;

namespace NewsApp.Application.Commands.NewsCommands;

public class DeleteNewsCommandHandler(INewsRepository newsRepository) : IRequestHandler<DeleteNewsCommand>
{
    public Task Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        newsRepository.DeleteNews(request.News);
        return Task.CompletedTask;
    }
}