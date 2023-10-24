using GalleryApi.Data;
using MediatR;

class UpdatePictureHandler : IRequestHandler<UpdatePictureCommand, IAsyncResult>
{
    private readonly IPictureRepository<PictureDto, Picture> repository;
    public UpdatePictureHandler(IPictureRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }

    public async Task<IAsyncResult> Handle(UpdatePictureCommand request, CancellationToken cancellationToken)
    {
        return await repository.Update(request.id,request.picture, request.name);
    }
}