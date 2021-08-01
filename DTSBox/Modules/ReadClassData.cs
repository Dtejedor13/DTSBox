using DTSBox_Core.Classes;
using DTSBox_Core.Interfaces;
using DTSBox_Core.Models;
using System;
using System.Linq;
using System.Reflection;

namespace DTSBox.Modules
{
    class ReadClassData : IModule
    {
        public bool StartModule()
        {
            return readModularClass();
        }

        public bool EndOfModule()
        {
            return true;
        }

        private bool readModularClass()
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
                    dummy.ExecuteMethod(index);
            }

            return true;
        }

        private bool readClassData()
        {
            try
            {
                Konto konto = new Konto();
                MethodInfo[] methodInfos =
                 konto.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance);

                Console.WriteLine("<<< Methods of TargetClass... >>>");
                foreach (MemberInfo item in methodInfos)
                    Console.WriteLine(item.ToString());

                Console.WriteLine("<<< Properties of TargetClass... >>>");
                foreach (var item in konto.GetType().GetProperties())
                    Console.WriteLine($"{item.Name} = {item.GetValue(konto, null)}");

                FieldInfo[] fields = konto.GetType().GetFields();

                Console.WriteLine("<<< Fields of TargetClass... >>>");
                foreach (FieldInfo item in fields)
                    Console.WriteLine(item.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }


            return true;
        }
    }
}
