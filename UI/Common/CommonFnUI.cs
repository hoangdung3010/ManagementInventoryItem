using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FormUI.Common;
using MT.Data;
using MT.Data.BO;
using MT.Data.Rep;
using MT.Library;
using MT.Library.Extensions;
using MT.Library.Log;
using MTControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace FormUI
{
    public static class CommonFnUI
    {
        #region"Xử lý chung cho việc hiển thị form"

        /// <summary>
        /// Add form vào form
        /// </summary>
        /// <param name="frm">Form cần add</param>
        /// <param name="parentForm">Form cha</param>
        /// dvthang-10.07.2016
        public static void AddForm(MFormBase frm, DevExpress.XtraEditors.XtraForm parentForm)
        {
            frm.TopLevel = false;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Visible = true;
            parentForm.Controls.Add(frm);
            frm.Show();
            frm.BringToFront();
        }

        /// <summary>
        /// Add form vào form
        /// </summary>
        /// <param name="frm">Form cần add</param>
        /// <param name="parentForm">Form cha</param>
        /// dvthang-10.07.2016
        public static void AddFormIntoPanel(MFormBase frm, MSplitContainerControl splitPanel)
        {
            frm.TopLevel = false;
            frm.ControlBox = false;
            frm.ShowInTaskbar = false;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Visible = true;
            splitPanel.Panel2.Controls.Clear();
            splitPanel.Panel2.Controls.Add(frm);
            frm.Show();
        }

        /// <summary>
        /// Add form userControl form
        /// </summary>
        /// <param name="frm">Form cần add</param>
        /// <param name="parentForm">Form cha</param>
        /// dvthang-10.07.2016
        public static void AddUserControl(MXtraUserControl userControl, DevExpress.XtraEditors.XtraForm parentForm)
        {
            userControl.Dock = System.Windows.Forms.DockStyle.Fill;
            userControl.Visible = true;
            parentForm.Controls.Add(userControl);
            userControl.BringToFront();
        }

        /// <summary>
        /// Duyệt lấy toàn bộ control nhập liệu trên form
        /// </summary>
        /// <param name="container">Control to nhất chứa tất cả các control nhập liệu</param>
        /// <param name="list">Danh sách các control nhập liệu lấy được trong vùng</param>
        /// <returns>dvthang-27.07.2016</returns>

        public static Dictionary<string, IEditControl> GetAllControls(Control container, Dictionary<string, IEditControl> dicControls)
        {
            if (container != null)
            {
                foreach (Control c in container.Controls)
                {
                    IEditControl editControl = c as IEditControl;
                    if (editControl != null && !string.IsNullOrWhiteSpace(editControl.SetField))
                    {
                        switch (editControl.Mtype)
                        {
                            case Ctype.MTextEdit:
                            case Ctype.MSpinEdit:
                            case Ctype.MTimeEdit:
                            case Ctype.MLookUpEdit:
                            case Ctype.MListBox:
                            case Ctype.MRadioGroup:
                            case Ctype.MComboBox:
                            case Ctype.MCheckBoxEdit:
                            case Ctype.MComboBoxTree:
                            case Ctype.MCheckComboBox:
                            case Ctype.MImageComboBox:
                            case Ctype.MMemoEdit:
                            case Ctype.MDateEdit:
                            case Ctype.MTokenEdit:
                            case Ctype.MUploadImage:
                            case Ctype.MGridLookUpEdit:
                            case Ctype.MTreeLookUpEdit:
                                dicControls.Add(editControl.SetField, editControl);
                                break;

                        }
                    }
                    else
                    {
                        if (c.Controls.Count > 0)
                        {
                            dicControls = GetAllControls(c, dicControls);
                        }
                    }
                }
            }
            return dicControls;
        }

        /// <summary>
        /// Duyệt lấy toàn bộ control nhập liệu trên form
        /// </summary>
        /// <param name="container">Control to nhất chứa tất cả các control nhập liệu</param>
        /// <param name="list">Danh sách các control nhập liệu lấy được trong vùng</param>
        /// <returns>dvthang-03.09.2021</returns>

        public static void GetAllControls<T>(Control container, ref List<T> controls) where T : Control
        {
            if (container != null)
            {
                if (controls == null)
                {
                    controls = new List<T>();
                }
                foreach (Control c in container.Controls)
                {
                    if (c is T)
                    {
                        controls.Add((T)c);
                    }
                    if (c.Controls.Count > 0)
                    {
                        GetAllControls<T>(c, ref controls);
                    }
                }
            }
        }

        #endregion

        #region"Validate control"
        /// <summary>
        /// Gán các thông tin validate cho các control
        /// </summary>
        /// <param name="lstControl">Danh sách các control trên form</param>
        public static void InitValidateControl(MDxValidationProvider validationProvider, Dictionary<string, IEditControl> dicControl)
        {
            if (dicControl != null)
            {
                foreach (var c in dicControl)
                {

                    switch (c.Value.Mtype)
                    {
                        case Ctype.MTextEdit:
                            MTextEdit txtControl = c.Value as MTextEdit;
                            if (c.Value.IsRequired)
                            {
                                ConditionValidationRule ruleRequired = new ConditionValidationRule();

                                ruleRequired.ConditionOperator = ConditionOperator.IsNotBlank;
                                ruleRequired.ErrorType = ErrorType.Warning;
                                ruleRequired.ErrorText = "Không được bỏ trống trường này.";
                                if (validationProvider != null)
                                {
                                    validationProvider.SetValidationRule((Control)c.Value, ruleRequired);
                                    validationProvider.SetIconAlignment((Control)c.Value, ErrorIconAlignment.MiddleRight);
                                }
                            }
                            if (txtControl.MaxLength > 0)
                            {
                                txtControl.Properties.MaxLength = txtControl.MaxLength;
                            }
                            //Kiểm tra địa chỉ email có hợp lệ không
                            if (txtControl.IsMail && !string.IsNullOrEmpty(Convert.ToString(txtControl.EditValue)))
                            {
                                EmailValidationRule ruleEmail = new EmailValidationRule();

                                ruleEmail.ErrorType = ErrorType.Warning;
                                ruleEmail.ErrorText = "Email không hợp lệ. Vui lòng kiểm tra lại.";
                                if (validationProvider != null)
                                {
                                    validationProvider.SetValidationRule(txtControl, ruleEmail);
                                    validationProvider.SetIconAlignment(txtControl, ErrorIconAlignment.MiddleRight);
                                }
                            }
                            break;
                        case Ctype.MSpinEdit:
                            if (c.Value.IsRequired)
                            {
                                SpinEditValidationRule ruleRequired = new SpinEditValidationRule();

                                ruleRequired.ConditionOperator = ConditionOperator.IsNotBlank;
                                ruleRequired.ErrorType = ErrorType.Warning;
                                ruleRequired.ErrorText = "Không được bỏ trống trường này.";
                                if (validationProvider != null)
                                {
                                    validationProvider.SetValidationRule((Control)c.Value, ruleRequired);
                                    validationProvider.SetIconAlignment((Control)c.Value, ErrorIconAlignment.MiddleRight);
                                }
                            }
                           
                            break;
                        case Ctype.MLookUpEdit:
                        case Ctype.MGridLookUpEdit:
                        case Ctype.MTreeLookUpEdit:
                        case Ctype.MComboBox:
                            if (c.Value.IsRequired)
                            {
                                MLookUpEditConditionValidationRule ruleRequired = new MLookUpEditConditionValidationRule();
                                ruleRequired.ErrorType = ErrorType.Warning;
                                ruleRequired.ErrorText = "Không được bỏ trống trường này.";
                                if (validationProvider != null)
                                {
                                    validationProvider.SetValidationRule((Control)c.Value, ruleRequired);
                                    validationProvider.SetIconAlignment((Control)c.Value, ErrorIconAlignment.MiddleRight);
                                }
                            }
                            break;
                        default:
                            if (c.Value.IsRequired)
                            {
                                ConditionValidationRule ruleRequired = new ConditionValidationRule();

                                ruleRequired.ConditionOperator = ConditionOperator.IsNotBlank;
                                ruleRequired.ErrorType = ErrorType.Warning;
                                ruleRequired.ErrorText = "Không được bỏ trống trường này.";
                                if (validationProvider != null)
                                {
                                    validationProvider.SetValidationRule((Control)c.Value, ruleRequired);
                                    validationProvider.SetIconAlignment((Control)c.Value, ErrorIconAlignment.MiddleRight);
                                }
                            }
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Kiểm tra control có hợp lệ hay không
        /// </summary>
        /// <param name="txtControl">Control cần kiểm tra</param>
        public static bool IsValid(MDxValidationProvider validationProvider, Control txtControl)
        {
            bool isValid = false;
            isValid = validationProvider.Validate(txtControl);
            return isValid;
        }

        /// <summary>
        /// Thực hiện validate dữ liệu nhập trên grid chi tiết
        /// </summary>
        /// <returns></returns>
        public static bool IsValidateDataChangedGridDetail(MGridEditable mGridEditable, IList dataChanged)
        {
            if (dataChanged == null || dataChanged.Count == 0)
            {
                return true;
            }
            bool isValid = true;
            MGridControl mGridControl = mGridEditable.GrdDetail;
            MGridView mGridView = (MGridView)mGridControl.FirstView;
            foreach (var data in dataChanged)
            {
                BaseEntity baseEntity = (BaseEntity)data;
                foreach (MGridColumn item in mGridView.Columns)
                {
                    string repName = item.RepName;
                    object vVal = data.GetValue<object>(item.FieldName);

                    if (item.Visible && !item.ReadOnly && item.IsRequired)
                    {
                        if (baseEntity.MTEntityState == MT.Library.Enummation.MTEntityState.Delete)
                        {
                            continue;
                        }
                        if (string.IsNullOrWhiteSpace(repName))
                        {
                            continue;
                        }
                        if (vVal == null)
                        {
                            isValid = false;
                            MMessage.ShowWarning($"Trường thông tin <{item.Caption}> không được bỏ trống.");
                            mGridView.FocusedColumn = item;
                            mGridView.FocusedRowHandle = baseEntity.RowHandle;
                            mGridView.ShowEditor();
                            return isValid;
                        }

                        switch (repName)
                        {
                            case "MRepositorySpinEdit":
                                break;
                            case "RepositoryItemTimeEdit":
                                break;
                            case "MRepositoryDateEdit":
                                break;
                            case "MRepositoryItemGridLookUpEdit":
                            case "MRepositoryItemLookUpEdit":
                            case "MRepositoryItemTreeLookUpEdit":
                            case "MRepositoryComboBox":
                                if (!baseEntity.HasIdentity() && Guid.Empty.ToString().Equals(vVal.ToString()))
                                {
                                    isValid = false;
                                    MMessage.ShowWarning($"Trường thông tin <{item.Caption}> không được bỏ trống.");
                                    mGridView.FocusedColumn = item;
                                    mGridView.FocusedRowHandle = baseEntity.RowHandle;
                                    mGridView.ShowEditor();
                                    return isValid;
                                }

                                if (baseEntity.HasIdentity() && Convert.ToInt64(vVal.ToString()) <= 0)
                                {
                                    isValid = false;
                                    MMessage.ShowWarning($"Trường thông tin <{item.Caption}> không được bỏ trống.");
                                    mGridView.FocusedColumn = item;
                                    mGridView.FocusedRowHandle = baseEntity.RowHandle;
                                    mGridView.ShowEditor();
                                    return isValid;
                                }
                                break;
                            case "MRepositoryTextEdit":
                                if (item.MaxLength > 0 && vVal.ToString().Length > item.MaxLength)
                                {
                                    isValid = false;
                                    MMessage.ShowWarning($"Trường thông tin <{item.Caption}> độ dài không được vượt quá <{item.MaxLength}> kí tự.");
                                    mGridView.FocusedColumn = item;
                                    mGridView.FocusedRowHandle = baseEntity.RowHandle;
                                    mGridView.ShowEditor();
                                    return isValid;
                                }
                                break;
                        }

                    }

                    if (item.Visible && !item.ReadOnly)
                    {
                        switch (repName)
                        {
                            case "MRepositoryTextEdit":
                                if (item.MaxLength > 0
                                    && vVal != null
                                    && !string.IsNullOrWhiteSpace(vVal.ToString())
                                    && vVal.ToString().Length > item.MaxLength)
                                {
                                    isValid = false;
                                    MMessage.ShowWarning($"Trường thông tin <{item.Caption}> độ dài không được vượt quá <{item.MaxLength}> kí tự.");
                                    mGridView.FocusedColumn = item;
                                    mGridView.FocusedRowHandle = baseEntity.RowHandle;
                                    mGridView.ShowEditor();
                                    return isValid;
                                }
                                break;
                        }
                    }
                }
            }

            return isValid;
        }


        /// <summary>
        /// Kiểm tra danh sách control có hợp lệ hay không
        /// </summary>
        /// <param name="lstControl">Danh sách control cần kiểm tra</param>
        public static bool IsValidAll(MDxValidationProvider validationProvider, Dictionary<string, IEditControl> dicControl)
        {
            bool isValid = true;
            HashSet<bool> hs = new HashSet<bool>();
            if (dicControl != null)
            {
                foreach (var c in dicControl)
                {
                    isValid = validationProvider.Validate((Control)c.Value);
                    //validate bị lỗi
                    if (!isValid)
                    {
                        hs.Add(isValid);
                    }
                }
            }

            return hs.Count == 0;
        }

        /// <summary>
        /// Clear thông báo lỗi trên form mỗi lần show form
        /// </summary>
        /// <param name="dxValidate"></param>
        public static void ClearValidateForm(MDxValidationProvider dxValidate)
        {
            for (int i = dxValidate.GetInvalidControls().Count - 1; i >= 0; i--)
            {
                dxValidate.RemoveControlError(dxValidate.GetInvalidControls()[i]);
            }

        }
        #endregion

        #region"Gán giá trị từ form vào object và ngược lại"
        /// <summary>
        /// Đẩy giá trị của control vào object
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        public static void BinddingValueIntoObject(object entity, IEditControl editControl)
        {
            if (!string.IsNullOrEmpty(editControl.SetField))
            {
                Ctype ctype = editControl.Mtype;
                switch (ctype)
                {
                    case Ctype.MTextEdit:
                        object objValue = editControl.GetValue();
                        if (objValue != null)
                        {
                            entity.SetValue(editControl.SetField, objValue.ToString().Trim());
                        }
                        else
                        {
                            entity.SetValue(editControl.SetField, string.Empty);
                        }
                        break;
                    case Ctype.MRadioGroup:
                    case Ctype.MSpinEdit:
                    case Ctype.MMemoEdit:
                    case Ctype.MTimeEdit:
                    case Ctype.MCheckBoxEdit:
                    case Ctype.MUploadImage:
                    case Ctype.MCheckComboBox:
                        entity.SetValue(editControl.SetField, editControl.GetValue());
                        break;
                    case Ctype.MLookUpEdit:
                    case Ctype.MGridLookUpEdit:
                    case Ctype.MTreeLookUpEdit:
                    case Ctype.MComboBox:
                        entity.SetValue(editControl.SetField, editControl.GetValue());
                        var pInfo = editControl.GetType().GetProperty("Text");
                        if (pInfo != null)
                        {
                            var v = pInfo.GetValue(editControl);
                            entity.SetValue(editControl.SetField + "_Ten", v);
                            entity.SetValue(editControl.SetField + "Text", v);
                        }
                        break;
                    case Ctype.MDateEdit:
                        string strValue = Convert.ToString(editControl.GetValue());
                        if (!string.IsNullOrEmpty(strValue))
                        {
                            IFormatProvider culture = new System.Globalization.CultureInfo("vi-VN", true);
                            DateTime dteValue = DateTime.Parse(strValue, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                            entity.SetValue(editControl.SetField, dteValue);
                        }
                        else
                        {
                            entity.SetValue(editControl.SetField, null);
                        }
                        break;


                }
            }

        }

        /// <summary>
        /// Đẩy giá trị của control vào Dictionary
        /// </summary>
        /// <param name="dicData"></param>
        /// <param name="value"></param>
        public static void BinddingValueIntoDictionary(ref Dictionary<string, object> dicData, IEditControl editControl)
        {
            if (!string.IsNullOrEmpty(editControl.SetField))
            {
                Ctype ctype = editControl.Mtype;
                switch (ctype)
                {

                    case Ctype.MTextEdit:
                        object objValue = editControl.GetValue();
                        if (objValue != null)
                        {
                            dicData.AddOrUpdate(editControl.SetField, objValue.ToString().Trim());
                        }
                        else
                        {
                            dicData.AddOrUpdate(editControl.SetField, string.Empty);
                        }
                        break;
                    case Ctype.MRadioGroup:
                    case Ctype.MSpinEdit:
                    case Ctype.MMemoEdit:
                    case Ctype.MTimeEdit:
                    case Ctype.MCheckBoxEdit:
                    case Ctype.MUploadImage:
                    case Ctype.MCheckComboBox:
                        dicData.AddOrUpdate(editControl.SetField, editControl.GetValue());
                        break;
                    case Ctype.MLookUpEdit:
                    case Ctype.MGridLookUpEdit:
                    case Ctype.MTreeLookUpEdit:
                    case Ctype.MComboBox:
                        dicData.AddOrUpdate(editControl.SetField, editControl.GetValue());
                        var pInfo = editControl.GetType().GetProperty("Text");
                        if (pInfo != null)
                        {
                            var v = pInfo.GetValue(editControl);
                            dicData.AddOrUpdate(editControl.SetField + "_Ten",v);
                            dicData.AddOrUpdate(editControl.SetField + "Text",v);
                        }
                        break;
                    case Ctype.MDateEdit:
                        string strValue = Convert.ToString(editControl.GetValue());
                        if (!string.IsNullOrEmpty(strValue))
                        {
                            IFormatProvider culture = new System.Globalization.CultureInfo("vi-VN", true);
                            DateTime dteValue = DateTime.Parse(strValue, culture, System.Globalization.DateTimeStyles.AssumeLocal);
                            if (!dicData.ContainsKey(editControl.SetField))
                            {
                                dicData.Add(editControl.SetField, dteValue);
                            }
                        }
                        else
                        {
                            if (!dicData.ContainsKey(editControl.SetField))
                            {
                                dicData.Add(editControl.SetField, null);
                            }
                        }
                        break;


                }
            }

        }

        /// <summary>
        /// Đẩy giá trị từ object vào control
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        public static void BinddingValueIntoControl(object entity, Dictionary<string, IEditControl> dicControls,
            Dictionary<string, IList> dicDetails = null, List<string> ignoreColumnBindding = null)
        {
            if (dicControls != null)
            {

                foreach (var control in dicControls)
                {
                    string columnName = control.Key;
                    if (ignoreColumnBindding != null
                        && ignoreColumnBindding.Count > 0
                        && ignoreColumnBindding.IndexOf(columnName) > -1)
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(columnName))
                    {
                        Ctype ctype = control.Value.Mtype;
                        switch (ctype)
                        {
                            case Ctype.MTextEdit:
                            case Ctype.MRadioGroup:
                            case Ctype.MSpinEdit:
                            case Ctype.MTimeEdit:
                            case Ctype.MCheckBoxEdit:
                            case Ctype.MLookUpEdit:
                            case Ctype.MGridLookUpEdit:
                            case Ctype.MTreeLookUpEdit:
                            case Ctype.MMemoEdit:
                            case Ctype.MComboBox:
                            case Ctype.MCheckComboBox:
                            case Ctype.MUploadImage:
                                control.Value.SetValue(entity.GetValue<object>(columnName));
                                break;
                            case Ctype.MDateEdit:
                                object vVal = entity.GetValue<object>(columnName);
                                if (vVal != null)
                                {
                                    IFormatProvider culture = new System.Globalization.CultureInfo("vi-VN", true);
                                    DateTime dteValue = DateTime.Parse(Convert.ToString(vVal), culture, System.Globalization.DateTimeStyles.AssumeLocal);
                                    control.Value.SetValue(dteValue);
                                }
                                else
                                {
                                    control.Value.SetValue(null);
                                }
                                break;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Đẩy giá trị từ object vào control
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        public static void BinddingValueIntoControl(Dictionary<string, object> dicParams, Dictionary<string, IEditControl> dicControls,
            Dictionary<string, IList> dicDetails = null, List<string> ignoreColumnBindding = null)
        {
            if (dicControls != null)
            {

                foreach (var control in dicControls)
                {
                    string columnName = control.Key;
                    if (ignoreColumnBindding != null
                        && ignoreColumnBindding.Count > 0
                        && ignoreColumnBindding.IndexOf(columnName) > -1)
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(columnName))
                    {
                        Ctype ctype = control.Value.Mtype;
                        switch (ctype)
                        {
                            case Ctype.MRadioGroup:
                            case Ctype.MTextEdit:
                            case Ctype.MSpinEdit:
                            case Ctype.MTimeEdit:
                            case Ctype.MCheckBoxEdit:
                            case Ctype.MLookUpEdit:
                            case Ctype.MGridLookUpEdit:
                            case Ctype.MTreeLookUpEdit:
                            case Ctype.MMemoEdit:
                            case Ctype.MComboBox:
                            case Ctype.MCheckComboBox:
                            case Ctype.MUploadImage:
                                control.Value.SetValue(dicParams.GetValueOfDictionary<object>(columnName));
                                break;
                            case Ctype.MDateEdit:
                                object vVal = dicParams.GetValueOfDictionary<object>(columnName);
                                if (vVal != null)
                                {
                                    IFormatProvider culture = new System.Globalization.CultureInfo("vi-VN", true);
                                    DateTime dteValue = DateTime.Parse(Convert.ToString(vVal), culture, System.Globalization.DateTimeStyles.AssumeLocal);
                                    control.Value.SetValue(dteValue);
                                }
                                else
                                {
                                    control.Value.SetValue(null);
                                }
                                break;
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Lấy về giá trị khóa chính của table
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="primaryKeyName"></param>
        /// <returns></returns>
        public static object GetIdentify(MGridControl grdControl, string primaryKeyName)
        {
            object id = null;
            GridView view = grdControl.FirstView;
            if (view.GetSelectedRows().Length > 0)
            {
                id = view.GetRowCellValue(view.GetSelectedRows()[0], primaryKeyName);
            }
            return id;
        }
        #endregion


        #region"Thiết mode(Thêm, Sửa, Hoãn...) cho các control trên form"
        /// <summary>
        /// Thực hiện set readonly cho các control trên form theo mode form
        /// </summary>
        /// <param name="bEnable">=true thì chỉ xem được giá trị trên control, ngược lại thì sửa được</param>
        /// <param name="lstControl">Danh sách các bộ control trên form cần set mode</param>
        public static void SetReaOnlyForControlByFormAction(bool bEnable, Dictionary<string, IEditControl> dicControls)
        {
            if (dicControls != null)
            {
                foreach (var control in dicControls)
                {
                    control.Value.SetReadOnly(bEnable);
                }
            }

        }
        #endregion

        #region"Xử lý lỗi chung"
        /// <summary>
        /// Tất cả các exception đều bị bắt thông qua hàm này
        /// </summary>
        /// <param name="e"></param>
        public static void HandleException(Exception e)
        {
            if (e is OverflowException)
            {
                MTControl.MMessage.ShowError("Giá trị số không được vượt quá 999,999,999,999.9999.Bạn vui lòng kiểm tra lại");
            }
            else
            {
                MMessage.ShowError("Đã có lỗi xảy ra");
            }
        }
        #endregion

        public static frmMain Main;

        public static void InvokeGuiThread(Form f, Action action)
        {
            if (!f.IsDisposed)
            {
                if (f.IsHandleCreated)
                {
                    f.BeginInvoke(action);
                }
                else
                {
                    f.HandleCreated += (sender, e) =>
                    {
                        action.Invoke();
                    };
                }
            }
        }

        public static Form OpenChildForm(Control main, Form childForm, Form currentChildForm = null)
        {

            SplashScreenManager.ShowForm(childForm, typeof(frmWaiting), true, true, false);
            try
            {
                System.Threading.Thread.Sleep(10);
                //open only form
                if (currentChildForm != null)
                {
                    currentChildForm.Close();
                    if (currentChildForm != null)
                    {
                        currentChildForm.Dispose();
                    }

                }
                currentChildForm = childForm;
                //End
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                main.Controls.Clear();
                main.Controls.Add(childForm);
                childForm.Dock = DockStyle.Fill;
                main.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
            return currentChildForm;

        }

        /// <summary>
        /// Hiển thị indicator
        /// </summary>
        /// <param name="ctl"></param>
        /// <returns></returns>
        public static IOverlaySplashScreenHandle ShowProgress(Control ctl)
        {
            try
            {
                bool useFadeIn = false;
                bool useFadeOut = false;
                Color backColor = Color.Black;
                Color foreColor = Color.Black;
                double opacity = 0.5;
                Image waitImage = FormUI.Properties.Resources.loading;
                OverlayWindowOptions options = new OverlayWindowOptions(
                    useFadeIn,
                    useFadeOut,
                    backColor,
                    foreColor,
                    opacity,
                    waitImage);
                return SplashScreenManager.ShowOverlayForm(ctl, options);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Đong indicator
        /// </summary>
        /// <param name="handle"></param>
        public static void CloseProgress(IOverlaySplashScreenHandle handle)
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(handle);
        }

        /// <summary>
        /// Hàm kiểm tra quyển của ứng dụng
        /// </summary>
        /// <returns>true: Có quyền, ngược lại không có quyền</returns>
        /// Created by: dvthang: 07.11.2020
        public static bool CheckPermission(string formId, params MT.Library.Enummation.PermissionValue[] permissionValue)
        {
            return MT.Library.Utility.CheckPermission(formId, permissionValue);
        }

        /// <summary>
        /// Hàm hiển thị thông báo lỗi
        /// </summary>
        /// <param name="ex"></param>
        public static void ShowError(Exception ex, string program)
        {
            MMessage.ShowError("Đã có lỗi xảy ra");
            LogHelper.AddError(ex, program);
        }

        /// <summary>
        /// Lấy về thể hiện của object
        /// </summary>
        /// <param name="strEntityName">Tên object </param>
        /// <returns>dvthang-05.08.2016</returns>
        public static object GetInstance(string strEntityName)
        {
            if (!string.IsNullOrEmpty(strEntityName))
            {
                Type t = Type.GetType(string.Format("MT.Data.BO.{0},MT.Data", strEntityName));
                return Activator.CreateInstance(t);
            }
            return null;
        }

        /// <summary>
        /// Lấy về form cha
        /// </summary>
        /// <typeparam name="T">Kiểu của form cha</typeparam>
        /// <param name="control">Control hiện tại</param>
        public static T GetParentOfType<T>(this Control control) where T : class
        {
            if (control?.Parent == null)
                return null;

            if (control.Parent is T parent)
                return parent;

            return GetParentOfType<T>(control.Parent);
        }

        #region "Ton Kho"
        /// <summary>
        /// Kiểm tra "Mã vạch" có còn trong Kho không
        /// Thêm mới: 
        /// Sửa:
        /// </summary>
        /// <param name="formAction">State của form</param>
        /// <param name="maVach">Mã Vạch</param>
        /// <param name="dataChanges">Data chỉnh sửa của grid detail</param>
        /// <param name="donViId">Mã đơn vị đăng nhập</param>
        /// <returns></returns>
        public static bool CheckTonKhoPhieu(int formAction, string maVach, IList dataChanges, Guid donViId)
        {
            int soLuongXoa = 0;
            if (dataChanges?.Count > 0 && formAction == (int)MT.Library.Enummation.MTEntityState.Edit)
            {
                foreach (var item in dataChanges)
                {
                    BaseEntity entity = (BaseEntity)item;
                    string oldMaVach = entity.GetValue<string>("sMaVach");
                    if (entity.MTEntityState == Enummation.MTEntityState.Delete
                        && oldMaVach.Equals(maVach))
                    {
                        soLuongXoa = (int)entity.GetValue<int>("rSoLuong");
                    }
                }
            }
            TonKhoViewModel tonKhoViewModel = GhiSoKho.GetTonKho(maVach, donViId, soLuongXoa);
            if (tonKhoViewModel == null || tonKhoViewModel.rSoLuongTon == 0)
            {
                MMessage.ShowWarning($"Mã vạch <{maVach}> trong kho đã hết");
                return false;
            }
            if (tonKhoViewModel.rSoLuongTon < 0)
            {
                MMessage.ShowWarning($"Mã vạch <{maVach}> số lượng xuất đã vượt quá số lượng nhập với số lượng là {Math.Abs(tonKhoViewModel.rSoLuongTon)}.");
                return false;
            }

            return true;
        }
        #endregion

        #region "Mã vạch"
        /// <summary>
        /// Hàm chuyển chuỗi mã vạch thành đối tượng
        /// </summary>
        /// <param name="sMaVach">Chuỗi mã vạch</param>
        /// <returns>Đối tượng chứa các thông tin trong mã vạch</returns>
        public static MaVach ConvertsMaVachToObject(string sMaVach)
        {

            /*
             * Mã vạch gồm 15 số (Nguồn(1) -->Nhà cung cấp (1)--> Mã nhóm trang bị (2) --> Mã sản phẩm (4) --> Số series (5) -->năm sx (2))
             */
            var result = MT.Library.Utility.ConvertsMaVachToObject(sMaVach);

            return new MaVach
            {
                sNguon = result.sNguon,
                sNhaCungCap = result.sNhaCungCap,
                sMaNhomTrangBi = result.sMaNhomTrangBi,
                sMaSanPham = result.sMaSanPham,
                sSoSeries=result.sSoSeries,
                sNam=result.sNam
            };
        }

        public static void ImportMaVach(Form frm,MGridControl mGridControl)
        {
            using (OpenFileDialog fdlg = new OpenFileDialog())
            {
                fdlg.Title = "Chọn tệp đính kèm";
                fdlg.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                fdlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", fdlg.Filter, "", "All Files", "*.*");
                // Code for image filter  
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                foreach (ImageCodecInfo c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    fdlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", fdlg.Filter, "|", codecName, c.FilenameExtension);
                }
                // Code for files filter  
                fdlg.Filter = fdlg.Filter + "|Excel Files (.xls ,.xlsx)|  *.xls ;*.xlsx";

                fdlg.FilterIndex = 1;
                fdlg.RestoreDirectory = true;
                fdlg.Multiselect = false;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    string filePath = fdlg.FileName;
                    XlsFile xls = new XlsFile(false);
                    xls.Open(filePath);
                    xls.ActiveSheet = 1;
                    int rowCount = xls.RowCount;
                   
                    var now = SysDateTime.Instance.Now();
                    int rowHandle = 0;
                    try
                    {
                        SplashScreenManager.ShowForm(frm, typeof(WaitFormCustom), true, true, false);

                        List<string> sMaVachs = new List<string>();
                        var col = mGridControl.FirstView.Columns["sMaVach"];
                        if (col == null)
                        {
                            return;
                        }
                      
                        for (int r = 2; r <= rowCount; r++)
                        {
                            // mGridControl.AddRow(false);
                            var value = GetCellValue(xls, r, 1, false);
                            if (string.IsNullOrWhiteSpace(value))
                            {
                                MMessage.ShowWarning("Mã vạch không được trống");
                                return;
                            }
                            if (!MT.Library.Utility.ValidsMaVach(value))
                            {
                                MMessage.ShowWarning("Mã vạch không hợp lệ");
                                return;
                            }

                            sMaVachs.Add(value);
                           
                        }

                        mGridControl.BeginUpdate();

                        MRepositoryTextEdit colsMaVach = (MRepositoryTextEdit)col.ColumnEdit;

                        int dataRowCount = mGridControl.FirstView.DataRowCount;


                        foreach (var item in sMaVachs)
                        {

                            if (colsMaVach.CustomEventEnter != null)
                            {
                                if (mGridControl.FirstView.DataRowCount == 0)
                                {
                                    mGridControl.AddRow(false);
                                    mGridControl.SetFocusCell("sMaVach", 0);
                                }
                                else
                                {
                                    var sMaVach = mGridControl.FirstView.GetRowCellValue(mGridControl.FirstView.DataRowCount - 1, "sMaVach");
                                    if(sMaVach!=null && !string.IsNullOrWhiteSpace(sMaVach.ToString().Trim()))
                                    {
                                        mGridControl.AddRow(false);                                        
                                    }
                                    mGridControl.SetFocusCell("sMaVach", mGridControl.FirstView.DataRowCount - 1);
                                }

                                mGridControl.SetValueCell(mGridControl.FirstView.FocusedRowHandle, "sMaVach", item);
                                mGridControl.SetValueCell(mGridControl.FirstView.FocusedRowHandle, "SortOrder", rowHandle);
                               
                                
                                var result = colsMaVach.CustomEventEnter(colsMaVach, new MTextEdit { EditValue = item });
                                if (!result)
                                {
                                    return;
                                }
                                rowHandle++;
                            }
                        }
                    }
                    finally
                    {
                        mGridControl.EndUpdate();
                        SplashScreenManager.CloseForm(false);
                    }
                }
            }

           
        }

        /// <summary>
        /// Lấy về giá trị của cell
        /// </summary>
        /// <param name="rowIndex">Hàng</param>
        /// <param name="colIndex">Cột</param>
        /// <param name="formatted">=true lấy giá trị đúng như format trên excel, ngược lại chỉ lấy rawvalue</param>
        public static string GetCellValue(XlsFile xls ,int rowIndex, int colIndex, bool formatted = false)
        {
            try
            {
                if (formatted)
                {
                    TRichString rs = xls.GetStringFromCell(rowIndex, colIndex);
                    return rs.Value;
                }

                int XF = 0; //This is the cell format, we will not use it here.
                object val = xls.GetCellValueIndexed(rowIndex, colIndex, ref XF);

                TFormula fmla = val as TFormula;
                if (fmla != null)
                {
                    return Convert.ToString(fmla.Result);
                }
                else
                {
                    return Convert.ToString(val);
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        #endregion
    }
}
