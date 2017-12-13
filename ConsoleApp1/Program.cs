using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           Controller c = new Controller(); //Why not start directly in the menu?
           c.OpenMenu();
        }
    }
}
