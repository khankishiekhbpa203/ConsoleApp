

using Domain.Common;

namespace Repository.Repository.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        void Create(T data);
        void Update(T data);
        void Delete(T data);
        T Get(Predicate<T> predicate);
        List<T> GetAll(Predicate<T> predicate);
    }
}
