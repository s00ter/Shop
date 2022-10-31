using DAL.Entities;
using DAL.Repositories.Abstractions;
using System.Linq.Expressions;

namespace DAL.Repositories.Implimentations;

internal class OrderRepository : RepositoryBase<Order, int>, IOrderRepository
{
    public OrderRepository(ShopContext shopContext) : base(shopContext)
    {
    }

    protected override Expression<Func<Order, bool>> GetExpressionById(int id)
    {
        return order => order.Id == id;
    }

    protected override int GetId(Order entity)
    {
        return entity.Id;
    }

    protected override IQueryable<Order> IncludeAllChildren(IQueryable<Order> query)
    {
        return query;
    }
}