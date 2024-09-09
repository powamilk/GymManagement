using FluentValidation;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.ClassRegistrationVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/registrations")]
    [ApiController]
    public class ClassRegistrationsController : ControllerBase
    {
        private readonly IClassRegistrationService _registrationService;
        private readonly IValidator<CreateClassRegistrationVM> _createValidator;
        private readonly IValidator<UpdateClassRegistrationVM> _updateValidator;

        public ClassRegistrationsController(IClassRegistrationService registrationService, IValidator<CreateClassRegistrationVM> createValidator, IValidator<UpdateClassRegistrationVM> updateValidator)
        {
            _registrationService = registrationService;
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
            var registrations = _registrationService.GetAll();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var registration = _registrationService.GetById(id);
            if (registration == null)
                return NotFound("Đăng ký không tồn tại");

            return Ok(registration);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateClassRegistrationVM model)
        {
            var validationResult = _createValidator.Validate(model);
            if (!validationResult.IsValid)
                return FormatValidationResponse(validationResult);

            _registrationService.Create(model);
            return StatusCode(201, "Đăng ký lớp học thành công");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateClassRegistrationVM model)
        {
            var validationResult = _updateValidator.Validate(model);
            if (!validationResult.IsValid)
                return FormatValidationResponse(validationResult);

            var updated = _registrationService.Update(id, model);
            if (!updated)
                return NotFound("Đăng ký không tồn tại");

            return Ok("Cập nhật đăng ký thành công");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _registrationService.Delete(id);
            if (!deleted)
                return NotFound("Đăng ký không tồn tại");

            return NoContent();
        }
    }
}
