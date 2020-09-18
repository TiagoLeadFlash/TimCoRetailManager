using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDataManager.Library.Internal.DataAccess

{
    public class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T, U>(String storedprocedure, U parameters, string connectionsStringName)
        {
            string connectionsString = GetConnectionString(connectionsStringName);

            using (IDbConnection connection = new SqlConnection(connectionsString))
            {
                List<T> rows = connection.Query<T>(storedprocedure, parameters, 
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(String storedprocedure, T parameters, string connectionsStringName)
        {
            string connectionsString = GetConnectionString(connectionsStringName);

            using (IDbConnection connection = new SqlConnection(connectionsString))
            {
                connection.Execute(storedprocedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

    }
}
