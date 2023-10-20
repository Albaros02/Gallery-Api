using MediatR;
public record CreatePictureCommand(Picture picture) : IRequest<IAsyncResult>; 
