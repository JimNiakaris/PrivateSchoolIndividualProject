using IndividualProjectB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenuService();
            mainMenu.MainMenuMethod();

        }

    }
}


