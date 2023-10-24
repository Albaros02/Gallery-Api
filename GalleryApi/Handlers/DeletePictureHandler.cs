using GalleryApi.Data;
using MediatR;

class DeletePictureHandler : IRequestHandler<DeletePictureCommand, IAsyncResult>
{
    private readonly IPictureRepository<PictureDto, Picture> repository;
    public DeletePictureHandler(IPictureRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }
    public async Task<IAsyncResult> Handle(DeletePictureCommand request, CancellationToken cancellationToken)
    {
        var name = (request.userName is null)? "nullName": request.userName;
        return await repository.Delete(request.id, name);
    }
}