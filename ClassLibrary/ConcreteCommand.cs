namespace ClassLibrary
{
    // Конкретная команда
    public class ConcreteCommand : ICommand
    {
        private readonly Receiver _receiver;
        private readonly string _parameter;

        public ConcreteCommand(Receiver receiver, string parameter)
        {
            _receiver = receiver;
            _parameter = parameter;
        }

        public void Execute()
        {
            _receiver.Action(_parameter);
        }
    }
}
