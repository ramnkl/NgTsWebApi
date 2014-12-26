using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NgTs.DataAccess.Generic;
using NgTs.Entities;
using System.Collections.Generic;
namespace NgTs.DataAccess
{
#region GetAll factory
public partial class NgTsUserRepository : Repository<NgTsUser>
	{
	public NgTsUserRepository(string databaseName) : base(databaseName)
		{
		}
	public List<NgTsUser> GetAllFromNgTsUser()
		{
		ISelectionFactory<NullableIdentity> selectionFactory = new GetAllFromNgTsUserSelectionFactory();
		try
			{
			NullableIdentity nullableIdentity = new NullableIdentity();
			return base.Find(selectionFactory, new GetAllFromNgTsUserFactory(), nullableIdentity);
			}
		catch (DbException ex)
			{
			}
		return new List<NgTsUser>();
		}
	public NgTsUserRepository() : this(PlatformConfig.DefaultDatabaseConnection)
		{
		}
	public void Add( NgTsUser ngtsuser )
		{
		NgTsUserInsertFactory insertFactory = new NgTsUserInsertFactory();
		try
			{
			base.Add(insertFactory, ngtsuser );
			}
		catch (DbException ex)
			{
			HandleSqlException(ex, insertFactory);
			}
		}
	public void Save( NgTsUser ngtsuser)
		{
		NgTsUserUpdateFactory updateFactory = new NgTsUserUpdateFactory();
		try
			{
			base.Save(updateFactory, ngtsuser);
			}
		catch (DbException ex)
			{
			HandleSqlException(ex, updateFactory);
			}
		}
	public void Remove(long userid)
		{
		IDeleteFactory<long> deleteFactory = new NgTsUserDeleteFactory();
		try
			{
			base.Remove(deleteFactory, userid);
			}
		catch (DbException ex)
			{
			HandleSqlException(ex, deleteFactory);
			}
		}
	public NgTsUser GetNgTsUserByuserid(long  userid  )
		{
		ISelectionFactory<long> selectionFactory = new GetNgTsUserByUserIdSelectionFactory();
		try
			{
			return base.FindOne(selectionFactory, new GetAllFromNgTsUserFactory(), userid);
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
internal class GetAllFromNgTsUserFactory : IDomainObjectFactory<NgTsUser>
	{
	 public NgTsUser Construct(IDataReader reader)
		{
		NgTsUser ngtsuser = new NgTsUser();
		int useridIndex = reader.GetOrdinal("UserId");
		if(!reader.IsDBNull(useridIndex ))
			{
			ngtsuser.UserId= reader. GetInt64(useridIndex );
			}
		int usernameIndex = reader.GetOrdinal("UserName");
		if(!reader.IsDBNull(usernameIndex ))
			{
			ngtsuser.UserName= reader. GetString(usernameIndex );
			}
		int usercodeIndex = reader.GetOrdinal("UserCode");
		if(!reader.IsDBNull(usercodeIndex ))
			{
			ngtsuser.UserCode= reader. GetString(usercodeIndex );
			}
		int firstnameIndex = reader.GetOrdinal("FirstName");
		if(!reader.IsDBNull(firstnameIndex ))
			{
			ngtsuser.FirstName= reader. GetString(firstnameIndex );
			}
		int lastnameIndex = reader.GetOrdinal("LastName");
		if(!reader.IsDBNull(lastnameIndex ))
			{
			ngtsuser.LastName= reader. GetString(lastnameIndex );
			}
		int passwordIndex = reader.GetOrdinal("Password");
		if(!reader.IsDBNull(passwordIndex ))
			{
			ngtsuser.Password= reader. GetString(passwordIndex );
			}
		return ngtsuser;
		}
	}
#endregion
}
