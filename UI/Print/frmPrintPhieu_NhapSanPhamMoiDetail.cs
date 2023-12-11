using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using MT.Data.Rep;
using MT.Data.BO;
using MT.ObjectDataSource;
using System.Collections.Generic;

namespace FormUI
{
    public partial class frmPrintPhieu_NhapSanPhamMoiDetail : MFormXtraReport
    {
        public frmPrintPhieu_NhapSanPhamMoiDetail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý binding dữ liệu cho báo cáo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tableName"></param>
        public override void InitData(object id, string tableName)
        {
            base.InitData(id, tableName);

            Phieu_NhapSanPhamMoiDataSource phieuNhapSanPhamMoiDataSource = new Phieu_NhapSanPhamMoiDataSource();
            phieuNhapSanPhamMoiDataSource.InitData(id, tableName);
            objectDataSource2.DataSource = phieuNhapSanPhamMoiDataSource;
        }

    }
}
