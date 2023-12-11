using MT.Data.Rep;
using MT.Library.Log;
using MTControl;
using System;
using System.Collections;
using System.Windows.Forms;

namespace FormUI
{
    public partial class frmChangePass : FormUI.FormUIBase
    {
        #region"Property"
        private ArrayList paraList = new ArrayList();
        #endregion
        public frmChangePass()
        {
            InitializeComponent();
            Init();
        }

        #region"Sub/Func"
        private void Init()
        {
            //this.Text =MT.Libs.AppInfo.TitleFull;
            //base.Icon = MT.Libs.AppInfo.ico;
            this.txtNewPass.MaxLength = 15;
            this.txtOldPass.MaxLength = 15;
            this.txtConfirm.MaxLength = 15;
            base.ActiveControl = this.txtOldPass;
            this.AcceptButton = btnSave;
            this.Program = "Đổi mật khẩu";
        }

        /// <summary>
        /// Đổi title form
        /// </summary>
        /// <param name="title">Tên title</param>
        public void SetTitle(string title)
        {
            lblTitle.Text = title;
        }
        private void Save()
        {
            
            try
            {
                SysUserRepository sysUserRepository = (SysUserRepository)DBContext.GetRep<SysUserRepository>();
                string str = MT.Library.Utility.AddChar(this.txtOldPass.Text.Trim());
                string strToEncrypt = MT.Library.Utility.AddChar(this.txtNewPass.Text.Trim());
                string str3 = MT.Library.Utility.AddChar(this.txtConfirm.Text.Trim());
                string username = MT.Library.SessionData.UserName;
                if (((str == "") || (strToEncrypt == "")) || (str3 == ""))
                {
                    MMessage.ShowWarning(MT.Library.CommonKey.MsgLoginFailure);
                    base.ActiveControl = this.txtOldPass;
                }
                else
                {
                    if (strToEncrypt.Equals(str3))
                    {
                        if (!strToEncrypt.Equals(str))
                        {
                            if (sysUserRepository.CheckPass(username, str))
                            {
                                sysUserRepository.ChangePass(username, str, strToEncrypt);
                                sysUserRepository.InsertAuditingLog("SysUser", "Đổi mật khẩu", "Cập nhật", $"Tài khoản <{username}> đã đổi mật khẩu mới thành công");
                                MMessage.ShowInfor("Đ\x00e3 đổi mật khẩu! Xin vui l\x00f2ng nhớ mật khẩu mới!");
                                base.Close();
                                return;
                            }
                            MMessage.ShowWarning("Mật khẩu kh\x00f4ng hợp lệ ! Nhập Lại !!!");
                        }
                        else
                        {
                            MMessage.ShowWarning("Mật Khẩu cũ v\x00e0 mật Khẩu mới tr\x00f9ng nhau, y\x00eau cầu nhập lại mật khẩu mới!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu mới kh\x00f4ng hợp lệ !! Nhập Lại", "Th\x00f4ng b\x00e1o", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    this.txtNewPass.Text = "";
                    this.txtOldPass.Text = "";
                    this.txtConfirm.Text = "";
                    base.ActiveControl = this.txtOldPass;
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }
        #endregion

        #region"Event"

        private void frmChangePass_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
            LogHelper.AddEvent(this.UUID,this.Program);
        }

        private void pic_Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Save();
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
        }

        private void frmChangePass_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogHelper.UpdateEvent(this.UUID);
            base.Dispose();
        }
        #endregion


    }
}
