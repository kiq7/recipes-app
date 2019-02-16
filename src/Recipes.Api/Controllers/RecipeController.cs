using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Recipes.Api.ViewModels;
using Recipes.Domain.Entities;
using Recipes.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net;

namespace Recipes.Api.Controllers
{
    [Route("api/")]
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
        [ProducesResponseType(typeof(IEnumerable<RecipesListViewModel>), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var recipes = _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<RecipesListViewModel>>(recipes));
        }

        [HttpGet("receitas/{recipeId}")]
        [ProducesResponseType(typeof(RecipeViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetById(Guid recipeId)
        {
            var recipe = _service.GetById(recipeId);
            return Ok(_mapper.Map<RecipeViewModel>(recipe));
        }

        [HttpGet("receitas/{recipeId}/ingredientes")]
        [ProducesResponseType(typeof(IEnumerable<IngredientViewModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetRecipeIngredients(Guid recipeId)
        {
            var ingredients = _service.GetRecipeIngredients(recipeId);
            return Ok(_mapper.Map<IEnumerable<IngredientViewModel>>(ingredients));
        }

        [HttpGet("receitas/ingredientes/{ingredientId}")]
        [ProducesResponseType(typeof(RecipeViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetRecipesByUsedIngredient(Guid ingredientId)
        {
            var recipes = _service.GetRecipesByUsedIngredient(ingredientId);
            return Ok(_mapper.Map<IEnumerable<RecipeViewModel>>(recipes));
        }

        [HttpPost("receita")]
        [ProducesResponseType(typeof(AddRecipeViewModel), (int)HttpStatusCode.OK)]
        public IActionResult Post([FromBody] AddRecipeViewModel addRecipeViewModel)
        {
            var recipe = _mapper.Map<Recipe>(addRecipeViewModel);

            if (recipe.Invalid)
                return BadRequest(new { Messages = recipe.Notifications });

            _service.Add(recipe);
            return Ok(addRecipeViewModel);
        }
    }
}
