using System;
using System.Collections.Generic;
namespace NgTs.Entities
{
#region entity factory
public class Product{
	long _productid;
	public long ProductId
		{
		get {return  this._productid;}
		set { this._productid =  value;}
		}
	string _productname;
	public string ProductName
		{
		get {return  this._productname;}
		set { this._productname =  value;}
		}
	string _productdesc;
	public string ProductDesc
		{
		get {return  this._productdesc;}
		set { this._productdesc =  value;}
		}
	decimal _price;
	public decimal Price
		{
		get {return  this._price;}
		set { this._price =  value;}
		}
	}
#endregion
}
