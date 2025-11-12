using CoursePresentation.Helpers;
using Domain.Entities;
using Repository.Exceptions;
using Service.Services.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePresentation.Controllers
{
    public class StudentController
    {
        StudentService _studentService = new();
        UserGroupService _usergroupService = new();

        public void CreateStudent()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Add Student Name:");

            string studentname = Console.ReadLine();

            Helper.PrintConsole(ConsoleColor.Blue, "Add Student Surname:");

            string studentsurname = Console.ReadLine();

            Helper.PrintConsole(ConsoleColor.Blue, "Add Student Age:");

selectAge: string Age = Console.ReadLine();

            int age;

            bool isValidAge = int.TryParse(Age, out age);
            if (!isValidAge)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add Correct Age Type");
                goto selectAge;
            }

selectGroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id:");

            string groupId = Console.ReadLine();

            int groupid;

            bool isValidGroupId = int.TryParse(groupId, out groupid);

            if (isValidGroupId)
            {
                try
                {
                    UserGroup userGroup = _usergroupService.GetById(groupid);
                    Student student = new Student { Name= studentname, Surname=studentsurname, Age=age, userGroup=userGroup };
                    _studentService.Create(student);
                    Helper.PrintConsole(ConsoleColor.Green, $"Student Id: {student.Id} ,Student Name: {student.Name} ,Student Surname: {student.Surname} ,Student Age: {student.Age},group id: {userGroup.Id}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("please create group");
                }


            }

            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add Correct GroupId type");
                goto selectGroupId;
            }
        }
        public void DeleteStudent()
        {
StudentId: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Id:");
            string studentId = Console.ReadLine();
            int id;

            bool isStudentId = int.TryParse(studentId, out id);
            if (isStudentId)
            {
                try
                {
                    _studentService.Delete(id);
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct id type");
              
            }  
            goto StudentId;
        }
        public void UpdateStudent()
        {
GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Id (or press Enter to cancel)");

            string studentId = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentId)||studentId=="exit")
            {
                Helper.PrintConsole(ConsoleColor.Red, "Update operation cancelled.");
                return;
            }

            int id;

            bool isStudentId = int.TryParse(studentId, out id);

            if (isStudentId)
            {
                Student findGroup = _studentService.GetById(id);

                if (findGroup != null)
                {
                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Name: {findGroup.Name}. Add Student new name (or press Enter to keep current)");

                    string StudentNewName = Console.ReadLine();

AgeCount: Helper.PrintConsole(ConsoleColor.Blue, $"Current Surname: {findGroup.Surname}. Add Group new Surname (or press Enter to keep current)");

                    string StudentNewSurname = Console.ReadLine();
                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Room Count: {findGroup.Age}. Add Group new Age (or press Enter to keep current)");
                   
                    string StudentNewAge = Console.ReadLine();

                    int studentage = findGroup.Age;

                    if (!string.IsNullOrWhiteSpace(StudentNewAge))
                    {
                        bool isAgeCount = int.TryParse(StudentNewAge, out studentage);

                        if (!isAgeCount)
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Add correct room count type");
                            goto AgeCount;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(StudentNewName))
                    {
                        StudentNewName = findGroup.Name;
                    }

                    Student student = new Student { Name = StudentNewName, Surname = StudentNewSurname, Age = studentage };

                    var updatedStudent = _studentService.Update(id, student);

                    if (updatedStudent == null)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Student not Updated, please try again");
                        goto GroupId;
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Student Id: {updatedStudent.Id}, Name: {updatedStudent.Name}, Surname: {updatedStudent.Surname}, Age: {updatedStudent.Age} ");
                    }
                }
                else
                {
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct StudentId type");
                goto GroupId;
            }
        }
        public void GetById()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Add Student Id:");
GroupId: string studentId = Console.ReadLine();
            int id;

            bool isStudentId = int.TryParse(studentId, out id);
            if (isStudentId)
            {
                try
                {
                    Student student = _studentService.GetById(id);

                    if (student != null)
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Student Id: {student.Id}, Student Name: {student.Name}, Student Surname: {student.Surname}, Student Age: {student.Age} Student Group:{student.userGroup}");
                    }
                }
                catch (Exception ex)
                {
                    Helper.PrintConsole(ConsoleColor.Red, ex.Message);
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct student id type");
                goto GroupId;
            }
        }
        public void GetStudentByAge()
        {
Studentage: Helper.PrintConsole(ConsoleColor.Blue, "Add Student Age:");
            string Age = Console.ReadLine().ToLower().Trim();
            int age;
            bool isTrueAge=int.TryParse(Age, out age);
            if (isTrueAge)
            {
                try
                {
                    List<Student> students = _studentService.GetStudentByAge(age);

                    if (students != null)
                    {
                        foreach (Student student in students)
                        {
                            Helper.PrintConsole(ConsoleColor.Green, $"Student Id: {student.Id}, Student Name: {student.Name}, Student Surname: {student.Surname}, Student Age: {student.Age}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helper.PrintConsole(ConsoleColor.Red, ex.Message);
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add valid Student age");
                goto Studentage;
            }
        }
        public void GetStudentsByGroupId()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id:");

selectGroupId:
            string groupIdInput = Console.ReadLine();
            int groupId;
            bool isValidGroupId = int.TryParse(groupIdInput, out groupId);

            if (!isValidGroupId)
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct group id type");
                goto selectGroupId;
            }

            try
            {
                UserGroup userGroup = _usergroupService.GetById(groupId);

                List<Student> students = _studentService.GetAll(s => s.userGroup != null && s.userGroup.Id == userGroup.Id);

                if (students.Count == 0)
                {
                    Helper.PrintConsole(ConsoleColor.Yellow, $"There are no students in Group {userGroup.Name} ID: {userGroup.Id})");
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Green, ($"Students in Group [{userGroup.Name}] ID: {userGroup.Id}:"));

                    foreach (var student in students)
                    {
                        Helper.PrintConsole(ConsoleColor.White,
                            $"Student Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}");
                    }
                }
            }
            catch (NotFoundException ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
                goto selectGroupId; 
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, $"error: {ex.Message}");
            }
        }
        public void SearchStudentByNameOrSurname()
        {
SearchAgain:
            Helper.PrintConsole(ConsoleColor.Blue, "Enter student name or surname:");
            string text = Console.ReadLine();

            try
            {
                var students = _studentService.Search(text);

                foreach (var student in students)
                {
                    Helper.PrintConsole(ConsoleColor.Green,
                        $"Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}, Age: {student.Age}, Group: {(student.userGroup != null ? student.userGroup.Name : "No Group")}");
                }
            }
            catch (ArgumentException ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
                goto SearchAgain;
            }
            catch (NotFoundException ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
                goto SearchAgain;
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, $"Unexpected error: {ex.Message}");
                goto SearchAgain;
            }
        }




    }
}


