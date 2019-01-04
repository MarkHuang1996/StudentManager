using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmUserLogin objFrmLogin = new FrmUserLogin();
            DialogResult result = objFrmLogin.ShowDialog();

            //判断是否成功
            if (result == DialogResult.OK)
            {
                Application.Run(new FrmMain());

            }
            else
            {
                Application.Exit();

            }
        }

        //
        public static Models.sysAdmin objCurrentAdmin = null;

    }
}


