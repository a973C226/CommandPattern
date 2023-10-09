using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSwitch
{
    public class Switch
    {
        private ICommand flipUpCommand;
        private ICommand flipDownCommand;

        public Switch(ICommand flipUpCommand, ICommand flipDownCommand)
        {
            this.flipUpCommand = flipUpCommand;
            this.flipDownCommand = flipDownCommand;
        }

        public void FlipUp()
        {
            flipUpCommand.Execute();
        }

        public void FlipDown()
        {
            flipDownCommand.Execute();
        }
    }
}
