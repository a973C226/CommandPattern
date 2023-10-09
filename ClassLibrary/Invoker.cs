namespace ClassLibrary
{
    // Инициатор команды
    public class Invoker
    {
        private readonly ICommand _command;

        public Invoker(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
}
