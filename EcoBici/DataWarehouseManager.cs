using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace EcoBici
{
    class DataWarehouseManager : IDisposable
    {
        private SqlConnection connection; 
        private const string dbSchemaName = "EcoBici";

        public DataWarehouseManager()
        {
            connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            connection.Open();
        }

        public int ExecuteIntFunction(string functionName, params SqlParameter[] parameters) {
            using (SqlCommand cmd = new SqlCommand(dbSchemaName + "." + functionName, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter result = new SqlParameter("@retorno", SqlDbType.Int);
                result.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);

                foreach (SqlParameter p in parameters)
                    cmd.Parameters.Add(p).Direction = ParameterDirection.Input;

                cmd.ExecuteNonQuery();
                return (int)result.Value;
            }
        }

        public int ExcuteIA(int estationId)
        {
            return ExecuteIntFunction("IA", new SqlParameter("@IdEstacion", estationId));
        }

        public void Close()
        {
            connection.Close();
        }
        public virtual void Dispose()
        {
            if (connection != null)
            {
                Close();
                connection.Dispose();
            }
        }
    }
}
