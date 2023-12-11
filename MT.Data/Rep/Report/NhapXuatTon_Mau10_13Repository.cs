using FlexCel.Core;
using FlexCel.XlsAdapter;
using MT.Data.BO;
using MT.Library.Extensions;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.Rep
{
    public class NhapXuatTon_Mau10_13Repository: BaseReportRepository
    {
        public NhapXuatTon_Mau10_13Repository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }

        /// <summary>
        /// Custom lại format cell
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="result"></param>
        /// <param name="mTCell"></param>
        /// <returns></returns>
        protected override TFlxFormat SetCustomCellFormat(ConfigExcel configExcel, XlsFile result, MTCell mTCell)
        {
            var formatCell= base.SetCustomCellFormat(configExcel, result, mTCell);

            var vsTT = mTCell.Row.GetRowCellValue<object>("sSTT");
            int iSTT = 0;
            if (!int.TryParse(vsTT.ToString(), out iSTT))
            {
                formatCell.Font.Style = TFlxFontStyles.Bold;
            }
            switch (mTCell.Column.ColumnName)
            {
                case "sSTT":
                case "sDonViTinh":
                    formatCell.HAlignment = THFlxAlignment.center;
                    break;
                case "sDienGiai":
                    DateTime? dNgay = mTCell.Row.GetRowCellValue<DateTime?>("dNgay");
                    if (!dNgay.HasValue)
                    {
                        formatCell.Font.Style = TFlxFontStyles.Bold;
                    }
                    break;
                case "rSoluongDK":
                case "rSoluongCK":
                    formatCell.Font.Style = TFlxFontStyles.Bold;
                    break;
            }

            return formatCell;
        }

        protected override void SetCustomCellValue(ConfigExcel configExcel, XlsFile result, MTCell mTCell)
        {
            base.SetCustomCellValue(configExcel, result, mTCell);
        }
    }
}
