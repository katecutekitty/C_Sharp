using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{

    internal class TestClass
    {
        [Unreadable] public string Name { get; set; }
        public TestClass(string name)
        {
            Name = name;
        }
    }
}
