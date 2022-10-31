using DAL.Entities;
using DAL.Repositories.Abstractions;
using System.Linq.Expressions;

namespace DAL.Repositories.Implimentations;

internal class CustomerRepository : RepositoryBase<Customer, int>, ICustomerRepository
{
    public CustomerRepository(ShopContext shopContext) : base(shopContext)
    {
    }

    protected override Expression<Func<Customer, bool>> GetExpressionById(int id)
    {
        return customer => customer.Id == id;
    }

    protected override int GetId(Customer entity)
    {
        return entity.Id;
    }

    protected override IQueryable<Customer> IncludeAllChildren(IQueryable<Customer> query)
    {
        return query;
    }
}