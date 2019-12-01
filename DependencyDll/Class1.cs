using System;

namespace DependencyDll
{
    [MetaDataAttribute]
    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    [AttributeUsage(AttributeTargets.Class)]
    public class MetaDataAttribute : Attribute
    {
        public string DependencyName { get; set; }
    }
}
