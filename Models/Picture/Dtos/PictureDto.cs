using MediatR;
public record PictureDto( IFormFile picture,string Description,string Album, string URL);