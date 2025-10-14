using StatePattern.Models.Enums;

namespace StatePattern.Models.States
{
    /// <summary>
    /// Defines all actions that a document can perform depending on its current state.
    /// Each concrete state (Draft, Moderation, Published) implements this interface
    /// to enforce valid transitions and role-based permissions.
    /// </summary>
    public interface IDocumentState
    {
        /// <summary>
        /// The type associated with this state (for persistence and factory resolution).
        /// </summary>
        DocumentStateType StateType { get; }

        /// <summary>
        /// Called when a user attempts to submit a draft for moderation.
        /// </summary>
        /// <param name="document">The document instance being modified.</param>
        /// <param name="user">The user performing the action.</param>
        void SubmitForReview(Document document, User user);

        /// <summary>
        /// Called when an admin approves a document currently under moderation.
        /// </summary>
        /// <param name="document">The document instance being modified.</param>
        /// <param name="user">The admin performing the action.</param>
        void Approve(Document document, User user);

        /// <summary>
        /// Called when an admin rejects a document currently under moderation.
        /// </summary>
        /// <param name="document">The document instance being modified.</param>
        /// <param name="user">The admin performing the action.</param>
        void Reject(Document document, User user);

        /// <summary>
        /// Called when an admin directly publishes a draft document.
        /// </summary>
        /// <param name="document">The document instance being modified.</param>
        /// <param name="user">The admin performing the action.</param>
        void Publish(Document document, User user);
    }
}
