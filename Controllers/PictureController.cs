using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using GalleryApi.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
namespace GalleryApi.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
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
        var userIdentity = this.User.Identity;
        if(userIdentity is null || userIdentity.Name is null)
        {
            return BadRequest("There is not a user given.");
        }
        var userName = userIdentity.Name;
        bool flag =_mediator.Send(new UserExistsQuery(userName)).Result;
        if(flag)
        {
            var result = await _mediator.Send(new GetPictureQuery(userName));
            return Ok(result);
        }
        else 
        {
            return NotFound("User not found.");
        }
    }
    [HttpGet]
    [Route("Picture/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var userIdentity = this.User.Identity;
        if(userIdentity is null || userIdentity.Name is null)
        {
            return BadRequest("There is not a user given.");
        }
        var userName = userIdentity.Name;
        bool flag =_mediator.Send(new UserExistsQuery(userName)).Result;
        if(flag)
        {
            var result = await _mediator.Send(new GetPictureByIdQuery(id,userName));
            if(result.Item1.Length<=0 || result.Item2 == "")
                return NotFound($"The id {id} is not in the data base.");
            var response = File(result.Item1, result.Item2);
                return response;
        }
        else 
        {
            return NotFound("User not found.");
        }
    }
    [HttpPost]
    [Route("Picture")]
    public async Task<IActionResult> Create([FromForm]PictureDto picture)
    {   
        var userIdentity = this.User.Identity;
        if(userIdentity is null || userIdentity.Name is null)
        {
            return BadRequest("There is not a user given.");
        }
        var userName = userIdentity.Name;
        bool flag =_mediator.Send(new UserExistsQuery(userName)).Result;
        if(flag)
        {
            var result = await _mediator.Send(new CreatePictureCommand(picture, userName));
            return Ok(result);
        }
        else 
        {
            return NotFound("User not found.");
        }
    }
    [HttpDelete]
    [Route("Picture/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userIdentity = this.User.Identity;
        if(userIdentity is null || userIdentity.Name is null)
        {
            return BadRequest("There is not a user given.");
        }
        var userName = userIdentity.Name;
        bool flag =_mediator.Send(new UserExistsQuery(userName)).Result;
        if(flag)
        {
            var result = await _mediator.Send(new DeletePictureCommand(id,userName));
            return Ok(result);
        }
        else
        {
            return NotFound("User not found.");
        }
    }
    [HttpPut]
    [Route("Picture/{id}")]
    public async Task<IActionResult> Update([FromForm]PictureDto picture,int id)
    {
        var userIdentity = this.User.Identity;
        if(userIdentity is null || userIdentity.Name is null)
        {
            return BadRequest("There is not a user given.");
        }
        var userName = userIdentity.Name;
        bool flag =_mediator.Send(new UserExistsQuery(userName)).Result;
        if(flag)
        {
            // var userName = "string";
            var result = await _mediator.Send(new UpdatePictureCommand(id, picture, userName));
            return Ok(result);
        }
        else
        {
            return NotFound("User not found.");
        }
    }
}
