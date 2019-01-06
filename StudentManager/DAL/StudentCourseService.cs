using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;



namespace DAL
{
    public class StudentCourseService
    {
        /// <summary>
        /// get all course objects
        /// </summary>
        /// <returns></returns>
        public List<StudentCourse> GetAllCourse()
        {
            string sql = "select * from StudentClass";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentCourse> list = new List<StudentCourse>();
            while (objReader.Read())
            {
                list.Add(new StudentCourse()
                {
                    ClassId = Convert.ToInt32(objReader["ClassId"]),
                    ClassName = objReader["ClassName"].ToString()
                });
            }
            objReader.Close();
            return list;


        }


    }
}
