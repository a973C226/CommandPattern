namespace DrawingApp
{
    public class App
    {
        private List<ICommand> commands = new List<ICommand>();
        private Canvas canvas = new Canvas();

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void ExecuteCommands()
        {
            foreach (var command in commands)
                command.Execute();
        }

        public void UndoCommands()
        {
            for (int i = commands.Count - 1; i >= 0; i--)
                commands[i].Undo();
        }

        public Canvas GetCanvas()
        {
            return canvas;
        }

        public void RedrawCanvas()
        {
            canvas.Redraw();
        }
    }
}
