using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatePattern.DTOs;
using StatePattern.Services;
using System.Security.Claims;

namespace StatePattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // ------------------ Get all documents ------------------
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var documents = await _documentService.GetAllAsync();
            return Ok(documents);
        }

        // ------------------ Get a single document ------------------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var document = await _documentService.GetByIdAsync(id);
            if (document == null) return NotFound();
            return Ok(document);
        }

        // ------------------ Create a new document (Draft) ------------------
        [HttpPost("create")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Create([FromBody] DocumentCreateDto dto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var document = await _documentService.CreateDocumentAsync(dto, userId);
            return Ok(document);
        }

        // ------------------ Submit document for review ------------------
        [HttpPost("{id}/submit")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> SubmitForReview(Guid id)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _documentService.SubmitForReviewAsync(id, userId);
            return Ok(new { Message = "Document submitted for review" });
        }

        // ------------------ Admin: Approve document ------------------
        [HttpPost("{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(Guid id)
        {
            var adminId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _documentService.ApproveDocumentAsync(id, adminId);
            return Ok(new { Message = "Document approved" });
        }

        // ------------------ Admin: Reject document ------------------
        [HttpPost("{id}/reject")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Reject(Guid id, [FromBody] string reason)
        {
            var adminId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _documentService.RejectDocumentAsync(id, adminId, reason);
            return Ok(new { Message = "Document rejected" });
        }

        // ------------------ Admin: Publish document directly ------------------
        [HttpPost("{id}/publish")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Publish(Guid id)
        {
            var adminId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _documentService.PublishDocumentAsync(id, adminId);
            return Ok(new { Message = "Document published" });
        }
    }
}
