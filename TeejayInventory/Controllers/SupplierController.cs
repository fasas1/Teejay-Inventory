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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplyRepo;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public SupplierController(ISupplierRepository supplyRepo, IMapper mapper)
        {
            _supplyRepo = supplyRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetSupplies()
        {
            try
            {
                var supplyLists = await _supplyRepo.GetAllAsync();
                _response.Result = _mapper.Map<List<SupplierDto>>(supplyLists);
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

        [HttpGet("{id:int}", Name ="GetSupply")]
        public async Task<ActionResult<APIResponse>> GetSupply(int id)
        {
            try
            {
              if(id == 0)
               {
                  _response.IsSuccess=false;
                 _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
              var supply = await _supplyRepo.GetAsync(x => x.SupplierId == id); 
                if(supply == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return NotFound(_response);
                }
                
                _response.Result = _mapper.Map<SupplierDto>(supply);
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
        public async Task<ActionResult<APIResponse>> CreateSupply([FromBody] CreateSupplierDto createSupplierDto)
        {
            try
            {
              if(createSupplierDto == null)
                {
                    _response.IsSuccess=false;
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var model =  _mapper.Map<Supplier>(createSupplierDto);
                      await _supplyRepo.CreateAsync(model);
                       await _supplyRepo.SaveAsync();

                _response.IsSuccess = true;
                _response.Result = _mapper.Map<SupplierDto>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetSupplier", new { id = model.SupplierId }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpPut("{id:int}", Name="UpdateSupply")]
        public async Task<ActionResult<APIResponse>> UpdateSupply(int id, [FromBody] UpdateSupplierDto updateSupplierDto)
        {
            try
            {
              if(id == 0 || updateSupplierDto.SupplierId != id)
                {
                    _response.IsSuccess=false;
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
              var supplyFromDb = await _supplyRepo.GetAsync(x => x.SupplierId == id);
                if(supplyFromDb == null)
                {
                    _response.IsSuccess=false;
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return NotFound(_response);
                }
                 _mapper.Map(updateSupplierDto, supplyFromDb);
                  await _supplyRepo.UpdateAsync(supplyFromDb);
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
        public async Task <ActionResult<APIResponse>> DeleteSupply(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var model = await _supplyRepo.GetAsync(x => x.SupplierId == id);
                if (model == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return NotFound(_response);
                }
                await _supplyRepo.RemoveAsync(model);
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
