using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Library.BO
{
    public class ResultData
    {
        /// <summary>
        /// =true kết quả thành công, ngược lại thất bại
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Lỗi thông báo cho người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Lỗi thông báo cho dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Dữ liệu trả về thêm cho kết quả, tùy từng tính hướng
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gán lỗi
        /// </summary>
        public void SetError(Exception ex,string customMsg="")
        {
            this.Success = false;
            this.DevMsg = $"Message: {ex.Message},StackTrace: {ex.StackTrace}";
            if(!string.IsNullOrEmpty(customMsg) && customMsg.Trim().Length > 0)
            {
                this.UserMsg = customMsg;
            }
            else
            {
                this.UserMsg = ex.Message;
            }
            MT.Library.Log.LogHelper.AddError(ex);
        }
    }
}
