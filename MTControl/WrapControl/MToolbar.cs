using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace MTControl
{
    public class MToolbar : DevExpress.XtraEditors.XtraUserControl
    {

        #region"Declare"
        //Bắt sự kiện click trên form
        private System.EventHandler<DevExpress.XtraBars.ItemClickEventArgs> myEventHandler;

        public System.EventHandler<DevExpress.XtraBars.ItemClickEventArgs> MyEventHandler
        {
            get { return myEventHandler; }
            set { myEventHandler = value; }
        }

        private DevExpress.XtraBars.BarManager bmgrToolbar;
        private IContainer components;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
       
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSaveAdd;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        #endregion
        #region"Contructor"
        public MToolbar()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bmgrToolbar = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnSaveAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            ((System.ComponentModel.ISupportInitialize)(this.bmgrToolbar)).BeginInit();
            this.SuspendLayout();
            // 
            // bmgrToolbar
            // 
            this.bmgrToolbar.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.bmgrToolbar.DockControls.Add(this.barDockControlTop);
            this.bmgrToolbar.DockControls.Add(this.barDockControlBottom);
            this.bmgrToolbar.DockControls.Add(this.barDockControlLeft);
            this.bmgrToolbar.DockControls.Add(this.barDockControlRight);
            this.bmgrToolbar.Form = this;
            this.bmgrToolbar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnSave,
            this.btnSaveAdd,
            this.barStaticItem1,
            this.btnDelete,
            this.btnUndo,
            this.btnPrint,
            this.btnHelp,
            this.btnClose});
            this.bmgrToolbar.MainMenu = this.bar2;
            this.bmgrToolbar.MaxItemId = 17;
            this.bmgrToolbar.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
            this.bmgrToolbar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bmgrToolbar_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHelp, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Thêm";
            this.btnAdd.Glyph = global::MTControl.Properties.Resources.addnew;
            this.btnAdd.Id = 0;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Tag = "Add";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Glyph = global::MTControl.Properties.Resources.edit;
            this.btnEdit.Id = 1;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Tag = "Edit";
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Glyph = global::MTControl.Properties.Resources.save;
            this.btnSave.Id = 9;
            this.btnSave.Name = "btnSave";
            this.btnSave.Tag = "Save";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Glyph = global::MTControl.Properties.Resources.delete;
            this.btnDelete.Id = 12;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Tag = "Delete";
            // 
            // btnUndo
            // 
            this.btnUndo.Caption = "Hủy";
            this.btnUndo.Glyph = global::MTControl.Properties.Resources.undo;
            this.btnUndo.Id = 13;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Tag = "Undo";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Glyph = global::MTControl.Properties.Resources.print;
            this.btnPrint.Id = 14;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Tag = "Print";
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Giúp";
            this.btnHelp.Glyph = global::MTControl.Properties.Resources.help;
            this.btnHelp.Id = 15;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Tag = "Help";
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Glyph = global::MTControl.Properties.Resources.close;
            this.btnClose.Id = 16;
            this.btnClose.Name = "btnClose";
            this.btnClose.Tag = "Close";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(582, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 26);
            this.barDockControlBottom.Size = new System.Drawing.Size(582, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(582, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // btnSaveAdd
            // 
            this.btnSaveAdd.ActAsDropDown = true;
            this.btnSaveAdd.Caption = "Cất &&Thêm";
            this.btnSaveAdd.Glyph = global::MTControl.Properties.Resources.saveadd;
            this.btnSaveAdd.Id = 10;
            this.btnSaveAdd.Name = "btnSaveAdd";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 11;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // MToolbar
            // 
            this.AllowDrop = true;
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "MToolbar";
            this.Size = new System.Drawing.Size(582, 26);
            this.Load += new System.EventHandler(this.MToolbar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bmgrToolbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region"Sub/Func"
        /// <summary>
        /// Lấy về control toolbar
        /// </summary>
        /// <returns></returns>
        public BarManager GetToolBar()
        {
            return bmgrToolbar;
        }

        /// <summary>
        /// Hiển thị các button theo mode trên form
        /// </summary>
        public void SetEnableButtonToolBar(int formAction)
        {
            switch (formAction)
            {
                case (int)MTControl.FormAction.Duplicate:
                case (int)MTControl.FormAction.Add:
                    btnSave.Enabled = true;
                    btnHelp.Enabled = true;
                    btnClose.Enabled = true;

                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = false;
                    btnPrint.Enabled = false;
                    break;
                case (int)MTControl.FormAction.Edit:
                    //Hiển thì cất, hoãn , giúp đóng
                    btnSave.Enabled = true;
                    btnUndo.Enabled = true;
                    btnHelp.Enabled = true;
                    btnClose.Enabled = true;

                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnPrint.Enabled = false;
                    break;
                case (int)MTControl.FormAction.None:
                case (int)MTControl.FormAction.View:
                    //Ẩn cất, hoãn
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    btnHelp.Enabled = true;
                    btnClose.Enabled = true;

                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnPrint.Enabled = true;
                    break;
            }
        }
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            this.Height = 30;
            this.Dock = DockStyle.Top;


            base.OnCreateControl();

            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);

        }
        #endregion
        #region"Implement"

        #endregion

        #region"event"
        private void bmgrToolbar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MyEventHandler != null)
            {
                this.MyEventHandler(sender, e);
            }
        }
        #endregion

        private void MToolbar_Load(object sender, System.EventArgs e)
        {
           
        }

       
    }

}
