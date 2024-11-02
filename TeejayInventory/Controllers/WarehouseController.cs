using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TeejayInventory.Interface;
using TeejayInventory.Models.Dto;
using TeejayInventory.Models;

namespace TeejayInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepo;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public WarehouseController(IWarehouseRepository warehouseRepo, IMapper mapper)
        {
            _warehouseRepo = warehouseRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetStocks()
        {
            try
            {
                var warehouseLists = await _warehouseRepo.GetAllAsync(includeProperties: "Stocks.Product");
                _response.Result = _mapper.Map<List<WarehouseDto>>(warehouseLists);
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

        [HttpGet("{id:int}", Name = "GetWarehouse")]
        public async Task<ActionResult<APIResponse>> GetCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var warehouse = await _warehouseRepo.GetAsync(x => x.WarehouseId == id, includeProperties: "Stocks.Product");
                if (warehouse == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<WarehouseDto>(warehouse);
                _response.IsSuccess = true;
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
        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateWarehouse([FromBody] CreateWarehouseDto createWarehouseDto)
        {
            try
            {
                if (createWarehouseDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var model = _mapper.Map<Warehouse>(createWarehouseDto);
                await _warehouseRepo.CreateAsync(model);
                await _warehouseRepo.SaveAsync();

                _response.Result = _mapper.Map<WarehouseDto>(model);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetWarehouse", new { id = model.WarehouseId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        //[HttpPut("{id:int}")]
        //public async Task<ActionResult<APIResponse>> UpdateStock(int id, [FromBody] UpdateStockDto updateStockDto)
        //{
        //    try
        //    {
        //        if (id == 0 || updateStockDto.StockId != id)
        //        {
        //            _response.IsSuccess = false;
        //            _response.StatusCode = HttpStatusCode.BadRequest;
        //            return BadRequest(_response);
        //        }
        //        var stockFromDb = await _stockRepo.GetAsync(x => x.StockId == id);
        //        if (stockFromDb == null)
        //        {
        //            _response.IsSuccess = false;
        //            _response.StatusCode = HttpStatusCode.NotFound;
        //            return BadRequest(_response);
        //        }
        //        _mapper.Map(updateStockDto, stockFromDb);
        //        await _stockRepo.UpdateAsync(stockFromDb);
        //        _response.IsSuccess = true;
        //        _response.StatusCode = HttpStatusCode.NoContent;
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
