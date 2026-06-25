using GraduationProject.API.DTOs;
using GraduationProject.API.Helpers;
using GraduationProject.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GraduationProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(
            UserManager<User> userManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        // ===================== REGISTER =====================
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ApiResponse<object>.Failure("Invalid data provided"));

            var user = new User
            {
                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.FullName,
                UserType = dto.UserType.ToString(),
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return BadRequest(ApiResponse<object>.Failure(errors.FirstOrDefault() ?? "Registration failed"));
            }

            // إسناد الدور مع التحقق
            string role = dto.UserType.ToString();
            await _userManager.AddToRoleAsync(user, await _roleManager.RoleExistsAsync(role) ? role : "Student");

            return Ok(ApiResponse<object>.Success(new { user.Id, user.Email }, "User registered successfully"));
        }

        // ===================== LOGIN =====================
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            // تحسين: التحقق من وجود المستخدم، كلمة المرور، وحالة التفعيل
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password) || !user.IsActive)
                // غيري السطر 70 ليصبح كالتالي:
                return Unauthorized(ApiResponse<object>.Failure("Invalid credentials or account inactive"));
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim("UserType", user.UserType)
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // توليد الـ Token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7), // زيادة المدة لراحة المستخدم
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return Ok(ApiResponse<object>.Success(new { Token = new JwtSecurityTokenHandler().WriteToken(token) }, "Login successful"));
        }
    }
}
