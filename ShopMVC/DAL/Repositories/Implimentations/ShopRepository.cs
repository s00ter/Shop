using DAL.Entities;
using DAL.Repositories.Abstractions;
using System.Linq.Expressions;

namespace DAL.Repositories.Implimentations;

internal class ShopRepository : RepositoryBase<Shop, int>, IShopRepository
{
    public ShopRepository(ShopContext shopContext) : base(shopContext)
    {
    }

    protected override Expression<Func<Shop, bool>> GetExpressionById(int id)
    {
        return shop => shop.Id == id;
    }

    protected override int GetId(Shop entity)
    {
        return entity.Id;
    }

    protected override IQueryable<Shop> IncludeAllChildren(IQueryable<Shop> query)
    {
        return query;
    }
}