using GraduationProject.API.DTOs;
using GraduationProject.API.Helpers;
using GraduationProject.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // يتطلب تسجيل دخول
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound(ApiResponse<object>.Failure("User not found"));

            user.FullName = dto.FullName ?? user.FullName;
            user.Specialization = dto.Specialization ?? user.Specialization;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return BadRequest(ApiResponse<object>.Failure("Update failed"));

            return Ok(ApiResponse<object>.Success(null, "Profile updated successfully"));
        }
    }
}
