using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using NgTs.DataAccess.Generic;
using System.Globalization;

namespace NgTs.DataAccess.Generic
{
	/// <summary>
    /// This exception is thrown when an unexpected error
    /// is received from the database.
    /// </summary>
    [Serializable]
    public class RepositoryFailureException : RepositoryException
    {
        public RepositoryFailureException()
        {
        }

        public RepositoryFailureException(string message)
            : base(message)
        {
        }

        public RepositoryFailureException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public RepositoryFailureException(Exception inner)
            : base(string.Format(CultureInfo.CurrentCulture, null), inner)
        {
        }

        protected RepositoryFailureException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

