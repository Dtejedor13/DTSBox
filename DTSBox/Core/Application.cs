using DTSBox_Core.Interfaces;

namespace DTSBox.Core
{
    class Application : IApplication
    {
        IDTSModule module;

        public Application(IDTSModule module)
        {
            this.module = module;
        }

        public void Run()
        {
            bool result = module.ModuleMain();
            printResults(result);
        }

        private void printResults(bool result)
        {
            string message = result ? "Operation succesfully completed !" : "Operation failed !";
            System.Console.WriteLine(message);
        }
    }
}
