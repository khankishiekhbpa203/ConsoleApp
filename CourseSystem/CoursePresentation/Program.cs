using CoursePresentation.Controllers;
using CoursePresentation.Helpers;
using Domain.Entities;
using Service.Services.Implementations;

namespace CoursePresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserGroupController userGroupController = new();

            Helper.PrintConsole(ConsoleColor.Green, "Select one option!");
            Helper.PrintConsole(ConsoleColor.Yellow, "1-Create Group     8-Create Student\n2-Delete Group     9-Delete Student\n3-Update Group     10-Update Student\n4-Get group by id     11-Get Student by id\n5-Get all groups by teacher   12-Get Student by age\n6-Get all groups by room     13-Search method for groups by name\n7-Get all groups     14-Get all students by group id\n15-Search method for students by name or surname");
            while (true)
            {
                Selectoption: string selectOption = Console.ReadLine();
                int option;
                bool istrueOption = int.TryParse(selectOption, out option);
                if (istrueOption)
                {
                    switch (option)
                    {
                        case 1:
                            userGroupController.Create();
                            break;
                            case 2:
                            userGroupController.GetById();
                            break;
                            case 3:
                            userGroupController.Delete();
                            break;
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Select correct option type");
                    goto Selectoption;
                }
            }
        }
    }
}
