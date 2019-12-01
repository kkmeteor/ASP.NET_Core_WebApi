using System;
using System.Collections.Generic;
using System.Text;
using DependencyDll;

namespace ConsoleAppTest
{
    [MetaData]
    public class TestModel
    {
        public Class1 class1 { get; set; }

        public MetaDataAttribute MetaData { get; set; }
    }
}
