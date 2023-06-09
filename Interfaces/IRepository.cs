namespace DotNetWebApiSupport.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Get();
        T? Get(int id);
    }
}