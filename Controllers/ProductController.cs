using DotNetWebApiSupport.EntityLayer;
using DotNetWebApiSupport.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApiSupport.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  [HttpGet]
  public ActionResult<List<Product>> Get()
  {
    List<Product> list;
    list = new ProductRepository().Get();
    return StatusCode(StatusCodes.Status200OK, list);
  }

  [HttpGet("{id}")]
  public ActionResult<Product> Get(int id)
  {
    
    Product? entity;

    entity = new ProductRepository().Get(id);
    if (entity != null)
    {
      return StatusCode(StatusCodes.Status200OK, entity);
    }
    else
    {
      return StatusCode(StatusCodes.Status404NotFound, $"Can't find Product with a Product Id of '{id}'.");
    }
  }
}
