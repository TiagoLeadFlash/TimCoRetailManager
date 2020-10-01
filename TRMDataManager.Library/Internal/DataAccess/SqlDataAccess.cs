using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace TRMDataManager.Library.Internal.DataAccess

{
    public class SqlDataAccess:IDisposable
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
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public void StartTransaction(string connectionsStringName)
        {
            string connectionsString = GetConnectionString(connectionsStringName);

            _connection = new SqlConnection(connectionsString);

            _connection.Open();

            _transaction = _connection.BeginTransaction();


        }
        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();
        }


        public void Dispose()
        {
            CommitTransaction();

        }

        public void SaveDataInTransaction<T>(String storedprocedure, T parameters)
        {
                _connection.Execute(storedprocedure, parameters,
                    commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public List<T> LoadDataInTransaction<T, U>(String storedprocedure, U parameters)
        {

            List<T> rows = _connection.Query<T>(storedprocedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

            return rows;
        }

        //Open connect/start transaction method
        //load using the transaction
        //save using the transaction
        //close connectiion/top transaction method
        //dispose
    }
}
