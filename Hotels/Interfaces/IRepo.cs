namespace Hotels.Interfaces
{
    public interface IRepo<K,T>

    {
        ICollection<T> GetAll();

        T Add(T item);
       
    }
}
