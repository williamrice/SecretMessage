

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
        var secrets = _repository.GetSecretsAsync().Result;
        return Ok(secrets);
    }
}