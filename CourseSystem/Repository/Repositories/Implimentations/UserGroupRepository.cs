using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using System.Xml.Linq;

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
                if (data == null) throw new NotFoundException("Usergroup cant be null");

                
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


                for (int i = 0; i < AppDbContext<UserGroup>.datas.Count; i++)
                {
                    var item = AppDbContext<UserGroup>.datas[i];
                    if (predicate(item))
                    {
                        return item;
                    }
                }

                throw new Exception("Group not found.");
            }
            catch (Exception ex)
            {
              
                return null;
            }
        }

        public List<UserGroup> GetAll(Predicate<UserGroup> predicate)
        {
            try
            {
                List<UserGroup> userGroups = new();

                if (predicate == null)
                {
                    for (int i = 0; i < AppDbContext<UserGroup>.datas.Count; i++)
                    {
                        userGroups.Add(AppDbContext<UserGroup>.datas[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < AppDbContext<UserGroup>.datas.Count; i++)
                    {
                        var item = AppDbContext<UserGroup>.datas[i];
                        if (predicate(item))
                        {
                            userGroups.Add(item);
                        }
                    }
                }

                if (userGroups.Count == 0)
                    Console.WriteLine(" UserGroups cant found.");

                return userGroups;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error :{ex.Message}");
                return new List<UserGroup>();
            }
        }

        public void Update(UserGroup data)
        {
            try
            {
                if (data == null) throw new NullPredicateException("UserGroup cannot be null.");

                bool found = false;

                for (int i = 0; i < AppDbContext<UserGroup>.datas.Count; i++)
                {
                    if (AppDbContext<UserGroup>.datas[i].Id == data.Id)
                    {
                        AppDbContext<UserGroup>.datas[i].Name = data.Name;
                        found = true;
                        break;
                    }
                }

                if (!found) throw new NotFoundException("UserGroup not found.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
        }
    }
}
