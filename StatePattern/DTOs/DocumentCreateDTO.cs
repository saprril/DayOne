    using StatePattern.Models.Enums;
namespace StatePattern.DTOs;
    public class DocumentCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }