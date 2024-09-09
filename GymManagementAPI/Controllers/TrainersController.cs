using FluentValidation;
using GymManagementAPI.Extensions;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.TrainerVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/trainers")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;
        private readonly IValidator<CreateTrainerVM> _createTrainerValidator;
        private readonly IValidator<UpdateTrainerVM> _updateTrainerValidator;

        public TrainerController(ITrainerService trainerService, IValidator<CreateTrainerVM> createTrainerValidator, IValidator<UpdateTrainerVM> updateTrainerValidator)
        {
            _trainerService = trainerService;
            _createTrainerValidator = createTrainerValidator;
            _updateTrainerValidator = updateTrainerValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainers()
        {
            var trainers = await _trainerService.GetAllAsync();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainerById(int id)
        {
            var trainer = await _trainerService.GetByIdAsync(id);
            if (trainer == null)
            {
                return NotFound(new { message = "Huấn luyện viên không tồn tại." });
            }
            return Ok(trainer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainer([FromBody] CreateTrainerVM model)
        {
            var validationResult = _createTrainerValidator.Validate(model);
            var validationResponse = validationResult.ToValidationResponse();
            if (!validationResult.IsValid)
            {
                return validationResponse;
            }

            var result = await _trainerService.CreateAsync(model);
            if (result)
            {
                return Ok(new { message = "Huấn luyện viên được tạo thành công." });
            }

            return StatusCode(500, "Đã có lỗi xảy ra.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer(int id, [FromBody] UpdateTrainerVM model)
        {
            var validationResult = _updateTrainerValidator.Validate(model);
            var validationResponse = validationResult.ToValidationResponse();
            if (!validationResult.IsValid)
            {
                return validationResponse;
            }

            var result = await _trainerService.UpdateAsync(id, model);
            if (result)
            {
                return Ok(new { message = "Huấn luyện viên đã được cập nhật thành công." });
            }

            return NotFound(new { message = "Huấn luyện viên không tồn tại." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var result = await _trainerService.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound(new { message = "Huấn luyện viên không tồn tại." });
        }
    }
}
