using ClassLibrary;

var receiver = new Receiver();
var command = new ConcreteCommand(receiver, "Command");
var invoker = new Invoker(command);

invoker.ExecuteCommand();
