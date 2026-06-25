using GraduationProject.API.Models;
using GraduationProject.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. ربط الـ DbContext مع الـ Connection String (كودك القديم)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. إضافة خدمات الـ Identity لإدارة الحسابات والباسوردات (جديد)
builder.Services.AddIdentity<User, IdentityRole>(options => {
    options.Password.RequireDigit = true;         // الباسورد لازم يحتوي على رقم
    options.Password.RequiredLength = 6;          // أقل طول للباسورد 6 حروف
    options.Password.RequireNonAlphanumeric = false; // مش شرط رموز معقدة
    options.Password.RequireUppercase = false;       // مش شرط حروف كابيتال
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// 3. إعدادات الـ JWT Authentication لتأمين الـ APIs بالتوكن (جديد)
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "GraduationProjectIssuer",
        ValidAudience = builder.Configuration["Jwt:Audience"] ?? "GraduationProjectAudience",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "SuperSecretKey1234567890123456"))
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 4. ترتيب الـ Middleware مهم جداً: التحقق من الهوية أولاً ثم الصلاحيات
app.UseAuthentication(); // (جديد)
app.UseAuthorization();  // (كودك القديم)

app.MapControllers();

app.Run();
