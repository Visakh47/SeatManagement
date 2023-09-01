namespace SeatManagementAPI
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SeatManagementDbContext context;

        public Repository(SeatManagementDbContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                context.Set<T>().Remove(item);
                context.SaveChanges();
            }
        }

        public T[] GetAll()
        {
            return context.Set<T>().ToArray();
        }

        public T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
