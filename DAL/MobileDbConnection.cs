using Microsoft.Data.SqlClient;
using System.Data;

namespace AkBrandMobile.DAL
{
    public class MobileDbConnection
    {
        private readonly string _connectionString;

        public MobileDbConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new ArgumentNullException("Connection string not found.");
        }

        public object[] ExecuteStoredProcedure(string storedProcedureName, Dictionary<string, object>? parameters, bool isDataRetrieval)
        {
            try
            {
                using SqlConnection conn = new(_connectionString);
                using SqlCommand cmd = new(storedProcedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                conn.Open();

                if (isDataRetrieval)
                {
                    using SqlDataReader reader = cmd.ExecuteReader();
                    return ProcessMultipleResultSets(reader); // ✅ Call the new function
                }
                else
                {
                    return new object[] { cmd.ExecuteNonQuery() }; // Return affected rows in an array
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing stored procedure", ex);
            }
        }

        private object[] ProcessMultipleResultSets(SqlDataReader reader)
        {
            List<object> resultSets = new();

            do
            {
                List<Dictionary<string, object>> rows = new();

                while (reader.Read())  // Manually iterate through the reader
                {
                    Dictionary<string, object> row = new();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader[i] == DBNull.Value ? null : reader[i];
                    }
                    rows.Add(row);
                }

                if (rows.Count > 0)  // Only add non-empty result sets
                {
                    resultSets.Add(rows);
                }

            }
            while (reader.NextResult());

            return resultSets.ToArray();
        }




        public int ExecuteStoredProcedureNonQuery(string storedProcedureName, Dictionary<string, object> parameters)
        {
            using SqlConnection conn = new SqlConnection(_connectionString);
            using SqlCommand cmd = new SqlCommand(storedProcedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            AddParameters(cmd, parameters);

            conn.Open();
            return cmd.ExecuteNonQuery(); // Returns number of affected rows
        }

        private static void AddParameters(SqlCommand cmd, Dictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                }
            }
        }

        private List<Dictionary<string, object>> DataTableToList(DataTable dataTable)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

            foreach (DataRow row in dataTable.Rows)
            {
                Dictionary<string, object> rowDict = new Dictionary<string, object>();

                foreach (DataColumn column in dataTable.Columns)
                {
                    rowDict[column.ColumnName] = row[column];
                }

                rows.Add(rowDict);
            }

            return rows;
        }


    }
}
