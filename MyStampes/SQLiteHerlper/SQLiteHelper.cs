using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStampes.SQLiteHerlper
{
    public class SQLiteHelper
    {
        private static SQLiteConnection iConn;
         
        
        public void CreateDataBase()
        {
            string dbFilename = @"MyStampes.db";
            string cs = string.Format( "Version=3;uri=file:{0}", dbFilename);

            if( iConn == null )
            {
                iConn = new SQLiteConnection(cs);
            }

            if( iConn.State != ConnectionState.Open )
                iConn.Open();

            return;
        }

        public void CloseDataBase()
        {
            iConn.Close();
            return;
        }

        public void CreateTable_Info()
        {
            IDbCommand cmd = iConn.CreateCommand();
            cmd.CommandText = "CREATE TABLE if not exists tb_Info (\"index\" INTEGER PRIMARY KEY AUTOINCREMENT, info VARCHAR (128) DEFAULT (''), sellerId INTEGER,  purchaseData not null default (datetime(\'localtime\')),  sellerInfo VARCHAR(64) DEFAULT (''), progress INTEGER DEFAULT(0),  progressInfo VARCHAR(32) DEFAULT(''));";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "CREATE TABLE if not exists tb_InfoExt (\"index\" INTEGER PRIMARY KEY AUTOINCREMENT, info VARCHAR (128), infoId INTEGER);";
            cmd.ExecuteNonQuery();
            return ;
        }


        public void CreateTable_AddrBook()
        {
            IDbCommand cmd = iConn.CreateCommand();
            cmd.CommandText = "CREATE TABLE if not exists tb_AddrBook (\"index\" INTEGER PRIMARY KEY AUTOINCREMENT, name VARCHAR (32) , addr VARCHAR (256), addressCode VARCHAR(10), tel VARCHAR(20), info1Title INTEGER DEFAULT (0), info1 VARCHAR(256) DEFAULT(''),   info2Title INTEGER DEFAULT (0), info2 VARCHAR(256) DEFAULT(''),  info3Title INTEGER DEFAULT (0), info3 VARCHAR(256) DEFAULT(''),  info4Title INTEGER DEFAULT (0), info4 VARCHAR(256) DEFAULT(''));";
            cmd.ExecuteNonQuery();


            cmd.CommandText = "CREATE TABLE if not exists tb_AddrBookExt (\"index\" INTEGER PRIMARY KEY AUTOINCREMENT, info VARCHAR (128) , sellerId VARCH (64), startTime timestamp not null default (datetime(\'now\',\'localtime\')), logExistsMaxTime VARCHAR(64) DEFAULT ('') );";
            cmd.ExecuteNonQuery();
            return ;
        }

        static public SQLiteHelper Instance
        {
            get
            {
                return iInstance;
            }
           
        }

        private static SQLiteHelper iInstance = new SQLiteHelper();

        public void InitDB()
        {
            CreateDataBase();

            CreateTable_Info();
            CreateTable_AddrBook();
        }
    }
}
