using AssemblyTest;
using System;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AECore.Model
{
    internal class Testing
    {
        string assemblyPath = "";
        public Testing(string path)
        {
            assemblyPath = path;
        }

        public void Run()
        {
            //Document document = new Document(assemblyPath);
            //foreach (Element e in document.Elements)
            //{
            //    Console.WriteLine(e);
            //}
            //Console.ReadKey();
        }
    }
}
