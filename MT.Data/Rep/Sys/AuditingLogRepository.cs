using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library.Extensions;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class AuditingLogRepository : MT.Data.Rep.BaseRepository<AuditingLog>
    {
        #region "Constructor"
        public AuditingLogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        /// </summary>
        /// <param name="userId">Id của user</param>
        /// <param name="searchValue">Giá trị tìm kiếm</param>
        /// Created by: dvthang: 19.12.2020
        public ResultPaging GetLogAction(ArgumentSearchLogAction argumentSearchLogAction)
        {
            ResultPaging resultPaging = new ResultPaging();
            string searchValue = MT.Library.Utility.AddChar(argumentSearchLogAction.SearchValue.Trim());

            if (MT.Library.Utility.CheckForSQLInjection(searchValue))
            {
                throw new Exception("Lỗi SQL Injection");
            }

            string sWhere = string.Empty;
            int total = 0;
            Dictionary<string, object> dicSumary = new Dictionary<string, object>();
            int start = (argumentSearchLogAction.Page-1) * argumentSearchLogAction.PageSize + 1;

            if (argumentSearchLogAction.UserId != Guid.Empty)
            {
                sWhere = $@" UserId='{argumentSearchLogAction.UserId}'";
            }

            if (String.IsNullOrWhiteSpace(sWhere))
            {
                sWhere += $@" LogTime BETWEEN '{argumentSearchLogAction.FromDate.StartOfDay().ToString("yyyy/MM/dd")}' 
                             AND '{argumentSearchLogAction.ToDate.EndOfDay().ToString("yyyy/MM/dd hh:mm:ss:fff")}'";
            }
            else
            {
                sWhere += $@" AND LogTime BETWEEN '{argumentSearchLogAction.FromDate.StartOfDay().ToString("yyyy/MM/dd")}' 
                             AND '{argumentSearchLogAction.ToDate.EndOfDay().ToString("yyyy/MM/dd hh:mm:ss:fff")}'";
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                sWhere += $@" AND (FunctionName LIKE N'%{searchValue}%' OR ActionName LIKE N'%{searchValue}%' OR Description LIKE N'%{searchValue}%' OR EntityInfo LIKE N'%{searchValue}%')";
            }
            string viewName = $@"(SELECT 0 AS IsChecked,Id,LTRIM(RTRIM(n.CreatedBy)) AS sCreatedBy,FunctionName,LogTime,ActionName,Description,EntityInfo FROM dbo.AuditingLog n 
                             WHERE {sWhere})";

            resultPaging.Data= this.GetDataPaging(viewName, "LogTime DESC", start, argumentSearchLogAction.PageSize, "", "IsChecked,Id,sCreatedBy,FunctionName,LogTime,ActionName,Description,EntityInfo", ref total, ref dicSumary);
            resultPaging.Total = total;
           
            return resultPaging;
        }
    }
}
