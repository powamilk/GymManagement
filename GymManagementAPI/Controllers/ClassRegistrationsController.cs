using FluentValidation;
using GymManagementAPI.Extensions;
using GymManagementAPI.Service.Implement;
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
        private readonly IClassRegistrationService _classRegistrationService;
        private readonly IValidator<CreateClassRegistrationVM> _createClassRegistrationValidator;
        private readonly IValidator<UpdateClassRegistrationVM> _updateClassRegistrationValidator;

        public ClassRegistrationsController(IClassRegistrationService classRegistrationService, IValidator<CreateClassRegistrationVM> createClassRegistrationValidator, IValidator<UpdateClassRegistrationVM> updateClassRegistrationValidator)
        {
            _classRegistrationService = classRegistrationService;
            _createClassRegistrationValidator = createClassRegistrationValidator;
            _updateClassRegistrationValidator = updateClassRegistrationValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegistrations()
        {
            var registrations = await _classRegistrationService.GetAllAsync();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationById(int id)
        {
            var registration = await _classRegistrationService.GetByIdAsync(id);
            if (registration == null)
            {
                return NotFound(new { message = "Đăng ký không tồn tại." });
            }
            return Ok(registration);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistration([FromBody] CreateClassRegistrationVM model)
        {
            var validationResult = _createClassRegistrationValidator.Validate(model);
            var validationResponse = validationResult.ToValidationResponse();
            if (!validationResult.IsValid)
            {
                return validationResponse;
            }

            var result = await _classRegistrationService.CreateAsync(model);
            if (result)
            {
                return Ok(new { message = "Đăng ký lớp học thành công." });
            }

            return StatusCode(500, "Đã có lỗi xảy ra.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration(int id, [FromBody] UpdateClassRegistrationVM model)
        {
            var validationResult = _updateClassRegistrationValidator.Validate(model);
            var validationResponse = validationResult.ToValidationResponse();
            if (!validationResult.IsValid)
            {
                return validationResponse;
            }

            var result = await _classRegistrationService.UpdateAsync(id, model);
            if (result)
            {
                return Ok(new { message = "Đăng ký lớp học đã được cập nhật thành công." });
            }

            return NotFound(new { message = "Đăng ký không tồn tại." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var result = await _classRegistrationService.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound(new { message = "Đăng ký không tồn tại." });
        }
    }
}
