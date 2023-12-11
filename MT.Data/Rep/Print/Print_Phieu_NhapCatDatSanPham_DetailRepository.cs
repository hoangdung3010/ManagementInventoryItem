using FlexCel.Core;
using FlexCel.Report;
using FlexCel.XlsAdapter;
using MT.Data.BO;
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
    public class Print_Phieu_NhapCaiDatSanPham_DetailRepository : BaseReportRepository
    {
        public Print_Phieu_NhapCaiDatSanPham_DetailRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        /// <summary>
        /// Thực hiện tham param vào báo cáo
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="result"></param>
        /// <param name="fr"></param>
        protected override void CustomInitParameterExcel(ConfigExcel configExcel, XlsFile result, FlexCelReport fr)
        {
            base.CustomInitParameterExcel(configExcel, result, fr);


            var piLoai = configExcel.ParametersExcel.GetValueOfDictionary("iLoai");
            if (piLoai != null)
            {
                MTControl.DisplayEnum displayEnum = MTControl.MCommon.GetDisplayEnum("iTCNhapCĐ",
                    Convert.ToInt32(piLoai.OriginValue));
                configExcel.ParametersExcel.AddOrUpdate("iLoai_Text", new MTParameter
                {
                    Value = displayEnum?.Text,
                    OriginValue = piLoai.OriginValue
                });
            }

            var piThoiGianHieuLuc = configExcel.ParametersExcel.GetValueOfDictionary("iThoiGianHieuLuc");
            if (piThoiGianHieuLuc != null)
            {
                var piDonViThoiGianHieuLuc = configExcel.ParametersExcel.GetValueOfDictionary("iDonViThoiGianHieuLuc");
                if (piDonViThoiGianHieuLuc != null)
                {
                    MTControl.DisplayEnum displayEnum = displayEnum = MTControl.MCommon.GetDisplayEnum("iDonViThoiGianHieuLuc",
                    (int)piDonViThoiGianHieuLuc.OriginValue);

                    if (displayEnum != null)
                    {
                        piThoiGianHieuLuc.Value += " " + displayEnum.Text;
                    }
                }

            }

            //SubTitle
            var pdNgayPhieu_Nhap = configExcel.ParametersExcel.GetValueOfDictionary("dNgayPhieu_Nhap");
            if (pdNgayPhieu_Nhap != null)
            {
                DateTime dNgayPhieu_Nhap = (DateTime)pdNgayPhieu_Nhap.OriginValue;
                configExcel.SubTitle = $"Ngày {dNgayPhieu_Nhap.Day.ToString().PadLeft(2, '0')}, tháng {dNgayPhieu_Nhap.Month.ToString().PadLeft(2, '0')}, năm {dNgayPhieu_Nhap.Year}";
            }
            //Tham số phụ lục
            configExcel.ParametersExcel.AddOrUpdate("PL_Title", new MTParameter
            {
                Value = "PHỤ LỤC CHI TIẾT PHIẾU NHẬP CÀI ĐẶT SẢN PHẨM"
            });

            var psMa = configExcel.ParametersExcel.GetValueOfDictionary("sMa");

            configExcel.ParametersExcel.AddOrUpdate("PL_SubTitle", new MTParameter
            {
                Value = $"Kèm theo phiếu nhập số {psMa.OriginValue}"
            });
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
            var formatCell = base.SetCustomCellFormat(configExcel, result, mTCell);
            int iPhuKien = mTCell.Row.GetRowCellValue<int>("iPhuKien");
            if (iPhuKien == 1)
            {
                formatCell.Font.Style = TFlxFontStyles.Italic;
                formatCell.Font.Size20 = 8 * 20;
            }
            else
            {
                formatCell.Font.Style = TFlxFontStyles.Bold;
                formatCell.Font.Size20 = 9 * 20;
            }
            formatCell.Indent = 0;
            switch (mTCell.Column.ColumnName)
            {
                case "sSTT":
                    formatCell.HAlignment = THFlxAlignment.center;
                    break;
                case "sDM_SanPham_Id_Ten":
                    if (iPhuKien == 1)
                    {
                        formatCell.Indent = 1;
                    }
                    break;
            }

            return formatCell;
        }

        /// <summary>
        /// Gán lại giá trị trước khi đưa vào cell
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="result"></param>
        /// <param name="mTCell"></param>
        protected override void SetCustomCellValue(ConfigExcel configExcel, XlsFile result, MTCell mTCell)
        {
            int iPhuKien = mTCell.Row.GetRowCellValue<int>("iPhuKien");
            switch (mTCell.Column.ColumnName)
            {
                case "sSTT":
                    if (iPhuKien == 1)
                    {
                        mTCell.StringValue = string.Empty;
                    }
                    break;
                case "iThoiGianBaoHanh":
                    MTControl.DisplayEnum displayEnum = displayEnum = MTControl.MCommon.GetDisplayEnum("iDonViThoiGianBaoHanh",
                    mTCell.Row.GetRowCellValue<int>("iDonViThoiGianBaoHanh"));
                    if (displayEnum != null)
                    {
                        mTCell.StringValue += $" {displayEnum.Text}";
                    }
                    break;
            }

            base.SetCustomCellValue(configExcel, result, mTCell);

        }

        /// <summary>
        /// Render dòng tổng cộng
        /// </summary>
        /// <param name="configExcel"></param>
        /// <param name="result"></param>
        /// <param name="fr"></param>
        /// <param name="data"></param>
        protected override void RenderFooterReport(ConfigExcel configExcel, XlsFile result, FlexCelReport fr, DataTable data)
        {
            base.RenderFooterReport(configExcel, result, fr, data);

            //Tính giá tổng
            var rSoLuong = Convert.ToDecimal(data.Compute("SUM(rSoLuong)", "iPhuKien=0"));
            fr.SetValue("S_rSoLuong", MT.Library.Utility.FormatValue(rSoLuong));
        }

    }
}
