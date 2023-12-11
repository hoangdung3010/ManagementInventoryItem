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
using DevExpress.XtraEditors.Repository;

namespace MTControl
{
     [UserRepositoryItem("RegisterMLookUpEdit")]
    public class MRepositoryItemLookUpEdit : DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    {
         #region"Declare"
        public const string MLookUpEdit = "MLookUpEdit";

        private string _dictionaryName;
        private EditorButton _deleteButton;
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
                _deleteButton = new EditorButton(ButtonPredefines.Clear, MTControl.Properties.Resources.cleardata,null);
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
                return MLookUpEdit;
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

        /// <summary>
        /// Chỉ định enum cho combo
        /// </summary>
        private string enumData;

        public string EnumData
        {
            get { return enumData; }
            set
            {
                enumData = value;
                if (!string.IsNullOrEmpty(value))
                {
                    this.LoadDataEnumForControlComboEdit();
                }
            }
        }

        /// <summary>
        /// Đánh dấu editor là filter row
        /// </summary>
        public bool IsEditorFilterRow { get; set; }

        /// <summary>
        /// Load data cho control lookup
        /// </summary>
        private void LoadDataEnumForControlComboEdit()
        {
            if (!string.IsNullOrEmpty(this.EnumData))
            {
                AddColumn("Text", "Tên");
                this.DisplayMember = "Text";
                this.ValueMember = "Value";
                this.ShowHeader = false;
                this.DataSource=MCommon.GetDisplayEnums(this.EnumData);
                this.BestFitMode = BestFitMode.BestFitResizePopup;
                this.BestFit();
            }
           
        }

        /// <summary>
        /// Add column cho gridColum
        /// </summary>
        /// <param name="fieldName">Định danh cột</param>
        /// <param name="caption">Tên cột</param>
        /// <param name="width">Độ rộng</param>
        /// Create by: dvthang:21.09.2017
        public LookUpColumnInfo AddColumn(string fieldName, string caption, int width = -1, bool isEnd = false)
        {
            LookUpColumnInfo col = new LookUpColumnInfo();
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Visible = true;
            if (width > 0)
            {
                col.Width = width;
            }
            this.Columns.Add(col);
            return col;
        }

        public MGridControl GridMaster { get; set; }
        #endregion

        #region"MRepositoryLookUpEdit"
        static MRepositoryItemLookUpEdit()
        {
           RegisterMLookUpEdit();
        }
        public MRepositoryItemLookUpEdit()
        {
            this.NullText = string.Empty;
            
            this.EditValueChanging -= MRepositoryItemLookUpEdit_EditValueChanging;
            this.EditValueChanging += MRepositoryItemLookUpEdit_EditValueChanging;
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
                MCommon.ShowForm("", this.DictionaryName, this.DictionaryName, (MLookUpEdit)sender, sender, e);
            }
        }

        #endregion
        #region"Sub/Func"

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
                LookUpColumnInfoCollection cols = this.Columns;
                if (cols != null)
                {
                    row.BeginEdit();
                    foreach (LookUpColumnInfo col in cols)
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

        public static void RegisterMLookUpEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MLookUpEdit, typeof(MLookUpEdit), typeof(MRepositoryItemLookUpEdit),
                typeof(LookUpEditViewInfo),new ButtonEditPainter(),true,null,typeof(PopupEditAccessible)));
        }

        public void SetClearButton(object editValue)
        {
            if (this.ReadOnly)
            {
                this.Buttons[0].Visible = false;
            }
            else
            {
                this.Buttons[0].Visible = !Equals(editValue, null);
            }
        }
        #endregion
        #region"Ovrrides"
        public override void Assign(DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                MRepositoryItemLookUpEdit source = item as MRepositoryItemLookUpEdit;
                if (source == null)
                {
                    return;
                }
                source.EditValueChanging -= MRepositoryItemLookUpEdit_EditValueChanging;
                this.IsRequired = source.IsRequired;
                this.GridMaster = source.GridMaster;
                this.DictionaryName = source.DictionaryName;
               
            }
            finally{
                EndUpdate();
            }
        }
        #endregion

        #region "Event"
       
        private void MRepositoryItemLookUpEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!IsOrigin && GridMaster!=null && GridMaster.FirstView.Editable && !object.Equals(e.OldValue,e.NewValue))
            {
                Type type = GridMaster.FirstView.FocusedColumn.ColumnType;
                if(e.NewValue==null || e.NewValue.GetType()== type)
                {
                    if (GridMaster.ValidEditValueChanging == null || GridMaster.ValidEditValueChanging(GridMaster.FirstView.FocusedColumn, e))
                    {
                        GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle, GridMaster.FirstView.FocusedColumn.FieldName, e.NewValue);
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
