using System;
namespace NgTs.DataAccess.Generic
{
    public interface IDbToBusinessEntityNameMapper
    {
        string MapDbParameterToBusinessEntityProperty(string dbParameter);
    }
}
