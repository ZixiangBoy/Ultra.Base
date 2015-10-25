using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace Ultra.Web.Core.Common
{
    [Serializable]
    public class SqlAsyncExecuter 
    {
        private string _connstr = string.Empty;

        public string ConnectionString
        {
            get { return _connstr; }
            set { _connstr = value; }
        }

        public SqlAsyncExecuter() : base() { }

        public SqlAsyncExecuter(string con)
            : base()
        {
            ConnectionString = con;
            OpenAsyncProcess();
        }

        private void OpenAsyncProcess()
        {
            SqlConnectionStringBuilder cb=new SqlConnectionStringBuilder(ConnectionString);
            if(!cb.AsynchronousProcessing)
            {
                cb.AsynchronousProcessing=true;
                ConnectionString=cb.ConnectionString;
            }
        }
        
        public event EventHandler<SqlAsyncExecuteResultArg> OnExecuteCompleted;

        /// <summary>
        /// 异步执行SQL
        /// </summary>
        /// <param name="sql"></param>
        public void Execute(string sql)
        {
            if (string.IsNullOrEmpty(sql)) return;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.BeginExecuteReader(new AsyncCallback((arg) =>
            {
                if (null != this.OnExecuteCompleted && arg.IsCompleted)
                    this.OnExecuteCompleted(this, new SqlAsyncExecuteResultArg
                    {
                        AsyncResult = arg
                    });
            }), null,System.Data.CommandBehavior.CloseConnection);
            
        }

        /// <summary>
        /// 异步执行SQL
        /// </summary>
        /// <param name="sqlFilePath"></param>
        public void ExecuteSqlFile(string sqlFilePath)
        {
            if (!File.Exists(sqlFilePath)) return;
            var sql = File.ReadAllText(sqlFilePath);
            if (string.IsNullOrEmpty(sql)) return;
            Execute(sql);
        }
    }

    public class SqlAsyncExecuteResultArg : EventArgs
    {
        public IAsyncResult AsyncResult { get; set; }

        public object Extra { get; set; }
    }
}
