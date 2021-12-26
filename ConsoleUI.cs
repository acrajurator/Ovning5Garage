using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageSpace
{
    public class ConsoleUI : IUI
    {
        public string GetStringInput()
        {
            return Console.ReadLine();
        }

        public void PrintString(string message)
        {
            Console.WriteLine(message);
        }


    }

}
