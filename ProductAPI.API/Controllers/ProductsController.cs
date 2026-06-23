using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Application.Features.Products.DTOs.Requests;

namespace ProductAPI.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedAll(int pageNumber, int pageSize)
        {
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            return Ok();
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request)
        {
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
