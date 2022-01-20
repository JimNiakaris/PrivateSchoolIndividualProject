using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProjectB.Services
{
    class ReadDataService
    {
 
        public void ReadData<T>()
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                Type tType = typeof(T);
                var types = db.Set(tType);

                foreach (var data in types)
                {
                    Console.WriteLine(data);
                }
            }
        }

        public void ReadStudentPerCourse()
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                var sPc = db.Courses;
                foreach (var data in sPc)
                {
                    Console.WriteLine(data);
                    var students = string.Join("\t\n", data.Students);
                    Console.WriteLine(students);
                }
            }
        }

        public void ReadTrainersPerCourse()
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                var tPc = db.Courses.Select(t => t);
                foreach (var data in tPc)
                {
                    Console.WriteLine(data);
                    var trainers = string.Join("\t\n", data.Trainers);
                    Console.WriteLine(trainers);
                }
            }
        }

        public void ReadAssignmentsPerCourse()
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                var aPc = db.Courses.Select(t => t);
                foreach (var data in aPc)
                {
                    Console.WriteLine(data);
                    var assignments = string.Join("\t\n", data.Assignments);
                    Console.WriteLine(assignments);

                }
            }
        }

        public void ReadAssignmentPerStudentPerCourse()
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                var aPsPc = db.Students;
                foreach (var student in aPsPc)
                {
                    Console.WriteLine(student);
                    var courses = string.Join("\t\n", student.Courses);
                    foreach (var course in student.Courses)
                    {

                        Console.WriteLine(course + string.Join("\n\t", course.Assignments));
                    }
                }
            }
        }

        public void ReadStudentsInMultipleCourses()
        {
            using (PrivateSchool db = new PrivateSchool())
            {
                var students = db.Students;
                foreach (var student in students)
                {
                    if (student.Courses.Count() > 1)
                    {
                        Console.WriteLine(student);
                    }
                    
                }
            }
        }


    }
}
