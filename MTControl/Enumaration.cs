using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MTControl
{
    public enum DateRangeEnum
    {
        Today=0,//Hôm nay
        Yesterday=1,//Hôm qua
        ThisWeek=2,//Tuần này
        LastWeek=3,//Tuần trước
        ThisMonth=4,//Tháng này
        LastMonth=5,//Tháng trước
        ThisQuater=6,//Quý này
        LastQuater=7,// Quý trước
        ThisYear=6,//Năm nay
        LastYear=7//Năm trước
    }

    public enum DataTypeColumn
    {
        MemoEdit = 0,
        DateEdit = 1,
        CheckEdit = 2,
        SpinEdit = 3,
        TimeEdit = 4,
        ComboBox = 5,
        GridLookUpEdit = 6,
        HyperLinkEdit = 7,
        LookUpEdit = 8,
        ImageComboBox = 9,
        Button=10,
        None=11,
        TreeLookUpEdit = 12,
        CheckedComboBox = 13
    }
    /// <summary>
    /// Hành động đang thực hiện là gì(Thêm, sửa, xóa, xem,deplucate)
    /// </summary>
    public enum FormAction
    {
        None = 0,
        Add = 1,
        Edit = 2,
        Delete = 3,
        View = 4,
        Duplicate = 5
    }

    /// <summary>
    /// Các kiểu của định dạng số
    /// </summary>
    public enum FormatType
    {
        None=0,
        QuanlityInt=1,
        QuanlityFloat = 2,
        UnitPrice = 3,
        Amount = 4,
        Coefficient=5,
        Year=6,
        QuanlityFloat_0 = 7,
        QuanlityFloat_1 = 8
    }

    /// <summary>
    /// Các kiểu của định dạng số
    /// </summary>
    public enum Ctype
    {
        None=0,
        MTextEdit = 1,
        MSpinEdit = 2,
        MTimeEdit = 3,
        MLookUpEdit = 4,
        MGridLookUpEdit = 5,
        MTreeLookUpEdit = 6,
        MGridEditable = 7,
        MComboBox=8,
        MCheckBoxEdit=9,
        MComboBoxTree=10,
        MListBox=11,
        MDateEdit=12,
        MMemoEdit=13,
        MTokenEdit=14,
        MUploadImage=15,
        MGridControl=16,
        MSearchLookUpEdit=17,
        MSimpleButton=18,
        MPopupContainerControl=19,
        MAccordionControl=20,
        MGroupControl=21,
        MNavBarControl=22,
        MXtraPanel=23,
        MRibbonStatusBar=24,
        MTileNavPane=25,
        MLabel=26,
        MTreeView=27,
        MDropDownButton=28,
        MCheckComboBox=29,
        MCalculator=30,
        MHyperlink=31,
        MRadioGroup=32,
        MImageComboBox=33,
        MPopupContainerEdit=34,
        MButtonEdit=35,
        MRibbonControl=36,
        MLinkFormVoucher = 37
    }

    public enum MCommandName
    {
        [Description("Thêm mới")]
        AddNew = 1,
        [Description("Nhân bản")]
        Duplicate = 2,
        [Description("Xem")]
        View = 4,
        [Description("Sửa")]
        Edit = 8,
        [Description("Xóa")]
        Delete = 16,
        [Description("Làm mới")]
        Refresh = 32,
        [Description("Sắp xếp")]
        SortOrder = 64,
        [Description("In")]
        Print = 128,
        [Description("Xuất excel")]
        Excel = 256,
        [Description("Đóng")]
        Close = 512,
        [Description("Hủy bỏ")]
        Cancel = 1024,
        [Description("Trợ giúp")]
        Help = 2048,
        [Description("Phê duyệt")]
        Approve =4096,
        [Description("Từ chối")]
        Reject = 8192,
        [Description("Nhập khẩu")]
        Import =16384
    }
}
