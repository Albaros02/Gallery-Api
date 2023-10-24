using MediatR;
public record DeletePictureCommand(int id, string userName) : IRequest<IAsyncResult>; 
