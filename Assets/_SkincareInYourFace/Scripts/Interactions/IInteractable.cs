namespace Campero.SkincareInYourFace.Interactions
{
    public interface IInteractable
    {
        CursorModel Cursor { get; }
        void Interact();
        void SetHighlight(bool highlight);
    }
}