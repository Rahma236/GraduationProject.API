using System;
using System.Collections.Generic;

namespace GraduationProject.API.Helpers
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // 1. في حالة النجاح
        public static ApiResponse<T> Success(T data, string? message = null, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                IsSuccess = true,
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessageForStatusCode(statusCode),
                Data = data,
                Errors = null
            };
        }

        // 2. في حالة الفشل (قائمة أخطاء)
        public static ApiResponse<T> Failure(List<string> errors, string? message = null, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessageForStatusCode(statusCode),
                Data = default,
                Errors = errors
            };
        }

        // 3. في حالة الفشل (رسالة خطأ واحدة)
        public static ApiResponse<T> Failure(string errorMessage, string? message = null, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                IsSuccess = false,
                StatusCode = statusCode,
                Message = message ?? GetDefaultMessageForStatusCode(statusCode),
                Data = default,
                Errors = new List<string> { errorMessage }
            };
        }

     
        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Request completed successfully.",
                201 => "New record created successfully.",
                400 => "Validation failed. Please check your inputs.",
                401 => "Access denied. Please login first.",
                404 => "The requested data could not be found.",
                500 => "Server error. Please try again later.",
                _ => "An unexpected error occurred."
            };
        }
    }
}

