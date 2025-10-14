using StatePattern.Models;
using StatePattern.DTOs;

namespace StatePattern.Services
{
    public interface IDocumentService
    {
        Task<IEnumerable<DocumentDto>> GetAllAsync();
        Task<DocumentDto?> GetByIdAsync(Guid id);
        Task<DocumentDto> CreateDocumentAsync(DocumentCreateDto dto, Guid authorId);
        Task SubmitForReviewAsync(Guid documentId, Guid userId);
        Task ApproveDocumentAsync(Guid documentId, Guid adminId);
        Task RejectDocumentAsync(Guid documentId, Guid adminId, string reason);
        Task PublishDocumentAsync(Guid documentId, Guid adminId);
    }
}
