using Domain.Models;
using Repository.Repository.Interfaces;


namespace Repository.Repository.Implementations
{
    public class GroupRepository : IRepository<Group>
    {
        public void Create(Group data)
        {
            try
            {

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Group data)
        {
            throw new NotImplementedException();
        }

        public Group Get(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll(Predicate<Group> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Group data)
        {
            throw new NotImplementedException();
        }
    }
}
