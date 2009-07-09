namespace SqlAliaser.UI
{
    public interface ICommand
    {
        void Execute();
        string Title { get; }
    }
}