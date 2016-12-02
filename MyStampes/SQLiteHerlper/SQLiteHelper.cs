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

        public void CreateTable(string table)
        {
            bool retVal;
            return ;
        }


    }
}
