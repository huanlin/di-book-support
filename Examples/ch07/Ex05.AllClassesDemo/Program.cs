using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity.RegistrationByConvention;

namespace Ex05.AllClassesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AllClassesDemo();
        }

        static void AllClassesDemo()
        {
            Console.WriteLine("\n<<< AllClassesDemo >>>");
            Console.WriteLine("=============FromLoadedAssemblies");
            ShowClassesInfo(AllClasses.FromLoadedAssemblies().ToList());

            Console.WriteLine("=============FromAssembliesInBasePath");
            ShowClassesInfo(AllClasses.FromAssembliesInBasePath().ToList());

            Console.WriteLine("=============FromAssemblies");
            ShowClassesInfo(AllClasses.FromAssemblies().ToList());
        }

        static void ShowClassesInfo(List<Type> classes)
        {
            Console.WriteLine("Count: " + classes.Count);
            foreach (var aType in classes)
            {
                Console.WriteLine(aType.FullName);
            }
        }

    }
}
