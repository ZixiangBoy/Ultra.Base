using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DataAccess.Util {
    public enum EnConnectionType : short {
        DataBaseAccount = 1,
        Integrated = 0,
        None = -1
    }

    public class SQLInstance {
        public string InstanceName { get; set; }
        public string IsClustered { get; set; }
        public string ServerName { get; set; }
        public string Version { get; set; }
    }

    public sealed class SQLInstanceEnumrator {
        public static List<SQLInstance> Enum() {
            var sqlinsLst = new List<SQLInstance>();
            try {
                var dt = SqlDataSourceEnumerator.Instance.GetDataSources();
                if ((dt == null) || (dt.Rows.Count < 1)) {
                    return null;
                }
                foreach (DataRow row in dt.Rows) {
                    SQLInstance item = new SQLInstance();
                    if (row.Table.Columns.Contains("ServerName")) {
                        item.ServerName = row["ServerName"].ToString();
                    }
                    if (row.Table.Columns.Contains("InstanceName")) {
                        item.InstanceName = row["InstanceName"].ToString();
                    }
                    if (row.Table.Columns.Contains("IsClustered")) {
                        item.IsClustered = row["IsClustered"].ToString();
                    }
                    if (row.Table.Columns.Contains("Version")) {
                        item.Version = row["Version"].ToString();
                    }
                    sqlinsLst.Add(item);
                }
            } catch (Exception ex) {
                throw ex;
            }
            return sqlinsLst;
        }
    }


    public sealed class SQLServerMeta {
        private static string SQL_GET_ALL_DATABASE = "SELECT Name FROM Master..SysDatabases ORDER BY Name";

        public List<string> GetAllDataBaseName() {
            var dbNameLst = new List<string>();
            try {
                if ((this.ConnStrCfg == null) || string.IsNullOrEmpty(ConnStrCfg.ConnectionString)) {
                    return null;
                }
                var table = SqlHelper.ExecuteDataTable(this.ConnStrCfg.ConnectionString, CommandType.Text, SQL_GET_ALL_DATABASE);
                if ((table == null) || (table.Rows.Count < 1)) {
                    return null;
                }
                foreach (DataRow row in table.Rows) {
                    dbNameLst.Add(row[0].ToString());
                }
            } catch (Exception ex) {
                throw ex;
            }
            return dbNameLst;
        }

        public SQLConnStringConfig ConnStrCfg { get; set; }
    }


    public class SQLConnStringConfig {
        private static SQLConnStringConfig _ins;
        private int maxPoolSize = 100;
        private int portNum = 1433;
        private SqlConnectionStringBuilder sqlconnbuldr;
        private int timeout = 15;

        public bool Async {
            get;
            set;
        }

        public string ConnectionString {
            get {
                return this.ConnStrBuilder.ConnectionString;
            }
        }

        public EnConnectionType ConnectionType {
            get;
            set;
        }

        public string DataBaseName { get; set; }

        public static SQLConnStringConfig Instance {
            get {
                _ins = _ins ?? new SQLConnStringConfig();
                return _ins;
            }
        }

        public int MaxPoolSize {
            get {
                return this.maxPoolSize;
            }
            set {
                this.maxPoolSize = value;
            }
        }

        public string PassWord { get; set; }

        public int PortNumber {
            get {
                return this.portNum;
            }
            set {
                this.portNum = value;
            }
        }

        public string ServerIP { get; set; }

        public int Timeout {
            get {
                return this.timeout;
            }
            set {
                this.timeout = value;
            }
        }

        public string UserName { get; set; }

        public bool TryConnect() {
            var result = false;
            using (SqlConnection connection = new SqlConnection(this.ConnectionString)) {
                try {
                    if (connection == null)
                        return false;
                    connection.Open();
                    result = connection.State == ConnectionState.Open;
                    connection.Close();
                } catch (SqlException) {
                    return false;
                } catch (Exception ex) {
                    throw ex;
                } finally {
                    if (connection.State == ConnectionState.Open) {
                        connection.Close();
                    }
                }
            }
            return result;
        }

        public SqlConnectionStringBuilder ConnStrBuilder {
            get {
                this.sqlconnbuldr = this.sqlconnbuldr ?? new SqlConnectionStringBuilder();
                this.sqlconnbuldr["Data Source"] = string.IsNullOrEmpty(this.ServerIP) ? "." : this.ServerIP;
                if (this.PortNumber != 1433) {
                    this.sqlconnbuldr["Data Source"] = string.Format("{0},{1}", this.sqlconnbuldr["Data Source"].ToString(), this.PortNumber.ToString());
                }
                this.sqlconnbuldr["DataBase"] = string.IsNullOrEmpty(this.DataBaseName) ? "master" : this.DataBaseName;
                this.sqlconnbuldr["Persist Security Info"] = false;
                this.sqlconnbuldr["Integrated Security"] = (this.ConnectionType == EnConnectionType.Integrated) ? "sspi" : ((this.ConnectionType == EnConnectionType.DataBaseAccount) ? "false" : "false");
                if (this.ConnectionType != EnConnectionType.Integrated) {
                    this.sqlconnbuldr["uid"] = string.IsNullOrEmpty(this.UserName) ? "sa" : this.UserName;
                    this.sqlconnbuldr["pwd"] = this.PassWord;
                }
                if (this.MaxPoolSize != 100) {
                    this.sqlconnbuldr["Max Pool Size"] = this.MaxPoolSize;
                }
                if (this.Timeout != 15) {
                    this.sqlconnbuldr["Connection Timeout"] = this.Timeout;
                }
                return this.sqlconnbuldr;
            }
        }

    }
}

