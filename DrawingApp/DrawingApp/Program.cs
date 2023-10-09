using DrawingApp;
using System.Drawing;

App app = new App();

// Рисуем линию кистью
ICommand brushCommand = new BrushCommand(app.GetCanvas(), new Point(0, 0), new Point(10, 10));
app.AddCommand(brushCommand);

// Стираем линию ластиком
ICommand eraserCommand = new EraserCommand(app.GetCanvas(), new Point(0, 0), new Point(10, 10));
app.AddCommand(eraserCommand);

// Выполняем команды
app.ExecuteCommands();

// Перерисовываем холст
app.RedrawCanvas();

// Отменяем команды
app.UndoCommands();

// Перерисовываем холст
app.RedrawCanvas();