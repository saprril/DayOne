namespace StatePattern.Models.Enums
{
    /// <summary>
    /// Represents the possible workflow states of a Document.
    /// This enum value is persisted in the database and used
    /// to reconstruct the corresponding IDocumentState at runtime.
    /// </summary>
    public enum DocumentStateType
    {
        /// <summary>
        /// Document is created but not yet submitted for review.
        /// Editable by its author (user or admin).
        /// </summary>
        Draft = 0,

        /// <summary>
        /// Document is submitted by a regular user
        /// and waiting for admin approval.
        /// </summary>
        Moderation = 1,

        /// <summary>
        /// Document has been approved and published.
        /// Only admins can publish.
        /// </summary>
        Published = 2
    }
}
