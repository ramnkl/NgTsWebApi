using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NgTs.DataAccess.Generic;
using NgTs.Entities;
using System.Collections.Generic;
namespace NgTs.DataAccess
{
#region GetAll factory
public partial class ProductRepository : Repository<Product>
	{
	public ProductRepository(string databaseName) : base(databaseName)
		{
		}
	public List<Product> GetAllFromProduct()
		{
		ISelectionFactory<NullableIdentity> selectionFactory = new GetAllFromProductSelectionFactory();
		try
			{
			NullableIdentity nullableIdentity = new NullableIdentity();
			return base.Find(selectionFactory, new GetAllFromProductFactory(), nullableIdentity);
			}
		catch (DbException ex)
			{
			}
		return new List<Product>();
		}
	public ProductRepository() : this(PlatformConfig.DefaultDatabaseConnection)
		{
		}
	public void Add( Product product )
		{
		ProductInsertFactory insertFactory = new ProductInsertFactory();
		try
			{
			base.Add(insertFactory, product );
			}
		catch (DbException ex)
			{
			HandleSqlException(ex, insertFactory);
			}
		}
	public void Save( Product product)
		{
		ProductUpdateFactory updateFactory = new ProductUpdateFactory();
		try
			{
			base.Save(updateFactory, product);
			}
		catch (DbException ex)
			{
			HandleSqlException(ex, updateFactory);
			}
		}
	public void Remove(long productid)
		{
		IDeleteFactory<long> deleteFactory = new ProductDeleteFactory();
		try
			{
			base.Remove(deleteFactory, productid);
			}
		catch (DbException ex)
			{
			HandleSqlException(ex, deleteFactory);
			}
		}
	public Product GetProductByproductid(long  productid  )
		{
		ISelectionFactory<long> selectionFactory = new GetProductByProductIdSelectionFactory();
		try
			{
			return base.FindOne(selectionFactory, new GetAllFromProductFactory(), productid);
			}
		catch (DbException ex)
			{
			HandleSqlException(ex, selectionFactory);
			}
		return null;
		}
	private void HandleSqlException(DbException ex, IDbToBusinessEntityNameMapper mapper)
		{
		throw new RepositoryFailureException(ex);
		}
	}
#endregion
#region Select factory
internal class GetAllFromProductFactory : IDomainObjectFactory<Product>
	{
	 public Product Construct(IDataReader reader)
		{
		Product product = new Product();
		int productidIndex = reader.GetOrdinal("ProductId");
		if(!reader.IsDBNull(productidIndex ))
			{
			product.ProductId= reader. GetInt64(productidIndex );
			}
		int productnameIndex = reader.GetOrdinal("ProductName");
		if(!reader.IsDBNull(productnameIndex ))
			{
			product.ProductName= reader. GetString(productnameIndex );
			}
		int productdescIndex = reader.GetOrdinal("ProductDesc");
		if(!reader.IsDBNull(productdescIndex ))
			{
			product.ProductDesc= reader. GetString(productdescIndex );
			}
		int priceIndex = reader.GetOrdinal("Price");
		if(!reader.IsDBNull(priceIndex ))
			{
			product.Price= reader. GetDecimal(priceIndex );
			}
		return product;
		}
	}
#endregion
}
