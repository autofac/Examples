using System.Collections.Generic;
using AspNetCore3Example.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore3Example.Controllers
{
    /// <summary>
    /// Simple REST API controller that shows Autofac injecting dependencies.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService _valuesService;

        public ValuesController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _valuesService.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _valuesService.Find(id);
        }
    }
}
