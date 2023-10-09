namespace DrawingApp
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}
