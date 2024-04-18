using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietPlanner.DAO.dbutil
{
    //Class to be used as a database connector

    internal class DBUtil
    {
        private static SQLiteConnection conn;
 
        public static SQLiteConnection OpenConnection()
        {
            string connectionString = "Data source=DietPlanner.db;Version=3;";
            conn = new SQLiteConnection(connectionString);
            conn.Open();
            return conn;
        }

        public static void CloseConnection()
        {
            try { 
                if (conn!= null) conn.Close();
            } catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


    }

    
}  