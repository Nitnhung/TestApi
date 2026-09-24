namespace TestApi.DTOs
{
    public class SoftDeleteResult
    {
        public SoftDeleteStatus Status { get; set; }
        public string? ErrorMessage { get; set; }

        public static SoftDeleteResult Ok() =>new() { Status = SoftDeleteStatus.Success };

        public static SoftDeleteResult NotFound(string message) =>new() { Status = SoftDeleteStatus.NotFound, ErrorMessage = message };

        public static SoftDeleteResult Conflict(string message) => new() { Status = SoftDeleteStatus.InvalidStatus, ErrorMessage = message };
    }
    public enum SoftDeleteStatus{Success,NotFound, InvalidStatus}
}
