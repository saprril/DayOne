using System;
using StatePattern.Models.Enums;

namespace StatePattern.Models.States
{
    /// <summary>
    /// Represents the "Draft" state of a document.
    /// Users can submit for moderation.
    /// Admins can directly publish from draft.
    /// </summary>
    public class DraftState : IDocumentState
    {
        public DocumentStateType StateType => DocumentStateType.Draft;

        public void SubmitForReview(Document document, User user)
        {
            if (user.Role != "User")
                throw new UnauthorizedAccessException("Only regular users can submit drafts for moderation.");

            document.ChangeState(DocumentStateType.Moderation);
        }

        public void Approve(Document document, User user)
        {
            throw new InvalidOperationException("Cannot approve a document in Draft state.");
        }

        public void Reject(Document document, User user)
        {
            throw new InvalidOperationException("Cannot reject a document in Draft state.");
        }

        public void Publish(Document document, User user)
        {
            if (user.Role != "Admin")
                throw new UnauthorizedAccessException("Only admins can publish a draft.");

            document.ChangeState(DocumentStateType.Published);
        }
    }
}
