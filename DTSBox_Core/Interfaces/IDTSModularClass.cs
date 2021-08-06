using System;
using System.Collections.Generic;

namespace DTSBox_Core.Interfaces
{
    public interface IDTSModularClass
    {
        List<Action> Methods
        {
            get;
            set;
        }

        void MethodMain(int index);
        void PrintMethods();
    }
}
