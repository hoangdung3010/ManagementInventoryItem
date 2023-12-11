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
using DevExpress.Utils;

namespace MTControl
{
    [UserRepositoryItem("RegisterMComboBox")]
    public class MRepositoryComboBox : DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    {
        #region"Declare"

        public const string MComboBox = "MComboBox";
        public override string EditorTypeName
        {
            get
            {
                return MComboBox;
            }
        }

        public bool IsOrigin { get; set; }
        public string FieldName { get; set; }

        /// <summary>
        /// Không có giá trị default cho enum
        /// </summary>
        public bool NoDefaultValue { get; set; } = false;

        /// <summary>
        /// Tên bảng load data
        /// </summary>
        private bool entityName;

        public bool EntityName
        {
            get { return entityName; }
            set { entityName = value; }
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
        /// Đánh dấu có required trường này không
        /// </summary>
        public bool IsRequired
        {
            get; set;
        }
        public MGridControl GridMaster { get; set; }
        List<DisplayEnum> lstDisplayEnum = null;

        /// <summary>
        /// Đánh dấu editor là filter row
        /// </summary>
        public bool IsEditorFilterRow { get; set; }
        #endregion

        #region"MRepositoryComboBox"
        static MRepositoryComboBox()
        {
            RegisterMComboBox();
        }
        public MRepositoryComboBox()
        {
            this.EditValueChanging -= MRepositoryComboBox_EditValueChanging;
            this.EditValueChanging += MRepositoryComboBox_EditValueChanging; 
            this.ParseEditValue -= MRepositoryComboBox_ParseEditValue;
            this.ParseEditValue += MRepositoryComboBox_ParseEditValue;
        }

       

        #endregion
        #region"Sub/Func"
        public static void RegisterMComboBox()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MComboBox, typeof(MComboBox), typeof(MRepositoryComboBox),
                typeof(ComboBoxViewInfo),new ButtonEditPainter(),true,null,typeof(PopupEditAccessible)));
        }
        #endregion
        #region"Ovrrides"
        /// <summary>
        /// Load data cho control lookup
        /// </summary>
        private void LoadDataEnumForControlComboEdit()
        {
            ComboBoxItemCollection col = this.Items;
            if (!string.IsNullOrEmpty(this.EnumData))
            {
                col.BeginUpdate();
                col.Clear();

                try
                {
                    string enumName = this.EnumData;

                    if (!string.IsNullOrEmpty(enumName))
                    {
                        int firstValue = -1;
                        lstDisplayEnum = new List<DisplayEnum>();
                        //Nếu đã tồn tại giá trị enum roh thì ko load lại nữa
                        if (MCommon.ShareEnum != null && MCommon.ShareEnum.ContainsKey(this.EnumData))
                        {
                            lstDisplayEnum = MCommon.ShareEnum[this.enumData];
                            if (lstDisplayEnum != null)
                            {
                                Dictionary<int, string> itemEnum = new Dictionary<int, string>();
                                int countItem = lstDisplayEnum.Count;
                                for (int i = 0; i < countItem; i++)
                                {
                                    DisplayEnum oDisplayEnum = lstDisplayEnum[i];
                                    col.Add(oDisplayEnum);
                                    itemEnum.Add(oDisplayEnum.Value, oDisplayEnum.Text);
                                    if (i == 0)
                                    {
                                        firstValue = oDisplayEnum.Value;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MCommon.SetAssemblyModels();
                            Type t = MCommon.GetEnumType(enumName);
                            if (t != null)
                            {
                                System.Array arrValue = Enum.GetValues(t);
                                System.Array arrName = Enum.GetNames(t);
                                Dictionary<int, string> itemEnum = new Dictionary<int, string>();
                                lstDisplayEnum = new List<DisplayEnum>();
                                for (int i = 0; i < arrValue.Length; i++)
                                {
                                    DisplayEnum objEnum = new DisplayEnum();
                                    objEnum.Value = Convert.ToInt32(arrValue.GetValue(i));
                                    string nameEnum = string.Format("{0}_{1}", enumName, Convert.ToString(arrName.GetValue(i)));
                                    objEnum.Text = MCommon.GetGlobalResources(MCommon.AssemblyEnum, string.Format("{0}.EnumResources", MCommon.AssemblyNameEnum), nameEnum);
                                    col.Add(objEnum);
                                    itemEnum.Add(objEnum.Value, objEnum.Text);
                                    if (i == 0)
                                    {
                                        firstValue = objEnum.Value;
                                    }
                                    lstDisplayEnum.Add(objEnum);
                                }

                                //Nếu có ENum thì lưu lại
                                if (lstDisplayEnum.Count > 0)
                                {
                                    if (MCommon.ShareEnum == null)
                                    {
                                        MCommon.ShareEnum = new Dictionary<string, List<DisplayEnum>>();
                                    }
                                    MCommon.ShareEnum.Add(this.EnumData, lstDisplayEnum);
                                }
                            }
                        }

                    }

                }
                catch (Exception e)
                {
                    MMessage.ShowError(e.StackTrace);
                }
                finally
                {
                    col.EndUpdate();
                }
            }
            else
            {
                col.Clear();
            }
        }

        /// <summary>
        /// Custom việc hiển thị display text trên grid
        /// </summary>
        /// <param name="format"></param>
        /// <param name="editValue"></param>
        /// <returns></returns>
        public override string GetDisplayText(FormatInfo format, object editValue)
        {
            if (string.IsNullOrWhiteSpace(this.enumData))
            {
                return base.GetDisplayText(format, editValue);
            }

            if(lstDisplayEnum == null || lstDisplayEnum.Count == 0)
            {
                lstDisplayEnum = new List<DisplayEnum>();
                LoadDataEnumForControlComboEdit();
            }

            if (editValue == null)
            {
                if (NoDefaultValue)
                {
                    return string.Empty;
                }
                return lstDisplayEnum?.FirstOrDefault().ToString();
            }
            else
            {
                int value = -1;
                DisplayEnum displayEnum = null;
                bool isBoolValue = false;
                if ("true".Equals(editValue.ToString().ToLower()))
                {
                    value = 1;
                    isBoolValue = true;
                }
                if ("false".Equals(editValue.ToString().ToLower()))
                {
                    value = 0;
                    isBoolValue = true;
                }
                if (!isBoolValue)
                {
                    if (int.TryParse(editValue.ToString(), out value))
                    {
                        displayEnum = lstDisplayEnum.Find(m => m.Value == value);
                    }
                    else
                    {
                        displayEnum = editValue as DisplayEnum;
                    }
                }
                else
                {
                    displayEnum = lstDisplayEnum.Find(m => m.Value == value);
                }
               
                if (displayEnum == null)
                {
                    displayEnum = lstDisplayEnum.FirstOrDefault();
                }
                return displayEnum.ToString();
            }
        }

    
        public override void Assign(DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                MRepositoryComboBox source = item as MRepositoryComboBox;
                if (source == null)
                {
                    return;
                }
                this.enumData = source.enumData;
                this.FieldName = source.FieldName;
            }
            finally{
                EndUpdate();
            }
        }
        #endregion

        #region "Event"

        private void MRepositoryComboBox_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
          
            if (!string.IsNullOrWhiteSpace(this.enumData))
            {
                DisplayEnum displayEnum = e.Value as DisplayEnum;
                if (displayEnum != null)
                {
                    e.Value = displayEnum.Value;
                    e.Handled = true;
                }
                else
                {
                    if (e.Value != null && lstDisplayEnum != null && lstDisplayEnum.Count > 0)
                    {
                        int val = 0;
                        bool isBoolValue = false;
                        if ("true".Equals(e.Value.ToString().ToLower()))
                        {
                            val = 1;
                            isBoolValue = true;
                        }
                        if ("false".Equals(e.Value.ToString().ToLower()))
                        {
                            val = 0;
                            isBoolValue = true;
                        }
                        if (!isBoolValue)
                        {
                            int.TryParse(e.Value.ToString(), out val);
                        }
                        
                        displayEnum = lstDisplayEnum.Find(m => m.Value == val);
                        e.Value = displayEnum?.Value;
                        e.Handled = true;
                    }
                }

            }
        }

        private void MRepositoryComboBox_EditValueChanging(object sender, ChangingEventArgs e)
        {
          
            if (!IsOrigin && GridMaster != null && GridMaster.FirstView.Editable)
            {
                if (GridMaster.ValidEditValueChanging == null || GridMaster.ValidEditValueChanging(GridMaster.FirstView.FocusedColumn, e))
                {
                    DisplayEnum displayEnum = e.NewValue as DisplayEnum;
                    if (displayEnum != null && !displayEnum.Value.Equals(e.OldValue))
                    {
                        GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle,
                        GridMaster.FirstView.FocusedColumn.FieldName, displayEnum?.Value);
                    }
                    else
                    {
                        GridMaster.SetValueCell(GridMaster.FirstView.FocusedRowHandle,
                        GridMaster.FirstView.FocusedColumn.FieldName, 0);
                    }
                    GridMaster.FirstView.UpdateCurrentRow();
                }
            }
        }
        #endregion

        #region"Implement"

        #endregion
    }
}
