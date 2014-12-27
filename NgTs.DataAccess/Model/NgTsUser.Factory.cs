 
// This auto genrated code please donot alter  12/26/2014 11:03:39
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NgTs.DataAccess.Generic;
using NgTs.Entities;
using System.Collections.Generic;
namespace NgTs.DataAccess
{
#region Insert factory
	internal class NgTsUserInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<NgTsUser>
		{
		public NgTsUserInsertFactory()
			{
			}
		public DbCommand ConstructInsertCommand(Database db, NgTsUser ngtsuser)
			{
			DbCommand command = db.GetStoredProcCommand( "NgTsUserInsert");
			db.AddInParameter(command,  "UserId",DbType.Int64, ngtsuser.UserId );
			db.AddInParameter(command,  "UserName",DbType.String, ngtsuser.UserName );
			db.AddInParameter(command,  "UserCode",DbType.String, ngtsuser.UserCode );
			db.AddInParameter(command,  "FirstName",DbType.String, ngtsuser.FirstName );
			db.AddInParameter(command,  "LastName",DbType.String, ngtsuser.LastName );
			db.AddInParameter(command,  "Password",DbType.String, ngtsuser.Password );
			return command;
			}
		 //Write generate/fetch new Id while insert a record 
		public void SetNewID(Database db, DbCommand command, NgTsUser ngtsuser)
			{
			long userid1 = (long)(db.GetParameterValue(command,  "userid"));
			ngtsuser.UserId= userid1;
			}
		public string MapDbParameterToBusinessEntityProperty(string dbParameter)
			{
			switch (dbParameter)
				{
				case "UserId" :
				return "UserId";
				case "UserName" :
				return "UserName";
				case "UserCode" :
				return "UserCode";
				case "FirstName" :
				return "FirstName";
				case "LastName" :
				return "LastName";
				case "Password" :
				return "Password";
				default : 
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Invalid Parameter Name");
				}
			}
		}
	#endregion
#region update factory
	internal class NgTsUserUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<NgTsUser>
		{
		public NgTsUserUpdateFactory()
			{
			}
		public DbCommand ConstructUpdateCommand(Database db, NgTsUser ngtsuser)
			{
			DbCommand command = db.GetStoredProcCommand( "NgTsUserUpdate");
			db.AddInParameter(command,  "UserId",DbType.Int64, ngtsuser.UserId );
			db.AddInParameter(command,  "UserName",DbType.String, ngtsuser.UserName );
			db.AddInParameter(command,  "UserCode",DbType.String, ngtsuser.UserCode );
			db.AddInParameter(command,  "FirstName",DbType.String, ngtsuser.FirstName );
			db.AddInParameter(command,  "LastName",DbType.String, ngtsuser.LastName );
			db.AddInParameter(command,  "Password",DbType.String, ngtsuser.Password );
			return command;
			}
		public string MapDbParameterToBusinessEntityProperty(string dbParameter)
			{
			switch (dbParameter)
				{
				case "UserId" :
				return "UserId";
				case "UserName" :
				return "UserName";
				case "UserCode" :
				return "UserCode";
				case "FirstName" :
				return "FirstName";
				case "LastName" :
				return "LastName";
				case "Password" :
				return "Password";
				default : 
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Invalid Parameter Name");
				}
			}
		}
	#endregion
#region delete factory
	 internal class 
	NgTsUserDeleteFactory : IDeleteFactory<long>{
		public NgTsUserDeleteFactory()
			{
			}
		public DbCommand ConstructDeleteCommand(Database db, long UserId)
			{
			DbCommand command = db.GetStoredProcCommand( "NgTsUserDelete");
			db.AddInParameter(command,  "UserId",DbType.Int64, UserId );
			return command;
			}
		public string MapDbParameterToBusinessEntityProperty(string dbParameter)
			{
			switch (dbParameter)
				{
				case "UserId" :
				return "UserId";
				default : 
				return string.Format(System.Globalization.CultureInfo.CurrentCulture, "InvalidParameterName");
				}
			}
		}
	#endregion
#region get all select factory
internal class GetAllFromNgTsUserSelectionFactory : ISelectionFactory<NullableIdentity>
	{
	public GetAllFromNgTsUserSelectionFactory()
		{
		}
	public DbCommand ConstructSelectCommand(Database db, NullableIdentity nullableIdentity)
		{
		DbCommand command = db.GetStoredProcCommand("NgTsUserGetAll");
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
internal class GetNgTsUserByUserIdSelectionFactory : ISelectionFactory<long>
	{
	public GetNgTsUserByUserIdSelectionFactory()
		{
		}
	public DbCommand ConstructSelectCommand(Database db,  long  userid)
		{
		DbCommand command = db.GetStoredProcCommand("GetNgTsUserByUserId");
		db.AddInParameter(command, "UserId", DbType.Int64,  userid);
		return command;
		}
	public string MapDbParameterToBusinessEntityProperty(string dbParameter)
		{
		switch (dbParameter)
			{
			case "UserId" :
				return "UserId";
			default:
			return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Invalid Parameter Name (Create get all from(UserId))" );
			}
		}
	}
#endregion
}
