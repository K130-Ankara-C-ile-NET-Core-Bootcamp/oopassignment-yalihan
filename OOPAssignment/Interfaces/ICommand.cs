using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Interfaces
{
    public interface ICommand<T>
    {
        public void ExecuteCommand(T commandObject);
    }
}
