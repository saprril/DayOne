using System;
using System.ComponentModel.DataAnnotations.Schema;
using StatePattern.Models.Enums;
using StatePattern.Models.States;

namespace StatePattern.Models
{
    public class Document
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        // Foreign Key
        public Guid AuthorId { get; set; }

        public User Author { get; set; } = null!;

        public Guid? ReviewedBy { get; set; }

        public User? Reviewer { get; set; }

        // Enum persisted in DB
        public DocumentStateType StateType { get; set; } = DocumentStateType.Draft;

        // Optional metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string? RejectedReason { get; set; }

        // --- State Pattern integration ---
        [NotMapped]
        private IDocumentState? _stateBehavior;

        [NotMapped]
        public IDocumentState StateBehavior
        {
            get
            {
                // Lazy-load state object based on persisted StateType
                _stateBehavior ??= StateFactory.Create(StateType);
                return _stateBehavior;
            }
            private set => _stateBehavior = value;
        }

        // --- Domain Methods (delegating behavior to the state class) ---
        public void SubmitForReview(User user)
        {
            StateBehavior.SubmitForReview(this, user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void Approve(User user)
        {
            StateBehavior.Approve(this, user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void Reject(User user, string reason)
        {
            RejectedReason = reason;
            StateBehavior.Reject(this, user);
            UpdatedAt = DateTime.UtcNow;
        }

        public void Publish(User user)
        {
            StateBehavior.Publish(this, user);
            UpdatedAt = DateTime.UtcNow;
        }

        // --- Called by state classes to transition state safely ---
        public void ChangeState(DocumentStateType newState)
        {
            StateType = newState;
            StateBehavior = StateFactory.Create(newState);
        }
    }
}
