using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;

namespace MTControl
{
    public class MMessage
    {

        private const string MSC_TITLE = "Phần mềm q.lý Trang Thiết Bị";
        /// <summary>
        /// Show cảnh báo dạng warning
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowWarning(string msg)
        {
            MCommon.SetSkins();
            XtraMessageBox.Show(msg, MSC_TITLE, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
        }

        /// <summary>
        /// Show cảnh báo dạng thông tin
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowInfor(string msg)
        {
            MCommon.SetSkins();
            XtraMessageBox.Show(msg, MSC_TITLE, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information, DevExpress.Utils.DefaultBoolean.True);
        }

        /// <summary>
        /// Show cảnh báo dạng error
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowError(string msg)
        {
            MCommon.SetSkins();
            XtraMessageBox.Show(msg, MSC_TITLE, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error, DevExpress.Utils.DefaultBoolean.True);
        }

        /// <summary>
        /// Show cảnh báo dạng câu hỏi yes no
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowQuestion(string msg,Action<string> actionHandler, Action actionCancel=null)
        {
           MCommon.SetSkins();
          System.Windows.Forms.DialogResult dlg=  XtraMessageBox.Show(msg, MSC_TITLE, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, DevExpress.Utils.DefaultBoolean.True);
          if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
              actionHandler(msg);
            }
            else
            {
                if (actionCancel != null)
                {
                    actionCancel();
                }
            }
        }

        /// <summary>
        /// Show cảnh báo dạng câu hỏi yes no
        /// </summary>
        /// <param name="msg"></param>
        public static System.Windows.Forms.DialogResult ShowQuestion(string msg)
        {
            MCommon.SetSkins();
            System.Windows.Forms.DialogResult dlg = XtraMessageBox.Show(msg, MSC_TITLE, System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question, DevExpress.Utils.DefaultBoolean.True);
            return dlg;
        }
    }
}
