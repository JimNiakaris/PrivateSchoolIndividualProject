using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB.Services
{
    class UserInputMenuService
    {
        public void UserInputMenu()
        {
            CreateDataService createData = new CreateDataService();
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("//////////////////////////////////");
                Console.WriteLine("DATA INSERT MENU");
                Console.WriteLine("//////////////////////////////////");
                Console.WriteLine(
                    "Type :     (1)       to add a new Student\n" +
                    "Type :     (2)       to add a new Trainer\n" +
                    "Type :     (3)       to add a new Assignment\n" +
                    "Type :     (4)       to add a new Course\n" +
                    "Type :     (5)       to print a list of all the Students in each Course\n" +
                    "Type :     (6)       to print a list of all the Trainers in each Course\n" +
                    "Type :     (7)       to print a list of all the Assignments in each course\n");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        var newStudent = CreateEntitiesService.CreateNewStudent();
                        CreateEntitiesService.AddStudentToCourse(newStudent);
                        createData.InsertData<Student>(newStudent);

                        break;
                    case "2":
                        var newTrainer = CreateEntitiesService.CreateNewTrainer();
                        CreateEntitiesService.AddTrainerToCourse(newTrainer);
                        createData.InsertData<Trainer>(newTrainer);
                        break;
                    case "3":
                        var newAssignment = CreateEntitiesService.CreateNewAssignment();
                        CreateEntitiesService.AddAssignmentToCourse(newAssignment);
                        createData.InsertData<Assignment>(newAssignment);
                        break;
                    case "4":
                        createData.InsertData<Course>(CreateEntitiesService.CreateNewCourse());
                        break;
                }

            } while (input != "E" && input != "e");
        }


    }
}
