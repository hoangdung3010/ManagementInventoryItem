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
using System.Windows.Forms;

namespace MTControl
{
    [UserRepositoryItem("RegisterMTextEdit")]
    public class MRepositoryTextEdit : DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    {
        #region"Declare"
        private bool useDefaultMode;

        public bool UseDefaultMode
        {
            get { return useDefaultMode; }
            set
            {
                if (useDefaultMode != value)
                {
                    useDefaultMode = value;
                    OnPropertiesChanged();
                }
            }
        }
        public const string MTextEdit = "MTextEdit";
        public override string EditorTypeName
        {
            get
            {
                return MTextEdit;
            }
        }

        public string FieldName { get; set; }
        /// <summary>
        /// Đánh dấu có required trường này không
        /// </summary>
        public bool IsRequired
        {
            get; set;
        }

        public bool IsOrigin { get; set; }
        public MGridControl GridMaster { get; set; }

        /// <summary>
        /// Hàm cho phép custom event enter
        /// Hàm trả về true thì cho phép, ngược lại thì không
        /// </summary>
        public Func<MRepositoryTextEdit,MTextEdit,bool> CustomEventEnter { get; set; }

        /// <summary>
        /// Đánh dấu editor là filter row
        /// </summary>
        public bool IsEditorFilterRow { get; set; }
        #endregion

        #region"MRepositoryTextEdit"
        static MRepositoryTextEdit()
        {
            RegisterMTextEdit();
        }
        public MRepositoryTextEdit()
        {
            this.EditValueChanging -= MRepositoryTextEdit_EditValueChanging;
            this.EditValueChanging += MRepositoryTextEdit_EditValueChanging;

            this.EditValueChanged -= MRepositoryTextEdit_EditValueChanged;
            this.EditValueChanged += MRepositoryTextEdit_EditValueChanged;
        }

        
        #endregion
        #region"Sub/Func"
        public static void RegisterMTextEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MTextEdit,typeof(MTextEdit),typeof(MRepositoryTextEdit),
                typeof(TextEditViewInfo),new TextEditPainter(),true,null,typeof(TextEditAccessible)));
        }
        #endregion
        #region"Ovrrides"
        public override void Assign(DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                MRepositoryTextEdit source = item as MRepositoryTextEdit;
                if (source == null)
                {
                    return;
                }
                useDefaultMode = source.useDefaultMode;
                this.IsRequired = source.IsRequired;
                this.GridMaster = source.GridMaster;
                this.IsEditorFilterRow = source.IsEditorFilterRow;
                this.CustomEventEnter = source.CustomEventEnter;
            }
            finally{
                EndUpdate();
            }
        }
        #endregion

        #region "Event"
        private void MRepositoryTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsOrigin &&  GridMaster != null && GridMaster.FirstView.Editable)
            {
                MTControl.MTextEdit mTextEdit = (sender as MTControl.MTextEdit);
                if (mTextEdit == null)
                {
                    return;
                }
                GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle,
                    GridMaster.FirstView.FocusedColumn.FieldName, mTextEdit.EditValue);
                GridMaster.FirstView.UpdateCurrentRow();
            }
        }

        private void MRepositoryTextEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            if (!IsOrigin && GridMaster != null && GridMaster.FirstView.Editable && !object.Equals(e.OldValue, e.NewValue))
            {
                if (GridMaster.ValidEditValueChanging != null && !GridMaster.ValidEditValueChanging(GridMaster.FirstView.FocusedColumn, e))
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region"Implement"

        #endregion
    }
}
