using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;


namespace Repository.Repositories.Implimentations
{
    public class UserGroupRepository : IRepository<UserGroup>
    {
        public void Create(UserGroup? data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Group Not Found");

                AppDbContext<UserGroup>.datas.Add(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(UserGroup? data)
        {
            try
            {
                if (data == null) throw new NotFoundException("Cant find group");


                if (AppDbContext<UserGroup>.datas.Count!=0)
                {
                    bool isDeleted = AppDbContext<UserGroup>.datas.Remove(data);
                    if (!isDeleted)
                    {
                        throw new NotFoundException("UserGroup not found.");
                    }
                    else
                    {
                        Console.WriteLine("Successfully Deleted");
                    }
                }
                else
                {
                    throw new NotFoundException("UserGroup not found.");
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public UserGroup Get(Predicate<UserGroup> predicate)
        {
            try
            {
                if (predicate == null) throw new NullPredicateException("Predicate cannot be null");

                if (AppDbContext<UserGroup>.datas.Count!=0)
                {

                    for (int i = 0; i < AppDbContext<UserGroup>.datas.Count; i++)
                    {
                        var item = AppDbContext<UserGroup>.datas[i];
                        if (predicate(item))
                        {
                            return item;
                        }
                    }

                }
                else
                {
                    throw new NullReferenceException("group icinde her hansi bir element yoxdur");
                }

                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<UserGroup> GetAll(Predicate<UserGroup> predicate=null)
        {
            return predicate != null ? AppDbContext<UserGroup>.datas.FindAll(predicate) : AppDbContext<UserGroup>.datas;
        }

        public void Update(UserGroup data)
        {
            UserGroup dbGroup = Get(l => l.Id == data.Id);

            if (dbGroup == null) return;

            if (!string.IsNullOrEmpty(data.Name))
            {
                dbGroup.Name = data.Name;
            }

            if (!string.IsNullOrEmpty(data.Teacher))
            {
                dbGroup.Teacher = data.Teacher;
            }
            if (data.Room>0)
            {
                dbGroup.Room = data.Room;
            }
        }
        public List<UserGroup> Getbyteacher(Predicate<UserGroup> predicate)
        {
            
            List<UserGroup>userGroups=AppDbContext<UserGroup>.datas.FindAll(predicate);
            if (userGroups.Count==0)
            {
                throw new NullReferenceException("cant find teacher for all groups");
            }
            return userGroups;

        }
        public List<UserGroup> GetByRoom(Predicate<UserGroup> predicate)
        {
            List<UserGroup> userGroups = AppDbContext<UserGroup>.datas.FindAll(predicate);
            if (userGroups.Count==0)
            {
                throw new NullReferenceException("cant find this roomcount for all groups");
            }
            return userGroups;
        }

    }
}
