 
// This auto genrated code please donot alter  01/04/2015 16:12:39
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using NgTs.BusinessLogic;
using NgTs.Entities;
namespace NgTsWebApi
{
#region  controller
public class ProductController : ApiController
	{
	static readonly ProductManager mgr = new ProductManager();
	public IEnumerable<Product> GetAllProduct()
		{
		return mgr.GetAll();
	}

	public Product GetProduct(long id)
		{
		Product item = mgr.GetProduct(id);
		if (item == null)
			{
			throw new HttpResponseException(HttpStatusCode.NotFound);
		}
		return item;
	}

	public HttpResponseMessage PostProduct(Product item)
		{
		item = mgr.CreateProduct(item);
		var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);
		string uri = Url.Link("DefaultApi", new { id = item.ProductId});
		response.Headers.Location = new Uri(uri);
		return response;
	}

	public void PutProduct(long id, Product item)
		{
		item.ProductId = id;
		mgr.UpdateProduct(item);
	}

}
#endregion
}
