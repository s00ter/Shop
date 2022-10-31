using DAL.Entities;
using DAL.Repositories.Abstractions;
using System.Linq.Expressions;

namespace DAL.Repositories.Implimentations;

internal class ProductRepository : RepositoryBase<Product, int>, IProductRepository
{
    public ProductRepository(ShopContext shopContext) : base(shopContext)
    {
    }

    protected override Expression<Func<Product, bool>> GetExpressionById(int id)
    {
        return product => product.Id == id;
    }

    protected override int GetId(Product entity)
    {
        return entity.Id;
    }

    protected override IQueryable<Product> IncludeAllChildren(IQueryable<Product> query)
    {
        return query;
    }
}