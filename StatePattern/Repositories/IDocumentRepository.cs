using StatePattern.Models;

namespace StatePattern.Repositories
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllAsync();
        Task<Document?> GetByIdAsync(Guid id);
        Task<IEnumerable<Document>> GetByAuthorIdAsync(Guid authorId);
        Task AddAsync(Document document);
        Task UpdateAsync(Document document);
        Task DeleteAsync(Document document);
    }
}
