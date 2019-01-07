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
    public class StudentService
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

        public List<StudentExt> GetStudentByCourse(string Course)
        {
            string sql = "select StudentId,FirstName,LastName,Birthday,Gender,ClassName from Students";
            sql += "  inner join StudentClass on Students.Classid = StudentClass.ClassId ";
            sql += "where ClassName = '{0}'";
            sql = string.Format(sql, Course);
            SqlDataReader reader = SQLHelper.GetReader(sql);
            List<StudentExt> list = new List<StudentExt>();
            while (reader.Read())
            {
                list.Add(new StudentExt()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    FirstName = reader["FirstName"].ToString(),

                    LastName = reader["LastName"].ToString(),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    Gender = reader["Gender"].ToString(),
                    ClassName = reader["ClassName"].ToString()

                });
            }
            reader.Close();
            return list;
        }

        public StudentExt GetStudentByStudentId(int StudentId)
        {
            string sql = " select StudentId,FirstName,LastName,Birthday,Gender,ClassName,StudentAddress,PhoneNumber  from Students ";
            sql += "inner join StudentClass on Students.Classid = StudentClass.ClassId ";
            sql += "where StudentId = {0} ";
            sql = string.Format(sql, StudentId);
            SqlDataReader reader = SQLHelper.GetReader(sql);
            StudentExt objStudentExt = null;

            if (reader.Read())
            {
                objStudentExt = new StudentExt()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    FirstName = reader["FirstName"].ToString(),

                    LastName = reader["LastName"].ToString(),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    Gender = reader["Gender"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Address = reader["StudentAddress"].ToString(),
                    ClassName = reader["ClassName"].ToString()
                };
            }
            reader.Close();
            return objStudentExt;
                

        }

        public int ModifyStudent(Student objStudent)
        {
            StringBuilder sqlbuilder = new StringBuilder();
            sqlbuilder.Append("Update Students set FirstName = '{0}',LastName = '{1}',Gender='{2}',Birthday='{3}',");
            sqlbuilder.Append("Age ={4},PhoneNumber = '{5}',StudentAddress='{6}',ClassId={7} ");
            sqlbuilder.Append("where StudentId ={8}");
            string sql = string.Format(sqlbuilder.ToString(), objStudent.FirstName,
              objStudent.LastName, objStudent.Gender,  objStudent.Birthday, objStudent.Age, objStudent.PhoneNumber,
              objStudent.Address, objStudent.ClassId,objStudent.StudentId);
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public int DeleteStudentByID(int StudetnId)
        {
            string sql = "delete from Students where StudentId ={0}";
            sql = string.Format(sql, StudetnId);
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if(ex.Number  == 547)
                {
                    throw new Exception("this student is used  by other database ,cant direct delete");
                }
                throw;
                
            }
            catch(Exception ex)
            {
                throw;
            }
        }




    }
}