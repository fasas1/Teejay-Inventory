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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public CategoryController(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetCategories()
        {
            try
            {
                var categoryLists = await _categoryRepo.GetAllAsync();
                _response.Result = _mapper.Map<List<CategoryDto>>(categoryLists);
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

        [HttpGet("{id:int}", Name ="GetCategory")]
        public async Task<ActionResult<APIResponse>> GetCategory(int id)
        {
            try
            {
              if(id == 0)
               {
                  _response.IsSuccess=false;
                 _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
              var category = await _categoryRepo.GetAsync(x => x.CategoryId == id); 
                if(category == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return NotFound(_response);
                }
                
                _response.Result = _mapper.Map<CategoryDto>(category);
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
        public async Task<ActionResult<APIResponse>> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            try
            {
              if(createCategoryDto == null)
                {
                    _response.IsSuccess=false;
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var model =  _mapper.Map<Category>(createCategoryDto);
                      await _categoryRepo.CreateAsync(model);
                       await _categoryRepo.SaveAsync();

                _response.IsSuccess = true;
                _response.Result = _mapper.Map<CategoryDto>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpPut("{id:int}", Name="UpdateCategory")]
        public async Task<ActionResult<APIResponse>> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            try
            {
              if(id == 0 || updateCategoryDto.CategoryId != id)
                {
                    _response.IsSuccess=false;
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
              var categoryFromDb = await _categoryRepo.GetAsync(x => x.CategoryId == id);
                if(categoryFromDb == null)
                {
                    _response.IsSuccess=false;
                    _response.StatusCode=HttpStatusCode.BadRequest;
                    return NotFound(_response);
                }
                 _mapper.Map(updateCategoryDto,categoryFromDb);
                  await _categoryRepo.UpdateAsync(categoryFromDb);
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
        public async Task <ActionResult<APIResponse>> DeleteCategory(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var model = await _categoryRepo.GetAsync(x => x.CategoryId == id);
                if (model == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return NotFound(_response);
                }
                await _categoryRepo.RemoveAsync(model);
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
