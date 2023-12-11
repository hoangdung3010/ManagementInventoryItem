using MT.Data.BO;
using MT.Data.ViewModels;
using MT.Library.Extensions;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Data;

namespace MT.Data.Rep
{
    public class DBOptionRepository : MT.Data.Rep.BaseRepository<DBOption>
    {
        #region "Constructor"
        public DBOptionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        #endregion

        #region"Sub/Func"
        /// <summary>
        /// Lấy về thiết lập lưu trong dboption
        /// </summary>
        /// <param name="optionId">OptionId</param>
        /// <param name="userId">Id của user</param>
        public DBOption GetDBOptionByOptionId(string optionId,Guid? userId=null)
        {
            string query = $@"select OptionValue from DBOption WHERE OptionId=@OptionId AND (UserId=@UserId OR @UserId IS NULL OR @UserId='{Guid.Empty}')";
            return _unitOfWork.QueryFirstOrDefault<DBOption>(query, new { OptionId=optionId, UserId =userId});
        }

        /// <summary>
        /// Lưu trong dboption
        /// </summary>
        /// <param name="optionId">OptionId</param>
        /// <param name="userId">Id của user</param>
        public bool SaveDBOption(string optionId,string optionValue, Guid? userId=null)
        {
            string query = string.Empty;
            var now = SysDateTime.Instance.Now();
            if (userId.HasValue)
            {
                //Lưu theo user id
                query = $@"select * from DBOption WHERE OptionId=@OptionId AND UserId=@UserId";
                var dbOption= _unitOfWork.QueryFirstOrDefault<DBOption>(query, new { OptionId = optionId, UserId = userId });
                if (dbOption != null)
                {
                    dbOption.OptionValue = optionValue;
                    dbOption.ModifiedDate = now;
                    dbOption.ModifiedBy = MT.Library.SessionData.UserName;
                    _unitOfWork.SaveEntity(dbOption, "DBOption", Library.Enummation.MTEntityState.Edit);
                }
                else
                {
                    dbOption = new DBOption
                    {
                        OptionId =optionId,
                        OptionValue=optionValue,
                        UserId=userId,
                        CreatedBy= MT.Library.SessionData.UserName,
                        ModifiedBy= MT.Library.SessionData.UserName,
                        CreatedDate=now,
                        ModifiedDate=now
                    };
                    _unitOfWork.SaveEntity(dbOption, "DBOption", Library.Enummation.MTEntityState.Add);
                }
               
            }
            else
            {
                query = $@"select * from DBOption WHERE OptionId=@OptionId";
                var dbOption = _unitOfWork.QueryFirstOrDefault<DBOption>(query, new { OptionId = optionId, UserId = userId });
                if (dbOption != null)
                {
                    dbOption.OptionValue = optionValue;
                    dbOption.ModifiedDate = now;
                    dbOption.ModifiedBy = MT.Library.SessionData.UserName;
                    dbOption.UserId = null;
                    _unitOfWork.SaveEntity(dbOption, "DBOption", Library.Enummation.MTEntityState.Edit);
                }
                else
                {
                    dbOption = new DBOption
                    {
                        OptionId = optionId,
                        OptionValue = optionValue,
                        UserId = null,
                        CreatedBy = MT.Library.SessionData.UserName,
                        ModifiedBy = MT.Library.SessionData.UserName,
                        CreatedDate = now,
                        ModifiedDate = now
                    };
                    _unitOfWork.SaveEntity(dbOption, "DBOption", Library.Enummation.MTEntityState.Add);
                }
            }

            return true;
        }
        #endregion
    }
}
