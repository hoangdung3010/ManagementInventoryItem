using DevExpress.XtraEditors.Controls;

namespace MTControl
{
    public class VietnameEditorsLocalizer : Localizer
    {
        public override string Language { get { return "Vietnam"; } }
        public override string GetLocalizedString(StringId id)
        {
            if (id == StringId.XtraMessageBoxAbortButtonText) return "&Hủy bỏ";
            if (id == StringId.XtraMessageBoxCancelButtonText) return "&Hủy";
            if (id == StringId.XtraMessageBoxIgnoreButtonText) return "&Chấp nhận";
            if (id == StringId.XtraMessageBoxNoButtonText) return "&Không";
            if (id == StringId.XtraMessageBoxOkButtonText) return "&Đồng ý";
            if (id == StringId.XtraMessageBoxRetryButtonText) return "&Thử lại";
            if (id == StringId.XtraMessageBoxYesButtonText) return "&Có";
            if (id == StringId.DateEditClear) return "&Xóa";
            if (id == StringId.DateEditToday) return "&Hôm nay";
            if (id == StringId.FilterClauseDoesNotEqual) return "Không bằng";
            if (id == StringId.FilterClauseDoesNotContain) return "Không chứa";
            if (id == StringId.FilterClauseEndsWith) return "Kết thúc bởi";
            if (id == StringId.FilterClauseEquals) return "Bằng";
            if (id == StringId.FilterClauseContains) return "Chứa";
            if (id == StringId.FilterClauseBetween) return "Nằm giữa";
            if (id == StringId.FilterClauseBeginsWith) return "Bắt đầu bởi";
            if (id == StringId.FilterClauseGreaterOrEqual) return "Lớn hơn hoặc bằng";
            if (id == StringId.FilterClauseGreater) return "Lớn hơn";
            if (id == StringId.FilterClauseLess) return "Nhỏ hơn";
            if (id == StringId.FilterClauseLessOrEqual) return "Nhỏ hơn hoặc bằng";
            if (id == StringId.FilterClauseLike) return "Giống";
            if (id == StringId.FilterClauseNotLike) return "Không giống";
            if (id == StringId.FilterClauseNotBetween) return "Không nằm giữa";
            if (id == StringId.FilterClauseAnyOf) return "Bất kỳ";
            if (id == StringId.FilterClauseIsNull) return "Không có giá trị";
            if (id == StringId.FilterClauseIsNotNull) return "Có giá trị";
            if (id == StringId.FilterClauseIsNotNullOrEmpty) return "Có giá trị hoặc bằng rỗng";
            if (id == StringId.FilterClauseIsNullOrEmpty) return "Không Có giá trị hoặc bằng rỗng";
            if (id == StringId.FilterClauseNoneOf) return "Là không có";
            if (id == StringId.CaptionError) return "Lỗi";
            return base.GetLocalizedString(id);
        }
    }
}
