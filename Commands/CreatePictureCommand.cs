using MediatR;
public record CreatePictureCommand(PictureDto picture) : IRequest<IAsyncResult>; 
