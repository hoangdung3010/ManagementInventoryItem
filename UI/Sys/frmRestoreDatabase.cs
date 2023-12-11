using MT.Data.Rep;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmRestoreDatabase : Form
    {
        #region Declare
        //Khai báo các biến trung gian
        private string sID_MaDonVi = "";
        private string sServerName = "";
        private string sDatabaseName = "";
        private string sUserID = "";
        private string sPass = "";
        int iCheDoXacThuc = 1;
        //
        #endregion
        public frmRestoreDatabase()
        {
            InitializeComponent();
            LoadDataForCombo();
        }
        /// <summary>
        /// Hàm đọc các tham số đã lưu trữ của hệ thống lên
        /// </summary>
        private void Init_ThamSo()
        {
            MT.Library.SessionData.Read();
            if(!String.IsNullOrEmpty(MT.Library.SessionData.DataBaseName))
            {
                sDatabaseName = MT.Library.SessionData.DataBaseName;
                sUserID = MT.Library.SessionData.UserData;
                sPass = MT.Library.SessionData.PassData;
                sServerName = MT.Library.SessionData.ServerName;
                /*sServerName = RB_AppSettings.Get("sServerName");
                sDatabaseName = RB_AppSettings.Get("sDatabase");
                sUserID = RB_AppSettings.Get("sUserID");
                sPass = RB_AppSettings.Get("sPass");*/

                //Đưa các giá trị vào Form
                cb_sServerName.Text = sServerName;
                tb_sDatabaseName.Text = sDatabaseName;
                tb_sUserID.Text = sUserID;
                tb_sPass.Text = sPass;
                //Đặt năm làm việc = năm hiện tại
                tb_iYear.Text = SysDateTime.Instance.Now().Year.ToString();
                cbCheDoXacThuc.SelectedValue = MT.Library.SessionData.iCheDoXacThuc;
            }                
        }
        private bool Check()
        {
            //
            if (Convert.ToString(cb_sServerName.SelectedValue) == "")
            {
                MessageBox.Show("Đồng chí chưa chọn máy chủ SQL");
                //
                return false;
            }
            //
            if (Convert.ToString(tb_sUserID.Text) == "")
            {
                MessageBox.Show("Đồng chí nhập tài khoản đăng nhập SQL");
                //
                return false;
            }
            ////
            //if (Convert.ToString(mte_sPassword_SQL.EditValue) == "")
            //{
            //    MMessage.ShowInfor("Đồng chí nhập mật khẩu đăng nhập SQL");
            //    //
            //    return false;
            //}
            //
            //
            if (Convert.ToString(tb_sDatabaseName.Text) == "")
            {
                MessageBox.Show("Đồng chí nhập tên cơ sở dữ liệu");
                //
                return false;
            }
            if (Convert.ToString(tb_sPath.Text) == "") 
            {
                MessageBox.Show("Đồng chí chưa chọn thư mục lưu trữ dữ liệu");
                //
                return false;
            }
            if (Convert.ToString(tb_sFile.Text) == "") 
            {
                MessageBox.Show("Đồng chí chưa chọn file dữ liệu (.bak) gốc để phục hồi");
                //
                return false;
            }
            //
            if (!IsExistsFolder(Convert.ToString(tb_sPath.Text)))
            {
                MessageBox.Show("Lỗi: Đường dẫn lưu trữ dữ liệu sau phục hồi không tồn tại");
                //
                return false;
            }
            if (!IsExistsFile(Convert.ToString(tb_sFile.Text)))
            {
                MessageBox.Show("Lỗi: Đường dẫn chứa file dữ liệu gốc để phục hồi không tồn tại");
                //
                return false;
            }
            //
            return true;
        }

        private void bt_sFile_Click(object sender, EventArgs e)
        {
            //
            OpenFileDialog oOFD = new OpenFileDialog();
            oOFD.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            oOFD.Filter = "bak files (*.bak)|*.bak";
            oOFD.FilterIndex = 2;
            oOFD.RestoreDirectory = true;

            if (oOFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    tb_sFile.Text = oOFD.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi trong quá trình chọn file, đồng chí chọn lại file (.bak)");
                }
            }
        }

        private void bt_sPath_Click(object sender, EventArgs e)
        {
            //Lấy thư mục lưu trữ
            //Chọn đường dẫn cất File
            FolderBrowserDialog oFBD = new FolderBrowserDialog();
            oFBD.SelectedPath = "c:\\";//co the lay duong dan tu file 
            oFBD.ShowNewFolderButton = true;
            if (oFBD.ShowDialog() == DialogResult.OK)
            {
                tb_sPath.Text = oFBD.SelectedPath;
            } 
        }

        private void bt_Run_Click(object sender, EventArgs e)
        {

            string ConnnectionString = "";
            try
            {
                if (this.cb_sServerName.SelectedValue.ToString() == "")
                {
                    MessageBox.Show("Chưa chọn máy chủ cơ sở dữ liệu SQL SERVER", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (this.tb_sFile.Text == "")
                {
                    MessageBox.Show("Chưa chọn file dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Thực sự muốn khôi phục dữ liệu. Nếu tiếp tục dữ liệu cũ sẽ bị đè ?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No) return;
                //
                bool mSucceful = true;
                int iCheDoXacThuc = int.Parse(cbCheDoXacThuc.SelectedValue.ToString());
                //
                if (mSucceful == true)
                {
                    //MessageBox.Show("Phục hồi dữ liệu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        //Kiểm tra mã đơn vị làm việc
                        //
                        //string vsID_MaDonVi = Convert.ToString(txtMaDV.Text).Trim();
                        //if (vsID_MaDonVi.Length < 2)
                        //{
                        //    MessageBox.Show("Lỗi. Mã đơn vị phải >= 2 kí tự");
                        //    //
                        //    txtMaDV.Focus();
                        //    //
                        //    return;
                        //}
                        //if (vsID_MaDonVi.Length % 2 != 0)
                        //{
                        //    MessageBox.Show("Lỗi. Mã đơn vị phải chẵn kí tự");
                        //    //
                        //    txtMaDV.Focus();
                        //    //
                        //    return;
                        //}
                        //Thực hiện sao lưu dữ liệu
                        string sServerName = Convert.ToString(cb_sServerName.Text);
                        string sUserID = Convert.ToString(tb_sUserID.Text);
                        string sPass = Convert.ToString(tb_sPass.Text);
                        string sDatabaseName = Convert.ToString(tb_sDatabaseName.Text);
                        //
                        string sPath = Convert.ToString(tb_sPath.Text);
                        string sFile = Convert.ToString(tb_sFile.Text);
                        //
                        bool bBool =MTLib.Utility.RestoreDatabase(sServerName, sUserID, sPass, sDatabaseName, sFile, sPath + "\\", iCheDoXacThuc);
                        if (bBool)
                        {
                            MessageBox.Show("Dữ liệu đã được phục hồi thành công vào thư mục :" + sPath + "; đ/c chạy lại chương trình");
                            //Lưu các tham số
                            MT.Library.SessionData.DataBaseName = this.sDatabaseName;
                            MT.Library.SessionData.UserData = this.sUserID;
                            MT.Library.SessionData.PassData = this.sPass;
                            MT.Library.SessionData.ServerName = this.sServerName;
                            MT.Library.SessionData.iCheDoXacThuc = this.iCheDoXacThuc;

                            MT.Library.SessionData.Save();
                           
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi trong quá trình phục hồi dữ liệu");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình phục hồi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #region Init giá trị các ComboBox
        private void AddToComboBox()
        {
            DataTable dt = new DataTable("Phamlai");
            dt.Columns.Add("iID", typeof(Int32));
            dt.Columns.Add("sTen", typeof(String));
            //
            DataRow dr = dt.NewRow();
            dr["iID"] = 1;
            dr["sTen"] = "Windows Authentication";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["iID"] = 2;
            dr["sTen"] = "SQL Server Authentication";
            dt.Rows.Add(dr);
            //
            cbCheDoXacThuc.Items.Clear();
            cbCheDoXacThuc.DisplayMember = "sTen";
            cbCheDoXacThuc.ValueMember = "iID";
            cbCheDoXacThuc.DataSource = dt;
        }
        private void LoadDataForCombo()
        {
            //Đưa chế độ xác thực vào
            AddToComboBox();

            //Nạp dữ liệu Database cho Server
            DataTable dtServer = getAll_SQLSERVER();
            //Thêm 1 dòng tạm thời vào
            //DataRow dr = dtServer.NewRow();
            //dr["sID"] = "123.30.236.5";
            //dr["sTen"] = "123.30.236.5";
            //dtServer.Rows.Add(dr);

            var dr = dtServer.NewRow();
            dr["sID"] = ".";
            dr["sTen"] = "localhost";
            dtServer.Rows.Add(dr);
            //Đưa vào tree
            cb_sServerName.DataSource = dtServer;
            cb_sServerName.DisplayMember = "sTen";
            cb_sServerName.ValueMember = "sID";
            cb_sServerName.SelectedValue = ".";
            //
            //Init_ThamSo();
        }
        #endregion
        #region Hàm sao lưu, phục hồi dữ liệu

        /// <summary>
        /// Hàm lấy về tất cả các máy chủ SQL cài trên máy tính
        /// </summary>
        /// Create by: laipv:15.05.2017
        private DataTable getAll_SQLSERVER()
        {
            //Lấy đưa vào bảng
            DataTable dt = new DataTable("SQL");
            dt.Columns.Add("sID", typeof(String));
            dt.Columns.Add("sTen", typeof(String));
            //
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController controller in services)
            {
                //MSSQLSERVER MSSQL$SQL2000  MSSQL$SQLEXPRESS
                if (controller.ServiceName.Contains("MSSQLSERVER"))
                {
                    DataRow dr = dt.NewRow();
                    dr["sID"] = Environment.MachineName;
                    dr["sTen"] = Environment.MachineName;
                    //
                    dt.Rows.Add(dr);
                }
                else if (controller.ServiceName.Contains("MSSQL$"))
                {
                    DataRow dr = dt.NewRow();
                    dr["sID"] = Environment.MachineName + @"\" + controller.ServiceName.Replace("MSSQL$", "");
                    dr["sTen"] = Environment.MachineName + @"\" + controller.ServiceName.Replace("MSSQL$", "");
                    //
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        #endregion
        #region Hàm liên quan tới Folder
        public static bool IsExistsFolder(string sFolder)
        {
            //
            if (!Directory.Exists(sFolder))
            {
                return false;
            }
            //
            return true;
        }
        public static bool IsExistsFile(string sFile)
        {
            //
            if (!File.Exists(sFile))
            {
                return false;
            }
            //
            return true;
        }
        #endregion

        private void frmRestoreDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                //LoadDataForCombo();
                
                //Đưa các tham số vào
               /* string[] sArgs = Environment.GetCommandLineArgs();
                if (sArgs.Length >= 7)
                {
                    sServerName = sArgs[1];
                    sUserID = sArgs[2];
                    sPass = sArgs[3];
                    sDatabaseName = sArgs[4];
                    iCheDoXacThuc = Convert.ToInt16(sArgs[5]);
                    sID_MaDonVi = sArgs[6];
                    //
                    //Đưa các giá trị vào Form
                    txtMaDV.Text = sID_MaDonVi;
                    cb_sServerName.SelectedValue = sServerName;
                    tb_sDatabaseName.Text = sDatabaseName;
                    tb_sUserID.Text = sUserID;
                    tb_sPass.Text = sPass;
                    cbCheDoXacThuc.SelectedValue = iCheDoXacThuc;
                }*/
                string p1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string filePath = @"Data\ManagementInventoryItem.bak";
                string combinedPath = Path.Combine(p1, filePath);
                tb_sFile.Text = combinedPath;

                Init_ThamSo();
                //MessageBox.Show(p1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Đưa mặc định vào

        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {
            //tb_sDatabaseName.Text = "XDQD_" + txtMaDV.Text.Trim() + "_" + tb_iYear.Text.Trim();
            //bt_Run.Enabled = (txtMaDV.Text != "");
        }

        private void tb_iYear_TextChanged(object sender, EventArgs e)
        {
            //tb_sDatabaseName.Text = "XDQD_" + txtMaDV.Text.Trim() + "_" + tb_iYear.Text.Trim();
            //bt_Run.Enabled = (txtMaDV.Text != "");
        }

        private void cbCheDoXacThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            iCheDoXacThuc = int.Parse(cbCheDoXacThuc.SelectedValue.ToString());
            if (iCheDoXacThuc == 1)// win
            {
                tb_sUserID.Enabled = false;
                tb_sPass.Enabled = false;
            }
            else
            {
                tb_sUserID.Enabled = true;
                tb_sPass.Enabled = true;
            }
        }
    }
}
