using StatePattern.Models.Enums;

namespace StatePattern.DTOs
{
    // For returning document data
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public Guid? ReviewerId { get; set; }
        public string? ReviewerName { get; set; }
        public DocumentStateType StateType { get; set; }
        public string? RejectedReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
