using IndividualProject.Models.Menu;
using System;
using System.Text;

namespace IndividualProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Menu.MainMenu();
        }
    }
}
