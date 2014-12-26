using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using NgTs.DataAccess.Generic;
using System.Globalization;

namespace NgTs.DataAccess.Generic
{
    /// <summary>
    /// This exception is thrown when a validation error
    /// is detected in the repository or database.
    /// </summary>
    [Serializable]
    public class RepositoryValidationException : RepositoryException
    {
        private string failedField;
        private string failureReason;

        public RepositoryValidationException( string failedField, string failureReason )
            : this( failedField, failureReason, null )
        {
        }

        public RepositoryValidationException(string failedField, string failureReason, Exception inner)
            : base(string.Format(CultureInfo.CurrentCulture, null, failedField, failureReason), inner)
        {
            this.failedField = failedField;
            this.failureReason = failureReason;
        }

        public string FailedField
        {
            get { return failedField; }
        }

        public string FailureReason
        {
            get { return failureReason; }
        }

		#region Standard Exception Constructors
        public RepositoryValidationException()
        {
        }

        public RepositoryValidationException(string message)
            : base(message)
        {
        }

        public RepositoryValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected RepositoryValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
		#endregion
    }
}
