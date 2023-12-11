using DevExpress.XtraEditors;
using FlexCel.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Base
{
    public partial class MFormPDFViewer : XtraForm
    {
        private ExcelFile excelFile;
        private string sPath_Out = "";
        public MFormPDFViewer(ExcelFile excelFile,string sPath_Out)
        {
            InitializeComponent();
            this.excelFile = excelFile;
            this.sPath_Out = sPath_Out;
        }

        private void MFormPDFViewer_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.sPath_Out))
            {
                return;
            }
            if (System.IO.File.Exists(this.sPath_Out))//
            {
                pdfViewer.LoadDocument(sPath_Out);
                this.pdfZoom100CheckItem1.Checked = true;
            }
        }

        private void MFormPDFViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Hủy file
            pdfViewer.DocumentFilePath = "";
            //Xóa File cũ đi
            MT.Library.FileHelper.DeleteFile(sPath_Out);
        }
    }
}
