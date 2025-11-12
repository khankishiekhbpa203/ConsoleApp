using Domain.Entities;
using Repository.Exceptions;
using Repository.Repositories.Implimentations;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            return _userGroupRepository.GetAll();
        }
        public UserGroup GetById(int id)
        {
            UserGroup userGroup = _userGroupRepository.Get(g => g.Id == id);
            return userGroup;
        }

        public List<UserGroup> GetByTeacher(string name)
        {
            List<UserGroup> userGroup = _userGroupRepository.Getbyteacher(g => g.Teacher == name);
            return userGroup;
        }
        public List<UserGroup> GetByRoom(int roomcount)
        {
            List<UserGroup> userGroup = _userGroupRepository.GetByRoom(g => g.Room==roomcount);
            return userGroup;
        }
        public List<UserGroup> Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Group name cannot be empty");

            List<UserGroup> groups = _userGroupRepository.GetAll(g => g.Name != null && g.Name.ToLower().Contains(name.ToLower()));

            if (groups == null || groups.Count == 0)
                throw new NotFoundException($" cant find group {name}");

            return groups;
        }


        public UserGroup Update(int id, UserGroup userGroup)
        {
            UserGroup dbGroup = GetById(id);

            if (dbGroup is null) return null;

            userGroup.Id = id;

            _userGroupRepository.Update(userGroup);

            return GetById(id);

        }
    }
}
