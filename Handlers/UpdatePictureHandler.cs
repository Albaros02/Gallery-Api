using GalleryApi.Data;
using MediatR;

class UpdatePictureHandler : IRequestHandler<UpdatePictureCommand, IAsyncResult>
{
    private readonly IRepository<PictureDto, Picture> repository;
    public UpdatePictureHandler(IRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }

    public async Task<IAsyncResult> Handle(UpdatePictureCommand request, CancellationToken cancellationToken)
    {
        return await repository.Update(request.id,request.picture);
    }
}