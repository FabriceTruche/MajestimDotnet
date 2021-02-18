namespace Majestim.View.Interface.Component
{
    public interface IProgressBar
    {
        void Show();
        void Hide();
        void Next();
        void Reset();

        int Min { get; }
        int Max { get; }
        int Step { get; }
        int Value { get; }
    }
}