

namespace Ventas.Application.Core
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Result { get; set; } = null;
    }
}
