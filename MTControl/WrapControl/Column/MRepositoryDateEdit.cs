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
using DevExpress.XtraEditors.Drawing;
using DevExpress.Accessibility;
using DevExpress.XtraEditors.ViewInfo;

namespace MTControl
{
    [UserRepositoryItem("RegisterMDateEdit")]
    public class MRepositoryDateEdit : DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    {
        #region"Declare"

        public const string MDateEdit = "MDateEdit";
        public override string EditorTypeName
        {
            get
            {
                return MDateEdit;
            }
        }

        public bool IsOrigin { get; set; }

        public string FieldName { get; set; }
        /// <summary>
        /// Đánh dấu có required trường này không
        /// </summary>
        public bool IsRequired
        {
            get;set;
        }
        public MGridControl GridMaster { get; set; }

        /// <summary>
        /// Đánh dấu editor là filter row
        /// </summary>
        public bool IsEditorFilterRow { get; set; }
        #endregion

        #region"MRepositoryDateEdit"
        static MRepositoryDateEdit()
        {
            RegisterMDateEdit();
        }
        public MRepositoryDateEdit()
        {
            this.EditValueChanged -= MRepositoryDateEdit_EditValueChanged;
            this.EditValueChanged += MRepositoryDateEdit_EditValueChanged;
        }
        #endregion
        #region"Sub/Func"
        public static void RegisterMDateEdit()
        {
            try
            {
            }catch{
            }
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MDateEdit, typeof(MDateEdit), typeof(MRepositoryDateEdit),
                typeof(DateEditViewInfo),new ButtonEditPainter(),true,null,typeof(PopupEditAccessible)));
        }
        #endregion
        #region"Ovrrides"
        public override void Assign(DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                MRepositoryDateEdit source = item as MRepositoryDateEdit;
                if (source == null)
                {
                    return;
                }

                this.IsRequired = source.IsRequired;
                this.GridMaster = source.GridMaster;
            }
            finally{
                EndUpdate();
            }
        }
        #endregion

        #region "Event"
        private void MRepositoryDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsOrigin &&  GridMaster != null && GridMaster.FirstView.Editable)
            {
                MTControl.MDateEdit mDateEdit = (sender as MTControl.MDateEdit);
                if (mDateEdit == null)
                {
                    return;
                }
                GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle,
                        GridMaster.FirstView.FocusedColumn.FieldName, mDateEdit.EditValue);
                GridMaster.FirstView.UpdateCurrentRow();
            }
        }
        #endregion

        #region"Implement"

        #endregion
    }
}
