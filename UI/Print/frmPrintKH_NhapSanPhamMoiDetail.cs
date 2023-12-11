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
    public partial class frmPrintKH_NhapSanPhamMoiDetail : MFormXtraReport
    {
        public frmPrintKH_NhapSanPhamMoiDetail()
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

            KH_NhapSanPhamMoiDataSource kH_NhapSanPhamMoiDataSource = new KH_NhapSanPhamMoiDataSource();
            kH_NhapSanPhamMoiDataSource.InitData(id, tableName);
            objectDataSource1.DataSource = kH_NhapSanPhamMoiDataSource;
        }

        private void xrLabel30_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void DetailReportPhuKien_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }
    }
}
