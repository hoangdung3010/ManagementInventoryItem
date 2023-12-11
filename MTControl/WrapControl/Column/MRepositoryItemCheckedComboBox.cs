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

namespace MTControl
{
     [UserRepositoryItem("MCheckComboBox")]
    public class MRepositoryItemCheckedComboBox : DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit
    {
         #region"Declare"
        public const string MCheckComboBox = "MCheckComboBox";

        public string DictionaryName { get; set; }
        public override string EditorTypeName
        {
            get
            {
                return MCheckComboBox;
            }
        }
        public bool IsOrigin { get; set; }

        public string FieldName { get; set; }
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

        #region"MRepositoryItemCheckedComboBox"
        static MRepositoryItemCheckedComboBox()
        {
            RegisterMCheckComboBox();
        }
        public MRepositoryItemCheckedComboBox()
        {
            this.NullText = string.Empty;
            this.EditValueChanging -= MRepositoryItemCheckComboBox_EditValueChanging;
            this.EditValueChanging += MRepositoryItemCheckComboBox_EditValueChanging;
        }
        #endregion
        #region"Sub/Func"
        public static void RegisterMCheckComboBox()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MCheckComboBox, typeof(MCheckComboBox), typeof(MRepositoryItemCheckedComboBox),
                typeof(DevExpress.XtraEditors.ViewInfo.PopupContainerEditViewInfo),new ButtonEditPainter(),true,null,typeof(PopupEditAccessible)));
        }
        #endregion
        #region"Ovrrides"
        public override void Assign(DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                MRepositoryItemCheckedComboBox source = item as MRepositoryItemCheckedComboBox;
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
        private void MRepositoryItemCheckComboBox_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!IsOrigin && GridMaster !=null && GridMaster.FirstView.Editable && e.OldValue != e.NewValue)
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
        #endregion

        #region"Implement"

        #endregion
    }
}
