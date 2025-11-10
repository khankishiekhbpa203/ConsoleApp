using Domain.Entities;
using Repository.Repositories.Implimentations;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Implementations
{
    public class UserGroupService : IUserGroupService
    {
        private UserGroupRepository _userGroupRepository;
        private int _count = 1;
        public UserGroupService()
        {
            _userGroupRepository= new UserGroupRepository();
        }
        public UserGroup Create(UserGroup userGroup)
        {
            userGroup.Id=_count;

            _userGroupRepository.Create(userGroup);

            _count++;

            return userGroup;
        }

        public void Delete(int id)
        {
            UserGroup userGroup = GetById(id);

            _userGroupRepository.Delete(userGroup);
        }

        public List<UserGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserGroup GetById(int id)
        {
                if (id <= 0)
                {
                    throw new ArgumentException("Id sifirdan boyuk olmalidir");
                }
                UserGroup userGroup = _userGroupRepository.Get(g => g.Id == id);
                if (userGroup == null)
                {
                    throw new NullReferenceException($"ID-si {id} olan UserGroup tapılmadı.");
                }
                return userGroup;
        }

        public List<UserGroup> Search(string name)
        {
            throw new NotImplementedException();
        }

        public UserGroup Update(int id, UserGroup userGroup)
        {
            throw new NotImplementedException();
        }
    }
}
