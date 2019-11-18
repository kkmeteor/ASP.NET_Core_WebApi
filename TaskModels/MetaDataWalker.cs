using System;
using System.Collections.Generic;
using System.Text;

namespace TaskModels
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MetaDataWalker:Attribute
    {
        public string DependencyAssemblyName { get; set; }
    }
}
