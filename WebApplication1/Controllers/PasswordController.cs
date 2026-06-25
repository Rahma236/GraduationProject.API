using GraduationProject.API.DTOs;
using GraduationProject.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            // هنا ستضيفين منطق إرسال إيميل الـ Reset
            return Ok(ApiResponse<object>.Success(null, "Reset instructions sent to your email"));
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDto dto)
        {
            // هنا ستضيفين منطق تغيير كلمة السر في القاعدة
            return Ok(ApiResponse<object>.Success(null, "Password reset successfully"));
        }
    }
}
