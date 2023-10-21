using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using GalleryApi.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
namespace GalleryApi.Controllers;

// [Authorize(AuthenticationSchemes = "Bearer")]
[ApiController]
[Route("")]
public class PictureController : ControllerBase
{
    private readonly IMediator _mediator;

    public PictureController(IMediator mediator)
    {
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
        if(result.Item1.Length<=0 || result.Item2 == "")
            return NotFound($"The id {id} is not in the data base.");
        var response = File(result.Item1, result.Item2);
        return response;
    }
    [HttpPost]
    [Route("Picture")]
    public async Task<IActionResult> Create([FromForm]PictureDto picture)
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
    public async Task<IActionResult> Update([FromForm]PictureDto picture,int id)
    {
        var result = await _mediator.Send(new UpdatePictureCommand(id, picture));
        return Ok(result);
    }
}
