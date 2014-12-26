using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgTs.DataAccess
{
    public delegate void RepositoryEventsHandler(RepositoryEventsArgs e);


    public enum DBActions
    {
        Create = 0,
        Read = 1,
        Update = 2,
        Delete = 3
    }
    public class RepositoryEventsArgs
    {
        public object Obj; //This is the actual DataObject which was just saved into a DB Table.
        public string ObjectTypeName; //This is the name of the DB Table.
        public DBActions DBActionType;

        public RepositoryEventsArgs(object obj, string objectTypeName, DBActions action)
        {
            Obj = obj;
            ObjectTypeName = objectTypeName;
            DBActionType = action;
        }
    }


}
