using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB.Services
{
    class ReadMenuService
    {
        public void ReadMenu()
        {
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("//////////////////////////////////");
                Console.WriteLine("DATA PRINT MENU");
                Console.WriteLine("//////////////////////////////////");
                Console.WriteLine(
                    "Type :     (1)       to print all the enrolled Students \n" +
                    "Type :     (2)       to print all the available Trainers\n" +
                    "Type :     (3)       to print all the Assignments\n" +
                    "Type :     (4)       to print all the available Courses\n" +
                    "Type :     (5)       to print a list of all the Students in each Course\n" +
                    "Type :     (6)       to print a list of all the Trainers in each Course\n" +
                    "Type :     (7)       to print a list of all the Assignments in each course\n" +
                    "Type :     (8)       to print a list of all the Assignments per Student per Course\n" +
                    "Type :     (9)       to print a list of all the Students enrolled in more than one Course\n" +
                    "Type :     (E)       to Exit the Print Menu\n");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var student = new ReadDataService();
                        student.ReadData<Student>();
                        Console.ReadKey();
                        break;
                    case "2":
                        var trainer = new ReadDataService();
                        trainer.ReadData<Trainer>();
                        Console.ReadKey();
                        break;
                    case "3":
                        var assignment = new ReadDataService();
                        assignment.ReadData<Assignment>();
                        Console.ReadKey();
                        break;
                    case "4":
                        var course = new ReadDataService();
                        course.ReadData<Course>();
                        Console.ReadKey();
                        break;
                    case "5":
                        var sPc = new ReadDataService();
                        sPc.ReadStudentPerCourse();
                        Console.ReadKey();
                        break;
                    case "6":
                        var tPc = new ReadDataService();
                        tPc.ReadTrainersPerCourse();
                        Console.ReadKey();
                        break;
                    case "7":
                        var aPc = new ReadDataService();
                        aPc.ReadAssignmentsPerCourse();
                        Console.ReadKey();
                        break;
                    case "8":
                        var aPsPC = new ReadDataService();
                        aPsPC.ReadAssignmentPerStudentPerCourse();
                        Console.ReadKey();
                        break;
                    case "9":
                        var sImC = new ReadDataService();
                        sImC.ReadStudentsInMultipleCourses();
                        Console.ReadKey();
                        break;
                }
                

            } while (input != "E" && input != "e");
        }

    }
}
