using GalleryApi.Data;
using MediatR;

class DeletePictureHandler : IRequestHandler<DeletePictureCommand, IAsyncResult>
{
    private readonly IRepository<Picture> repository;
    public DeletePictureHandler(IRepository<Picture> repository) 
    {
        this.repository = repository;
    }

    public Task<IAsyncResult> Handle(DeletePictureCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(repository.Delete(request.id));
    }
}