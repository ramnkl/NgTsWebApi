// -----------------------------------------------------------------------
// <copyright file="EdsTransactionScope.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Transactions;

namespace NgTs.BusinessLogic
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public sealed class NgTsTransactionScope : IDisposable
    {
        TransactionScope _transactionScope = null;

        #region Public Members

        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.EdsTransactionScope class with Isolation level as ReadCommitted.
        public NgTsTransactionScope()
        {
            //reverting the earlier due to inconsistent reads that were noticed in some cases !! temporary fix !! We might have to review and use this on a case to case basis.
            _transactionScope = new TransactionScope();
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     and sets the specified transaction as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        //
        // Parameters:
        //   transactionToUse:
        //     The transaction to be set as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        public NgTsTransactionScope(Transaction transactionToUse)
        {
            _transactionScope = new TransactionScope(transactionToUse);
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified requirements.
        //
        // Parameters:
        //   scopeOption:
        //     An instance of the System.Transactions.TransactionScopeOption enumeration
        //     that describes the transaction requirements associated with this transaction
        //     scope.
        public NgTsTransactionScope(TransactionScopeOption scopeOption)
        {
            _transactionScope = new TransactionScope(scopeOption);
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified timeout value, and sets the specified transaction as the
        //     ambient transaction, so that transactional work done inside the scope uses
        //     this transaction.
        //
        // Parameters:
        //   transactionToUse:
        //     The transaction to be set as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        //
        //   scopeTimeout:
        //     The System.TimeSpan after which the transaction scope times out and aborts
        //     the transaction.
        public NgTsTransactionScope(Transaction transactionToUse, TimeSpan scopeTimeout)
        {
            _transactionScope = new TransactionScope(transactionToUse, scopeTimeout);
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified timeout value and requirements.
        //
        // Parameters:
        //   scopeOption:
        //     An instance of the System.Transactions.TransactionScopeOption enumeration
        //     that describes the transaction requirements associated with this transaction
        //     scope.
        //
        //   scopeTimeout:
        //     The System.TimeSpan after which the transaction scope times out and aborts
        //     the transaction.
        public NgTsTransactionScope(TransactionScopeOption scopeOption, TimeSpan scopeTimeout)
        {
            _transactionScope = new TransactionScope(scopeOption, scopeTimeout);
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified requirements.
        //
        // Parameters:
        //   scopeOption:
        //     An instance of the System.Transactions.TransactionScopeOption enumeration
        //     that describes the transaction requirements associated with this transaction
        //     scope.
        //
        //   transactionOptions:
        //     A System.Transactions.TransactionOptions structure that describes the transaction
        //     options to use if a new transaction is created. If an existing transaction
        //     is used, the timeout value in this parameter applies to the transaction scope.
        //     If that time expires before the scope is disposed, the transaction is aborted.
        public NgTsTransactionScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions)
        {
            _transactionScope = new TransactionScope(scopeOption, transactionOptions);
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified timeout value and COM+ interoperability requirements,
        //     and sets the specified transaction as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        //
        // Parameters:
        //   transactionToUse:
        //     The transaction to be set as the ambient transaction, so that transactional
        //     work done inside the scope uses this transaction.
        //
        //   scopeTimeout:
        //     The System.TimeSpan after which the transaction scope times out and aborts
        //     the transaction.
        //
        //   interopOption:
        //     An instance of the System.Transactions.EnterpriseServicesInteropOption enumeration
        //     that describes how the associated transaction interacts with COM+ transactions.
        public NgTsTransactionScope(Transaction transactionToUse, TimeSpan scopeTimeout, EnterpriseServicesInteropOption interopOption)
        {
            _transactionScope = new TransactionScope(transactionToUse, scopeTimeout, interopOption);
        }
        //
        // Summary:
        //     Initializes a new instance of the System.Transactions.TransactionScope class
        //     with the specified scope and COM+ interoperability requirements, and transaction
        //     options.
        //
        // Parameters:
        //   scopeOption:
        //     An instance of the System.Transactions.TransactionScopeOption enumeration
        //     that describes the transaction requirements associated with this transaction
        //     scope.
        //
        //   transactionOptions:
        //     A System.Transactions.TransactionOptions structure that describes the transaction
        //     options to use if a new transaction is created. If an existing transaction
        //     is used, the timeout value in this parameter applies to the transaction scope.
        //     If that time expires before the scope is disposed, the transaction is aborted.
        //
        //   interopOption:
        //     An instance of the System.Transactions.EnterpriseServicesInteropOption enumeration
        //     that describes how the associated transaction interacts with COM+ transactions.
        public NgTsTransactionScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, EnterpriseServicesInteropOption interopOption)
        {
            _transactionScope = new TransactionScope(scopeOption, transactionOptions, interopOption);
        }
        // Summary:
        //     Indicates that all operations within the scope are completed successfully.
        //
        // Exceptions:
        //   System.InvalidOperationException:
        //     This method has already been called once.
        public void Complete()
        {
            _transactionScope.Complete();
        }

        #endregion

        #region IDisposable Members
        //
        // Summary:
        //     Ends the transaction scope.
        public void Dispose()
        {
            _transactionScope.Dispose();
        }

        #endregion
    }
}
