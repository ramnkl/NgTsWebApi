 
// This auto genrated code please donot alter  12/25/2014 19:01:33
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NgTs.DataAccess.Generic;
using NgTs.Entities;
using System.Collections.Generic;
namespace NgTs.DataAccess
{
#region Insert factory
	internal class ProductInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<Product>
		{
		public ProductInsertFactory()
			{
			}
		public DbCommand ConstructInsertCommand(Database db, Product product)
			{
			DbCommand command = db.GetStoredProcCommand( "ProductInsert");
			db.AddInParameter(command,  "ProductId",DbType.Int64, product.ProductId );
			db.AddInParameter(command,  "ProductName",DbType.String, product.ProductName );
			db.AddInParameter(command,  "ProductDesc",DbType.String, product.ProductDesc );
			db.AddInParameter(command,  "Price",DbType.Decimal, product.Price );
			return command;
			}
		 //Write generate/fetch new Id while insert a record 
		public void SetNewID(Database db, DbCommand command, Product product)
			{
			long productid1 = (long)(db.GetParameterValue(command,  "productid"));
			product.ProductId= productid1;
			}
		public string MapDbParameterToBusinessEntityProperty(string dbParameter)
			{
			switch (dbParameter)
				{
				case "ProductId" :
				return "ProductId";
				case "ProductName" :
				return "ProductName";
				case "ProductDesc" :
				return "ProductDesc";
				case "Price" :
				return "Price";
				default : 
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Invalid Parameter Name");
				}
			}
		}
	#endregion
#region update factory
	internal class ProductUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<Product>
		{
		public ProductUpdateFactory()
			{
			}
		public DbCommand ConstructUpdateCommand(Database db, Product product)
			{
			DbCommand command = db.GetStoredProcCommand( "ProductUpdate");
			db.AddInParameter(command,  "ProductId",DbType.Int64, product.ProductId );
			db.AddInParameter(command,  "ProductName",DbType.String, product.ProductName );
			db.AddInParameter(command,  "ProductDesc",DbType.String, product.ProductDesc );
			db.AddInParameter(command,  "Price",DbType.Decimal, product.Price );
			return command;
			}
		public string MapDbParameterToBusinessEntityProperty(string dbParameter)
			{
			switch (dbParameter)
				{
				case "ProductId" :
				return "ProductId";
				case "ProductName" :
				return "ProductName";
				case "ProductDesc" :
				return "ProductDesc";
				case "Price" :
				return "Price";
				default : 
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Invalid Parameter Name");
				}
			}
		}
	#endregion
#region delete factory
	 internal class 
	ProductDeleteFactory : IDeleteFactory<long>{
		public ProductDeleteFactory()
			{
			}
		public DbCommand ConstructDeleteCommand(Database db, long ProductId)
			{
			DbCommand command = db.GetStoredProcCommand( "ProductDelete");
			db.AddInParameter(command,  "ProductId",DbType.Int64, ProductId );
			return command;
			}
		public string MapDbParameterToBusinessEntityProperty(string dbParameter)
			{
			switch (dbParameter)
				{
				case "ProductId" :
				return "ProductId";
				default : 
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "InvalidParameterName");
				}
			}
		}
	#endregion
#region get all select factory
internal class GetAllFromProductSelectionFactory : ISelectionFactory<NullableIdentity>
	{
	public GetAllFromProductSelectionFactory()
		{
		}
	public DbCommand ConstructSelectCommand(Database db, NullableIdentity nullableIdentity)
		{
		DbCommand command = db.GetStoredProcCommand("ProductGetAll");
		return command;
		}
	public string MapDbParameterToBusinessEntityProperty(string dbParameter)
		{
		switch (dbParameter)
			{
			default:
			return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Invalid Parameter Name (Create get all from)" );
			}
		}
	}
#endregion
#region get by id select factory
internal class GetProductByProductIdSelectionFactory : ISelectionFactory<long>
	{
	public GetProductByProductIdSelectionFactory()
		{
		}
	public DbCommand ConstructSelectCommand(Database db,  long  productid)
		{
		DbCommand command = db.GetStoredProcCommand("GetProductByProductId");
		db.AddInParameter(command, "ProductId", DbType.Int64,  productid);
		return command;
		}
	public string MapDbParameterToBusinessEntityProperty(string dbParameter)
		{
		switch (dbParameter)
			{
			case "ProductId" :
				return "ProductId";
			default:
			return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Invalid Parameter Name (Create get all from(ProductId))" );
			}
		}
	}
#endregion
}
