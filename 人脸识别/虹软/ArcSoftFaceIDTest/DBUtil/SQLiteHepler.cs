using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace DBUtil
{
    public class SQLiteHepler
    {
        private const string connString = @"Data Source=DBFile\AfcSoftFaceTest.db;";

        private static void SetDBType()
        {
            Dapper.SimpleCRUD.SetDialect(Dapper.SimpleCRUD.Dialect.SQLite);
        }

        static SQLiteHepler()
        {
            SetDBType();
        }

        //public static IDbConnection Conn
        //{
        //    get { return new IDbConnection(connString); }
        //}
    }
}
