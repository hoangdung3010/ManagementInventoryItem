using MT.Library.Log;
using MTControl;
using System;
using System.Data;
using System.ServiceProcess;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmConfigSQL : FormUI.FormUIBase
    {
        private string login;
        private string pass;
        private string dbname;
        private string server;
        int iCheDoXacThuc = 2;
        public frmConfigSQL()
        {
            InitializeComponent();
            Init();
        }

        #region"Sub/Func"
        public void Init()
        {
            try
            {
                //Đưa chế độ xác thực vào
                AddToComboBox();
                // Load danh sách Server
                DataTable dtServer = getAll_SQLSERVER();
                var dr = dtServer.NewRow();
                dr["sID"] = ".";
                dr["sTen"] = "localhost";
                dtServer.Rows.Add(dr);
                //Đưa vào tree
                cbServer.DataSource = dtServer;
                cbServer.DisplayMember = "sTen";
                cbServer.ValueMember = "sID";
                cbServer.SelectedValue = ".";

                //MT.Library.SessionData.Read();
                //cbServer.Text = MT.Library.SessionData.ServerName;
                //this.txtDatabase.Text = MT.Library.SessionData.DataBaseName;
                //this.txtLogin.Text = MT.Library.SessionData.UserData;
                //this.txtPassword.Text = MT.Library.SessionData.PassData;
                //this.cbServer.Text = MT.Library.SessionData.ServerName;
                //cbCheDoXacThuc.SelectedValue = MT.Library.SessionData.iCheDoXacThuc;
                //if (String.IsNullOrEmpty(this.cbServer.Text))
                //{
                //    this.cbServer.Text = @".\SQLEXPRESS";
                //}
                AcceptButton = btnSave;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public void SetValue()
        {
            this.login = (this.txtLogin.Text.Trim() != "") ? MT.Library.Utility.AddChar(this.txtLogin.Text.Trim()) : "";
            this.pass = (this.txtPassword.Text.Trim() != "") ? MT.Library.Utility.AddChar(this.txtPassword.Text.Trim()) : "";
            this.server = (this.cbServer.Text.Trim() != "") ? MT.Library.Utility.AddChar(this.cbServer.Text.Trim()) : "";
            this.dbname = (this.txtDatabase.Text.Trim() != "") ? MT.Library.Utility.AddChar(this.txtDatabase.Text.Trim()) : "";
        }
        #endregion


        private void pic_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
            MT.Library.SessionData.Save();
        }
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
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetValue();
                string connectionString = MTLib.Utility.ConnectionString(this.dbname, this.login, this.pass, this.server, iCheDoXacThuc);
                using (MT.Data.DBContext context = new MT.Data.DBContext(connectionString))
                {
                    if (context.IsConnect())
                    {
                        MMessage.ShowInfor("Kết nối th\x00e0nh c\x00f4ng");
                    }
                    else
                    {
                        MMessage.ShowError("C\x00f3 lỗi khi kết nối, kiểm tra lại t\x00ean m\x00e1y chủ, Người d\x00f9ng, mật khẩu v\x00e0 t\x00ean cơ sở dữ liệu");
                    }
                }
                    

            }
            catch (Exception ex)
            {
                MMessage.ShowError("C\x00f3 lỗi khi kết nối, kiểm tra lại t\x00ean m\x00e1y chủ, Người d\x00f9ng, mật khẩu v\x00e0 t\x00ean cơ sở dữ liệu");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetValue();
                string connectionString = MTLib.Utility.ConnectionString(this.dbname, this.login, this.pass, this.server, iCheDoXacThuc);
                using (MT.Data.DBContext context = new MT.Data.DBContext(connectionString))
                {
                    if (context.IsConnect())
                    {
                        LogHelper.AddEvent(this.UUID, "Thiết lập kết nối cơ sở dữ liệu");
                        MT.Library.SessionData.DataBaseName = this.dbname;
                        MT.Library.SessionData.UserData = this.login;
                        MT.Library.SessionData.PassData = this.pass;
                        MT.Library.SessionData.ServerName = this.server;
                        MT.Library.SessionData.iCheDoXacThuc = this.iCheDoXacThuc;
                        MT.Library.SessionData.ConnectString = connectionString;
                        MT.Library.SessionData.Save();
                        
                        MMessage.ShowInfor("Lưu thành công");
                    }
                }

            }
            catch (Exception ex)
            {
                MMessage.ShowError("C\x00f3 lỗi khi kết nối, kiểm tra lại t\x00ean m\x00e1y chủ, Người d\x00f9ng, mật khẩu v\x00e0 t\x00ean cơ sở dữ liệu");
            }
        }

        private void frmConfigSQL_Load(object sender, EventArgs e)
        {
            MT.Library.SessionData.Read();
            //cbServer.Text = MT.Library.SessionData.ServerName;
            this.txtDatabase.Text = MT.Library.SessionData.DataBaseName;
            this.txtLogin.Text = MT.Library.SessionData.UserData;
            this.txtPassword.Text = MT.Library.SessionData.PassData;
            this.cbServer.Text = MT.Library.SessionData.ServerName;
            cbCheDoXacThuc.SelectedValue = MT.Library.SessionData.iCheDoXacThuc;
            if (String.IsNullOrEmpty(this.cbServer.Text))
            {
                this.cbServer.Text = @".\SQLEXPRESS";
            }
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);

            
        }

        private void frmConfigSQL_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.UpdateEvent(this.UUID);
            this.Dispose();
        }

        private void btnInitDatabase_Click(object sender, EventArgs e)
        {
            frmRestoreDatabase FrmInitDataBase = new frmRestoreDatabase();
            FrmInitDataBase.ShowDialog();
        }

        private void cbCheDoXacThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            iCheDoXacThuc = int.Parse(cbCheDoXacThuc.SelectedValue.ToString());
            if (iCheDoXacThuc==1)// win
            {
                txtLogin.Enabled = false;
                txtPassword.Enabled = false;
            }    
            else
            {
                txtLogin.Enabled = true;
                txtPassword.Enabled = true;
            }    
        }
    }
}
