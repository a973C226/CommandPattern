using LightSwitch;

Light l = new Light();
// создаем объекты для всех умений объекта Light:
ICommand switchUp = new TurnOnLightCommand(l);
ICommand switchDown = new TurnOffLightCommand(l);

// Создается invoker, с которым мы будем непосредственно контактировать:
Switch s = new Switch(switchUp, switchDown);

// вот проверка этого, используем методы:
s.FlipUp();
s.FlipDown();
