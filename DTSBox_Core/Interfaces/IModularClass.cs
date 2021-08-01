using System;
using System.Collections.Generic;

namespace DTSBox_Core.Interfaces
{
    public interface IModularClass
    {
        List<Action> Methods
        {
            get;
            set;
        }

        void ExecuteMethod(int index);
        void PrintMethods();
    }
}
