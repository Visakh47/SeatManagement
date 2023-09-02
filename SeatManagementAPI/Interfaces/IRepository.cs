namespace SeatManagementAPI.Interfaces
{
    public interface IRepository<T>
    {
        T[] GetAll();

        T? GetById(int id);

        void DeleteById(int id);

        void Update(T entity);

        void Add(T entity);

        void AddMany(List<T> entity);
    }
}
