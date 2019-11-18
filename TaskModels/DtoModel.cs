using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DependencyDll;

namespace TaskModels
{
    [MetaDataWalker(DependencyAssemblyName = "DependencyDll")]
    public class DtoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Class1 Class1 { get; set; }
        public string GetName => $"Hello,{Name}!";
    }
}
