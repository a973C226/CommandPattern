using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSwitch
{
    public class TurnOnLightCommand : ICommand
    {
        private Light theLight;

        public TurnOnLightCommand(Light light)
        {
            this.theLight = light;
        }

        public void Execute()
        {
            theLight.TurnOn();
        }
    }
}
