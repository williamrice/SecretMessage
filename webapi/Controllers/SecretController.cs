

using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class SecretController : ControllerBase
{
    private readonly ISecretRepository _repository;
    public SecretController(ISecretRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<List<Secret>> Get()
    {

        return NotFound();
    }

    [HttpGet("{uuid}")]
    public ActionResult<Secret> Get(string uuid)
    {
        var secret = _repository.GetSecretByUUIDAsync(uuid);
        if (secret == null)
        {
            return NotFound();
        }
        return Ok(secret);
    }
}