
namespace Loreal.Eds.DataAccess.Generic
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Text;
    using System.Data.Common;
    using System.Data;
    using Loreal.Eds.Common;
   

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class EdsGeneric
    {
        private string databaseName;
        private Database db;
        public EdsGeneric()
        {
            //this.db = DatabaseFactory.CreateDatabase(EdsConfig.DefaultDatabaseConnection );
            this.db = new DatabaseProviderFactory().Create(EdsConfig.DefaultDatabaseConnection);
        }
        public EdsGeneric(string databaseName)
        {

            this.databaseName = databaseName;
            this.db = DatabaseFactory.CreateDatabase(databaseName);

        }
        public int ExecuteNonQuery(string storedProcedureName, List<EdsSqlParameterData> parameters)
        {
            using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
            {
                //ToDo Timeout should be parameterized later.
                command.CommandTimeout = 600;
                getParameter(command, parameters);
                return (db.ExecuteNonQuery(command));
            }
            //return (command.ExecuteNonQuery((storedProcedureName,parameters));
        }
        public int ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
        {
                return (db.ExecuteNonQuery(storedProcedureName, parameterValues));
        }

        
        public object EdsExecuteScalar(string storedProcedureName, List<EdsSqlParameterData> parameters)
        {
            using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
            {

                getParameter(command, parameters);
                return (db.ExecuteScalar(command));
            }
        }
        public string EdsExecuteScalar(string storedProcedureName, object[] parameters)
        {
            var retStr = "";
            using (IDataReader rdr = db.ExecuteReader(storedProcedureName, parameters))
            {
                var hasRecord = rdr.Read();
                if (hasRecord)
                    retStr = rdr[0].ToString();
                rdr.Close();
            }
            return retStr;
        }

        public byte[] GetImageByte(string storedProcedureName, object[] parameters)
        {
            byte[] retImges=  null; 
            using (IDataReader rdr = db.ExecuteReader(storedProcedureName, parameters))
            {
                var hasRecord = rdr.Read();
                if (hasRecord)
                    retImges = (byte[]) rdr[0];
                rdr.Close();
            }
            return retImges;
        }



        public string EdsExecuteScalar(string query, CommandType commandType )
        {
            var retStr = "";
            using (IDataReader rdr = db.ExecuteReader(commandType, query ))
            {
                var hasRecord = rdr.Read();
                if (hasRecord)
                    retStr = rdr[0].ToString();
                rdr.Close();
            }
            return retStr;
        }
        public List<object[]> GetObject(
           string query, CommandType commandType )
        {
            List<object[]> results = new List<object[]>();
                using (IDataReader rdr = db.ExecuteReader (commandType,  query  ))
                {
                    while (rdr.Read())
                    {
                        object[] objs = new object[rdr.GetSchemaTable().Columns.Count];
                        rdr.GetValues(objs);
                        results.Add(objs);
                    }
                
            }
            return results;
        }

        public List<object[]> GetObject(
           string storedProcedureName, List<EdsSqlParameterData> parameters)
        {
            List<object[]> results = new List<object[]>();

            using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
            {
                //ToDo Timeout should be parameterized later.
                command.CommandTimeout = 600;
                getParameter(command, parameters);
                using (IDataReader rdr = db.ExecuteReader(command))
                {
                    while (rdr.Read())
                    {
                        object[] objs = new object[rdr.GetSchemaTable().Columns.Count];
                        rdr.GetValues(objs);
                        results.Add(objs);
                    }
                }
            }
            return results;
        }


        public List<object[]> GetObject(string storedProcName)
        {

            List<object[]> results = new List<object[]>();

            using (DbCommand command = db.GetStoredProcCommand(storedProcName))
            {
                //ToDo Timeout should be parameterized later.
                command.CommandTimeout = 600;

                using (IDataReader rdr = db.ExecuteReader(command))
                {
                    while (rdr.Read())
                    {
                        object[] objs = new object[rdr.GetSchemaTable().Columns.Count];
                        rdr.GetValues(objs);
                        results.Add(objs);
                    }
                }
            }
            return results;
        }
        
        public DataTable GetDataTable(string query, CommandType type)
        {

            DataTable dt = new DataTable();

            using (IDataReader rdr = db.ExecuteReader(type, query))
            {
                List<DataColumn> listCols = new List<DataColumn>();
                DataTable dtSchema = rdr.GetSchemaTable();
                if (dtSchema != null)
                {
                    foreach (DataRow drow in dtSchema.Rows)
                    {
                        string columnName = System.Convert.ToString(drow["ColumnName"]);
                        DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                        column.Unique = (bool)drow["IsUnique"];
                        //column.AllowDBNull = (bool)drow["AllowDBNull"];
                        column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                        listCols.Add(column);
                        dt.Columns.Add(column);
                    }
                }
                while (rdr.Read())
                {

                    DataRow dataRow = dt.NewRow();
                    for (int i = 0; i < listCols.Count; i++)
                    {
                        dataRow[((DataColumn)listCols[i])] = rdr[i];

                    }
                    dt.Rows.Add(dataRow);

                }

            }

            return dt;


        }
        public DataTable GetDataTable(string storedProcedureName, object[] param)
        {

            DataTable dt = new DataTable();
          
            using (IDataReader rdr = db.ExecuteReader(storedProcedureName, param))
            {
                List<DataColumn> listCols = new List<DataColumn>();
                DataTable dtSchema = rdr.GetSchemaTable();
                if (dtSchema != null)
                {
                    foreach (DataRow drow in dtSchema.Rows)
                    {
                        string columnName = System.Convert.ToString(drow["ColumnName"]);
                        DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                        column.Unique = (bool)drow["IsUnique"];
                        //column.AllowDBNull = (bool)drow["AllowDBNull"];
                        column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                        listCols.Add(column);
                        dt.Columns.Add(column);
                    }
                }
                while (rdr.Read())
                {

                    DataRow dataRow = dt.NewRow();
                    for (int i = 0; i < listCols.Count; i++)
                    {
                        dataRow[((DataColumn)listCols[i])] = rdr[i];

                    }
                    dt.Rows.Add(dataRow);

                }

            }

            return dt;


        }


        public DataTable GetDataTable(string storedProcedureName, List<EdsSqlParameterData> parameters)
        {

            using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
            {
                //ToDo Timeout should be parameterized later.
                command.CommandTimeout = 600;
                getParameter(command, parameters);

                DataSet dataSet = db.ExecuteDataSet(command);
                DataTable table = dataSet.Tables.Count > 0 ?  dataSet.Tables[0] : null;
                if (table != null)
                {
                    IDataReader reader = table.CreateDataReader();
                    foreach (EdsSqlParameterData param in parameters)
                    {
                        if (!param.IsIn)
                        {
                            param.Value = db.GetParameterValue(command, param.SqlParameterName);
                        }
                    }
                }
                return table;
                
            }

            
        }
        public DataTableCollection GetDataTables(string storedProcedureName, List<EdsSqlParameterData> parameters)
        {

            using (DbCommand command = db.GetStoredProcCommand(storedProcedureName))
            {
                //ToDo Timeout should be parameterized later.
                command.CommandTimeout = 600;
                getParameter(command, parameters);

                DataSet dataSet = db.ExecuteDataSet(command);
                DataTableCollection tables = dataSet.Tables.Count > 0 ? dataSet.Tables : null;
                if (tables != null && tables[0] !=null)
                {
                    IDataReader reader = tables[0].CreateDataReader();
                    foreach (EdsSqlParameterData param in parameters)
                    {
                        if (!param.IsIn)
                        {
                            param.Value = db.GetParameterValue(command, param.SqlParameterName);
                        }
                    }
                }
                return tables;
            }
        }

        public DataTableCollection GetDataTables(string storedProcedureName, object[] param)
        {

            using (DbCommand command = db.GetStoredProcCommand(storedProcedureName, param))
            {
                //ToDo Timeout should be parameterized later.
                command.CommandTimeout = 600;
                

                DataSet dataSet = db.ExecuteDataSet(command);
                DataTableCollection tables = dataSet.Tables.Count > 0 ? dataSet.Tables : null;
                
                return tables;
            }
        }


       
        public DataTable GetDataTable(string storedProcedureName, object[] param, int timeout)
        {

            DataTable dt = new DataTable();
            DbCommand command = db.GetStoredProcCommand(storedProcedureName, param);
            command.CommandTimeout = timeout;
            using (IDataReader rdr = db.ExecuteReader(command))
            {
                List<DataColumn> listCols = new List<DataColumn>();
                DataTable dtSchema = rdr.GetSchemaTable();
                if (dtSchema != null)
                {
                    foreach (DataRow drow in dtSchema.Rows)
                    {
                        string columnName = System.Convert.ToString(drow["ColumnName"]);
                        DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                        column.Unique = (bool)drow["IsUnique"];
                        //column.AllowDBNull = (bool)drow["AllowDBNull"];
                        column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                        listCols.Add(column);
                        dt.Columns.Add(column);
                    }
                }
                while (rdr.Read())
                {

                    DataRow dataRow = dt.NewRow();
                    for (int i = 0; i < listCols.Count; i++)
                    {
                        dataRow[((DataColumn)listCols[i])] = rdr[i];

                    }
                    dt.Rows.Add(dataRow);

                }

            }

            return dt;


        }


        private string GetJsonSerialized(IDataReader rdr)
        {
            StringBuilder sb = new StringBuilder();
            DataTable schemaTable = rdr.GetSchemaTable();

            sb.Append(@"[");

            {
                int rowIdx = 0;

                while (rdr.Read())
                {

                    sb.Append("{");
                    int idx = 0;
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        sb.Append(string.Format(@"""{0}"":""{1}""{2}", ((string)row[0]).Replace(" ", "_"),
                            rdr[(string)row[0]], idx < schemaTable.Rows.Count - 1 ? "," : ""));
                        idx++;
                    }
                    sb.Append("},");
                }
            }

            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");
                return sb.ToString();
            }
            else
                return "";
        }
        public string GetJson(string storedProcedureName, object[] param)
        {

            var retStr = "";
            using (IDataReader rdr = db.ExecuteReader(storedProcedureName, param))
            {
                retStr = GetJsonSerialized(rdr);

            }
            return retStr;
        }


        public string GetJson(string query, CommandType type)
        {

            var retStr = "";
            using (IDataReader rdr = db.ExecuteReader(type, query))
            {
                retStr = GetJsonSerialized(rdr);
            }
            return retStr;
        }
        public int ExecuteNonQuery(string query, CommandType type)
        {

            return (db.ExecuteNonQuery(type, query));

        }




        private void getParameter(DbCommand command, List<EdsSqlParameterData> parameters)
        {
            //ToDo Timeout should be parameterized later.
            command.CommandTimeout = 600;
            foreach (EdsSqlParameterData p in parameters)
            {
                if (p.IsIn == true)
                    db.AddInParameter(command, p.SqlParameterName, GetSqlDataType(p.SqlDataType), p.Value);
                else
                    db.AddOutParameter(command, p.SqlParameterName, GetSqlDataType(p.SqlDataType), p.Size);
                
            }
        }

        private DbType GetSqlDataType(string type)
        {
            if (type == "DbType.Int64" || type == "Int64" || type.ToUpper() == "BIGINT")
                return DbType.Int64;
            else if (type == "DbType.Int32" || type == "Int32")
                return DbType.Int32;
            else if (type == "DbType.Date" || type == "Date")
                return DbType.Date;
            else if (type == "DbType.DateTime" || type == "DateTime")
                return DbType.DateTime;

            else
                return DbType.String;
            
        }
        public byte[] GetBinData(string fName)
        {
            byte[] ImageData;
            FileStream fs = new FileStream(fName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            return ImageData;

        }

    }




}
