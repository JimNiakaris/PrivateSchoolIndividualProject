using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB.Services
{
    class MainMenuService : IMainMenuService
    {


        public void MainMenuMethod()
        {

            var userInputMenuService = new Services.UserInputMenuService();
            var readMenuService = new Services.ReadMenuService();
            //// MAIN MENU ////
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("//////////////////////////////////");
                Console.WriteLine("Welcome to the main menu");
                Console.WriteLine("//////////////////////////////////");
                Console.WriteLine("What would you like to do? \n" +
                    "Type :     I       to insert data into the Database \n" +
                    "Type :     P       to print the available data\n" +
                    "Type :     E       to exit");
                input = Console.ReadLine();
                if (input=="I" || input == "i")
                {
                    
                    userInputMenuService.UserInputMenu();
                }
                else if (input=="P" || input == "p")
                {

                    readMenuService.ReadMenu();
                }
                
            } while (input != "E" && input != "e");

        }
    }
}
