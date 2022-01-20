using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB.Services
{
    class CreateEntitiesService 
    {

        public static Student CreateNewStudent()
        {

            Console.WriteLine("Type the student's Info :");
            Console.WriteLine("Type student's first name");
            string fName = Console.ReadLine();
            UserInputValidationService.ValidateString(fName);
            Console.WriteLine("Type student's last name");
            string lName = Console.ReadLine();
            UserInputValidationService.ValidateString(lName);
            Console.WriteLine("Enter the student's birth date in the following" +
                    "format: dd/mm/YYYY");
            string inputBdate = Console.ReadLine();
            var bDate = UserInputValidationService.ValidateDate(inputBdate);
            Console.WriteLine("Type student's tuitions");
            string tuition = Console.ReadLine();
            var tuitions = UserInputValidationService.ValidateInt(tuition);

            Student student = new Student()
            {
                first_name = fName,
                last_name = lName,
                date_of_birth = bDate,
                tuitions = tuitions,

            };

            return student;

        }

        public static void AddStudentToCourse(Student newStudent)
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                Console.WriteLine("Would you like to add this student to a Course?\n" +
                                        "Type (Y) if Yes\n Press AnyKey if No");
                string userInput = Console.ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    var courseID = AddEntityToCourse("Student");
                    newStudent.Courses.Add(db.Courses.Single(c => c.courseID == courseID));
                    
                }
                db.SaveChanges();
            }
        }

        public static Trainer CreateNewTrainer()
        {

            Console.WriteLine("Type the trainer's Info :");
            Console.WriteLine("Type trainer's first name");
            string fName = Console.ReadLine();
            var fname = UserInputValidationService.ValidateString(fName);
            Console.WriteLine("Type trainer's last name");
            string lName = Console.ReadLine();
            var lname = UserInputValidationService.ValidateString(lName);
            Console.WriteLine("Type trainer's last name");
            string subject = Console.ReadLine();
            var subj = UserInputValidationService.ValidateString(subject);

            Trainer trainer = new Trainer()
            {
                first_name = fname,
                last_name = lname,
                subject = subj
            };
            return trainer;
        }

        public static void AddTrainerToCourse(Trainer newTrainer)
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                Console.WriteLine("Would you like to add this trainer to a Course?\n" +
                                        "Type (Y) if Yes\n Press AnyKey if No");
                string userInput = Console.ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    var courseID = AddEntityToCourse("Student");
                    newTrainer.Courses.Add(db.Courses.Single(c => c.courseID == courseID));

                }
                db.SaveChanges();
            }
        }

        public static Assignment CreateNewAssignment()
        {

            Console.WriteLine("Type the assignment's Info :");
            Console.WriteLine("Type assignment's Title");
            string title1 = Console.ReadLine();
            var title = UserInputValidationService.ValidateString(title1);
            Console.WriteLine("Type assignment's description");
            string description1 = Console.ReadLine();
            var description = UserInputValidationService.ValidateString(description1);
            Console.WriteLine("Type assignment's submision date");
            string subDate1 = Console.ReadLine();
            DateTime subDate;
            subDate = UserInputValidationService.ValidateDate(subDate1);
            Console.WriteLine("Type assignment's oral mark");
            string oralMark1 = Console.ReadLine();
            var oralMark = UserInputValidationService.ValidateInt(oralMark1);
            Console.WriteLine("Type assignment's oral mark");
            string totalMark1 = Console.ReadLine();
            var totalMark = UserInputValidationService.ValidateInt(totalMark1);

            Assignment assignment = new Assignment()
            {
                title = title,
                description = description,
                sub_date = subDate,
                oral_mark = oralMark,
                total_mark = totalMark

            };
            return assignment;
        }

        public static void AddAssignmentToCourse(Assignment newAssignment)
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                Console.WriteLine("Would you like to add this assignment to a Course?\n" +
                                        "Type (Y) if Yes\n Press AnyKey if No");
                string userInput = Console.ReadLine();
                if (userInput == "Y" || userInput == "y")
                {
                    var courseID = AddEntityToCourse("Student");
                    newAssignment.Courses.Add(db.Courses.Single(c => c.courseID == courseID));

                }
                db.SaveChanges();
            }
        }

        public static Course CreateNewCourse()
        {
            Console.WriteLine("Type the course's Info :");
            Console.WriteLine("Type course's Title");
            string title1 = Console.ReadLine();
            var title = UserInputValidationService.ValidateString(title1);
            Console.WriteLine("Type course's stream");
            string stream1 = Console.ReadLine();
            var stream = UserInputValidationService.ValidateString(stream1);
            Console.WriteLine("Type course's type");
            string type1 = Console.ReadLine();
            var type = UserInputValidationService.ValidateString(type1);
            Console.WriteLine("Type course's start date");
            string startDate1 = Console.ReadLine();
            DateTime startDate;
            startDate = UserInputValidationService.ValidateDate(startDate1);
            if (EndDateMethod() < startDate)
            {
                EndDateMethod();
            }
            Course course = new Course()
            {
                title = title,
                stream = stream,
                type = type,
                start_date = startDate,
                end_date = EndDateMethod()

            };
            return course;

            DateTime EndDateMethod()
            {
                Console.WriteLine("Type course's end date");
                string endDate1 = Console.ReadLine();
                DateTime endDate;
                endDate = UserInputValidationService.ValidateDate(endDate1);
                return endDate;
            }
        }


        public static int AddEntityToCourse(string entityType)
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                string message = $"Select to which course the {entityType} should be added." +
                    $" Enter the course id of your choice"
                  + string.Join("\n\t", db.Courses.Select(c => "\n\t" + 
                  c.courseID +
                  "\t" + c.title +
                  "\t" + c.stream +
                  "\t" + c.type));
                Console.WriteLine(message);
                var userInput = UserInputValidationService.ValidateCourseID(message);
                return userInput;
            }
        }
    }
}
