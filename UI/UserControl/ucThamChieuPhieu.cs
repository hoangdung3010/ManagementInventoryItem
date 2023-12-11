using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MT.Data.BO;
using MTControl;
using FontAwesome.Sharp;
using FormUI.Base;
using MT.Data.Rep;
using MT.Library.BO;
using MT.Library;

namespace FormUI
{
    public partial class ucThamChieuPhieu : FormUIUserControl
    {

        private Guid? _sObjectId;

        public Guid? sObjectId
        {
            get
            {
                return _sObjectId;
            }
            set
            {
                _sObjectId = value;
            }
        }

        private string _sTenBangCanCu;
        public string sTenBangCanCu
        {
            get
            {
                return _sTenBangCanCu;
            }
            set
            {
                _sTenBangCanCu = value;
            }
        }

        public ucThamChieuPhieu()
        {
            InitializeComponent();
        }

        private void ucThamChieuPhieu_Load(object sender, EventArgs e)
        {
            
            this.Padding = new Padding(0);
        }

        /// <summary>
        /// Bắt đầu load data
        /// </summary>
        public void LoadData()
        {
            if (_sObjectId.HasValue && !backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Tạo link tham chiếu
        /// </summary>
        /// <param name="_canCuPhieu"></param>
        void CreateLink(MLinkFormVoucher mLinkFormVoucher,CanCuPhieu _canCuPhieu)
        {
            string sMaPhieu = _canCuPhieu.sMaPhieu;
            if (string.IsNullOrWhiteSpace(sMaPhieu))
            {
                return;
            }
            if (sMaPhieu.Length > 20)
            {
                mLinkFormVoucher.Text = string.Concat(sMaPhieu.Substring(0, 20), "...");
            }
            else
            {
                mLinkFormVoucher.Text = sMaPhieu;
            }
            mLinkFormVoucher.TableName = _canCuPhieu.sTenBangPhieu;
            mLinkFormVoucher.VoucherId = _canCuPhieu.sPhieu_Id;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = DBContext.GetRep2<CanCuPhieuRepository>().GetThamChieuDenPhieu(_sObjectId.Value);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                fLayout.FlowDirection = FlowDirection.LeftToRight;
                fLayout.Padding = new Padding(0);
                fLayout.Margin = new Padding(0);
                fLayout.AutoScroll = false;
                fLayout.WrapContents = true;
                fLayout.Controls.Clear();
                List<CanCuPhieu> canCuPhieus = e.Result as List<CanCuPhieu>;
                if (canCuPhieus?.Count > 0)
                {
                    foreach (var item in canCuPhieus)
                    {
                        var p = new FlowLayoutPanel();
                        p.BackColor = Color.FromArgb(204,196,139);
                        p.SuspendLayout();
                        p.Width = 115;
                        p.Padding = new Padding(0);
                        p.FlowDirection = FlowDirection.LeftToRight;
                        p.AutoScroll = true; 
                        p.WrapContents = false; 
                        fLayout.Controls.Add(p);
                        MLinkFormVoucher mLinkFormVoucher = new MLinkFormVoucher();
                        mLinkFormVoucher.Margin = new Padding(0);
                        mLinkFormVoucher.TextAlign = ContentAlignment.MiddleLeft;
                        CreateLink(mLinkFormVoucher, item);
                        p.Controls.Add(mLinkFormVoucher);

                        IconPictureBox iconPictureBox = new IconPictureBox();
                        iconPictureBox.Margin = new Padding(0);
                        iconPictureBox.Width = 16;
                        iconPictureBox.Height = 16;
                        iconPictureBox.IconChar = IconChar.Times;                       
                        iconPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
                        iconPictureBox.ForeColor = System.Drawing.SystemColors.HighlightText;
                        iconPictureBox.IconColor = System.Drawing.SystemColors.HighlightText;
                        iconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
                        iconPictureBox.IconSize = 18;
                        iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        iconPictureBox.Tag = item;
                        iconPictureBox.Click += new EventHandler(deletePhieu_Click);
                        p.Controls.Add(iconPictureBox);
                        p.ResumeLayout();
                    }
                }
            }
            else
            {
                CommonFnUI.ShowError(e.Error, "Tham chiếu");
            }
            
        }
        /// <summary>
        /// Thực hiện xóa phiếu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletePhieu_Click(object sender,EventArgs e)
        {
            IconPictureBox iconPictureBox = sender as IconPictureBox;
            try
            {
                CanCuPhieu canCuPhieu = iconPictureBox.Tag as CanCuPhieu;

                if (!CommonFnUI.CheckPermission($"frm{canCuPhieu.sTenBangPhieu}", MT.Library.Enummation.PermissionValue.Delete))
                {
                    MMessage.ShowWarning("Bạn không có quyền thực hiện chức năng này");
                    return;
                }

                Action<string> dg = (s) =>
                {
                    var rep = DBContext.GetRepByTableName(canCuPhieu.sTenBangPhieu);
                    if (rep != null)
                    {
                        Type type = Type.GetType($"MT.Data.BO.{canCuPhieu.sTenBangPhieu},MT.Data");
                        var entity = Activator.CreateInstance(type);
                        MT.Library.Extensions.ExtensionMethod.SetValue(entity, "Id", canCuPhieu.sPhieu_Id);
                        MT.Library.Extensions.ExtensionMethod.SetValue(entity, "MTEntityState", (int)MT.Library.Enummation.MTEntityState.Delete);
                        ResultData resultData = rep.DeleteData(new List<object>
                        {
                            entity
                        });
                        if (!string.IsNullOrWhiteSpace(resultData.UserMsg))
                        {
                            MMessage.ShowWarning(resultData.UserMsg);
                        }
                        else
                        {
                            LoadData();
                        }
                    }
                };
                MTControl.MMessage.ShowQuestion($"Bạn có chắc chắn muốn xóa tham chiếu <{canCuPhieu.sMaPhieu}> đã chọn không?", dg);
            }
            catch (Exception ex)
            {
                CommonFnUI.ShowError(ex, "Xóa tham chiếu đến bản ghi");
               
            }
        }
    }
}
