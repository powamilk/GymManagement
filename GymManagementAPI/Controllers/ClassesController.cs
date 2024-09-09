using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymManagementAPI.Service.Implement;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.ClassVM;
using FluentValidation;

namespace GymManagementAPI.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly IValidator<CreateClassVM> _createValidator;
        private readonly IValidator<UpdateClassVM> _updateValidator;

        public ClassesController(IClassService classService, IValidator<CreateClassVM> createValidator, IValidator<UpdateClassVM> updateValidator)
        {
            _classService = classService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        private IActionResult FormatValidationResponse(FluentValidation.Results.ValidationResult validationResult)
        {
            var errors = validationResult.Errors.Select(error => new
            {
                propertyName = error.PropertyName,
                errorMessage = error.ErrorMessage
            });

            return BadRequest(errors);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var classes = _classService.GetAll();
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var classEntity = _classService.GetById(id);
            if (classEntity == null)
                return NotFound("Lớp học không tồn tại");

            return Ok(classEntity);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateClassVM model)
        {
            var validationResult = _createValidator.Validate(model);
            if (!validationResult.IsValid)
                return FormatValidationResponse(validationResult);

            _classService.Create(model);
            return StatusCode(201, "Lớp học đã được tạo thành công");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateClassVM model)
        {
            var validationResult = _updateValidator.Validate(model);
            if (!validationResult.IsValid)
                return FormatValidationResponse(validationResult);

            var updated = _classService.Update(id, model);
            if (!updated)
                return NotFound("Lớp học không tồn tại");

            return Ok("Cập nhật thành công");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _classService.Delete(id);
            if (!deleted)
                return NotFound("Lớp học không tồn tại");

            return NoContent();
        }
    }
}
