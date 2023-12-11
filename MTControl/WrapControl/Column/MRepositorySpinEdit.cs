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
    [UserRepositoryItem("RegisterMSpinEdit")]
    public class MRepositorySpinEdit : DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    {
        #region"Declare"
        public const string MSpinEdit = "MSpinEdit";
        public override string EditorTypeName
        {
            get
            {
                return MSpinEdit;
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

        #region"MRepositorySpinEdit"
        static MRepositorySpinEdit()
        {
            RegisterMSpinEdit();
        }
        public MRepositorySpinEdit()
        {
            this.EditValueChanged -= MRepositorySpinEdit_EditValueChanged;
            this.EditValueChanged += MRepositorySpinEdit_EditValueChanged;
        }

       
        #endregion
        #region"Sub/Func"
        public static void RegisterMSpinEdit()
        {

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MSpinEdit, typeof(MSpinEdit), typeof(MRepositorySpinEdit),
                typeof(BaseSpinEditViewInfo), new ButtonEditPainter(), true, null, typeof(BaseSpinEditAccessible)));
        }
        #endregion
        #region"Ovrrides"

        public override void Assign(DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                MRepositorySpinEdit source = item as MRepositorySpinEdit;
                if (source == null)
                {
                    return;
                }
                this.IsRequired = source.IsRequired;
                this.GridMaster = source.GridMaster;
            }
            finally
            {
                EndUpdate();
            }
        }
        #endregion

        #region "Event"
        private void MRepositorySpinEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsOrigin && GridMaster != null && GridMaster.FirstView.Editable)
            {
                MTControl.MSpinEdit mSpinEdit = (sender as MTControl.MSpinEdit);
                if (mSpinEdit == null)
                {
                    return;
                }
                GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle,
                   GridMaster.FirstView.FocusedColumn.FieldName, mSpinEdit.EditValue);
                GridMaster.FirstView.UpdateCurrentRow();
            }
        }
        #endregion

        #region"Implement"

        #endregion
    }
}
