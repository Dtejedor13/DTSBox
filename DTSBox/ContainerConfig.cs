using Autofac;
using DTSBox_Core.Interfaces;
using System.Linq;
using System.Reflection;

namespace DTSBox
{
    static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DTSBox.Core.Application>().As<DTSBox.Core.IApplication>();

            // Switch here executing Programm
            builder.RegisterType<DTSBox.Modules.AbfragePin>().As<IDTSModule>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DTSBox_Core)))
                .Where(t => t.Namespace.Contains("Interfaces"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
