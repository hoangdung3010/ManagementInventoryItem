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
using DevExpress.XtraEditors.Repository;

namespace MTControl
{
    [UserRepositoryItem("RegisterMButtonEdit")]
    public class MRepositoryItemButtonEdit : DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    {
        #region"Declare"

        public const string MButtonEdit = "MButtonEdit";
        public override string EditorTypeName
        {
            get
            {
                return MButtonEdit;
            }
        }

        /// <summary>
        /// Đánh dấu có required trường này không
        /// </summary>
        public bool IsRequired
        {
            get;set;
        }
        public MGridControl GridMaster { get; set; }
        #endregion

        #region"MRepositoryItemButtonEdit"
        static MRepositoryItemButtonEdit()
        {
            RegisterMButtonEdit();
        }
        public MRepositoryItemButtonEdit()
        {
        }
        #endregion
        #region"Sub/Func"
        public static void RegisterMButtonEdit()
        {
            try
            {
            }catch{
            }
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MButtonEdit, typeof(MButtonEdit), typeof(RepositoryItemButtonEdit),
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
                MRepositoryItemButtonEdit source = item as MRepositoryItemButtonEdit;
                if (source == null)
                {
                    return;
                }

                this.GridMaster = source.GridMaster;
            }
            finally{
                EndUpdate();
            }
        }
        #endregion

        #region "Event"
      
        #endregion

        #region"Implement"

        #endregion
    }
}
