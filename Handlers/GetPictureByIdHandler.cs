using GalleryApi.Data;
using MediatR;

class GetPictureByIdHandler : IRequestHandler<GetPictureByIdQuery, (byte[],string)>
{
    private readonly IPictureRepository<PictureDto, Picture> repository;
    public GetPictureByIdHandler(IPictureRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }
    public async Task<(byte[],string)> Handle(GetPictureByIdQuery request, CancellationToken cancellationToken)
    {
        var picture = repository.Get(request.id);   
        var response = repository.RetrievePicture(picture.PicturePathInPersistence!);
        return await Task.FromResult((response,picture.ContentType));
    }
}