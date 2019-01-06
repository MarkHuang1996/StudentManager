using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
  public  class StudentService
    {
        #region ADD student Object 
        /// <summary>
        /// valiate the Idnumber is unit;
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        //public bool isIdNoExisted(string studentId)
        //{
        //    string sql = "select count(*) from Students where StudentIdNo={0}";
        //    sql = string.Format(sql, studentIdNo);
        //    int resutl = Convert.ToInt32(SQLHelper.GetSingelResult(sql));
        //    if (resutl == 1) return true;
        //    else return false;
        //}


        public int AddStudent(Student objStudent)
        {

            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.Append("insert into Students(FirstName,LastName,Gender,Birthday,Age,PhoneNumber,StudentAddress,Classid)");
            sqlbuilder.Append(" values('{0}','{1}','{2}','{3}',{4},'{5}','{6}',{7})");
            //解析对象
            string sql = string.Format(sqlbuilder.ToString(), objStudent.FirstName,
                objStudent.LastName, objStudent.Gender, objStudent.Birthday, objStudent.Age, objStudent.PhoneNumber, 
                objStudent.Address, objStudent.ClassId);

            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                throw new Exception("database action error " + ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception("error");
            }
        }
        #endregion
    }
}
