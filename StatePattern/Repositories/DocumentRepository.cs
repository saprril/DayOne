using Microsoft.EntityFrameworkCore;
using StatePattern.Data;
using StatePattern.Models;

namespace StatePattern.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all documents including Author and Reviewer
        public async Task<IEnumerable<Document>> GetAllAsync()
        {
            return await _context.Documents
                .Include(d => d.Author)
                .Include(d => d.Reviewer)
                .ToListAsync();
        }

        // Get document by its Guid ID
        public async Task<Document?> GetByIdAsync(Guid id)
        {
            return await _context.Documents
                .Include(d => d.Author)
                .Include(d => d.Reviewer)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        // Get all documents by a specific author
        public async Task<IEnumerable<Document>> GetByAuthorIdAsync(Guid authorId)
        {
            return await _context.Documents
                .Include(d => d.Author)
                .Include(d => d.Reviewer)
                .Where(d => d.AuthorId == authorId)
                .ToListAsync();
        }

        // Add new document
        public async Task AddAsync(Document document)
        {
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
        }

        // Update existing document
        public async Task UpdateAsync(Document document)
        {
            _context.Documents.Update(document);
            await _context.SaveChangesAsync();
        }

        // Delete document
        public async Task DeleteAsync(Document document)
        {
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
        }
    }
}
