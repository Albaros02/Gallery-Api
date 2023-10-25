using GalleryApi.Data;
using MediatR;
using Microsoft.AspNetCore.Http.Features;

class GetPictureByIdDetailsHandler : IRequestHandler<GetPictureByIdDetailsQuery, Picture?>
{
    private readonly IPictureRepository<PictureDto, Picture> repository;
    public GetPictureByIdDetailsHandler(IPictureRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }
    public Task<Picture?> Handle(GetPictureByIdDetailsQuery request, CancellationToken cancellationToken)
    {
        var picture = repository.Get(request.id);   
        var name = (request.userName is null)? "nullName": request.userName;
        Picture? response = null;
        if(picture is null || picture.UserName != name)
            return Task.FromResult(response);
        response = repository.Get(request.id);
        return Task.FromResult(response)!;
    }
}