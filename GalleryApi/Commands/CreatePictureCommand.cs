using MediatR;
public record CreatePictureCommand(PictureDto picture, string? name) : IRequest<IAsyncResult>; 
