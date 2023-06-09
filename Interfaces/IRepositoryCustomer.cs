namespace DotNetWebApiSupport.Interfaces
{
    public interface IRepositoryCustomer<Customer>
    {
        IEnumerable<Customer>? GetByTitle(string title);
        IEnumerable<Customer>? GetByFirstAndLastName(string firstName, string lastName);
    }
}