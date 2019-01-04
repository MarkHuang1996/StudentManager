using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;// references the app.config file


namespace DAL
{
    public class SQLHelper
    {

        //public static string connString = "Server=.;Database=StudentManageDB;Uid=sa;Pwd=huangrui";
       
       private static string connString = DESEncrypt.DesDecrypt( ConfigurationManager.ConnectionStrings["connString"].ToString());


        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                //error massage write into log.txt

                throw ex;
            }
            finally
            {
                conn.Close();
            }
         
        }
        public static object GetSingelResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
                 
        }
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
               SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
