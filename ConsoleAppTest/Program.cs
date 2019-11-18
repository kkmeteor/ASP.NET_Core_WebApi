using System;
using System.Reflection;
using TaskModels;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var path = $"{AppDomain.CurrentDomain.BaseDirectory}Dll\\TaskModels.dll";
            var assembly = Assembly.LoadFrom(path);
            var dtoModel = new DtoModel();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (!Attribute.IsDefined(type, typeof(MetaDataWalker)))
                    continue;

                var attribute= type.GetCustomAttribute(typeof(MetaDataWalker));
                var name = attribute.GetType().GetProperty("DependencyAssemblyName")?.GetValue(attribute);
                Console.WriteLine(type.Name);

            }
        }
    }
}
