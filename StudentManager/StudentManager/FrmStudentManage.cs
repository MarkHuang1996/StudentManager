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
    public partial class FrmStudentManage : Form
    {
        private StudentCourseService objStudentCourseService = new StudentCourseService();
        private StudentService objStudentService = new StudentService();
        public FrmStudentManage()
        {
            InitializeComponent();
            this.cboClass.DataSource = objStudentCourseService.GetAllCourse();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.SelectedIndex = -1;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dgvStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnEidt_Click(object sender, EventArgs e)
        {

        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmStudentManage_Load(object sender, EventArgs e)
        {

        }

        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            if (cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Course");
                return;
            }
            this.dgvStudentList.AutoGenerateColumns = false;
            this.dgvStudentList.DataSource = objStudentService.GetStudentByCourse(this.cboClass.Text);

        }

        private void btnQueryById_Click(object sender, EventArgs e)
        {
            if (this.txtStudentId.Text.Length == 0)
            {
                MessageBox.Show("Please entry the StudentID");
                this.txtStudentId.Focus();
                return;
            }


            StudentExt objStudentExt = objStudentService.GetStudentByStudentId(Convert.ToInt32(this.txtStudentId.Text.Trim()));

            if (objStudentExt == null)
            {
                MessageBox.Show("This studentd not exist !");
                this.txtStudentId.Focus();
                return;
            }
            else
            {
                FrmStudentInfo objFrmStudentInfo = new FrmStudentInfo(objStudentExt);
                objFrmStudentInfo.Show();

            }
        }

        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && this.txtStudentId.Text.Trim().Length != 0)
            {
                btnQueryById_Click(null, null);// be used for smail database

            };
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEidt_Click_1(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                MessageBox.Show("Nothing should be edit");
                return;

            }
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("Please select a setudnet to edit");
                return;
            }
            //get StudentId
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            //GET Info of the student
            StudentExt objStudentExt = objStudentService.GetStudentByStudentId(Convert.ToInt32(studentId));
            //call editfrom
            FrmEditStudent objEditStudent = new FrmEditStudent(objStudentExt);
            DialogResult result = objEditStudent.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnQuery_Click_1(null, null);
            }

        }

        private void tsmiModifyStu_Click(object sender, EventArgs e)
        {
            btnEidt_Click_1(null, null);
        }

        private void tsmidDeleteStu_Click(object sender, EventArgs e)
        {
            btnDel_Click_1(null, null);
        }

        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dgvStudentList.CurrentRow != null)
            {
               this.txtStudentId.Text = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
                btnQueryById_Click(null, null);
            }
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0)
            {
                MessageBox.Show("Nothing should be delete");
                return;

            }
            if (this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("Please select a studnet to delete" +
                    "");
                return;
            }

            int StudentId = Convert.ToInt32(this.dgvStudentList.CurrentRow.Cells["StudentId"].Value);
            try
            {
                if(objStudentService.DeleteStudentByID(StudentId) == 1)
                {
                    btnQuery_Click_1(null, null);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
