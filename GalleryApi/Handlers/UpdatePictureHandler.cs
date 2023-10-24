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
        var name = (request.name is null)? "nullName": request.name;
        return await repository.Update(request.id,request.picture, name);
    }
}