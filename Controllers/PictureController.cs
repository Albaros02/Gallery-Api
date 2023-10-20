using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using GalleryApi.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
namespace GalleryApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("")]
public class PictureController : ControllerBase
{
    private readonly IRepository<Picture> repository;
    private readonly IMediator _mediator;

    public PictureController(IRepository<Picture> repository, IMediator mediator)
    {
        this.repository = repository;
        this._mediator = mediator;
    }
    [HttpGet]
    [Route("Picture")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetPictureQuery());
        return Ok(result);        
    }
    [HttpGet]
    [Route("Picture/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetPictureByIdQuery(id));
        return Ok(result);
    }
    [HttpPost]
    [Route("Picture")]
    public async Task<IActionResult> Create(Picture picture)
    {
        var result = await _mediator.Send(new CreatePictureCommand(picture));
        return Ok(result);
    }
    [HttpDelete]
    [Route("Picture/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeletePictureCommand(id));
        return Ok(result);
    }
    [HttpPut]
    [Route("Picture/{id}")]
    public async Task<IActionResult> Update(int id, Picture picture)
    {
        var result = await _mediator.Send(new UpdatePictureCommand(id, picture));
        return Ok(result);
    }
}
