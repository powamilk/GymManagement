using FluentValidation;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.TrainerVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/trainers")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerService _trainerService;
        private readonly IValidator<CreateTrainerVM> _createValidator;
        private readonly IValidator<UpdateTrainerVM> _updateValidator;

        public TrainersController(ITrainerService trainerService, IValidator<CreateTrainerVM> createValidator, IValidator<UpdateTrainerVM> updateValidator)
        {
            _trainerService = trainerService;
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
            var trainers = _trainerService.GetAll();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var trainer = _trainerService.GetById(id);
            if (trainer == null)
                return NotFound("Huấn luyện viên không tồn tại");

            return Ok(trainer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTrainerVM model)
        {
            var validationResult = _createValidator.Validate(model);
            if (!validationResult.IsValid)
                return FormatValidationResponse(validationResult);

            _trainerService.Create(model);
            return StatusCode(201, "Huấn luyện viên đã được tạo thành công");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateTrainerVM model)
        {
            var validationResult = _updateValidator.Validate(model);
            if (!validationResult.IsValid)
                return FormatValidationResponse(validationResult);

            var updated = _trainerService.Update(id, model);
            if (!updated)
                return NotFound("Huấn luyện viên không tồn tại");

            return Ok("Cập nhật thành công");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _trainerService.Delete(id);
            if (!deleted)
                return NotFound("Huấn luyện viên không tồn tại");

            return NoContent();
        }
    }
}
