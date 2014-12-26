using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NgTs.DataAccess.Generic
{
    /// <summary>
    /// This interface provides the signature for the
    /// class that converts a given InIdentityObject into
    /// a DbCommand to do a search for the corresponding
    /// result set.
    /// </summary>
    /// <typeparam name="TInIdentityObject">Type that identifies the
    /// items to search for.</typeparam>
    /// <typeparam name="TOutIdentityObject">Type that identifies the
    /// items to return along with regular type.</typeparam>
    public interface IIOSelectionFactory< TInIdentityObject, TOutIdentityObject > : IDbToBusinessEntityNameMapper
    {
        DbCommand ConstructSelectCommand(Database db, TInIdentityObject idObject, TOutIdentityObject outObject);
        
		/// <summary>
		/// Reads the out values of the command
		/// and set it in the TOutIdentityObject object.
		/// </summary>
		/// <param name="db">EntLib database object that the command was generated with.</param>
		/// <param name="command">Successfully executed command that now holds the out values. This should be the same command object that was returned from ConstructSelectCommand.</param>
		/// <param name="TOutIdentityObject">Domain object that was passed in to ConstructSelectCommand. </param>
		void PopulateOutValues(Database db, DbCommand command, ref TOutIdentityObject outObject);
    }
}
