using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using GalleryApi.Data;
namespace GalleryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PictureController : ControllerBase
{
    private readonly IRepository<Picture> repository;

    public PictureController(IRepository<Picture> repository)
    {
        this.repository = repository;
    }
    [HttpGet]
    [Route("Picture")]
    public IActionResult Get()
    {
        return Ok(repository.GetAll());
    }
    [HttpGet]
    [Route("Picture/{id}")]
    public IActionResult Get(int id)
    {
        return Ok(repository.Get(id));
    }
    [HttpPost]
    [Route("Picture")]
    public IActionResult Get(Picture picture)
    {
        return Ok(repository.Create(picture));
    }
    [HttpDelete]
    [Route("Picture/{id}")]
    public IActionResult Delete(int id)
    {
        return Ok(repository.Delete(id));
    }
    [HttpPut]
    [Route("Picture/{id}")]
    public IActionResult Delete(int id, Picture picture)
    {
        return Ok(repository.Update(id,picture));
    }
}
