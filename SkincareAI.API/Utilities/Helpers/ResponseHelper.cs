using SkincareAI.API.Models.Responses;

namespace SkincareAI.API.Utilities.Helpers
{
    public static class ResponseHelper
    {
        public static ApiResponse<T> Success<T>(T data, string message = "Operation completed successfully")
        {
            return ApiResponse<T>.SuccessResponse(data, message);
        }

        public static ApiResponse<T> Error<T>(string message, List<string>? errors = null)
        {
            return ApiResponse<T>.ErrorResponse(message, errors);
        }
    }
}