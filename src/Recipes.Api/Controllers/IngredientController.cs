using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.Api.ViewModels;
using Recipes.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Net;

namespace Recipes.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("ingredientes")]
        [ProducesResponseType(typeof(IEnumerable<IngredientViewModel>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var ingredients = _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<IngredientViewModel>>(ingredients));
        }
    }
}
