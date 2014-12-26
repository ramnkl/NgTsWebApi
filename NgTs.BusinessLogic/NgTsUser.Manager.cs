using System;
using System.Collections.Generic;
using NgTs.Entities;
using NgTs.DataAccess;
namespace NgTs.BusinessLogic
{
#region persistent manager
	public class  NgTsUserManager : NgTsManager
	{
	public  NgTsUserManager()
		{
		}
	//public  NgTsUserManager(NgTsSession session)  : base(session)
		//{
		//}
	public NgTsUser CreateNgTsUser( NgTsUser ngtsuser)
		{
		if (null ==  ngtsuser)
			{
			throw new ArgumentNullException("NgTsUser");
			}
		using (NgTsTransactionScope scope = new NgTsTransactionScope())
			{
			_AddUpdate( ngtsuser);
			scope.Complete();
			}
		return  ngtsuser;
		}
	public void UpdateNgTsUser( NgTsUser ngtsuser)
		{
		if (null ==  ngtsuser)
			{
			throw new ArgumentNullException("NgTsUser");
			}
		using (NgTsTransactionScope scope = new NgTsTransactionScope())
			{
			_AddUpdate( ngtsuser);
			scope.Complete();
			}
		}
	public NgTsUser GetNgTsUser(long userid)
		{
		return _GetLong(userid);
		}
	private NgTsUserRepository _RepNgTsUser;
	protected NgTsUserRepository RepNgTsUser
		{
		get { return NgTsUtility.GetObject(ref _RepNgTsUser); }
		}
	private void _DefaultsForCreate(NgTsUser ngtsuser)
		{
		//ngtsuser.CreatedDate = DateTime.UtcNow;
		//ngtsuser.UpdatedDate = DateTime.UtcNow;
		//ngtsuser.CreatedById = this.Session.MemberEzkey;
		//ngtsuser.UpdatedById = this.Session.MemberEzkey;
		}
	private void _DefaultsForUpdate(NgTsUser ngtsuser)
		{
		//ngtsuser.UpdatedDate = DateTime.UtcNow;
		//ngtsuser.UpdatedById = this.Session.MemberEzkey;
		}
	private void _OverrideEdit(NgTsUser oldValue, NgTsUser newValue)
		{
		//newValue.UpdatedDate = oldValue.UpdatedDate;
		//newValue.UpdatedById = oldValueMemberEzkey;
		}
	private void _Validate(NgTsUser ngtsuser)
		{
		}
	private void _AddUpdate(NgTsUser ngtsuser)
		{
		if (0 == ngtsuser.UserId)
			{
			_DefaultsForCreate(ngtsuser);
			//ValidationUtility.Validate(ngtsuser);
			RepNgTsUser.Add(ngtsuser);
			}
		else
			{
			NgTsUser oldNgTsUser;
			oldNgTsUser = _GetNgTsUser(ngtsuser.UserId);
			_DefaultsForUpdate(ngtsuser);
			_OverrideEdit(oldNgTsUser, ngtsuser);
			//ValidationUtility.Validate(ngtsuser);
			RepNgTsUser.Save(ngtsuser);
			}
		}
	private NgTsUser _GetNgTsUser(long  userid)
		{
		NgTsUser ngtsuser= this.RepNgTsUser.GetNgTsUserByuserid(userid);
		if (null ==  ngtsuser)
			{
			//throw new NgTsException(NgTsErrorCode.ErruseridInvalid, StringRes.ErruseridInvalid(UserId));
			}
		return ngtsuser;
		}
	}
#endregion
}
