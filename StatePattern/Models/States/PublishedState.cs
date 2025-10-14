using System;
using StatePattern.Models.Enums;

namespace StatePattern.Models.States
{
    /// <summary>
    /// Represents the "Published" state of a document.
    /// Published documents are finalized and visible to users.
    /// Only Admins can revert them back to draft.
    /// </summary>
    public class PublishedState : IDocumentState
    {
        public DocumentStateType StateType => DocumentStateType.Published;

        public void SubmitForReview(Document document, User user)
        {
            throw new InvalidOperationException("Cannot submit a published document for review.");
        }

        public void Approve(Document document, User user)
        {
            throw new InvalidOperationException("Document is already published.");
        }

        public void Reject(Document document, User user)
        {
            throw new InvalidOperationException("Cannot reject a published document.");
        }

        public void Publish(Document document, User user)
        {
            if (user.Role != "Admin")
                throw new UnauthorizedAccessException("Only admins can manage published documents.");

            // Re-publishing could just reaffirm the state
            document.ChangeState(DocumentStateType.Published);
        }

        /// <summary>
        /// Optional helper for Admins to unpublish a document (return to draft).
        /// </summary>
        public void Unpublish(Document document, User user)
        {
            if (user.Role != "Admin")
                throw new UnauthorizedAccessException("Only admins can unpublish documents.");

            document.ChangeState(DocumentStateType.Draft);
        }
    }
}
