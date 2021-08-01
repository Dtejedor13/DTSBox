using DTSBox_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DTSBox_Core.Classes
{
    public class ModularClass : IModularClass
    {
        public List<Action> Methods { get; set; }

        public List<Action<string>> MethodsParam_string { get; set; }

        private bool askedForParamMethod = false;
        private string[] askedParamValues = null;

        public ModularClass()
        {
            Methods = new List<Action>()
            { 
                new Action(hello),
                new Action(wuff),
                new Action(miau)
            };
            MethodsParam_string = new List<Action<string>>()
            {
                new Action<string>(funcParam)
            };
        }

        public void ExecuteMethod(int index)
        {
            if (askedForParamMethod)
                MethodsParam_string[index].Invoke(askedParamValues[0]);
            else
                Methods[index].Invoke();
        }

        public void PrintMethods()
        {
            foreach (Action action in Methods)
                Console.WriteLine(">> " + action.Method.ToString());
            Console.WriteLine("<<< Methods with parameters >>>");
            foreach (Action<string> action in MethodsParam_string)
                Console.WriteLine(">> " + action.Method.ToString());
        }

        public int GetIndexOfMethod(string methodName)
        {
            string[] parts = methodName.Split(' ');
            if(parts.Length == 1)
            {
                methodName = $"Void {methodName}()";
                Action selection = Methods.Where(x => x.Method.ToString() == methodName).FirstOrDefault();
                askedForParamMethod = false;
                if (selection != null)
                    return Methods.IndexOf(selection);
                else
                    return -1;
            }
            else
            {
                string[] values = parts[1].Split(' ');
                methodName = $"Void {parts[0]}(System.String)";
                Action<string> selection = MethodsParam_string.Where(x => x.Method.ToString() == methodName).FirstOrDefault();
                askedForParamMethod = true;
                askedParamValues = values;
                if (selection != null)
                    return MethodsParam_string.IndexOf(selection);
                else
                    return -1;
            }
        }

        #region Actions
        private void hello()
        {
            Console.WriteLine("Hello!");
            Console.Read();
        }

        private void wuff()
        {
            Console.WriteLine("Wuff Wuff");
            Console.Read();
        }

        private void miau()
        {
            Console.WriteLine("Miau Miau");
            Console.Read();
        }

        private void funcParam(string value)
        {
            Console.WriteLine($"{value} was passed as parameter");
            Console.Read();
        }
        #endregion
    }
}
