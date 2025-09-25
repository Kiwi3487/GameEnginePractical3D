namespace Assets
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}