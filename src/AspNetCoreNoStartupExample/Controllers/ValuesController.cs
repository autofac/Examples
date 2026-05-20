using AspNetCoreNoStartupExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreNoStartupExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private readonly IValuesService _valuesService;

    public ValuesController(IValuesService valuesService)
    {
        _valuesService = valuesService;
    }

    [HttpGet]
    public IEnumerable<string> Get()
    {
        return _valuesService.FindAll();
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
        return _valuesService.Find(id);
    }
}
