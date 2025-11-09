using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IUserGroupService
    {
        UserGroup Create(UserGroup userGroup);
        UserGroup Update(int id, UserGroup userGroup);
        void Delete(int id);
        UserGroup GetById(int id);
        List<UserGroup> GetAll();
        List<UserGroup> Search(string name);
    }
}
