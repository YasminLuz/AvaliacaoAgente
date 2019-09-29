using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProvaRecrutamento.DAO
{
    public class SQLConnection
    {
        private static SqlConnection connect;
        private static String connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["db_recrutamento"].ConnectionString;

        public static void conectar()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(connectionStr);
                connect = conn;
            }
            catch (SqlException ex)
            {
                throw ex;
            }


            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }


        public static void desconectar()
        {

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connectionStr);
                connect = conn;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public static SqlConnection statusConexao()
        {
            return connect;
        }


    }
}
