using OOPAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class CarStringCommandExecutor : CarCommandExecutorBase, IStringCommand
    {
        public CarStringCommandExecutor(ICarCommand carCommand) : base(carCommand)
        {

        }

        public void ExecuteCommand(string commandObject)
        {
            if (commandObject == "" || commandObject == null)
                throw new Exception();
            else
                foreach(char letter in commandObject)
                {
                    if (letter == 'L')
                        CarCommand.TurnLeft();
                    else if (letter == 'R')
                        CarCommand.TurnRight();
                    else if (letter == 'M')
                        CarCommand.Move();
                    else
                        throw new Exception();
                }
        }
    }
}
