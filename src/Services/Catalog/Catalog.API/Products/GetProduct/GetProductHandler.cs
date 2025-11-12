
namespace Catalog.API.Products.GetProduct;

public record GetProductQuery():IQuery<GetProductResult>;
public record GetProductResult(IEnumerable<Product>Products);


public class GetProductQueryHandler (IDocumentSession session,ILogger<GetProductQueryHandler>logger)
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductHandler.Handle called with {@Query}",query);
        var product=await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductResult(product);
    }
}
