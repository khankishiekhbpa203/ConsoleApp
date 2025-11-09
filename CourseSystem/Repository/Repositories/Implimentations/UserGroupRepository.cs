using Domain.Entities;
using Repository.Data;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Implimentations
{
    public class UserGroupRepository : IRepository<UserGroup>
    {
        public void Create(UserGroup data)
        {
            try
            {
                if (data is null) throw new NotFoundException("Book Not Found");

                AppDbContext<UserGroup>.datas.Add(data);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(UserGroup data)
        {
            throw new NotImplementedException();
        }

        public UserGroup Get(Predicate<UserGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public List<UserGroup> GetAll(Predicate<UserGroup> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(UserGroup data)
        {
            throw new NotImplementedException();
        }
    }
}
