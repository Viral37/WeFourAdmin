using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Shreeman.Models
{
    public class SQLHelper
    {
        public static SqlConnection GetSqlConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static void CloseSqlConnection(SqlConnection connection)
        {
            connection.Close();
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] commandParameters)
        {
            int affectedRows = 0;
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    command.Parameters.AddRange(commandParameters);
                    affectedRows = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return affectedRows;
        }

        public DataSet ExecuteQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var connection = GetSqlConnection())
            {
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandTimeout = 0;
                    DataSet ds = new DataSet();
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                    connection.Close();
                    return ds;
                }
            }
        }

        public void ExecuteSP(string SPName, SqlParameter[] objSqlPar, ref string strErrorMsg)
        {

            using (var connection = GetSqlConnection())
            {
                SqlCommand SQLCmd = SetCmdProperties(SPName, CommandType.StoredProcedure, objSqlPar, connection);

                #region Data Execution Process

                try
                {
                    SQLCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // ************************ Rollback Transaction **************************************
                    strErrorMsg = ex.Message.ToString();
                }
                finally
                {
                    
                    SQLCmd.Dispose();
                }
            }
            #endregion
        }

        #region Set Command Property
        public SqlCommand SetCmdProperties(string strStoredProcedureName, CommandType objCommandType, SqlParameter[] objSqlParm, SqlConnection connection)
        {
           
                SqlCommand cmdToExecute = new SqlCommand();
                cmdToExecute.CommandText = strStoredProcedureName;
                cmdToExecute.CommandType = objCommandType;
                if (objSqlParm != null)
                {
                    cmdToExecute.Parameters.AddRange(objSqlParm);
                }
                cmdToExecute.Connection = connection;
                cmdToExecute.CommandTimeout = 60;
                return cmdToExecute;
            
        }
        #endregion

        #region Get Scalar value
        public object GetScalarValue(string strSQL)
        {
            using (var connection = GetSqlConnection())
            {
                SqlCommand objSQMComm = new SqlCommand(strSQL, connection);

                try
                {
                    object objScalarVal = objSQMComm.ExecuteScalar();
                    objSQMComm.Dispose();
                    return objScalarVal;
                }
                catch (Exception Ex)
                {
                    if (objSQMComm != null)
                    {
                        objSQMComm.Dispose();
                        objSQMComm = null;
                    }
                    throw Ex;
                }
            }
        }

        public object GetScalarValue(string strSQL, SqlParameter[] objSqlPar)
        {
            using (var connection = GetSqlConnection())
            {
                SqlCommand objSQMComm = SetCmdProperties(strSQL, CommandType.StoredProcedure, objSqlPar,connection);

                try
                {
                    object objScalarVal = objSQMComm.ExecuteScalar();
                    objSQMComm.Dispose();
                    return objScalarVal;
                }
                catch (Exception Ex)
                {
                    if (objSQMComm != null)
                    {
                        objSQMComm.Dispose();
                        objSQMComm = null;
                    }
                    throw Ex;
                }
            }
              
        }

        #endregion
   

        public void ExecuteSPOutParameter(ref SqlCommand SQLcmd, string SPName, SqlParameter[] objSqlPar, ref string strErrorMsg)
        {
            using (var connection = GetSqlConnection())
            {

                SQLcmd = SetCmdProperties(SPName, CommandType.StoredProcedure, objSqlPar, connection);

                #region Data Execution Process

                try
                {
                    SQLcmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // ************************ Rollback Transaction **************************************
                    strErrorMsg = ex.Message.ToString();
                }
                finally
                {
                    SQLcmd.Dispose();
                }
                #endregion
            }
        }
    }
}