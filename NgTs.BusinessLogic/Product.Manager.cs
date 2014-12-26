using System;
using System.Collections.Generic;
using NgTs.Entities;
using NgTs.DataAccess;
namespace NgTs.BusinessLogic
{
#region persistent manager
	public class  ProductManager : NgTsManager
	{
	public  ProductManager()
		{
		}
	//public  ProductManager(NgTsSession session)  : base(session)
		//{
		//}
	public Product CreateProduct( Product product)
		{
		if (null ==  product)
			{
			throw new ArgumentNullException("Product");
			}
		using (NgTsTransactionScope scope = new NgTsTransactionScope())
			{
			_AddUpdate( product);
			scope.Complete();
			}
		return  product;
		}
	public void UpdateProduct( Product product)
		{
		if (null ==  product)
			{
			throw new ArgumentNullException("Product");
			}
		using (NgTsTransactionScope scope = new NgTsTransactionScope())
			{
			_AddUpdate( product);
			scope.Complete();
			}
		}
	public Product GetProduct(long productid)
		{
		return _GetLong(productid);
		}
	private ProductRepository _RepProduct;
	protected ProductRepository RepProduct
		{
		get { return NgTsUtility.GetObject(ref _RepProduct); }
		}
	private void _DefaultsForCreate(Product product)
		{
		//product.CreatedDate = DateTime.UtcNow;
		//product.UpdatedDate = DateTime.UtcNow;
		//product.CreatedById = this.Session.MemberEzkey;
		//product.UpdatedById = this.Session.MemberEzkey;
		}
	private void _DefaultsForUpdate(Product product)
		{
		//product.UpdatedDate = DateTime.UtcNow;
		//product.UpdatedById = this.Session.MemberEzkey;
		}
	private void _OverrideEdit(Product oldValue, Product newValue)
		{
		//newValue.UpdatedDate = oldValue.UpdatedDate;
		//newValue.UpdatedById = oldValueMemberEzkey;
		}
	private void _Validate(Product product)
		{
		}
	private void _AddUpdate(Product product)
		{
		if (0 == product.ProductId)
			{
			_DefaultsForCreate(product);
			//ValidationUtility.Validate(product);
			RepProduct.Add(product);
			}
		else
			{
			Product oldProduct;
			oldProduct = _GetProduct(product.ProductId);
			_DefaultsForUpdate(product);
			_OverrideEdit(oldProduct, product);
			//ValidationUtility.Validate(product);
			RepProduct.Save(product);
			}
		}
	private Product _GetProduct(long  productid)
		{
		Product product= this.RepProduct.GetProductByproductid(productid);
		if (null ==  product)
			{
			//throw new NgTsException(NgTsErrorCode.ErrproductidInvalid, StringRes.ErrproductidInvalid(ProductId));
			}
		return product;
		}
	}
#endregion
}
