using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library;
using MT.Library.Extensions;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.Rep
{
    public class LogAccessRepository: MT.Data.Rep.BaseRepository<NHATKY>
    {
        #region "Constructor"
        public LogAccessRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        /// <summary>
        /// Lấy về danh sách log truy cập
        /// </summary>
        /// <returns></returns>
        public ResultPaging GetLogAccess(ArgumentSearchLogAccess argumentSearchLogAccess)
        {

            ResultPaging resultPaging = new ResultPaging();
            string searchValue = MT.Library.Utility.AddChar(argumentSearchLogAccess.Program.Trim());

            if (MT.Library.Utility.CheckForSQLInjection(searchValue))
            {
                throw new Exception("Lỗi SQL Injection");
            }
            string sWhere = string.Empty;
            int total = 0;
            Dictionary<string, object> dicSumary = new Dictionary<string, object>();
            int start = (argumentSearchLogAccess.Page - 1) * argumentSearchLogAccess.PageSize + 1;

            if (argumentSearchLogAccess.UserId != Guid.Empty)
            {
                sWhere = $@" UserName='{argumentSearchLogAccess.UserName.Trim()}'";
            }

            if (String.IsNullOrWhiteSpace(sWhere))
            {
                sWhere += $@" Datein BETWEEN '{argumentSearchLogAccess.FromDate.StartOfDay().ToString("yyyy/MM/dd")}' 
                             AND '{argumentSearchLogAccess.ToDate.EndOfDay().ToString("yyyy/MM/dd hh:mm:ss:fff")}'";
            }
            else
            {
                sWhere += $@" AND Datein BETWEEN '{argumentSearchLogAccess.FromDate.StartOfDay().ToString("yyyy/MM/dd")}' 
                             AND '{argumentSearchLogAccess.ToDate.EndOfDay().ToString("yyyy/MM/dd hh:mm:ss:fff")}'";
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                sWhere += $@" AND (Program LIKE N'%{searchValue}%')";
            }
            string viewName = $@"(SELECT 0 AS IsChecked,Id,LTRIM(RTRIM(n.UserName)) AS UserName,Program ,
                             Timein,Datein,Timeout,Dateout,CONVERT(DATETIME,ISNULL(Timeuse,0)/86400.0)+'1970' as Dateuse FROM dbo.NHATKY n 
                             WHERE {sWhere})";


            resultPaging.Data = this.GetDataPaging(viewName, "Datein DESC", start, argumentSearchLogAccess.PageSize, "", @"IsChecked,Id,UserName,Program,
                                Timein,Datein,Timeout,Dateout,Dateuse", ref total, ref dicSumary);
            resultPaging.Total = total;

            return resultPaging;

        }
    }
}
