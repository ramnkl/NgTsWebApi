// -----------------------------------------------------------------------
// <copyright file="NgTsManager.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace  NgTs.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Transactions;
    using NgTs.Entities;
    using System.Web;


    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class NgTsManager
    {

        public NgTsManager()
        {
            //  this._AuditTrailLogger = AuditTrailLogger.Instance;
        }

        public NgTsManager(NgTsUser session)
            : this()
        {
            if (null == session)
            {
                throw new ArgumentNullException("session");
            }

            Session = session;

            //if (0 != session.MemberEzkey && false == string.IsNullOrEmpty(session.AuthSessionToken))
            //{
            //    //MgrAuthSession = new AuthSessionManager(session.AuthSessionToken);

            //    //if (false == MgrAuthSession.IsAuthSessionValid(session))
            //    //{
            //    //    throw new NgTsException(NgTsErrorCode.ErrAuthSessionExpired, StringRes.ErrAuthSessionExpired);
            //    //}
            //}
        }

        private NgTsUser _Session;
        public NgTsUser Session
        {
            get
            {
                if (_Session == null)
                {
                    _Session = null; //TODO need to be implmented if it is required HttpContext.Current.Session[ ] as NgTsUser;
                }
                return _Session;
            }
            set
            {
                _Session = value;
            }
        }






        #region Protected members

        protected T GetObject<T>(ref T value)
        where T : NgTsManager, new()
        {
            if (null == value)
            {
                value = new T();
                value.Session = Session;
            }

            return value;
        }

        private bool _bEnableSecurity = true;

        protected bool EnableSecurity
        {
            get
            {
                return _bEnableSecurity;
            }
            set
            {
                _bEnableSecurity = value;
            }
        }

        //private AuthSessionManager _MgrAuthSession;

        //protected AuthSessionManager MgrAuthSession
        //{
        //    get
        //    {
        //        return _MgrAuthSession;
        //    }
        //    private set
        //    {
        //        _MgrAuthSession = value;
        //    }
        //}

        //protected AuthSessionManager GetNewAuthSession(AuthSession session, AuthSessionTokenType? tokenType)
        //{
        //    MgrAuthSession = null; // AuthSessionManager.GetNewSession(session, tokenType);

        //    return MgrAuthSession;
        //}

        #endregion

        #region Static members

        static public T GetObject<T>(NgTsUser NgTsSes, ref T value)
            where T : NgTsManager, new()
        {
            if (null == value)
            {
                value = new T();
                NgTsManager NgTsMgr = value as NgTsManager;
                NgTsMgr.Session = NgTsSes;
            }

            return value;
        }

        #endregion

        #region Utility Methods

        protected List<T> GetEntityListByEntityIdList<T>(long[] entityIds, Func<string, List<T>> getterMethod)
        {
            return GetEntityListByEntityIdList(true, entityIds, getterMethod);
        }

        //
        // Summary:
        //     Gets the list of entities from database with the list of ids provided.
        //     This method is need as the SQL Varchar input paramter is restricted to
        //     4000 characters and the list neNgTs to be split and fetch the data.
        //
        // Parameters:
        //   entityIds:
        //     List of ids constructed as a long array which will be used to fetch the data
        //
        //   getterMethod:
        //     The getter method which has a string list as argument and will fetch the data
        //     from DB based on the list given as input.
        //
        // Returns:
        //     The list of entities retrieved from database.
        //
        // Exceptions:
        //   None
        protected List<T> GetEntityListByEntityIdList<T>(bool split, long[] entityIds, Func<string, List<T>> getterMethod)
        {
            List<T> entityList = new List<T>();
            StringBuilder ids = new StringBuilder();
            int fetchCount = 0;
            for (int i = 0; i < entityIds.Length; ++i)
            {
                ids.Append(entityIds[i] + ",");
                ++fetchCount;
                if (fetchCount > 190 && split)
                {
                    entityList.AddRange(getterMethod(ids.ToString()));
                    ids = new StringBuilder();
                    fetchCount = 0;
                }
            }
            if (fetchCount > 0)
            {
                entityList.AddRange(getterMethod(ids.ToString()));
            }
            return entityList;
        }

        protected void ExecuteInReadCommitedIsolation(Action operationsDelegate)
        {
            TransactionOptions opts = new System.Transactions.TransactionOptions();
            opts.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            using (NgTsTransactionScope tranScope = new NgTsTransactionScope(TransactionScopeOption.RequiresNew, opts))
            {
                operationsDelegate();
                tranScope.Complete();
            }
        }

        protected void ExecuteInReadUnCommitedIsolation(Action operationsDelegate)
        {
            TransactionOptions opts = new System.Transactions.TransactionOptions();
            opts.IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted;
            using (NgTsTransactionScope tranScope = new NgTsTransactionScope(TransactionScopeOption.RequiresNew, opts))
            {
                operationsDelegate();
                tranScope.Complete();
            }
        }

        #endregion

        #region Audit Trail

        //private ILogger _AuditTrailLogger;

        /// <summary>
        /// Records the audit trail.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="objectId">The object id.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="operationType">Type of the operation.</param>
        /// <param name="info">The info.</param>
        //public void RecordAuditTrail(string title, long objectId, AuditObjectType objectType, AuditOperationType operationType, String info)
        //{
        //    try
        //    {
        //        //AuditTrailLogEntry log = new AuditTrailLogEntry();
        //        //log.Title = title;
        //        //log.ObjectId = objectId;
        //        //log.AuditObjectType = (int)objectType;
        //        //log.AuditOperationType = (int)operationType;
        //        //log.Info = info;
        //        //this.RecordAuditTrail(log);
        //    }
        //    catch (Exception ex)
        //    {
        //        //NgTsDebugLog.AppServer.WriteError(ex, "Audit Trail Logging failed.");
        //    }

        //}

        /// <summary>
        /// Records the audit trial if it is enabled in the GSSettings.config (AppService_AuditTrailLoggingEnabled)
        /// </summary>
        /// <param name="log">The audit trail log entry.</param>
        //public void RecordAuditTrail(AuditTrailLogEntry log)
        //{
        //    if (GSSettings.AppServiceSettings.GetAppService_AuditTrailLoggingEnabled(false))
        //    {
        //        try
        //        {
        //            log.AuthSessionId = (MgrAuthSession != null) ? this.MgrAuthSession.AuthSession.AuthSessionId : 0;
        //            log.ImpersonatingMemberId = this.Session.ImpersonatingMemberId.HasValue ? this.Session.ImpersonatingMemberId.Value : 0;
        //            log.Time = DateTime.UtcNow;
        //            log.ContextId = this.Session.ContextOrgId;
        //            log.AuditContextType = (int)AuditContextType.Org;
        //            this._AuditTrailLogger.LogEntry(log);
        //        }
        //        catch (Exception ex)
        //        {
        //            NgTsDebugLog.AppServer.WriteError(ex, "Audit Trail Logging failed.");
        //        }
        //    }
        //}

        #endregion


    }
}