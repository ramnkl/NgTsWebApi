 
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
public class NgTsUserController : ApiController
	{
	static readonly NgTsUserManager mgr = new NgTsUserManager();
	public IEnumerable<NgTsUser> GetAllNgTsUser()
		{
		return mgr.GetAll();
	}

	public NgTsUser GetNgTsUser(long id)
		{
		NgTsUser item = mgr.GetNgTsUser(id);
		if (item == null)
			{
			throw new HttpResponseException(HttpStatusCode.NotFound);
		}
		return item;
	}

	public HttpResponseMessage PostNgTsUser(NgTsUser item)
		{
		item = mgr.CreateNgTsUser(item);
		var response = Request.CreateResponse<NgTsUser>(HttpStatusCode.Created, item);
		string uri = Url.Link("DefaultApi", new { id = item.UserId});
		response.Headers.Location = new Uri(uri);
		return response;
	}

	public void PutNgTsUser(long id, NgTsUser item)
		{
		item.UserId = id;
		mgr.UpdateNgTsUser(item);
	}

}
#endregion
}
