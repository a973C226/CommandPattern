using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSwitch
{
    public class TurnOffLightCommand : ICommand
    {
        private Light theLight;

        public TurnOffLightCommand(Light light)
        {
            this.theLight = light;
        }

        public void Execute()
        {
            theLight.TurnOff();
        }
    }
}
