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

        public void CreateTable_Log()
        {
            IDbCommand cmd = iConn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE if not exists tb_Log ('Id' INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                                   'Info' VARCHAR (256) DEFAULT (''), 
                                                                   'Price' FLOAT,
                                                                   'SellerId' INTEGER,  
                                                                   'Date' not null default (datetime('localtime')),  
                                                                   'Status' VARCHAR(32) DEFAULT(''),
                                                                   'SpecInfo' VARCHAR(1024));";
            cmd.ExecuteNonQuery();

            return ;
        }


        public void CreateTable_AddrBook()
        {
            IDbCommand cmd = iConn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE if not exists tb_AddrBook ('Id' INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                                        'Name' VARCHAR (32) , 
                                                                        'Addr' VARCHAR (256), 
                                                                        'AddrCode' VARCHAR(10), 
                                                                        'TelNumber' VARCHAR(20), 
                                                                        'Info1Title' VARCHAR(32), 
                                                                        'Info1' VARCHAR(256),   
                                                                        'Info2Title' VARCHAR(32), 
                                                                        'Info2' VARCHAR(256),  
                                                                        'Info3Title' VARCHAR(32), 
                                                                        'Info3' VARCHAR(256),  
                                                                        'Info4Title' VARCHAR(32), 
                                                                        'Info4' VARCHAR(256));";
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

            CreateTable_Log();
            CreateTable_AddrBook();
        }
    }
}
