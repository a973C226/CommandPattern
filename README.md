# Паттерн проектирования "Команда"
__Паттерн проектирования "Команда" (Command)__ является поведенческим паттерном, который позволяет инкапсулировать запросы в объекты, позволяя тем самым параметризовать клиентов с различными запросами, очередями или журналами запросов, а также поддерживать отмену операций.

>Термин «design patterns» можно перевести с английского как паттерны/шаблоны/образцы проектирования. Они применяются в процессе создания информационных систем и являются формализованными описаниями регулярно возникающих задач проектирования, эффективными решениями таких задач и рекомендациями по использованию полученных решений в тех или иных ситуациях.

Ключевые участники паттерна:
- __Команда (Command)__ - определяет интерфейс для выполнения операций.
- __Конкретная команда (ConcreteCommand)__ - реализует интерфейс команды и содержит ссылку на получателя.
- __Получатель (Receiver)__ - знает, как выполнять операции, связанные с запросом.
- __Инициатор (Invoker)__ - запрашивает выполнение команды.
- __Отмена (Undo)__ - позволяет отменить выполненную команду.

Применение паттерна "Команда":

__1. Необходимо параметризовать объекты выполняемым действием__
> Команда превращает операции в объекты. А объекты можно передавать, хранить и взаимозаменять внутри других объектов. Скажем, вы разрабатываете библиотеку графического меню и хотите, чтобы пользователи могли использовать меню в разных приложениях, не меняя каждый раз код ваших классов. Применив паттерн, разработчикам не придётся изменять классы меню, вместо этого они будут конфигурировать объекты меню различными командами.

__2. Необходимо ставить операции в очередь, выполнять их по расписанию или передавать по сети__
>Как и любые другие объекты, команды можно сериализовать, то есть превратить в строку, чтобы потом сохранить в файл или базу данных. Затем в любой удобный момент её можно достать обратно, снова превратить в объект команды и выполнить. Таким же образом команды можно передавать по сети, логгировать или выполнять на удалённом сервере.

__3. Когда вам нужна операция отмены__
>Для возможности отмены операций, необходимо хранить историю команд. История команд выглядит как стек, в который попадают все выполненные объекты команд. Каждая команда перед выполнением операции сохраняет текущее состояние объекта, с которым она будет работать. После выполнения операции копия команды попадает в стек истории, все ещё неся в себе сохранённое состояние объекта. Если потребуется отмена, программа возьмёт последнюю команду из истории и возобновит сохранённое в ней состояние

:white_check_mark: __Преимущества использования паттерна "Команда":__
1. Инкапсуляция запросов в объекты позволяет легко добавлять новые операции без изменения клиентского кода.
2. Поддержка отмены операций.
3. Возможность реализации очередей и журналов запросов.

:x: __Недостатки использования паттерна "Команда":__
1. Увеличение количества классов в системе.
2. Усложнение кода из-за необходимости создания множества классов для каждой операции.

Рассмотрим пример применения паттерна:

__Задача__ 
: Предположим, у нас есть приложение для рисования, которое позволяет пользователю выбирать инструменты и рисовать на холсте. Мы можем использовать паттерн "Команда" для реализации функционала отмены и повтора действий пользователя.

Для начала создадим интерфейс ICommand, который будет определять методы Execute() и Undo() для выполнения и отмены команд:

```C#
public interface ICommand
{
    void Execute();
    void Undo();
}
```

Затем создадим классы-команды для каждого инструмента, например, для кисти и ластика:

```C#
public class BrushCommand : ICommand
{
    private Canvas canvas;
    private Point startPoint;
    private Point endPoint;

    public BrushCommand(Canvas canvas, Point startPoint, Point endPoint)
    {
        this.canvas = canvas;
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }

    public void Execute()
    {
        canvas.DrawLine(startPoint, endPoint);
    }

    public void Undo()
    {
        canvas.RemoveLine(startPoint, endPoint);
    }
}

public class EraserCommand : ICommand
{
    private Canvas canvas;
    private Point startPoint;
    private Point endPoint;

    public EraserCommand(Canvas canvas, Point startPoint, Point endPoint)
    {
        this.canvas = canvas;
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }

    public void Execute()
    {
        canvas.RemoveLine(startPoint, endPoint);
    }

    public void Undo()
    {
        canvas.DrawLine(startPoint, endPoint);
    }
}
```
>Здесь мы определяем методы Execute() и Undo() для каждой команды. Метод Execute() выполняет действие, а метод Undo() отменяет его.

Далее создадим класс-получатель Canvas, который будет выполнять действия, связанные с рисованием:

```C#
public class Canvas
{
    private List<Point> points = new List<Point>();

    public void DrawLine(Point startPoint, Point endPoint)
    {
        points.Add(startPoint);
        points.Add(endPoint);
        Console.WriteLine($"Draw line from {startPoint} to {endPoint}");
    }

    public void RemoveLine(Point startPoint, Point endPoint)
    {
        points.Remove(startPoint);
        points.Remove(endPoint);
        Console.WriteLine($"Remove line from {startPoint} to {endPoint}");
    }

    public void Redraw()
    {
        Console.WriteLine("Redraw canvas:");
        if(points.Count != 0)
            foreach (var point in points)
                Console.WriteLine($"Point: {point}");
        else
            Console.WriteLine($"The canvas is clean");
    }
}
```
>Здесь мы определяем методы DrawLine() и RemoveLine() для рисования и стирания линий, а также метод Redraw() для перерисовки холста.

Наконец, создадим класс-инициатор App, который будет создавать команды и выполнять их:

```C#
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
```
>Здесь мы определяем методы AddCommand() для добавления команды в список, ExecuteCommands() для выполнения всех команд, UndoCommands() для отмены всех команд и RedrawCanvas() для перерисовки холста.

Теперь мы можем использовать паттерн "Команда" следующим образом:
```C#
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
```
>Здесь мы создаем объекты BrushCommand и EraserCommand, добавляем их в список команд, выполняем их, отменяем их и перерисовываем холст. При этом каждая команда инкапсулирует запрос на выполнение определенного действия, что позволяет отделить инициатора запроса от получателя и обеспечить более гибкую конфигурацию системы.

Результат вполнения программы:

    Draw line from {X=0,Y=0} to {X=10,Y=10}
    Draw line from {X=0,Y=0} to {X=10,Y=10}
    Redraw canvas:
    Point: {X=0,Y=0}
    Point: {X=10,Y=10}
    Point: {X=0,Y=0}
    Point: {X=10,Y=10}
    Remove line from {X=0,Y=0} to {X=10,Y=10}
    Remove line from {X=0,Y=0} to {X=10,Y=10}
    Redraw canvas:
    The canvas is clean
