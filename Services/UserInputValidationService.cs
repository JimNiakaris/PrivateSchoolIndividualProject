using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB
{
    static class UserInputValidationService
    {


        public static string ValidateString(string input)
        {
            Regex reg = new Regex(@"^+[A-Z]|[a-z]{1,50}\z");
            while (!reg.IsMatch(input))
            {
                Console.WriteLine("Invalid input. Please try again");
                input = Console.ReadLine();
            }
            return input;

            }
            
            public static DateTime ValidateDate(string date)
            {
                CultureInfo grCult = new CultureInfo("el-EL");
                while (!DateTime.TryParse(date, out _))
                {
                    Console.WriteLine("The date you entered was incorect.\n Try again.");
                    date = Console.ReadLine();
                }
                DateTime typedDT = DateTime.Parse(date, grCult);
                if (DateTime.Now.Year - typedDT.Year < 18)
                {
                    Console.WriteLine("People under the age of 18 are not permited.\n Try again.");
                }

                return typedDT;
            }
        public static int ValidateInt(string input)
        {
            Regex reg = new Regex(@"^+[0-9]{1,4}\z");
            while (!reg.IsMatch(input))
            {
                Console.WriteLine("!The tuition fee cannot include letters and cannot be more than 4 digits!");
                input = Console.ReadLine();
            }

            return Convert.ToInt32(input);
        }

        public static int ValidateCourseID(string message)
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                List<int> validIDs = db.Courses.Select(c => c.courseID).ToList();
                bool isInteger = int.TryParse(Console.ReadLine(), out int userInput);

                while (!isInteger || !(validIDs.Contains(userInput)))
                {
                    Console.WriteLine($"Invalid input. {message}");
                    isInteger = int.TryParse(Console.ReadLine(), out userInput);
                }

                return userInput;
            }
        }

    }

}
