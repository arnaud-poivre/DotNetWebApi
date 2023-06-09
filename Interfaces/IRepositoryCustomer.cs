namespace DotNetWebApiSupport.Interfaces
{
    public interface IRepositoryCustomer<Customer> : IRepository<Customer>
    {
        IEnumerable<Customer>? GetByTitle(string title);
        IEnumerable<Customer>? GetByFirstAndLastName(string firstName, string lastName);
    }
}