using MT.Data.BO;
using MTControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Dictionary
{
    public partial class frmTepDinhKemDetail : MFormBase
    {
        TepDinhKem _tepDinhKem = new TepDinhKem();

        private MDxValidationProvider ValidationProvider = null;
        private Dictionary<string, IEditControl> dicControls;

        public Dictionary<string, IEditControl> DicControls
        {
            get { return dicControls; }
            set { dicControls = value; }
        }
        public frmTepDinhKemDetail()
        {
            InitializeComponent();
            dicControls = new Dictionary<string, IEditControl>();
            ValidationProvider = new MDxValidationProvider();
        }

        /// <summary>
        /// Lấy dữ liệu hiện tại của form
        /// </summary>
        /// <returns></returns>
        public TepDinhKem GetCurrentData()
        {
            return _tepDinhKem;
        }

        /// <summary>
        /// Đồng ý chọn tệp đính kèm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            bool isValid = CommonFnUI.IsValidAll(ValidationProvider, dicControls);
            if (!isValid)
            {

                return;
            }

            float fSize = float.Parse(spinEditSize.EditValue.ToString());

            //Chỉ cho upload file max=10MB
            float fSizeMB = ConvertBytesToKb(fSize);
            if (fSizeMB > 10)
            {
                MMessage.ShowWarning("Bạn chỉ được thêm tệp đính kèm có dung lượng tối đa 10(MB)");
                return;
            }

            if (dicControls != null)
            {
                foreach (var c in dicControls)
                {
                    CommonFnUI.BinddingValueIntoObject(this._tepDinhKem, c.Value);
                }
                this._tepDinhKem.MTEntityState = MT.Library.Enummation.MTEntityState.Add;
                FileInfo fi = new FileInfo(txtChooseFile.Text);
                this._tepDinhKem.sExtention = fi.Extension;
                this._tepDinhKem.sTenGoc = System.IO.Path.GetFileName(fi.Name);
                byte[] bytes = System.IO.File.ReadAllBytes(txtChooseFile.Text);
                this._tepDinhKem.byBinaryData = bytes;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Chuyển định dạng bytes to KB
        /// </summary>
        /// <param name="fSize"></param>
        /// <returns></returns>
        private float ConvertBytesToKb(float fSize)
        {
            float fSizeKb = (float)Math.Round(fSize / 1024, 0);
            return fSizeKb;
        }

        /// <summary>
        /// Hủy hành động trên form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fdlg = new OpenFileDialog())
            {
                fdlg.Title = "Chọn tệp đính kèm";
                fdlg.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                fdlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", fdlg.Filter, "", "All Files", "*.*");
                // Code for image filter  
                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                foreach (ImageCodecInfo c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    fdlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", fdlg.Filter, "|", codecName, c.FilenameExtension);
                }
                // Code for files filter  
                fdlg.Filter = fdlg.Filter + "|CSV Files (*.csv)|*.csv";
                fdlg.Filter = fdlg.Filter + "|Excel Files (.xls ,.xlsx)|  *.xls ;*.xlsx";
                fdlg.Filter = fdlg.Filter + "|PDF Files (.pdf)|*.pdf";
                fdlg.Filter = fdlg.Filter + "|Text Files (*.txt)|*.txt";
                fdlg.Filter = fdlg.Filter + "|Word Files (.docx ,.doc)|*.docx;*.doc";
                fdlg.Filter = fdlg.Filter + "|XML Files (*.xml)|*.xml";

                fdlg.FilterIndex = 1;
                fdlg.RestoreDirectory = true;
                fdlg.Multiselect = false;
                if (fdlg.ShowDialog() == DialogResult.OK)
                {
                    string filePath = fdlg.FileName;
                    txtChooseFile.Text = filePath;
                    FileInfo fi = new FileInfo(filePath);
                    float fSizeMB = ConvertBytesToKb(fi.Length);
                    spinEditSize.EditValue = fSizeMB;
                    txtsTen.EditValue = System.IO.Path.GetFileNameWithoutExtension(fi.Name);
                }
            }
        }

        private void frmTepDinhKemDetail_Load(object sender, EventArgs e)
        {
            dicControls = CommonFnUI.GetAllControls(this, new Dictionary<string, IEditControl>());
            CommonFnUI.InitValidateControl(ValidationProvider, dicControls);
            //Clear validate lỗi trên form
            CommonFnUI.ClearValidateForm(this.ValidationProvider);
        }
    }
}
