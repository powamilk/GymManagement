using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymManagementAPI.Service.Implement;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.ClassVM;
using FluentValidation;
using GymManagementAPI.Extensions;

namespace GymManagementAPI.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IValidator<CreateClassVM> _createClassValidator;
        private readonly IValidator<UpdateClassVM> _updateClassValidator;

        public ClassController(IClassService classService, IValidator<CreateClassVM> createClassValidator, IValidator<UpdateClassVM> updateClassValidator)
        {
            _classService = classService;
            _createClassValidator = createClassValidator;
            _updateClassValidator = updateClassValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _classService.GetAllAsync();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            var classEntity = await _classService.GetByIdAsync(id);
            if (classEntity == null)
            {
                return NotFound(new { message = "Lớp học không tồn tại." });
            }
            return Ok(classEntity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] CreateClassVM model)
        {
            var validationResult = _createClassValidator.Validate(model);
            var validationResponse = validationResult.ToValidationResponse();
            if (!validationResult.IsValid)
            {
                return validationResponse;
            }

            var result = await _classService.CreateAsync(model);
            if (result)
            {
                return Ok(new { message = "Lớp học được tạo thành công." });
            }

            return StatusCode(500, "Đã có lỗi xảy ra.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, [FromBody] UpdateClassVM model)
        {
            var validationResult = _updateClassValidator.Validate(model);
            var validationResponse = validationResult.ToValidationResponse();
            if (!validationResult.IsValid)
            {
                return validationResponse;
            }

            var result = await _classService.UpdateAsync(id, model);
            if (result)
            {
                return Ok(new { message = "Lớp học đã được cập nhật thành công." });
            }

            return NotFound(new { message = "Lớp học không tồn tại." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var result = await _classService.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound(new { message = "Lớp học không tồn tại." });
        }
    }
}
