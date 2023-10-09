namespace ClassLibrary
{
    // Получатель команды
    public class Receiver
    {
        public void Action(string parameter)
        {
            Console.WriteLine($"Выполнение команды с параметром {parameter}");
        }
    }
}
