using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.UserInterfaces;
using Core.UserInterfaces.ConsoleInterface;

namespace pgConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IGamePlugin plugin = new ConsolePlugin();
            plugin.Run();
            Console.WriteLine("Plugin ended. Exiting.");
        }
    }
}
