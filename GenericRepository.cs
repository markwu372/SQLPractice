

public interface IRepository<T> where T : class
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

public interface IEntity
{
    int Id { get; set; }
}

public class GenericRepository<T>: IRepository<T> where T:class, IEntity
{
    private readonly List<T> _data;

    public GenericRepository()
    {
        _data = new List<T>();
    }
    
    public void Add(T item)
    {
        _data.Add(item);
    }

    public void Remove(T item)
    {
        _data.Remove(item);
    }

    public void Save()
    {
        // In a real implementation, this would persist the changes to the data source.
        Console.WriteLine("Saved changes.");
    }

    public IEnumerable<T> GetAll()
    {
        return _data;
    }

    public T GetById(int id)
    {
        return _data.FirstOrDefault(item=>item.Id==id);
    }
}