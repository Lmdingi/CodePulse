﻿using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpPost] //https://localhost:7176/api/Categories

        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

           await categoryRepository.CreateAsync(category);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            return Ok(response);
        }

        [HttpGet] //https://localhost:7176/api/Categories
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryRepository.GetAllAsync();

            var response = new List<CategoryDto>();

            foreach (var category in categories) 
            {
                response.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    UrlHandle = category.UrlHandle,
                });
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id) 
        {
            var existingCategory = await categoryRepository.GetById(id);

            if(existingCategory is null)
            {
                return NotFound();
            }

            var response = new CategoryDto
            {
                Id = existingCategory.Id,
                Name = existingCategory.Name,
                UrlHandle = existingCategory.UrlHandle,
            };

            return Ok(response);
        }

    }
}
