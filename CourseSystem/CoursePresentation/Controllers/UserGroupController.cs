using CoursePresentation.Helpers;
using Domain.Entities;
using Service.Services.Implementations;
using Service.Services.Interfaces;
using System;



namespace CoursePresentation.Controllers
{
    public class UserGroupController
    {
        UserGroupService _usergroupService = new();

        public void Create()
        {
GroupName: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Name:");

            string groupname = Console.ReadLine();

            if (!groupname.Any(ch => char.IsLetterOrDigit(ch)))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Group name cant be simvol or empty");
                goto GroupName;
            }

TeacherName: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Teacher Name:");

            string groupteacher = Console.ReadLine();
            if (groupteacher.Any(ch => !char.IsLetter(ch)) || string.IsNullOrWhiteSpace(groupteacher))
            {
                Helper.PrintConsole(ConsoleColor.Red, "Teacher name cant be simvol,digit or empty");
                goto TeacherName;
            }
            groupteacher=char.ToUpper(groupteacher[0]) + groupteacher.Substring(1).ToLower();

            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Room count:");

selectRoomCount: string roomcount = Console.ReadLine();

            int roomCount;

            bool isRoomCount = int.TryParse(roomcount, out roomCount);
            if (isRoomCount)
            {
                UserGroup userGroup = new UserGroup { Name=groupname.ToUpper(), Teacher=groupteacher, Room= roomCount };
                var result = _usergroupService.Create(userGroup);
                Helper.PrintConsole(ConsoleColor.Green, $"Group Id: {userGroup.Id} ,Group Name: {userGroup.Name} ,Group Teacher: {userGroup.Teacher} ,Group Room: {userGroup.Room}");
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add Correct Roomcount type");
                goto selectRoomCount;
            }
        }
        public void Delete()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id: (or enter for cancel operation)");
GroupId: string groupId = Console.ReadLine();
            int id;

            if (string.IsNullOrWhiteSpace(groupId)||groupId=="exit")
            {
                Helper.PrintConsole(ConsoleColor.Red, "Update operation cancelled.");
                return;
            }
            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                try
                {
                    _usergroupService.Delete(id);
                }
                catch (Exception ex)
                {
                    Helper.PrintConsole(ConsoleColor.Red,"Group can't find");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct group id type");
                goto GroupId;
            }
        }
        public void GetById()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id:");
GroupId: string groupId = Console.ReadLine();
            int id;

            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                try
                {
                    UserGroup userGroup = _usergroupService.GetById(id);

                    if (userGroup != null)
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Group Id: {userGroup.Id}, Group Name: {userGroup.Name}, Group Teacher: {userGroup.Teacher}, Group Room: {userGroup.Room}");
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
                Helper.PrintConsole(ConsoleColor.Red, "Add correct group id type");
                goto GroupId;
            }
        }
        public void Update()
        {
GroupId: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id (or press Enter to cancel)");

            string groupId = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(groupId)||groupId=="exit")
            {
                Helper.PrintConsole(ConsoleColor.Red, "Update operation cancelled.");
                return;
            }

            int id;

            bool isGroupId = int.TryParse(groupId, out id);

            if (isGroupId)
            {
                var findGroup = _usergroupService.GetById(id);

                if (findGroup != null)
                {
                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Name: {findGroup.Name}. Add Group new name (or press Enter to keep current)");

                    string GroupNewName = Console.ReadLine();

RoomCount: Helper.PrintConsole(ConsoleColor.Blue, $"Current Teacher: {findGroup.Teacher}. Add Group new Teacher name (or press Enter to keep current)");

                    string GroupNewTeacher = Console.ReadLine();
                    Helper.PrintConsole(ConsoleColor.Blue, $"Current Room Count: {findGroup.Room}. Add Group new Room count (or press Enter to keep current)");

                    string GroupNewRoom = Console.ReadLine();

                    int roomCount = findGroup.Room;

                    if (!string.IsNullOrWhiteSpace(GroupNewRoom))
                    {
                        bool isRoomCount = int.TryParse(GroupNewRoom, out roomCount);

                        if (!isRoomCount)
                        {
                            Helper.PrintConsole(ConsoleColor.Red, "Add correct room count type");
                            goto RoomCount;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(GroupNewName))
                    {
                        GroupNewName = findGroup.Name;
                    }

                    UserGroup userGroup = new UserGroup { Name = GroupNewName, Teacher = GroupNewTeacher, Room = roomCount };

                    var updatedGroup = _usergroupService.Update(id, userGroup);

                    if (updatedGroup == null)
                    {
                        Helper.PrintConsole(ConsoleColor.Red, "Group not Updated, please try again");
                        goto GroupId;
                    }
                    else
                    {
                        Helper.PrintConsole(ConsoleColor.Green, $"Group Id: {updatedGroup.Id}, Name: {updatedGroup.Name}, Teacher: {updatedGroup.Teacher}, Room: {updatedGroup.Room} ");
                    }
                }
                else
                {
                    Helper.PrintConsole(ConsoleColor.Red, "Group not found");
                    goto GroupId;
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Add correct GroupId type");
                goto GroupId;
            }
        }
        public void GetAll()
        {

            List<UserGroup> userGroups = _usergroupService.GetAll();

            if (userGroups.Count != 0)
            {
                foreach (var userGroup in userGroups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Group Id : {userGroup.Id}, Name : {userGroup.Name},Teacher name : {userGroup.Teacher}, Room Count : {userGroup.Room}");
                }
            }
            else
            {
                Helper.PrintConsole(ConsoleColor.Red, "Please Create Group!");
            }

        }
        public void GetByTeacher()
        {
GroupTeacherName: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Teacher name:");
            string name = Console.ReadLine().ToLower().Trim();

            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    List<UserGroup> userGroups = _usergroupService.GetByTeacher(name);

                    if (userGroups != null)
                    {
                        foreach (UserGroup userGroup in userGroups)
                        {
                            Helper.PrintConsole(ConsoleColor.Green, $"Group Id: {userGroup.Id}, Group Name: {userGroup.Name}, Group Teacher: {userGroup.Teacher}, Group Room: {userGroup.Room}");
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
                Helper.PrintConsole(ConsoleColor.Red, "Add valid Teacher name");
                goto GroupTeacherName;
            }

        }
        public void ClearConsole()
        {
            Console.Clear();
            Helper.PrintConsole(ConsoleColor.Green, "Select one option!");
            Helper.PrintConsole(ConsoleColor.Yellow, "1-Create Group     8-Create Student\n2-Delete Group     9-Delete Student\n3-Update Group     10-Update Student\n4-Get group by id     11-Get Student by id\n5-Get all groups by teacher   12-Get Student by age\n6-Get all groups by room     13-Search method for groups by name\n7-Get all groups     14-Get all students by group id\n15-Search method for students by name or surname  16-Clear Console");

        }
        public void GetByRoom()
        {
GroupRoomcount: Helper.PrintConsole(ConsoleColor.Blue, "Add Group Room:");
            string Room = Console.ReadLine();
            int roomcount;
            bool isRoomCount = int.TryParse(Room, out roomcount);
            if (isRoomCount)
            {
                try
                {
                    List<UserGroup> userGroups = _usergroupService.GetByRoom(roomcount);

                    if (userGroups != null)
                    {
                        foreach (UserGroup userGroup in userGroups)
                        {
                            Helper.PrintConsole(ConsoleColor.Green, $"Group Id: {userGroup.Id}, Group Name: {userGroup.Name}, Group Teacher: {userGroup.Teacher}, Group Room: {userGroup.Room}");
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
                Helper.PrintConsole(ConsoleColor.Red, "Add valid Room count");
                goto GroupRoomcount;
            }

        }
        public void SearchGroupByName()
        {
SearchGroupName: Helper.PrintConsole(ConsoleColor.Blue, "Enter group name to search:");
            string name = Console.ReadLine();
            try
            {
                var groups = _usergroupService.Search(name);

                foreach (var group in groups)
                {
                    Helper.PrintConsole(ConsoleColor.Green, $"Id: {group.Id}, Name: {group.Name}, Teacher: {group.Teacher}, Room: {group.Room}");
                }
            }
            catch (Exception ex)
            {
                Helper.PrintConsole(ConsoleColor.Red, ex.Message);
                goto SearchGroupName;
            }
        }
    }
}



