﻿namespace SeatManagementAPI
{
    public interface IRepository<T>
    {
        T[] GetAll();

        T? GetById(int id);

        void DeleteById(int id);

        void Update(T entity);

        void Add(T entity);
    }
}
