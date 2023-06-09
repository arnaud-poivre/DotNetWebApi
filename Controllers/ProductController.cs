using DotNetWebApiSupport.EntityLayer;
using DotNetWebApiSupport.RepositoryLayer;
using DotNetWebApiSupport.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApiSupport.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  private IRepository<Product> _repo;
  public ProductController(IRepository<Product> repository)
  {
    
    _repo = repository;
  }

  [HttpGet]
  public ActionResult<List<Product>> Get()
  {
    List<Product> list;
    list = _repo.Get();
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

  [HttpGet]
  [Route("ByCategory/{categoryId}")]
  public ActionResult<IEnumerable<Product>> SearchByCategory(int categoryId)
  {
    // TODO : recherche par catégorie à implémenter
    return StatusCode(StatusCodes.Status200OK);
  }

  [HttpGet]
  [Route("ByNameAndPrice/Name/{name}/Price/{price}")]
  public ActionResult<IEnumerable<Product>> SearchByNameAndPrice(string name, decimal price)
  {
    // TODO : recherche par nom et prix à implémenter
    return StatusCode(StatusCodes.Status200OK);
  }

  [HttpGet]
  [Route("ByNameAndPrice")]
  public ActionResult<IEnumerable<Product>> SearchByNameAndPriceQS(string name, decimal price)
  {
    // TODO : recherche par nom et prix à implémenter
    return StatusCode(StatusCodes.Status200OK);
  }
}
