using StatePattern.Models.Enums;
namespace StatePattern.Models.States
{
    public static class StateFactory
    {
        public static IDocumentState Create(DocumentStateType stateType) => stateType switch
        {
            DocumentStateType.Draft => new DraftState(),
            DocumentStateType.Moderation => new ModerationState(),
            DocumentStateType.Published => new PublishedState(),
            _ => throw new ArgumentOutOfRangeException(nameof(stateType))
        };
    }
}
