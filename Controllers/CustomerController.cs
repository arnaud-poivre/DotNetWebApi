using DotNetWebApiSupport.EntityLayer;
using DotNetWebApiSupport.Interfaces;
using DotNetWebApiSupport.RepositoryLayer;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApiSupport.Controllers;

[Route("[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
  private IRepository<Customer> _repo;

  public CustomerController(IRepository<Customer> repository){
    _repo = repository;
  }
  [HttpGet]
  public ActionResult<List<Customer>> Get()
  {
    List<Customer> list;
    list = _repo.Get();
    return StatusCode(StatusCodes.Status200OK, list);
  }

  [HttpGet("{id}")]
  public ActionResult<Customer> Get(int id)
  {
    
    Customer? entity;

    entity = new CustomerRepository().Get(id);
    if (entity != null)
    {
      return StatusCode(StatusCodes.Status200OK, entity);
    }
    else
    {
      return StatusCode(StatusCodes.Status404NotFound, $"Can't find Customer with a Customer Id of '{id}'.");
    }
  }

  [HttpGet]
  [Route("ByTitle")]
  public ActionResult<IEnumerable<Customer>> SearchByTitle(string title)
  {
    IEnumerable<Customer>? entities;
    entities = new CustomerRepository().GetByTitle(title);
    return StatusCode(StatusCodes.Status200OK, entities);
  }

  [HttpGet]
  [Route("ByFirstAndLastName/First/{firstName:alpha:maxlength(50)}/Last/{lastName:alpha:maxlength(50)}")]
  public ActionResult<IEnumerable<Customer>> SearchByFirstAndLastName(string firstName, string lastName)
  {
    IEnumerable<Customer>? entities;
    entities = new CustomerRepository().GetByFirstAndLastName(firstName,lastName);
    return StatusCode(StatusCodes.Status200OK, entities);
  }


}
