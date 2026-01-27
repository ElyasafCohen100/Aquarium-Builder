namespace AquariumBuilder.Backend.Dtos.Common
{
    public class ErrorResponseDto
    {
        public int StatusCode { get; set; }
        public string Error { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
