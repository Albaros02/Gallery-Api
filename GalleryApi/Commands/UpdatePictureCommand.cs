using MediatR;
public record UpdatePictureCommand(int id, PictureDto picture, string name) : IRequest<IAsyncResult>; 
