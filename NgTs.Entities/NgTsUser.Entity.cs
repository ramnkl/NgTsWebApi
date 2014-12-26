using System;
using System.Collections.Generic;
namespace NgTs.Entities
{
#region entity factory
public class NgTsUser{
	long _userid;
	public long UserId
		{
		get {return  this._userid;}
		set { this._userid =  value;}
		}
	string _username;
	public string UserName
		{
		get {return  this._username;}
		set { this._username =  value;}
		}
	string _usercode;
	public string UserCode
		{
		get {return  this._usercode;}
		set { this._usercode =  value;}
		}
	string _firstname;
	public string FirstName
		{
		get {return  this._firstname;}
		set { this._firstname =  value;}
		}
	string _lastname;
	public string LastName
		{
		get {return  this._lastname;}
		set { this._lastname =  value;}
		}
	string _password;
	public string Password
		{
		get {return  this._password;}
		set { this._password =  value;}
		}
	}
#endregion
}
