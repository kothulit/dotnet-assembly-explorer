using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AECore.Model;
using Autodesk.Revit.UI;

namespace AssemblyTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Testing test = new Testing(@"C:\Program Files\Autodesk\Revit 2021\RevitAPI.dll");
            test.Run();
        }
    }
}
