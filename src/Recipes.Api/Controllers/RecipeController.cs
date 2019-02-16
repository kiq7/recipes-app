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
    public class RecipeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRecipeService _service;

        public RecipeController(IRecipeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("receitas")]
        [ProducesResponseType(typeof(IEnumerable<RecipeViewModel>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var recipes = _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<RecipeViewModel>>(recipes));
        }

        [HttpGet("receitas/{id}")]
        [ProducesResponseType(typeof(RecipeViewModel), (int)HttpStatusCode.OK)]
        public IActionResult Get(Guid recipeId)
        {
            var recipe = _service.GetById(recipeId);
            return Ok(_mapper.Map<RecipeViewModel>(recipe));
        }

        [HttpGet("receitas/{id}/ingredientes")]
        [ProducesResponseType(typeof(IEnumerable<IngredientViewModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecipeIngredients(Guid ingredientId)
        {
            var ingredients = _service.GetById(ingredientId).Ingredients; // TODO
            return Ok(_mapper.Map<IEnumerable<IngredientViewModel>>(ingredients));
        }

        [HttpGet("receitas/ingredientes/{id}")]
        [ProducesResponseType(typeof(RecipeViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetRecipesByIngredientId(Guid ingredientId)
        {
            var recipes = _service.GetAll().Where(x => x.Ingredients.Any(y => y.Id == ingredientId)); // TODO
            return Ok(_mapper.Map<RecipeViewModel>(recipes));
        }

        [HttpPost("receita")]
        [ProducesResponseType(typeof(RecipeViewModel), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody] RecipeViewModel recipeViewModel)
        {
            var book = _mapper.Map<Recipe>(recipeViewModel);

            if (book.Invalid)
                return BadRequest(new { Messages = book.Notifications });

            _service.Add(book);
            return Ok(recipeViewModel);
        }
    }
}
