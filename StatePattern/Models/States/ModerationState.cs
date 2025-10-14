using System;
using StatePattern.Models.Enums;

namespace StatePattern.Models.States
{
    /// <summary>
    /// Represents the "Moderation" state of a document.
    /// Only Admins can approve or reject documents in this state.
    /// </summary>
    public class ModerationState : IDocumentState
    {
        public DocumentStateType StateType => DocumentStateType.Moderation;

        public void SubmitForReview(Document document, User user)
        {
            throw new InvalidOperationException("Document is already under moderation.");
        }

        public void Approve(Document document, User user)
        {
            if (user.Role != "Admin")
                throw new UnauthorizedAccessException("Only admins can approve documents under moderation.");

            document.ChangeState(DocumentStateType.Published);
        }

        public void Reject(Document document, User user)
        {
            if (user.Role != "Admin")
                throw new UnauthorizedAccessException("Only admins can reject documents under moderation.");

            document.ChangeState(DocumentStateType.Draft);
        }

        public void Publish(Document document, User user)
        {
            throw new InvalidOperationException("Document must be approved before publishing.");
        }
    }
}
