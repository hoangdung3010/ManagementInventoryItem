using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
using System.Data;
using Newtonsoft.Json;
using System.Drawing;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Accessibility;
using System.Collections;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;

namespace MTControl
{
     [UserRepositoryItem("RegisterMGridLookUpEdit")]
    public class MRepositoryItemGridLookUpEdit : DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    {
        #region"Declare"
        public const string MGridLookUpEdit = "MGridLookUpEdit";

        private EditorButton _deleteButton;

        private string _dictionaryName;

        public string DictionaryName
        {
            get
            {
                return _dictionaryName;
            }
            set
            {

                _dictionaryName = value;
                this.Buttons.Clear();
                _deleteButton = new EditorButton(ButtonPredefines.Clear, MTControl.Properties.Resources.cleardata, null);
                _deleteButton.Tag = "ClearValue";
                _deleteButton.ToolTip = "Xóa";
                _deleteButton.Visible = false;
                this.Buttons.Add(_deleteButton);

                this.Buttons.Add(new EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo));

                if (!string.IsNullOrWhiteSpace(_dictionaryName))
                {
                    EditorButton btnAddDic = new EditorButton(ButtonPredefines.Glyph, MTControl.Properties.Resources.quick_add, null);
                    btnAddDic.Tag = "AddDictionnary";
                    this.Buttons.Add(btnAddDic);
                }
                this.ActionButtonIndex = 1;
            }
        }

        public override string EditorTypeName
        {
            get
            {
                return MGridLookUpEdit;
            }
        }
        public string FieldName { get; set; }

        public bool IsOrigin { get; set; }
        public MGridControl GridMaster { get; set; }

        /// <summary>
        /// Đánh dấu editor là filter row
        /// </summary>
        public bool IsEditorFilterRow { get; set; }


        /// <summary>
        /// Đánh dấu có required trường này không
        /// </summary>
        public bool IsRequired
        {
            get; set;
        }

        private MGridView mGridView;
        #endregion

        #region"MRepositoryItemGridLookUpEdit"
        static MRepositoryItemGridLookUpEdit()
        {
            RegisterMGridLookUpEdit();
        }
        public MRepositoryItemGridLookUpEdit()
        {
            this.NullText = string.Empty;
            this.EditValueChanging -= MRepositoryItemGridLookUpEdit_EditValueChanging;
            this.EditValueChanging += MRepositoryItemGridLookUpEdit_EditValueChanging;
        }
        #endregion
        #region"Sub/Func"

        /// <summary>
        /// custom lại grid in lookup
        /// </summary>
        /// <returns></returns>
        protected override DevExpress.XtraGrid.GridControl CreateGrid()
        {
            return new MGridControl();
        }

        /// <summary>
        /// Tạo view cho lookupedit
        /// </summary>
        /// <returns></returns>
        protected override ColumnView CreateViewInstance()
        {
            switch (ViewType)
            {
                case GridLookUpViewType.BandedView:
                    return new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
                case GridLookUpViewType.AdvBandedView:
                    return new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            }
            return new MGridView();
        }

        /// <summary>
        /// Đăng ký event show form QuichSearch hoặc form danh mục thêm nhanh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Create by: dvthang:16.10.2016
        public void ShowForm(object sender, ButtonPressedEventArgs e)
        {
            if (!IsOrigin && GridMaster != null && GridMaster.FirstView.Editable && !this.ReadOnly)
            {
                MCommon.ShowForm("", this.DictionaryName, this.DictionaryName, (MGridLookUpEdit)sender, sender, e);
            }
        }
        /// <summary>
        /// Dùng binding source để đổ dữ liệu cho grid
        /// </summary>
        /// Create by: dvthang:21.10.2017
        public void PushItem(object oEntity)
        {
            object dataSource = this.DataSource;
            DataTable data = dataSource as DataTable;
            if (data != null)
            {
                DataRow row = data.NewRow();
                var cols = this.View.Columns;
                if (cols != null)
                {
                    row.BeginEdit();
                    foreach (MGridColumn col in cols)
                    {
                        row[col.FieldName] = MTControl.MCommon.GetValueObject(oEntity, col.FieldName);
                    }
                    row.EndEdit();
                }
                data.Rows.InsertAt(row, 0);
            }
            else
            {
                IList lstData = dataSource as IList;
                if (lstData != null && !lstData.Contains(oEntity))
                {
                    lstData.Insert(0, oEntity);
                }
            }
        }

        /// <summary>
        /// Add column cho gridColum
        /// </summary>
        /// <param name="fieldName">Định danh cột</param>
        /// <param name="caption">Tên cột</param>
        /// <param name="width">Độ rộng</param>
        /// Create by: dvthang:21.09.2017
        public MGridColumn AddColumn(string fieldName, string caption, int width = -1)
        {
            MGridColumn col = new MGridColumn();
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Visible = true;
            if (width > 0)
            {
                col.Width = width;
            }
            else
            {
                col.BestFit();
            }
            this.View.Columns.Add(col);
            
            return col;
        }

        public static void RegisterMGridLookUpEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MGridLookUpEdit, typeof(MGridLookUpEdit), typeof(MRepositoryItemGridLookUpEdit),
                typeof(GridLookUpEditBaseViewInfo),new ButtonEditPainter(),true,null,typeof(PopupEditAccessible)));
        }

        #endregion
        #region"Ovrrides"
        public override void Assign(DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                MRepositoryItemGridLookUpEdit source = item as MRepositoryItemGridLookUpEdit;
                if (source == null)
                {
                    return;
                }

                this.DictionaryName = source.DictionaryName;
                this.IsRequired = source.IsRequired;
                this.GridMaster = source.GridMaster;
            }
            finally{
                EndUpdate();
            }
        }
        #endregion

        #region "Event"
        private void MRepositoryItemGridLookUpEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!IsOrigin &&  GridMaster != null && GridMaster.FirstView.Editable && e.OldValue != e.NewValue)
            {
                Type type = GridMaster.FirstView.FocusedColumn.ColumnType;
                if (e.NewValue == null || e.NewValue.GetType() == type)
                {
                    if (GridMaster.ValidEditValueChanging == null || GridMaster.ValidEditValueChanging(GridMaster.FirstView.FocusedColumn, e))
                    {
                        GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle,
                    GridMaster.FirstView.FocusedColumn.FieldName, e.NewValue);
                        var stringText = GridMaster.FirstView.GetRowCellDisplayText(GridMaster.FirstView.FocusedRowHandle, GridMaster.FirstView.FocusedColumn);
                        GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle, GridMaster.FirstView.FocusedColumn.FieldName + "_Ten", stringText);
                        GridMaster.FirstView.UpdateCurrentRow();
                    }
                } 
            }
        }
        #endregion

        #region"Implement"

        #endregion
    }
}
