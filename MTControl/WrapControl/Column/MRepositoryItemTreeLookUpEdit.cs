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
using DevExpress.XtraTreeList.Columns;

namespace MTControl
{
     [UserRepositoryItem("RegisterMTreeLookUpEdit")]
    public class MRepositoryItemTreeLookUpEdit : DevExpress.XtraEditors.Repository.RepositoryItemTreeListLookUpEdit
    {
        #region"Declare"
        public const string MTreeLookUpEdit = "MTreeLookUpEdit";

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

        /// <summary>
        /// Lấy thêm 1 số cột để lưu lại, các cột cách nhau bởi dấu |
        /// </summary>
        public string CustomSetFields { get; set; }

        public override string EditorTypeName
        {
            get
            {
                return MTreeLookUpEdit;
            }
        }
        public string FieldName { get; set; }

        public bool IsOrigin { get; set; }

        /// <summary>
        /// Đánh dấu có required trường này không
        /// </summary>
        public bool IsRequired
        {
            get; set;
        }

        public MGridControl GridMaster { get; set; }

        /// <summary>
        /// Đánh dấu editor là filter row
        /// </summary>
        public bool IsEditorFilterRow { get; set; }
        #endregion

        #region"RepositoryItemTreeListLookUpEdit"
        static MRepositoryItemTreeLookUpEdit()
        {
            RegisterMTreeLookUpEdit();
            
        }
        public MRepositoryItemTreeLookUpEdit()
        {
            this.NullText = string.Empty;
            this.EditValueChanging -= MRepositoryItemTreeLookUpEdit_EditValueChanging;
            this.EditValueChanging += MRepositoryItemTreeLookUpEdit_EditValueChanging;
        }


        #endregion
        #region"Sub/Func"
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
                MCommon.ShowForm("", this.DictionaryName, this.DictionaryName, (MTreeLookUpEdit)sender, sender, e);
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
                row[this.ValueMember] = MTControl.MCommon.GetValueObject(oEntity, this.ValueMember);
                row[this.DisplayMember] = MTControl.MCommon.GetValueObject(oEntity, this.DisplayMember);
                row[this.TreeList.ParentFieldName] = MTControl.MCommon.GetValueObject(oEntity, this.TreeList.ParentFieldName);
                data.Rows.InsertAt(row, 0);
            }
            else
            {
                IList lstData = dataSource as IList;
                if (lstData != null)
                {
                    lstData.Insert(0, oEntity);
                }
            }
        }

        /// <summary>
        /// Add column cho treeList
        /// </summary>
        /// <param name="fieldName">Định danh cột</param>
        /// <param name="caption">Tên cột</param>
        /// <param name="width">Độ rộng</param>
        /// Create by: dvthang:10.03.2017
        public TreeListColumn AddColumn(string fieldName, string caption="")
        {
            TreeListColumn col = this.TreeList.Columns.ColumnByFieldName(fieldName);
            if (col == null)
            {
                col = new TreeListColumn();
                col.FieldName = fieldName;
                col.Caption = caption;
                col.Visible = true;
                this.TreeList.Columns.Add(col);
                col.BestFit();
            }
            return col;
        }

        public static void RegisterMTreeLookUpEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MTreeLookUpEdit, typeof(MTreeLookUpEdit), typeof(MRepositoryItemTreeLookUpEdit),
                typeof(LookUpEditViewInfo),new ButtonEditPainter(),true,null,typeof(PopupEditAccessible)));

           
        }
        #endregion
        #region"Ovrrides"
        public override void Assign(DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                MRepositoryItemTreeLookUpEdit source = item as MRepositoryItemTreeLookUpEdit;
                if (source == null)
                {
                    return;
                }
                this.DictionaryName = source.DictionaryName;
                this.IsRequired = source.IsRequired;
                this.GridMaster = source.GridMaster;
                this.CustomSetFields = source.CustomSetFields;
            }
            finally{
                EndUpdate();
            }
        }
        #endregion

        #region "Event"
        private void MRepositoryItemTreeLookUpEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!IsOrigin && GridMaster != null && GridMaster.FirstView.Editable && e.OldValue != e.NewValue)
            {
                try
                {
                    if (GridMaster.ValidEditValueChanging == null || GridMaster.ValidEditValueChanging(GridMaster.FirstView.FocusedColumn, e))
                    {
                        Type type = GridMaster.FirstView.FocusedColumn.ColumnType;
                        if(e.NewValue==null || e.NewValue.GetType()== type)
                        {
                            GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle,
                                        GridMaster.FirstView.FocusedColumn.FieldName, e.NewValue);

                            var stringText = GridMaster.FirstView.GetRowCellDisplayText(GridMaster.FirstView.FocusedRowHandle, GridMaster.FirstView.FocusedColumn);
                            GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle, GridMaster.FirstView.FocusedColumn.FieldName + "_Ten", stringText);

                            GridMaster.FirstView.UpdateCurrentRow();
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    //todo
                }
                   
            }
        }
        #endregion

        #region"Implement"

        #endregion
    }
}
