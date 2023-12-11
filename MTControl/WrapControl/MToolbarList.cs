using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraBars.Customization;
using DevExpress.XtraBars;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MTControl
{
    public class MToolbarList : DevExpress.XtraEditors.XtraUserControl
    {
        
        #region"Declare"
        //Bắt sự kiện click trên form
        private  System.EventHandler<DevExpress.XtraBars.ItemClickEventArgs> myEventHandler;

        public System.EventHandler<DevExpress.XtraBars.ItemClickEventArgs> MyEventHandler
        {
            get { return myEventHandler; }
            set { myEventHandler = value; }
        }

        private MButtonName[] mButtonNames;
        /// <summary>
        /// Danh sách các button hiển thị trên danh sách
        /// </summary>
        public MButtonName[] ButtonNames
        {
            get
            {
                if (mButtonNames == null || mButtonNames.Length == 0)
                {
                    mButtonNames = new MButtonName[8]
                    {
                    new MButtonName{CommandName=MCommandName.AddNew},
                    new MButtonName{CommandName=MCommandName.Duplicate},
                    new MButtonName{CommandName=MCommandName.View},
                    new MButtonName{CommandName=MCommandName.Edit},
                    new MButtonName{CommandName=MCommandName.Delete},
                    new MButtonName{CommandName=MCommandName.Print},
                    new MButtonName{CommandName=MCommandName.Refresh,BeginGroup=true},
                    new MButtonName{CommandName=MCommandName.Help,BeginGroup=true}
                    };
                }
                return mButtonNames;
            }
            set
            {
                mButtonNames = value;
            }
        }

        private Dictionary<string, BarButtonItem> _barItems=new Dictionary<string, BarButtonItem>();

        public Dictionary<string, BarButtonItem> BarItems
        {
            get
            {
                return _barItems;
            }
        }

        private DevExpress.XtraBars.BarManager bmgrToolbar;
        public Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnDuplicate;
        private DevExpress.XtraBars.BarButtonItem btnView;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private IContainer components;
        private BarButtonItem btnClose;
        private BarButtonItem barButtonItem3;
        private BarButtonItem barButtonItem4;
        private BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        #endregion
        #region"Contructor"
        public MToolbarList()
        {
            InitializeComponent();
            
            this.Load+=MToolbarList_Load;
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bmgrToolbar = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnDuplicate = new DevExpress.XtraBars.BarButtonItem();
            this.btnView = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
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
            this.btnDuplicate,
            this.btnView,
            this.btnEdit,
            this.btnDelete,
            this.btnPrint,
            this.btnHelp,
            this.btnClose});
            this.bmgrToolbar.MainMenu = this.bar2;
            this.bmgrToolbar.MaxItemId = 15;
            this.bmgrToolbar.RightToLeft = DevExpress.Utils.DefaultBoolean.False;
            this.bmgrToolbar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.toolBar_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatSize = this.Size;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDuplicate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnView, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHelp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MinHeight = 26;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Thêm";
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.Image = global::MTControl.Properties.Resources.addnew;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Tag = "Add";
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Caption = "Nhân bản";
            this.btnDuplicate.Id = 1;
            this.btnDuplicate.ImageOptions.Image = global::MTControl.Properties.Resources.duplicate;
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Tag = "Duplicate";
            // 
            // btnView
            // 
            this.btnView.Caption = "Xem";
            this.btnView.Id = 2;
            this.btnView.ImageOptions.Image = global::MTControl.Properties.Resources.view;
            this.btnView.Name = "btnView";
            this.btnView.Tag = "View";
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 3;
            this.btnEdit.ImageOptions.Image = global::MTControl.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Tag = "Edit";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 4;
            this.btnDelete.ImageOptions.Image = global::MTControl.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Tag = "Delete";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 5;
            this.btnPrint.ImageOptions.Image = global::MTControl.Properties.Resources.print;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Tag = "Print";
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Giúp";
            this.btnHelp.Id = 6;
            this.btnHelp.ImageOptions.Image = global::MTControl.Properties.Resources.help;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Tag = "Help";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bmgrToolbar;
            this.barDockControlTop.Size = new System.Drawing.Size(1200, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 26);
            this.barDockControlBottom.Manager = this.bmgrToolbar;
            this.barDockControlBottom.Size = new System.Drawing.Size(1200, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = this.bmgrToolbar;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1200, 26);
            this.barDockControlRight.Manager = this.bmgrToolbar;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 0);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Id = 11;
            this.btnClose.ImageOptions.Image = global::MTControl.Properties.Resources.close;
            this.btnClose.Name = "btnClose";
            this.btnClose.Tag = "Close";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Giúp";
            this.barButtonItem3.Id = 6;
            this.barButtonItem3.ImageOptions.Image = global::MTControl.Properties.Resources.help;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.Tag = "Help";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Giúp";
            this.barButtonItem4.Id = 6;
            this.barButtonItem4.ImageOptions.Image = global::MTControl.Properties.Resources.help;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.Tag = "Help";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Giúp";
            this.barButtonItem5.Id = 6;
            this.barButtonItem5.ImageOptions.Image = global::MTControl.Properties.Resources.help;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.Tag = "Help";
            // 
            // MToolbarList
            // 
            this.AllowDrop = true;
            this.Appearance.BackColor = System.Drawing.Color.Gainsboro;
            this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MToolbarList";
            this.Size = new System.Drawing.Size(1200, 26);
            ((System.ComponentModel.ISupportInitialize)(this.bmgrToolbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            this.Dock = DockStyle.Top;
            base.OnCreateControl();
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);

        }
        #endregion
        #region"Implement"

        #endregion
        #region"event"
        /// <summary>
        /// Đăng ký event shortcut
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:03.10.2017
        private void MToolbarList_Load(object sender, EventArgs e)
        {
            
            if (ButtonNames != null && ButtonNames.Length>0)
            {
                bmgrToolbar.Items.Clear();
                bmgrToolbar.BeginInit();
                foreach (var item in ButtonNames)
                {
                    string caption = string.IsNullOrWhiteSpace(item.Caption) ? GetCommandTextButtonItem(typeof(MCommandName),(int)item.CommandName) : item.Caption;

                    var buttonItem = new DevExpress.XtraBars.BarButtonItem(this.bmgrToolbar, caption);
                    buttonItem.ImageOptions.Image = GetImageButton(item);
                    buttonItem.ImageToTextAlignment = BarItemImageToTextAlignment.BeforeText;
                    buttonItem.Tag = (int)item.CommandName;
                    buttonItem.ItemAppearance.SetFont(new System.Drawing.Font(MFont.mscSysFontName, 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel));
                    _barItems.Add(item.CommandName.ToString(), buttonItem);

                    this.bmgrToolbar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
                       buttonItem
                     });

                    DevExpress.XtraBars.LinkPersistInfo link = new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle,
                    buttonItem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph);
                    this.bar2.LinksPersistInfo.Add(link);
                    link.BeginGroup = item.BeginGroup;
                }
                bmgrToolbar.EndInit();
            }

        }

        /// <summary>
        /// Thiết lập icon cho button
        /// </summary>
        /// <param name="mButtonName"></param>
        /// <param name="barButtonItem"></param>
        public Image GetImageButton(MButtonName mButtonName)
        {
           return MCommon.GetImageButton(mButtonName);
        }

        /// <summary>
        /// Thiết lập ẩn hiện button
        /// </summary>
        /// <param name="mButtonName"></param>
        public void SetEnable(MCommandName commandName,bool isEnable)
        {
            if (BarItems.ContainsKey(commandName.ToString()))
            {
                BarItems[commandName.ToString()].Enabled = isEnable;
            }
        }

        /// <summary>
        /// Lấy về text enum
        /// </summary>
        /// <param name="enumType">Kiểu enum</param>
        /// <param name="value">Giá trị enum</param>
        /// Create by: dvthang:12.04.2021
        public string GetCommandTextButtonItem(Type enumType, int value)
        {
            return MCommon.GetCommandTextButtonItem(enumType, value);
        }


        private void toolBar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MyEventHandler != null)
            {
                this.MyEventHandler(sender, e);
            }
        }
        #endregion

    }


}
