using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyTest
{
    internal class Document
    {
        string assemblyPath = "";
        public List<string> Namespaces { get; }
        public List<Element> Elements { get; }

        public Document(string path)
        {
            assemblyPath = path;
            if (CheckFile(path))
            {
                Assembly researchedAssembly = Assembly.LoadFile(assemblyPath);
                Namespaces = GetNamespaces(researchedAssembly);
                Elements = CreateElements(researchedAssembly);
            }
        }

        //Check the file exists and it is a dll or exe
        bool CheckFile(string path)
        {
            if (File.Exists(path))
                if (Path.GetExtension(assemblyPath) == ".dll" || Path.GetExtension(assemblyPath) == ".exe")
                    return true;
                else
                    return false;
            else
                return false;
        }

        //Get list of all namespaces in types
        List<string> GetNamespaces(Assembly assembly)
        {
            List<string> namespaces = new List<string>();
            foreach (var t in assembly.ExportedTypes)
            {
                if (!namespaces.Contains(t.Namespace))
                    namespaces.Add(t.Namespace);
            }
            return namespaces;
        }

        //Create Elements
        List<Element> CreateElements(Assembly assembly)
        {
            List<Element> elements = new List<Element>();
            foreach (var t in assembly.ExportedTypes)
            {
                string fullName = t.FullName;
                string name = t.Name;
                string nspace = t.Namespace;
                List<string> methods = new List<string>();
                foreach (var m in t.GetMethods())
                {
                    methods.Add(m.Name);
                }
                elements.Add(new Element(fullName, name, nspace, methods));
            }
            return elements;
        }

        //Get all methods in type
        public List<MethodInfo> GetMethodsOfType(Type type)
        {
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (var m in type.GetMethods())
            {
                methods.Add(m);
            }
            return methods;
        }
    }
}
