using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AECore.Model
{
    internal class Element
    {
        string FullName { get; }
        public string Name { get; }
        string Namespace { get; }
        List<string> Methods { get; }

        public Element(string fullName, string name, string nspace, List<string> methods)
        {
            FullName = fullName;
            Name = name;
            Namespace = nspace;
            Methods = methods;
        }

        public override string ToString()
        {
            string str = "-----------------------------\n";
            str += $"FullName: {FullName}\n";
            str += $"Name: {Name}\n";
            str += $"Namespace: {Namespace}\n";
            str += $"Methods:\n";
            foreach (var m in Methods)
            {
                str += $"\t{m}\n";
            }
            str += "-----------------------------\n";
            return str;
        }

        public static Element GetExample()
        {
            return new Element("System.Example",
                "Example", "System",
                new List<string>() { "Compare", "Concat", "Copy", "ToUpper", "Trim",
                    "Equals", "Format", "GetType", "IndexOf",
                    "Insert", "Join", "LastIndexOf", "Remove",
                    "Replace", "Split", "Substring", "ToLower"});
        }
    }
}
