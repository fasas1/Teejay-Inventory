﻿using AutoMapper;
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

        [HttpGet("{id:int}", Name = "GetStock")]
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
                var stock = await _stockRepo.GetAsync(x => x.StockId == id, includeProperties:"Product,Warehouse");
                if (stock == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<StockDto>(stock);
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
        public async Task<ActionResult<APIResponse>> CreateStock([FromBody] CreateStockDto createStockDto)
        {
            try
            {
              if(createStockDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
              var model = _mapper.Map<Stock>(createStockDto);
                await _stockRepo.CreateAsync(model);
                await _stockRepo.SaveAsync();

                 _response.Result  = _mapper.Map<StockDto>(model);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetStock", new { id = model.StockId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<APIResponse>> UpdateStock(int id, [FromBody] UpdateStockDto updateStockDto)
        {
            try
            {
                if (id == 0 || updateStockDto.StockId != id)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var stockFromDb = await _stockRepo.GetAsync(x => x.StockId == id);
                if (stockFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return BadRequest(_response);
                }
                _mapper.Map(updateStockDto, stockFromDb);
                 await _stockRepo.UpdateAsync(stockFromDb);
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
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> DeleteStock(int id)
        {
            try
            {
                if (id == 0 )
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var stockFromDb = await _stockRepo.GetAsync(x => x.StockId == id);
                if (stockFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return BadRequest(_response);
                }
                
                await _stockRepo.RemoveAsync(stockFromDb);
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
