# Реализация паттерна "Команда"в библиотеке классов

В данном примере мы создаем интерфейс __ICommand__, который определяет метод __Execute()__.

```C#
// Интерфейс команды
public interface ICommand
{
    void Execute();
}
```

Затем мы создаем конкретную команду __ConcreteCommand__, которая реализует интерфейс __ICommand__ и содержит ссылку на получателя команды __Receiver__. Конкретная команда также может содержать параметры, которые будут переданы получателю при выполнении команды.

```C#
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
```

Получатель команды __Receiver__ содержит метод __Action__, который будет выполнен при вызове команды.

```C#
// Получатель команды
public class Receiver
{
    public void Action(string parameter)
    {
        Console.WriteLine($"Выполнение команды с параметром {parameter}");
    }
}
```

Наконец, мы создаем инициатор команды __Invoker__, который содержит ссылку на объект команды и метод __ExecuteCommand()__, который вызывает метод __Execute()__ объекта команды.

```C#
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
```

Теперь мы можем создать объекты команды и передать их в инициатор команды для выполнения:

```C#
var receiver = new Receiver();
var command = new ConcreteCommand(receiver, "Command");
var invoker = new Invoker(command);

invoker.ExecuteCommand();
```

>При выполнении этого кода будет вызван метод __Action__ объекта __Receiver__ с переданным параметром __"Command"__.