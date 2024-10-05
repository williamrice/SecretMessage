

using Microsoft.AspNetCore.Mvc;
using webapi.Dto;
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
    public async Task<ActionResult<SecretDTO>> Get(string uuid)
    {
        var secret = await _repository.GetSecretByUUID(uuid);
        if (secret == null)
        {
            return NotFound();
        }
        return Ok(secret);
    }

    [HttpPost]
    public ActionResult<SecretDTO> Post([FromBody] SecretDTO secret)
    {

        var result = _repository.AddSecretAsync(secret);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}