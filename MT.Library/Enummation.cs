using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library
{
   public class Enummation
    {
        public enum MTEntityState
        {
           
            None = 0,
            Add = 1,
            Edit = 2,
            Delete = 3,
            View=4,
            Duplicate = 5,
            InsertOrUpdate = 6
        }

        /// <summary>
        /// Danh sách quyền của ứng dụng
        /// </summary>
        public enum PermissionValue
        {
            View = 1,
            Add = 2,
            Duplicate = 4,
            Edit = 8,
            Delete = 16,
            PheDuyet=32,
            TuChoi=64,
            In=128,
            Import=256,
            Export=512,
            Permission=1024,
            ViewPermission=2048,
            ViewDetail=4096,
            EmployeeAccessLevel=8192
        }

        /// <summary>
        /// Quyền export với B và H
        /// </summary>
        public enum PermissionExport
        {
            /// <summary>
            /// Ban cơ yếu
            /// </summary>
            BCY=1,
            /// <summary>
            /// Quân đội
            /// </summary>
            QĐ=2,
            /// <summary>
            /// Công An
            /// </summary>
            CA=4,
            /// <summary>
            /// Ngoại giao
            /// </summary>
            NN=8
        }

        public enum Period
        {
            [Description("Hôm nay")]
            HomNay = 1,
            [Description("Hôm qua")]
            HomQua = 2,
            [Description("Tuần này")]
            TuanNay = 3,
            [Description("Tuần trước")]
            TuanTruoc = 4,
            [Description("Tháng này")]
            ThangNay = 5,
            [Description("Tháng trước")]
            ThangTruoc = 6,
            [Description("Tháng 1")]
            T1 = 7,
            [Description("Tháng 2")]
            T2 = 8,
            [Description("Tháng 3")]
            T3 = 9,
            [Description("Tháng 4")]
            T4 = 10,
            [Description("Tháng 5")]
            T5 = 11,
            [Description("Tháng 6")]
            T6 = 12,
            [Description("Tháng 7")]
            T7 = 13,
            [Description("Tháng 8")]
            T8 = 14,
            [Description("Tháng 9")]
            T9 = 15,
            [Description("Tháng 10")]
            T10 = 16,
            [Description("Tháng 11")]
            T11 = 17,
            [Description("Tháng 12")]
            T12 = 18,
            [Description("Quý 1")]
            Q1 = 19,
            [Description("Quý 2")]
            Q2 = 20,
            [Description("Quý 3")]
            Q3 = 21,
            [Description("Quý 4")]
            Q4 = 22,
            [Description("Sáu tháng đầu năm")]
            SauThangDauNam = 23,
            [Description("Sáu tháng cuối năm")]
            SauThangCuoiNam = 24,
            [Description("Năm nay")]
            NamNay = 25,
            [Description("Năm trước")]
            NamTruoc = 26,
            [Description("Đầu năm đến hiện tại")]
            DauNamDenHT = 27,
            [Description("Toàn thời gian")]
            ToanThoiGian = 28,
            [Description("Tùy chọn")]
            TuyChon = 29
        }

        /// <summary>
        /// Loại lỗi
        /// </summary>
        public enum ErrorType
        {
            //Lỗi bình thường
            None=0,
            /// <summary>
            /// Lỗi dữ liệu đã phát sinh không cho xóa
            /// </summary>
            IncurrentData=1,

            /// <summary>
            /// Lỗi nghiệp vụ
            /// </summary>
            Business=2,

            /// <summary>
            /// Exception khi xóa
            /// </summary>
            Exception=3
        }
        /// <summary>
        /// 0: String;1:Guid,2: Int,3:Long,4:Decimal,5:Date,6:DateTime,7: Bool
        /// </summary>
        public enum DataType
        {
            String=0,
            Guid=1,
            Int=2,
            Long=3,
            Decimal=4,
            Date=5,
            DateTime=6,
            Bool=7
        }
    }
}
