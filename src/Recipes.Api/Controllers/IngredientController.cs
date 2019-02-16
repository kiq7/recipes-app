using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.Api.ViewModels;
using Recipes.Domain.Entities;
using Recipes.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Recipes.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecipeService _service; // TODO

        public IngredientController(IRecipeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("ingredientes")]
        [ProducesResponseType(typeof(IEnumerable<RecipeViewModel>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var recipes = _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<RecipeViewModel>>(recipes));
        }
    }
}
