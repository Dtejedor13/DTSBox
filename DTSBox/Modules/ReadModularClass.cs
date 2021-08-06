using DTSBox_Core.Classes;
using DTSBox_Core.Interfaces;
using System;

namespace DTSBox.Modules
{
    class ReadModularClass : IDTSModule
    {
        #pragma warning disable CS0162 // we will break the While (true) loop when the condition are met
        public bool ModuleMain()
        {
            ModularClass dummy = new ModularClass();

            while (true)
            {
                Console.Clear();
                dummy.PrintMethods();
                Console.WriteLine("Enter Method...");
                string select = Console.ReadLine();

                int index = dummy.GetIndexOfMethod(select);

                if (index != -1)
                    dummy.MethodMain(index);
            }
            return true;
        }
    }
}
