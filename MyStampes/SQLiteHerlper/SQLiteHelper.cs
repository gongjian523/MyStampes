using MyStampes.ViewModel;
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
        public static SQLiteHelper Instance
        {
            get
            {
                return iInstance;
            }

        }

        public void InitDB()
        {
            CreateTable_Log();
            CreateTable_AddrBook();
        }


        public void CreateTable_Log()
        {
            string commandText = @"CREATE TABLE if not exists tb_Log ('Id' INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                                   'Info' VARCHAR (256) DEFAULT (''), 
                                                                   'Price' FLOAT,
                                                                   'SellerId' INTEGER,  
                                                                   'Date' not null default (datetime('localtime')),  
                                                                   'Status' VARCHAR(32) DEFAULT(''),
                                                                   'SpecInfo' VARCHAR(1024));";
            ExecuteNonQuery(commandText);
            return;
        }


        public void CreateTable_AddrBook()
        {
            string commandText = @"CREATE TABLE if not exists tb_AddrBook ('Id' INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                                        'Name' VARCHAR (32) , 
                                                                        'Location' VARCHAR (32),
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
            ExecuteNonQuery(commandText);
            return;
        }

        public int InsertNewAddressItem(AddressItem addr)
        {
            string commandText = string.Format(@"INSERT INTO tb_AddrBook (Name, Location, Addr, AddrCode, TelNumber, Info1Title, Info1, 
                                                Info2Title, Info2, Info3Title, Info3, Info4Title, Info4) VALUES 
                                                ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", 
                                                addr.Name, addr.Location, addr.Addr, addr.AddrCode, addr.TelNumber, addr.Info1Title, addr.Info1,
                                                addr.Info2Title, addr.Info2, addr.Info3Title, addr.Info3, addr.Info4Tite, addr.Info4);
            
            if (!ExecuteNonQuery(commandText))
                return 0;


            return LastInsertRowId();
        }

        private int LastInsertRowId()
        {
            return Convert.ToInt16(ExecuteScalar("SELECT last_insert_rowid();"));
        }


        public List<AddressItem> GetAllAddress()
        {
            List<AddressItem> addrList = new List<AddressItem>();
            IDataReader data = ExecuteReader(@"SELECT * FROM tb_AddrBook");

            if (data == null)
                return addrList;


            while(data.Read())
            {
                AddressItem addr = new AddressItem();

                addr.Name = data["Name"].ToString();
                addr.Addr = data["Addr"].ToString();
                addr.AddrCode = data["AddrCode"].ToString();
                addr.TelNumber = data["TelNumber"].ToString();
                addr.Info1Title = data["Info1Title"].ToString();
                addr.Info1 = data["Info1"].ToString();
                addr.Info2Title = data["Info2Title"].ToString();
                addr.Info2 = data["Info2"].ToString();
                addr.Info3Title = data["Info3Title"].ToString();
                addr.Info1 = data["Info3"].ToString();
                addr.Info2Title = data["Info4Title"].ToString();
                addr.Info2 = data["Info4"].ToString();

                addrList.Add(addr);
            }

            return addrList;  
        }

        static private SQLiteHelper iInstance = new SQLiteHelper();
        private SQLiteConnection iConn;

        private SQLiteConnection SQLConnection
        {
            get
            {
                if( iConn == null )
                {
                    string dbFilename = @"MyStampes.db";
                    string cs = string.Format("Version=3;uri=file:{0}", dbFilename);

                    iConn = new SQLiteConnection(cs);
                }

                if( iConn.State != ConnectionState.Open )
                {
                    iConn.Open();
                }
                return iConn;
            }
        }

        public void CloseDataBase(SQLiteConnection iConn)
        {
            iConn.Close();
            return;
        }

        private bool ExecuteNonQuery(string sql)
        {
            SQLiteConnection _sqlConn = SQLConnection;

            bool ret = true;
            IDbCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandText = sql;
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                ret = false;
            }

            return ret;
        }


        private object ExecuteScalar(string sql)
        {
            SQLiteConnection _sqlConn = SQLConnection;

            object obj;

            IDbCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandText = sql;

            try
            {
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                return null;
            }

            return obj;
        }


        private IDataReader ExecuteReader(string sql)
        {
            SQLiteConnection _sqlConn = SQLConnection;

            IDataReader data;

            IDbCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandText = sql;

            try
            {
                data = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                return null;
            }

            return data;
        }
    }
}
