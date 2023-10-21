using MediatR;
public record UpdatePictureCommand(int id, PictureDto picture) : IRequest<IAsyncResult>; 
