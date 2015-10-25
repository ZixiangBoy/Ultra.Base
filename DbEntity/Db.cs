using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PetaPoco {
    public partial class Database {
        public Database() {
            string connectionString = string.Empty;
            try {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbconstr"].ConnectionString;
            } catch (Exception) {
                throw;
            }
            _connectionString = connectionString;
            //_providerName = true ? "System.Data.SqlClient" : "MySql.Data.MySqlClient";
            _providerName = "System.Data.SqlClient";
            CommonConstruct();
        }


        public DataTable ExecuteDataTable(string sql, params object[] args) {
            DataTable dt = new DataTable();
            OpenSharedConnection();
            try {
                using (var cmd = CreateCommand(_sharedConnection, sql, args)) {
                    using (DbDataAdapter dbDataAdapter = _factory.CreateDataAdapter()) {
                        dbDataAdapter.SelectCommand = (DbCommand)cmd;
                        dbDataAdapter.Fill(dt);
                        return dt;
                    }
                }
            } catch (Exception x) {
                OnException(x);
                throw;
            } finally {
                CloseSharedConnection();
            }
        }

        public void Insert<T>(List<T> objs) {
            objs.ForEach(k => Insert(k));
        }

    }
}
