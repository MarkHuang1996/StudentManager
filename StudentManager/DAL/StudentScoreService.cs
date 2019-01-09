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
    public class StudentScoreService
    {
        /// <summary>
        /// get students scoreList by ClassName 
        /// </summary>
        /// <param name="ClassName"></param>
        /// <returns> a studentExt list </returns>
        public List<StudentExt> GetScoreListByName(string ClassName)
        {
            string sql = "select Students.StudentId,FirstName,LastName,ClassName,CSharp,SQLServer from Students  ";
            sql += "inner join StudentClass on StudentClass.ClassId = Students.ClassId ";
            sql += "inner join ScoreList on ScoreList.StudentId = Students.Studentid ";
            if (ClassName != null && ClassName.Length != 0)
            {
                sql += string.Format("where ClassName ='{0}' ", ClassName);
            }
            SqlDataReader reader = SQLHelper.GetReader(sql);
            List<StudentExt> list = new List<StudentExt>();
            while (reader.Read())
            {
                list.Add(new StudentExt()
                {

                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                    CSharp = Convert.ToInt32(reader["CSharp"]),
                    SQLServerDB = Convert.ToInt32(reader["SQLServer"])
                });
            }
            reader.Close();
            return list;
        }


        /// <summary>
        /// get socreInfo
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetScoreInfo(string ClassName)
        { 
            string sql = "select stuCount  = count(*) ,avgCSharp = avg(CSharp) , avgDb = avg(SQLServer) from ScoreList ";
            if (ClassName != null && ClassName.Length != 0)
            {
                sql += "inner join StudentClass on StudentClass.ClassId = Students.ClassId ";
                sql += "inner join ScoreList on ScoreList.StudentId = Students.Studentid ";
                sql += string.Format("where ClassName ='{0}' ", ClassName);
            }

            sql += "select absentCount = Count(*) from Students where StudentId not in (select StudentId  from ScoreList ) ";
            if (ClassName != null && ClassName.Length != 0)
            {
                sql += "inner join StudentClass on StudentClass.ClassId = Students.ClassId ";
                sql += "inner join ScoreList on ScoreList.StudentId = Students.Studentid ";
                sql += string.Format("where ClassName ='{0}' ", ClassName);
            }


            Dictionary<string, string> scoreInfo = null;
            SqlDataReader reder = SQLHelper.GetReader(sql);
            if (reder.Read())
            {
                scoreInfo = new Dictionary<string, string>();
                scoreInfo.Add("stuCount", reder["stuCount"].ToString());
                scoreInfo.Add("avgCSharp", reder["avgCSharp"].ToString());
                scoreInfo.Add("avgDb", reder["avgDb"].ToString());
            }
            if (reder.NextResult())
            {
                if (reder.Read())
                {
                    scoreInfo.Add("absentCount", reder["absentCount"].ToString());
                }
            }
            reder.Close();
            return scoreInfo;
        }

        /// <summary>
        /// get list of absent students
        /// </summary>
        /// <returns></returns>
        public List<string> GetAbsentList()
        {
            string sql = "select FirstName,LastName from Students where StudentId  not in (select StudentId from ScoreList )";
            SqlDataReader reader = SQLHelper.GetReader(sql);
            List<string> list = new List<string>();
            while (reader.Read())
            {
                list.Add(reader["FirstName"].ToString() + "  " + reader["LastName"].ToString());
            }
            reader.Close();
            return list;

        }

        #region DataSet
        public DataSet GetAllScoreList()
        {
            string sql = "select Students.StudentId,FirstName,LastName,ClassName,CSharp,SQLServer ";
            sql += "from Students ";
            sql += "inner join StudentClass on StudentClass.ClassId  = Students.ClassId ";
            sql += "inner join ScoreList on ScoreList.StudentId =  Students.StudentId";

            return SQLHelper.GetDataSet(sql);
        }

        #endregion
    }
}
