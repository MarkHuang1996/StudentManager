using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;
using System.Data.SqlClient;

namespace StudentManager
{
  
    public partial class FrmScoreManage : Form
    {
        private string className;
        private StudentCourseService objStudentCourseService = new StudentCourseService();
        private StudentScoreService objStudentScoreService = new StudentScoreService();
        public FrmScoreManage()
        {
            InitializeComponent();
            this.cboClass.DataSource = objStudentCourseService.GetAllCourse();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember ="ClassId";
            this.cboClass.SelectedIndex = -1;
          
        }

        private void FrmScoreManage_Load(object sender, EventArgs e)
        {

        }

        private void btnStat_Click(object sender, EventArgs e)
        {

            this.gbStat.Text = "All Student Exam Info";
            className = "";
            writeTheList(className);
            

           


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboClass.SelectedIndex != -1)
            {
              
                className = this.cboClass.Text.Trim();
                writeTheList(className);
            }

           
        }

        private void writeTheList(string className)
        {
            this.dgvScoreList.AutoGenerateColumns = false;
            this.dgvScoreList.DataSource = objStudentScoreService.GetScoreListByName(className);
            Dictionary<string, string> dic = objStudentScoreService.GetScoreInfo();
            this.lblAttendCount.Text = dic["stuCount"];
            this.lblCSharpAvg.Text = dic["avgCSharp"];
            this.lblDBAvg.Text = dic["avgDb"];
            this.lblCount.Text = dic["absentCount"];

            //absent Student Name
            List<string> lis = objStudentScoreService.GetAbsentList();
            this.lblList.Items.Clear();
            this.lblList.Items.AddRange(lis.ToArray());
        }
    }
    
}
