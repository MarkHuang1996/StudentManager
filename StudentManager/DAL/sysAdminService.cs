using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;


namespace DAL
{
    /// <summary>
    /// login by ID and pwd
    /// </summary>
   public class sysAdminService
    {
        public sysAdmin  AdminLogin(sysAdmin objAdmin )
        {
            string sql = "select AdminName from Admins where LoginId={0} and LoginPwd ='{1}'";
            sql = string.Format(sql, objAdmin.LoginId, objAdmin.LoginPwd);

            //quary
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            if (objReader.Read())
            {
                objAdmin.AdminName = objReader["AdminName"].ToString();
            }
            else
            {
                objAdmin = null;
            }
            objReader.Close();
            //retrun 
            return objAdmin;

        }
    }
}
