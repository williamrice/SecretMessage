using Microsoft.AspNetCore.Http.Extensions;
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
    private readonly IUrlGeneratorService _urlGeneratorService;

    private readonly ILogger<SecretController> _logger;
    public SecretController(ISecretRepository repository, IUrlGeneratorService urlGeneratorService, ILogger<SecretController> logger)
    {
        _repository = repository;
        _urlGeneratorService = urlGeneratorService;

        _logger = logger;
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
    public async Task<ActionResult<SecretPostReturnDTO?>> Post([FromBody] CreateSecretDTO secret)
    {
        _logger.LogInformation("Secret: {secret}", secret);

        var result = await _repository.AddSecretAsync(secret);
        if (result == null)
        {
            return BadRequest();
        }
        var baseUrl = Request.Headers.Origin.ToString();

        if (String.IsNullOrEmpty(baseUrl))
        {
            return BadRequest();
        }

        var url = _urlGeneratorService.GenerateUrl(result.UUID, baseUrl);

        var secretPostReturnDTO = new SecretPostReturnDTO { Url = url };
        return Ok(secretPostReturnDTO);
    }
}