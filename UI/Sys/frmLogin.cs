using MT.Data.Rep;
using MT.Library;
using MT.Library.UW;
using MTControl;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using VGCACrypto;

namespace FormUI
{
    public partial class frmLogin : FormUI.FormUIBase
    {
        string Email = "";
        public frmLogin()
        {
            InitializeComponent();
            this.txtMatkhau.Text = "";
            this.txtDangnhap.Text =MT.Library.SessionData.UserName;
            this.Program = "Màn hình đăng nhập";
            Email = "";


        }

        private void pic_Exit_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception exception)
            {
                CommonFnUI.ShowError(exception, this.Program);
            }
        }
        public string getEmailFromUSBToken()
        {
            //string Email = "";
            VGCACrypto.Authorization.SetKey("TTBNNVFUQkJNakV0UWtJd05DMDBPVFJHTFRnMU1qZ3RNVVk0UkRsQk1EZzVPRFkyZkRZek56QTRNVFU1TXpVNU5EUTVPREU1Tnc9PXxkalZVQUNUbFdQbGZOS3RYOElsLzN1Vi84d1lYVldONk12eXA2Mjg4eXA5TmZhWVFXOHBlbVlQUTlIUGZNdk9oSXNCdWJwc0duMEZSMVM2cDhsbDEwSjI3bjcwajhLM1hzcmdKa1FYdmpHVDJSaDB6SkRteHF1Q24wNVVzQzJnSW14OG1tSGRoQjFaYjNGTHpNNFl4VEdlVXphd2FhNmZGZUp0WlFHc28ydENQZGpOQndxYVdEUmhDdGEvSGZhM3dCclJpbGZqMjkrTjRMNFg3dzVNYys3TzhNSkJTM3pDM3NqbnRzRzNUR0REUlkyaWp1bU1ucGsxOGl6MWZ4TEc3N0JlVW5Jc3FYeXN1cU9VY2JnT1J3RUE4cEVnKytaZjB5bEkyTlRuMGtSMkMwUStQU1I2OFoveXcxeGhhMzkwL3JzQm4rWVlhekUzQm5HMFpHdjlEZmc9PQ==");

            //Bước 1: Ký & Xác thực chữ ký ~ Authentication
            X509Certificate2Collection keyStore = new X509Certificate2Collection();
            X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            int num = 0;
            foreach (var cert in store.Certificates)
            {
                CertInfo ii = new CertInfo(cert);
                if ((ii.KeyUsages & X509KeyUsageFlags.NonRepudiation) != X509KeyUsageFlags.None)
                {
                    keyStore.Add(cert);
                    num++;
                }
            }
            if(num == 0)
            {
                MessageBox.Show("Bạn chưa cắm USB Token!");
                return "";
            }    
            //keyStore.AddRange(store.Certificates);
            store.Close();

            //Chung thu so nguoi ky
            X509Certificate2 signer = null;

            // [1] Chon chung thu so
            try
            {
                X509Certificate2Collection xCollection = X509Certificate2UI.SelectFromCollection(keyStore, "Chứng thư số ký", "Chọn chứng thư số ký", X509SelectionFlag.SingleSelection);
                if (xCollection != null && xCollection.Count > 0)
                {
                    signer = xCollection[0];
                }
                else
                {
                    //MessageBox.Show("Chưa chọn Chứng thư số ký");
                    return "";
                }    
                
                //Console.WriteLine(signer.Subject);
            }
            catch (Exception ex){ MessageBox.Show(SessionData.ERROR); ; }

            //Mã session phần mềm tự sinh
            byte[] sessionCode = Encoding.UTF8.GetBytes(@"qwr{@^h`h&_`50/ja9!'dcmh3!uw<&=?");

            try
            {
                VGCACrypto.PKCS7 p7 = new VGCACrypto.PKCS7(sessionCode, signer, "SHA256");
                p7.Sign("", true);

                //String signature = Convert.ToBase64String(p7.Signature);
                p7 = new VGCACrypto.PKCS7(sessionCode, p7.Signature, true);
                p7.Verify();

                CertInfo ci = new CertInfo(p7.Certificate.RawData);

                //String ChuKySoStatus = String.Format("OK: {0}, {1}", ci.ToString(), p7.SigningTime.Value.ToLocalTime().ToString());
                //Console.WriteLine(ChuKySoStatus);

                //Bước 2: Authorization
                //Lấy email mapping với user của phần mềm để phân quyền....
                Email = ci.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show(SessionData.ERROR);
            }

            return Email;
        }
        private void loginWithUSB_FIRST()
        {
            try
            {
                // Truong Added 2021
                if (Email == "")
                {
                    Email = getEmailFromUSBToken();
                }

                if (Email != "")
                {
                    string str = Email;// MT.Library.Utility.AddChar(Email.Trim());
                    //string strToEncrypt = MT.Library.Utility.AddChar(this.txtMatkhau.Text.ToString().Trim());
                    if (!DBContext.IsConnect())
                    {
                        MMessage.ShowInfor("Bạn chưa thiết lập Cơ sở dữ liệu!");
                        //frmConfigSQL frm = new frmConfigSQL();
                        //frm.ShowDialog();
                        return;
                    }
                    SysUserRepository sysUserRepository = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
                    var sysUser = sysUserRepository.LoginWithUSB(str);

                    // Truong Added 2021
                    if (sysUser != null && !sysUser.Id.Equals(Guid.Empty))
                    {
                        MT.Library.SessionData.UserId = sysUser.Id;
                        MT.Library.SessionData.UserName = sysUser.UserName.Trim();
                        MT.Library.SessionData.FullName = sysUser.FullName.Trim();
                        MT.Library.SessionData.RoleId = sysUser.RoleId.Value;
                        MT.Library.SessionData.OrganizationUnitId = sysUser.OrganizationUnitId.Value;
                        MT.Library.SessionData.OrganizationUnitCode = sysUser.OrganizationUnitCode;
                        MT.Library.SessionData.OrganizationUnitName = sysUser.OrganizationUnitName;
                        DBOptionRepository dBOptionRepository = (DBOptionRepository)DBContext.GetRep<DBOptionRepository>();
                        var dbOption= dBOptionRepository.GetDBOptionByOptionId(MT.Data.ConstantDBOption.MSC_OrganizationUnitType);
                        SetOrganizationUnitType();
                        SetResource();
                        //Lay ve quyen cua use
                        MT.Library.SessionData.RolePermissions = sysUserRepository.GetRolePermissionsByUser();
                        this.Hide();
                        this.Close();
                        using (frmMain frm = new frmMain())
                        {

                            frm.ShowDialog();
                            //frm.BringToFront();
                            frm.Dispose();
                        }
                        return;
                    }
                    else
                        MMessage.ShowWarning(MT.Library.CommonKey.MsgLoginNotExistsUSB);
                    //MMessage.ShowWarning(MT.Library.CommonKey.MsgLoginNotExists);
                    Email = "";
                    this.txtDangnhap.Text = "";
                    this.txtMatkhau.Text = "";
                    this.txtDangnhap.Enabled = false;
                    this.txtMatkhau.Enabled = false;
                    //this.ActiveControl = this.txtDangnhap;
                }


            }
            catch (Exception exception)
            {
                CommonFnUI.ShowError(exception, this.Program);
                /*frmConfigSQL frm = new frmConfigSQL();
                frm.ShowDialog();*/
            }
        }

        /// <summary>
        /// Lậy về Hệ CSDL 
        /// </summary>
        void SetOrganizationUnitType()
        {
            DBOptionRepository dBOptionRepository = (DBOptionRepository)DBContext.GetRep<DBOptionRepository>();
            var dbOption = dBOptionRepository.GetDBOptionByOptionId(MT.Data.ConstantDBOption.MSC_OrganizationUnitType);
            int organizationUnitType = 0;

            int.TryParse(dbOption?.OptionValue, out organizationUnitType);

            MT.Library.SessionData.OrganizationUnitType = organizationUnitType > 0 ? organizationUnitType : (int)MT.Data.OrganizationUnitType.BCY;

        }

        /// <summary>
        /// Lấy về thông tin resource
        /// </summary>
        void SetResource()
        {
            using (IUnitOfWork ofWork=new UnitOfWork(MT.Library.SessionData.ConnectString))
            {
                string query = "SELECT Name,Description FROM Resources";

                var resources = ofWork.Query<MT.Data.BO.Resources>(query);

                if (resources?.Count > 0)
                {
                    foreach (var item in resources)
                    {
                        MT.Library.SessionData.Resources.TryAdd(item.Name.ToLower(), item.Description);
                    }
                }
            }
        }
        private void  loginWithUSB()
        {
            try
            {
                // Truong Added 2021
                //string Email = getEmailFromUSBToken();
                if(Email=="")
                {
                    Email = getEmailFromUSBToken();
                }
                string str = MT.Library.Utility.AddChar(this.txtDangnhap.Text.ToString().Trim());
                string strToEncrypt = MT.Library.Utility.AddChar(this.txtMatkhau.Text.ToString().Trim());
                if ((str == ""))
                {
                    MMessage.ShowWarning(MT.Library.CommonKey.MsgLoginFailure);
                }
                else
                {
                    SysUserRepository sysUserRepository = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
                    var sysUser = sysUserRepository.Login(str, strToEncrypt);

                    // Truong Added 2021
                    if (sysUser == null)
                    {
                        MMessage.ShowWarning(MT.Library.CommonKey.MsgLoginNotExists);
                    }
                    else if (sysUser != null && sysUser.UserName != Email)
                    {
                        MessageBox.Show("Thông tin đăng ký trong CSDL và trong USB Token không trùng khớp!");
                        return;
                    }
                    else if (sysUser != null && !sysUser.Id.Equals(Guid.Empty))
                    {
                        MT.Library.SessionData.UserId = sysUser.Id;
                        MT.Library.SessionData.UserName = sysUser.UserName.Trim();
                        MT.Library.SessionData.FullName = sysUser.FullName.Trim();
                        MT.Library.SessionData.RoleId = sysUser.RoleId.Value;
                        MT.Library.SessionData.OrganizationUnitId = sysUser.OrganizationUnitId.Value;
                        MT.Library.SessionData.OrganizationUnitCode = sysUser.OrganizationUnitCode;
                        MT.Library.SessionData.OrganizationUnitName = sysUser.OrganizationUnitName;
                        //Lay ve quyen cua use
                        MT.Library.SessionData.RolePermissions = sysUserRepository.GetRolePermissionsByUser();
                        SetOrganizationUnitType();
                        SetResource();
                        this.Close();
                        using (frmMain frm = new frmMain())
                        {
                            frm.ShowDialog();
                            frm.Dispose();
                        }
                        return;
                    }
                    //MMessage.ShowWarning(MT.Library.CommonKey.MsgLoginNotExists);
                }
                this.txtDangnhap.Text = "";
                //this.txtMatkhau.Text = "";
                this.ActiveControl = this.txtDangnhap;
            }
            catch (Exception exception)
            {
                CommonFnUI.ShowError(exception, this.Program);
            }
        }
        private void loginWithouthUSB()
        {
            try
            {
                string str = MT.Library.Utility.AddChar(this.txtDangnhap.Text.ToString().Trim());
                string strToEncrypt = MT.Library.Utility.AddChar(this.txtMatkhau.Text.ToString().Trim());
                if ((str == "") || (strToEncrypt == ""))
                {
                    MMessage.ShowWarning(MT.Library.CommonKey.MsgLoginFailure);
                }
                else
                {
                    SysUserRepository sysUserRepository = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
                    var sysUser = sysUserRepository.Login(str, strToEncrypt);

                    if (sysUser != null && !sysUser.Id.Equals(Guid.Empty))
                    {
                        MT.Library.SessionData.UserId = sysUser.Id;
                        MT.Library.SessionData.UserName = sysUser.UserName.Trim();
                        MT.Library.SessionData.FullName = sysUser.FullName.Trim();
                        MT.Library.SessionData.RoleId = sysUser.RoleId.Value;
                        MT.Library.SessionData.OrganizationUnitId = sysUser.OrganizationUnitId.Value;
                        MT.Library.SessionData.OrganizationUnitCode = sysUser.OrganizationUnitCode;
                        MT.Library.SessionData.OrganizationUnitName = sysUser.OrganizationUnitName;
                        //Lay ve quyen cua use
                        MT.Library.SessionData.RolePermissions = sysUserRepository.GetRolePermissionsByUser();

                        SetOrganizationUnitType();
                        SetResource();
                        this.Hide();
                        this.Close();
                        using (frmMain frm = new frmMain())
                        {
                            frm.ShowDialog();
                            frm.Dispose();
                        }
                        return;
                    }
                    MMessage.ShowWarning(MT.Library.CommonKey.MsgLoginNotExists);
                }
                this.txtDangnhap.Text = "";
                //this.txtMatkhau.Text = "";
                this.ActiveControl = this.txtDangnhap;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
//CommonFnUI.ShowError(exception, this.Program);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //loginWithouthUSB();
#if (DEBUG)
            loginWithouthUSB();
#else
            loginWithUSB_FIRST();

#endif
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                CommonFnUI.ShowError(ex, this.Program);
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.Escape))
                {
                    MMessage.ShowQuestion("Tho\x00e1t khỏi chương tr\x00ecnh n\x00e0y? (Y/N)", (msg) =>
                    {
                        this.Close();
                    });

                }
            }
            catch (Exception exception)
            {
                CommonFnUI.ShowError(exception, this.Program);
            }
            
        }

        private void btnConfigSQL_Click(object sender, EventArgs e)
        {
            frmConfigSQL frm = new frmConfigSQL();
            frm.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            lblVersion.Text = MT.Library.SessionData.VersionName;
#if (DEBUG)
            btnLogin.Text = "Đăng nhập";
            //txtDangnhap.Text = "ncon";
            //txtMatkhau.Text = "123456@";
            this.ActiveControl = this.txtDangnhap;
            this.txtDangnhap.Focus();
            this.txtDangnhap.Select();
#else
            btnLogin.Text = "Xác thực";
            //txtDangnhap.Text = MT.Library.Utility.GetAppSettings<string>("UserDefault", "");
            //txtMatkhau.Text = MT.Library.Utility.GetAppSettings<string>("PassDefault", "");
            txtDangnhap.Enabled = false;
            txtMatkhau.Enabled = false;
            loginWithUSB_FIRST();
#endif




        }

        private void btnConfigSQL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
        }

        bool isShow = false;
        private void iconShowPass_Click(object sender, EventArgs e)
        {
            isShow = !isShow;
            txtMatkhau.UseSystemPasswordChar = !isShow;
            txtMatkhau.PasswordChar = isShow ? '\0' : '*';
        }
    }
}
