using MT.Data;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class ucImportMaVach : UserControl
    {
        public ucImportMaVach()
        {
            InitializeComponent();
        }
        public MGridControl Grd { get; set; }

        public Form FrmParent { get; set; }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if(this.Grd!=null && this.FrmParent != null)
            {
                CommonFnUI.ImportMaVach(FrmParent, Grd);
            }
        }

        private void linkDownload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            string path;
            if (result == DialogResult.OK)
            {
                path = folderDlg.SelectedPath;

                string templatepath = $@"Template\Import\MaVach.xls";


                if (System.IO.File.Exists(templatepath))
                {
                    string downloadPath = System.IO.Path.Combine(path, $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}.xls");
                    System.IO.File.Copy(templatepath, downloadPath, true);

                    MTLib.Utility.OpenFile(downloadPath);
                }

            }
        }
    }
}
