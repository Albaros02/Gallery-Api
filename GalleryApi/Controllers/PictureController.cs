using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using GalleryApi.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
namespace GalleryApi.Controllers;

// Comment here to avoid auth.
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
        if(isAuthorizedUser(User.Identity))
        {
            var result = await _mediator.Send(new GetPictureQuery(User.Identity!.Name!));
            return Ok(result);
        }
        else 
        {
            return BadRequest("There is not a user given or invalid.");
        }
    }
    [HttpGet]
    [Route("Picture/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        if(isAuthorizedUser(User.Identity))
        {
            var result = await _mediator.Send(new GetPictureByIdQuery(id,User.Identity!.Name!));
            if(result.Item1.Length<=0 || result.Item2 == "")
                return NotFound($"The id {id} is not in the data base.");
            var response = File(result.Item1, result.Item2);
                return response!;
        }
        else 
        {
            return BadRequest("There is not a user given or invalid.");
        }
    }
    [HttpPost]
    [Route("Picture")]
    public async Task<IActionResult> Create([FromForm]PictureDto picture)
    {   
        if(isAuthorizedUser(User.Identity))
        {
            var result = await _mediator.Send(new CreatePictureCommand(picture, User.Identity!.Name!));
            return Ok(result);
        }
        else 
        {
            return BadRequest("There is not a user given or invalid.");
        }
    }
    [HttpDelete]
    [Route("Picture/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if(isAuthorizedUser(User.Identity))
        {
            var result = await _mediator.Send(new DeletePictureCommand(id,User.Identity!.Name!));
            return Ok(result);
        }
        else 
        {
            return BadRequest("There is not a user given or invalid.");
        }
    }
    [HttpPut]
    [Route("Picture/{id}")]
    public async Task<IActionResult> Update([FromForm]PictureDto picture,int id)
    {
        if(isAuthorizedUser(User.Identity))
        {
            var result = await _mediator.Send(new UpdatePictureCommand(id, picture,User.Identity!.Name!));
            return Ok(result);
        }
        else 
        {
            return BadRequest("There is not a user given or invalid.");
        }
    }
    private bool isAuthorizedUser(IIdentity? userIdentity)
    {
        // Uncomment this line and comment the decorator in top
        // of the controller to use the api with no auth.
        // return true;
        if(userIdentity is null || userIdentity.Name is null)
        {
            return false;
        }
        var userName = userIdentity.Name;
        bool flag =_mediator.Send(new UserExistsQuery(userName)).Result;
        return flag;
    }
}
