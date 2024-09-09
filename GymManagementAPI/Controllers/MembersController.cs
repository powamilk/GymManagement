using FluentValidation;
using GymManagementAPI.Extensions;
using GymManagementAPI.Service.Interface;
using GymManagementAPI.ViewModel.MemberVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementAPI.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IValidator<CreateMemberVM> _createMemberValidator;
        private readonly IValidator<UpdateMemberVM> _updateMemberValidator;

        public MemberController(IMemberService memberService, IValidator<CreateMemberVM> createMemberValidator, IValidator<UpdateMemberVM> updateMemberValidator)
        {
            _memberService = memberService;
            _createMemberValidator = createMemberValidator;
            _updateMemberValidator = updateMemberValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberService.GetAllAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound(new { message = "Thành viên không tồn tại." });
            }
            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberVM model)
        {
            var validationResult = _createMemberValidator.Validate(model);
            var validationResponse = validationResult.ToValidationResponse();
            if (!validationResult.IsValid)
            {
                return validationResponse;
            }

            var result = await _memberService.CreateAsync(model);
            if (result)
            {
                return Ok(new { message = "Thành viên được tạo thành công." });
            }

            return StatusCode(500, "Đã có lỗi xảy ra.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] UpdateMemberVM model)
        {
            var validationResult = _updateMemberValidator.Validate(model);
            var validationResponse = validationResult.ToValidationResponse();
            if (!validationResult.IsValid)
            {
                return validationResponse;
            }

            var result = await _memberService.UpdateAsync(id, model);
            if (result)
            {
                return Ok(new { message = "Thành viên đã được cập nhật thành công." });
            }

            return NotFound(new { message = "Thành viên không tồn tại." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var result = await _memberService.DeleteAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound(new { message = "Thành viên không tồn tại." });
        }
    }
}
