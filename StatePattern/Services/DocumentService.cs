using AutoMapper;
using StatePattern.Models;
using StatePattern.DTOs;
using StatePattern.Repositories;
using StatePattern.Models.Enums;

namespace StatePattern.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;
        private readonly IMapper _mapper;

        public DocumentService(IDocumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DocumentDto>> GetAllAsync()
        {
            var docs = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DocumentDto>>(docs);
        }

        public async Task<DocumentDto?> GetByIdAsync(Guid id)
        {
            var doc = await _repository.GetByIdAsync(id);
            return doc == null ? null : _mapper.Map<DocumentDto>(doc);
        }

        public async Task<DocumentDto> CreateDocumentAsync(DocumentCreateDto dto, Guid authorId)
        {
            var document = _mapper.Map<Document>(dto);
            document.AuthorId = authorId;
            document.StateType = DocumentStateType.Draft;

            await _repository.AddAsync(document);
            return _mapper.Map<DocumentDto>(document);
        }

        public async Task SubmitForReviewAsync(Guid documentId, Guid userId)
        {
            var doc = await _repository.GetByIdAsync(documentId);
            if (doc == null) throw new Exception("Document not found");

            if (doc.AuthorId != userId)
                throw new UnauthorizedAccessException("You are not the author");

            doc.SubmitForReview(await GetUserById(userId)); // State pattern call
            await _repository.UpdateAsync(doc);
        }

        public async Task ApproveDocumentAsync(Guid documentId, Guid adminId)
        {
            var doc = await _repository.GetByIdAsync(documentId);
            if (doc == null) throw new Exception("Document not found");

            doc.Approve(await GetUserById(adminId)); // State pattern call
            await _repository.UpdateAsync(doc);
        }

        public async Task RejectDocumentAsync(Guid documentId, Guid adminId, string reason)
        {
            var doc = await _repository.GetByIdAsync(documentId);
            if (doc == null) throw new Exception("Document not found");

            doc.Reject(await GetUserById(adminId), reason);
            await _repository.UpdateAsync(doc);
        }

        public async Task PublishDocumentAsync(Guid documentId, Guid adminId)
        {
            var doc = await _repository.GetByIdAsync(documentId);
            if (doc == null) throw new Exception("Document not found");

            doc.Publish(await GetUserById(adminId));
            await _repository.UpdateAsync(doc);
        }

        // Dummy method to get user by ID — replace with UserManager in real app
        private async Task<User> GetUserById(Guid userId)
        {
            // This should call UserManager<User>.FindByIdAsync(userId.ToString())
            // For simplicity, just throw for now
            throw new NotImplementedException("Inject UserManager<User> to retrieve users");
        }
    }
}
