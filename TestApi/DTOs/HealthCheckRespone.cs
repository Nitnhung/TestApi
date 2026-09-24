namespace TestApi.DTOs
{
    public class HealthCheckRespone: BaseRespone
    {
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
