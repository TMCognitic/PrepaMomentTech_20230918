using System.Data;
using System.Reflection;

namespace Tools.Connections
{
    public static class Database
    {
        public static int ExecuteNonQuery(this IDbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            using (IDbCommand command = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                return command.ExecuteNonQuery();
            }
        }

        public static object? ExecuteScalar(this IDbConnection dbConnection, string query, bool isStoredProcedure = false, object? parameters = null)
        {
            using (IDbCommand command = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                object? result = command.ExecuteScalar();
                return result is DBNull ? null : result;
            }
        }

        public static IEnumerable<TResult> ExecuteReader<TResult>(this IDbConnection dbConnection, string query, Func<IDataRecord, TResult> mapper, bool isStoredProcedure = false, object? parameters = null)
        {
            ArgumentNullException.ThrowIfNull(mapper);
            using (IDbCommand command = CreateCommand(dbConnection, query, isStoredProcedure, parameters))
            {
                using(IDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        yield return mapper(reader);
                    }
                }
            }
        }

        private static void EnsureValidConnection(IDbConnection dbConnection)
        {
            ArgumentNullException.ThrowIfNull(dbConnection, nameof(dbConnection));

            if (dbConnection.State is not ConnectionState.Open)
                throw new InvalidOperationException("The connection must be open for execute a request");
        }

        private static IDbCommand CreateCommand(IDbConnection dbConnection, string query, bool isStoredProcedure, object? parameters = null)
        {
            EnsureValidConnection(dbConnection);

            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;

            if(isStoredProcedure)
                dbCommand.CommandType = CommandType.StoredProcedure;
            
            if(parameters is not null)
            {
                Type type = parameters.GetType();

                IEnumerable<PropertyInfo> properties = type.GetProperties().Where(p => p.CanRead);

                foreach(PropertyInfo propertyInfo in properties)
                {
                    IDataParameter parameter = dbCommand.CreateParameter();
                    parameter.ParameterName = propertyInfo.Name;
                    parameter.Value = propertyInfo.GetValue(parameters, null) ?? DBNull.Value;

                    dbCommand.Parameters.Add(parameter);
                }
            }

            return dbCommand;
        }
    }
}
