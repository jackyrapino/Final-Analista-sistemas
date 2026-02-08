using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Tools
{
    internal static class SqlHelper
    {
        private const string DefaultConnectionName = "ManagerAuth";

        /// <summary>
        /// Obtiene la cadena de conexión desde App.config por nombre.
        /// </summary>
        private static string GetConnectionString(string connectionName)
        {
            var cs = ConfigurationManager.ConnectionStrings[connectionName];
            if (cs == null)
                throw new ConfigurationErrorsException($"Connection string '{connectionName}' not found in configuration.");
            return cs.ConnectionString;
        }

        /// <summary>
        /// Convierte parámetros nulos en DBNull.Value.
        /// </summary>
        private static void CheckNullables(SqlParameter[] parameters)
        {
            if (parameters == null) return;
            foreach (SqlParameter item in parameters)
            {
                if (item.SqlValue == null)
                {
                    item.SqlValue = DBNull.Value;
                }
            }
        }

        // New signature: explicit connection name
        public static int ExecuteNonQuery(
            string connectionName,
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            CheckNullables(parameters);
            string conString = GetConnectionString(connectionName);

            using (SqlConnection conn = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Backwards-compatible overload: default connection
        public static int ExecuteNonQuery(
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            return ExecuteNonQuery(DefaultConnectionName, commandText, commandType, parameters);
        }

        public static object ExecuteScalar(
            string connectionName,
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            CheckNullables(parameters);
            string conString = GetConnectionString(connectionName);

            using (SqlConnection conn = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        // Backwards-compatible overload
        public static object ExecuteScalar(
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            return ExecuteScalar(DefaultConnectionName, commandText, commandType, parameters);
        }

        public static SqlDataReader ExecuteReader(
            string connectionName,
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            CheckNullables(parameters);
            string conString = GetConnectionString(connectionName);
            SqlConnection conn = new SqlConnection(conString);

            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = commandType;
            if (parameters != null && parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);

            conn.Open();
            // When using CommandBehavior.CloseConnection, the connection will be closed when the 
            // IDataReader is closed.
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }

        // Backwards-compatible overload
        public static SqlDataReader ExecuteReader(
            string commandText,
            CommandType commandType,
            params SqlParameter[] parameters)
        {
            return ExecuteReader(DefaultConnectionName, commandText, commandType, parameters);
        }
    }
}
