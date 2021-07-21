using DTSBox_Core.Interfaces;

namespace DTSBox.Core
{
    class Application : IApplication
    {
        IModule module;

        public Application(IModule module)
        {
            this.module = module;
        }

        public void Run()
        {
            module.StartModule();
            module.EndOfModule();
        }
    }
}
