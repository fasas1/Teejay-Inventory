using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TeejayInventory.Data;
using TeejayInventory.Interface;
using TeejayInventory.Models;
using TeejayInventory.Models.Dto;

namespace TeejayInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public ProductController(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetProducts()
        {
            try
            {
                var productLists = await _productRepo.GetAllAsync();
                _response.Result = _mapper.Map<List<ProductDto>>(productLists);
                _response.StatusCode = HttpStatusCode.OK;

                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };

            }
            return _response;
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task <ActionResult<APIResponse>> GetProduct(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                var Product = await _productRepo.GetAsync(u => u.ProductId == id);
                if (Product == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest();
                }
                _response.Result = _mapper.Map<ProductDto>(Product);
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
              
            }
            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            try
            {
                if (createProductDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var model = _mapper.Map<Product>(createProductDto);
                await _productRepo.CreateAsync(model);
                await _productRepo.SaveAsync();

                _response.Result = _mapper.Map<ProductDto>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetProduct", new { id = model.ProductId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name= "UpdateProduct")]
        public async Task<ActionResult<APIResponse>> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            try
            {
                if (id == 0 || updateProductDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var productFromDb = await _productRepo.GetAsync(u => u.ProductId == id);
                if (productFromDb == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                _mapper.Map(updateProductDto,productFromDb);
                await _productRepo.UpdateAsync(productFromDb);

                _response.Result = _mapper.Map<ProductDto>(productFromDb);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
             return _response;
        }

        [HttpDelete]
        public async Task<ActionResult<APIResponse>> DeleteProduct(int id)
        {
            try
            {
              if(id == 0)
                {
                    _response.IsSuccess= false;
                    _response.StatusCode = HttpStatusCode.BadRequest; 
                    return BadRequest(_response);
                }
              var model = await _productRepo.GetAsync(u =>u.ProductId == id);
                if(model == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return NotFound(_response);
                }
                await _productRepo.RemoveAsync(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
             return _response;
        }
    }
}
