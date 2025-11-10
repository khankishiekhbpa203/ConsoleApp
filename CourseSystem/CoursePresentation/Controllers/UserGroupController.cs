using CoursePresentation.Helpers;
using Domain.Entities;
using Service.Services.Implementations;


namespace CoursePresentation.Controllers
{
    public class UserGroupController
    {
        UserGroupService _usergroupService = new();

        public void Create()
        {
            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Name:");

            string groupname = Console.ReadLine();

            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Teacher Name:");

            string groupteacher = Console.ReadLine();

            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Room count:");

selectRoomCount: string roomcount = Console.ReadLine();

            int roomCount;

            bool isRoomCount = int.TryParse(roomcount, out roomCount);
            if (isRoomCount)
            {
                UserGroup userGroup = new UserGroup { Name=groupname, Teacher=groupteacher, Room= roomCount };
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
            Helper.PrintConsole(ConsoleColor.Blue, "Add Group Id:");
GroupId: string groupId = Console.ReadLine();
            int id;

            bool isGroupId = int.TryParse(groupId, out id);
            if (isGroupId)
            {
                try
                {
                    _usergroupService.Delete(id);
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

        }

    }
}
