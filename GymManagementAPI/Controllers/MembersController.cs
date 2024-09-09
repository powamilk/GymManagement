using FluentValidation;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.MemberVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IValidator<CreateMemberVM> _createValidator;
        private readonly IValidator<UpdateMemberVM> _updateValidator;

        public MembersController(IMemberService memberService, IValidator<CreateMemberVM> createValidator, IValidator<UpdateMemberVM> updateValidator)
        {
            _memberService = memberService;
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
            var members = _memberService.GetAll();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var member = _memberService.GetById(id);
            if (member == null)
                return NotFound("Thành viên không tồn tại");

            return Ok(member);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateMemberVM model)
        {
            var validationResult = _createValidator.Validate(model);
            if (!validationResult.IsValid)
                return FormatValidationResponse(validationResult);

            _memberService.Create(model);
            return StatusCode(201, "Thành viên đã được tạo thành công");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateMemberVM model)
        {
            var validationResult = _updateValidator.Validate(model);
            if (!validationResult.IsValid)
                return FormatValidationResponse(validationResult);

            var updated = _memberService.Update(id, model);
            if (!updated)
                return NotFound("Thành viên không tồn tại");

            return Ok("Cập nhật thành công");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _memberService.Delete(id);
            if (!deleted)
                return NotFound("Thành viên không tồn tại");

            return NoContent();
        }
    }
}
