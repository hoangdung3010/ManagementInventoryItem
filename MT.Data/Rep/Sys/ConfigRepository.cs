using MT.Library;
using MT.Library.UW;
using System.Collections.Generic;

namespace MT.Data.Rep
{
    public class ConfigRepository : MT.Data.Rep.BaseRepository<BaseEntity>
    {
        #region"ThuocTinh"
        #endregion
        #region "Constructor"
        public ConfigRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {
        }
        #endregion
        #region"PhuongThuc"
       
        public bool SaveConfig(Dictionary<string,string> values)
        {
            string query = $"UPDATE dbo.DBOption SET OptionValue=@OptionValue WHERE OptionID=@OptionID";
            return _unitOfWork.Execute(query, values);
        }

        public string GetOptionValueByOptionId(string optionId)
        {
            string query = $"SELECT OptionValue FROM dbo.DBOption WHERE OptionID=@OptionID";
            return _unitOfWork.QueryFirstOrDefault<string>(query, new { OptionID = optionId });
        }
        #endregion"PhuongThuc"
    }
}
