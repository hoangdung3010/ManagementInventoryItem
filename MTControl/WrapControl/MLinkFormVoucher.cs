using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MTControl
{
    /// <summary>
    /// Control hiển thị link tham chiếu đến chứng từ(Kế hoạch/phiếu nhập/xuất)
    /// </summary>
    public class MLinkFormVoucher : System.Windows.Forms.LinkLabel, IControl
        
    {
        #region"Declare"
        private string _description;
        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.ForeColor = Color.Blue;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.ActiveLinkColor = Color.Orange;
            this.VisitedLinkColor = Color.Green;
            this.LinkColor = Color.RoyalBlue;
            this.DisabledLinkColor = Color.Gray;
            SetFont();
        }

        #endregion
        #region"Implement"

        public void SetFont()
        {
            float sizeFont =13;
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, sizeFont, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        public Ctype Mtype
        {
            get { return Ctype.MLinkFormVoucher; }
        }

        public string Description { 
            get 
            {
                if (string.IsNullOrEmpty(_description))
                {
                    return "Link đến form được chỉ đinh";
                }
                return _description;
            } 
            set 
            { 
                _description = value;
            } 
        }

        /// <summary>
        /// Control lưu chứng từ
        /// </summary>
        public IEditControl ControlVoucher { get; set; }

        /// <summary>
        /// Id của chứng từ
        /// </summary>
        public object VoucherId { get; set; }

        /// <summary>
        /// Tên bảng chứng từ
        /// </summary>
        public string TableName { get; set; }

        protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
        {
            base.OnLinkClicked(e);
            if (!string.IsNullOrWhiteSpace(this.TableName))
            {
                if (VoucherId == null)
                {
                    VoucherId = ControlVoucher.GetValue();
                }
                if (VoucherId == null)
                {
                    return;
                }
                var frm = MCommon.FindFormByName(this.TableName);
                if (frm != null)
                {
                    frm.FormAction = (int)FormAction.View;
                    frm.EntityName = TableName;
                    frm.FormId = VoucherId;
                    frm.ControlCallForm = this;
                    frm.Show();
                }
            }

        }
        #endregion



    }
}
