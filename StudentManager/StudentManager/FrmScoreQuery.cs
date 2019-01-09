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
using System.Data.SqlClient;


namespace StudentManager
{
    public partial class FrmScoreQuery : Form
    {
        private StudentScoreService objStudentScoreService = new StudentScoreService();
        private StudentCourseService objStudentCourseService = new StudentCourseService();
        private DataTable dtScoreList = null;
        public FrmScoreQuery()
        {
            InitializeComponent();
            DataTable dt = objStudentCourseService.GetAllClass().Tables[0];
            this.cboClass.DataSource = dt;
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.DisplayMember = "ClassName";


            //Show all score at start 
            dtScoreList = objStudentScoreService.GetAllScoreList().Tables[0];

            this.dgvScoreList.DataSource = dtScoreList; //

        }

        private void FrmScoreQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMain.objFrmScoreQuery = null;
        }

        private void FrmScoreQuery_Load(object sender, EventArgs e)
        {

        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtScoreList == null) return;
            this.dtScoreList.DefaultView.RowFilter = string.Format("ClassName = '{0}'", this.cboClass.Text.Trim());
  
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (dtScoreList == null) return;
            this.dtScoreList.DefaultView.RowFilter = string.Format("ClassName like '%%'");
        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            if (dtScoreList == null) return;
            if (this.txtScore.Text.Trim().Length == 0) return;
            this.dtScoreList.DefaultView.RowFilter = string.Format("CSharp>{0}", this.txtScore.Text.Trim());
        }
    }
}
