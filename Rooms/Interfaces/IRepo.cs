﻿namespace Rooms.Interfaces
{
    public interface IRepo<K,T>
    {
        ICollection<T> GetAll();
        T Get(K key);

        T Add(T item);
        T Update(T item);
        T Delete(K key);

    }
}
