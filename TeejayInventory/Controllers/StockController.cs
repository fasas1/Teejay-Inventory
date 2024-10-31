using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TeejayInventory.Interface;
using TeejayInventory.Models;
using TeejayInventory.Models.Dto;

namespace TeejayInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepo;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public StockController(IStockRepository stockRepo, IMapper mapper)
        {
            _stockRepo = stockRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetStocks()
        {
            try
            {
                var stockLists = await _stockRepo.GetAllAsync(includeProperties: "Product,Warehouse");
                _response.Result = _mapper.Map<List<StockDto>>(stockLists);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        //[HttpGet("{id:int}", Name = "GetCategory")]
        //public async Task<ActionResult<APIResponse>> GetCategory(int id)
        //{
        //    try
        //    {
        //        if (id == 0)
        //        {
        //            _response.IsSuccess = false;
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var category = await _categoryRepo.GetAsync(x => x.CategoryId == id);
        //        if (category == null)
        //        {
        //            _response.IsSuccess = false;
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return NotFound(_response);
        //        }

        //        _response.Result = _mapper.Map<CategoryDto>(category);
        //        _response.IsSuccess = true;
        //        _response.StatusCode = HttpStatusCode.OK;
        //        return Ok(_response);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages = new List<string> { ex.Message };
        //    }
        //    return _response;
        //}
    }
}
