using GalleryApi.Data;
using MediatR;

class DeletePictureHandler : IRequestHandler<DeletePictureCommand, IAsyncResult>
{
    private readonly IRepository<PictureDto, Picture> repository;
    public DeletePictureHandler(IRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }
    public async Task<IAsyncResult> Handle(DeletePictureCommand request, CancellationToken cancellationToken)
    {
        return await repository.Delete(request.id);
    }
}