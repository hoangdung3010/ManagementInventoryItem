using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MTControl
{
    public class MUploadImage : DevExpress.XtraEditors.XtraUserControl, IControl, IEditControl
    {
        public MSplitContainerControl mSplitContainerControl1;
        public MSplitContainerControl mSplitContainerControl2;
        public MPictureEdit ptEditImage;
        private MSimpleButton btnDelImage;
        private MSimpleButton btnSelectImage;
        public MLabel mLabel1;
        public MGroupControl mGroupControl1;
        #region"Declare"
        private string decription;
        private int widthImage = 160;

        public int WidthImage
        {
            get { return widthImage; }
            set { widthImage = value; }
        }
        private int heightImage = 120;

        public int HeightImage
        {
            get { return heightImage; }
            set { heightImage = value; }
        }

        private string columnName;

        public string SetField
        {
            get { return columnName; }
            set { columnName = value; }
        }

        /// <summary>
        /// Tự gán value bằng tay nếu =true
        /// </summary>
        private bool isSetValueManual;

        public bool IsSetValueManual
        {
            get { return isSetValueManual; }
            set { isSetValueManual = value; }
        }
        /// <summary>
        /// Sử dụng để validate không cho bỏ trống
        /// </summary>
        private bool isRequired;

        [DefaultValue(false)]
        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }
        #endregion
        #region"Contructor"
        public MUploadImage()
        {
            InitializeComponent();
            MCommon.SetSkins();
        }
        private void InitializeComponent()
        {
            this.mSplitContainerControl1 = new MTControl.MSplitContainerControl();
            this.mGroupControl1 = new MTControl.MGroupControl();
            this.mSplitContainerControl2 = new MTControl.MSplitContainerControl();
            this.ptEditImage = new MTControl.MPictureEdit();
            this.btnDelImage = new MTControl.MSimpleButton();
            this.btnSelectImage = new MTControl.MSimpleButton();
            this.mLabel1 = new MTControl.MLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mSplitContainerControl1)).BeginInit();
            this.mSplitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mGroupControl1)).BeginInit();
            this.mGroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mSplitContainerControl2)).BeginInit();
            this.mSplitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptEditImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mSplitContainerControl1
            // 
            this.mSplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.mSplitContainerControl1.Horizontal = false;
            this.mSplitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.mSplitContainerControl1.Name = "mSplitContainerControl1";
            this.mSplitContainerControl1.Panel1.Controls.Add(this.mGroupControl1);
            this.mSplitContainerControl1.Panel1.Text = "Panel1";
            this.mSplitContainerControl1.Panel2.Controls.Add(this.mLabel1);
            this.mSplitContainerControl1.Panel2.Text = "Panel2";
            this.mSplitContainerControl1.Size = new System.Drawing.Size(198, 193);
            this.mSplitContainerControl1.SplitterPosition = 31;
            this.mSplitContainerControl1.TabIndex = 0;
            this.mSplitContainerControl1.Text = "mSplitContainerControl1";
            // 
            // mGroupControl1
            // 
            this.mGroupControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mGroupControl1.Appearance.Options.UseForeColor = true;
            this.mGroupControl1.Controls.Add(this.mSplitContainerControl2);
            this.mGroupControl1.Description = null;
            this.mGroupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mGroupControl1.Location = new System.Drawing.Point(0, 0);
            this.mGroupControl1.Name = "mGroupControl1";
            this.mGroupControl1.Size = new System.Drawing.Size(198, 157);
            this.mGroupControl1.TabIndex = 0;
            this.mGroupControl1.Text = "Ảnh đại diện";
            // 
            // mSplitContainerControl2
            // 
            this.mSplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mSplitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.mSplitContainerControl2.Location = new System.Drawing.Point(2, 20);
            this.mSplitContainerControl2.Name = "mSplitContainerControl2";
            this.mSplitContainerControl2.Panel1.Controls.Add(this.ptEditImage);
            this.mSplitContainerControl2.Panel1.Text = "Panel1";
            this.mSplitContainerControl2.Panel2.Controls.Add(this.btnDelImage);
            this.mSplitContainerControl2.Panel2.Controls.Add(this.btnSelectImage);
            this.mSplitContainerControl2.Panel2.Text = "Panel2";
            this.mSplitContainerControl2.Size = new System.Drawing.Size(194, 135);
            this.mSplitContainerControl2.SplitterPosition = 25;
            this.mSplitContainerControl2.TabIndex = 0;
            this.mSplitContainerControl2.Text = "mSplitContainerControl2";
            // 
            // ptEditImage
            // 
            this.ptEditImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptEditImage.IsSetValueManual = false;
            this.ptEditImage.Location = new System.Drawing.Point(0, 0);
            this.ptEditImage.Name = "ptEditImage";
            this.ptEditImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ptEditImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.ptEditImage.Size = new System.Drawing.Size(164, 135);
            this.ptEditImage.TabIndex = 0;
            // 
            // btnDelImage
            // 
            this.btnDelImage.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnDelImage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelImage.Appearance.Options.UseFont = true;
            this.btnDelImage.Appearance.Options.UseForeColor = true;
            this.btnDelImage.Description = null;
            this.btnDelImage.Image = global::MTControl.Properties.Resources.delete;
            this.btnDelImage.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnDelImage.Location = new System.Drawing.Point(-1, 32);
            this.btnDelImage.Name = "btnDelImage";
            this.btnDelImage.Size = new System.Drawing.Size(26, 24);
            this.btnDelImage.TabIndex = 1;
            this.btnDelImage.ToolTip = "Xóa";
            this.btnDelImage.Click += new System.EventHandler(this.btnDelImage_Click);
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSelectImage.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSelectImage.Appearance.Options.UseFont = true;
            this.btnSelectImage.Appearance.Options.UseForeColor = true;
            this.btnSelectImage.Description = null;
            this.btnSelectImage.Location = new System.Drawing.Point(-1, 3);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(26, 24);
            this.btnSelectImage.TabIndex = 0;
            this.btnSelectImage.Text = "...";
            this.btnSelectImage.ToolTip = "Chọn ảnh";
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // mLabel1
            // 
            this.mLabel1.AllowHtmlString = true;
            this.mLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.mLabel1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.mLabel1.Description = null;
            this.mLabel1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.mLabel1.LineVisible = true;
            this.mLabel1.Location = new System.Drawing.Point(0, -4);
            this.mLabel1.Name = "mLabel1";
            this.mLabel1.Size = new System.Drawing.Size(195, 32);
            this.mLabel1.TabIndex = 0;
            this.mLabel1.Text = "Chọn các ảnh có định dạng<br>(.jpg, .jpeg, .png, .gif)";
            // 
            // MUploadImage
            // 
            this.AllowDrop = true;
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.Controls.Add(this.mSplitContainerControl1);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "MUploadImage";
            this.Size = new System.Drawing.Size(198, 193);
            ((System.ComponentModel.ISupportInitialize)(this.mSplitContainerControl1)).EndInit();
            this.mSplitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mGroupControl1)).EndInit();
            this.mGroupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mSplitContainerControl2)).EndInit();
            this.mSplitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptEditImage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        #region"Sub/Func"

        /// <summary>
        /// Hiển thị ảnh trên control
        /// </summary>
        /// <param name="path"></param>
        public void SetValueByte(byte[] bytes)
        {
            try
            {
                if (bytes != null && bytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ms.Position = 0;
                        ms.Write(bytes, 0, bytes.Length);
                        this.ptEditImage.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    this.ptEditImage.Image = null;
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// Gán xem control có được sửa không
        /// </summary>
        /// <param name="bValue"></param>
        public void SetReadOnly(bool bValue)
        {
            btnSelectImage.Enabled = !bValue;
            btnDelImage.Enabled = !bValue;
        }
        #endregion
        #region"Ovrrides"

        /// <summary>
        /// ovrides lại hàm render control
        /// </summary>
        /// dvthang-17.07.2016
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetFont();
        }
        #endregion
        #region"Implement"
        [Description("ImageUpLoadControl")]
        [Category("MTControl")]
        public string Description
        {
            get
            {
                return decription;
            }
            set
            {
                decription = value;
            }
        }

        /// <summary>
        /// Thiết lập font cho control
        /// </summary>
        public void SetFont()
        {
            this.BackColor = MColor.BackColorEditor;
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        #endregion

        #region"Event"
        /// <summary>
        /// Bắt event chọn ảnh đại diện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectImage_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Tệp ảnh (.jpg)|*.jpg|(.jpeg)|*.jpeg|(.png)|*.png|(.gif)|*.gif";

            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.ptEditImage.Image = Image.FromFile(dlg.FileName);
            }
        }

        /// <summary>
        /// Xóa ảnh đã chọn đi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelImage_Click(object sender, EventArgs e)
        {
            this.ptEditImage.Image = null;
        }
        #endregion
        #region"Implement"
        /// <summary>
        /// Kiểu của control
        /// </summary>
        /// Create by: dvthang:04.10.2017
        public Ctype Mtype
        {
            get { return Ctype.MUploadImage; }
        }

        /// <summary>
        /// Thiết lập giá trị cho control
        /// </summary>
        /// <param name="value">Giá trị cần gán</param>
        /// Create by: dvthang:25.10.2017
        public void SetValue(object value)
        {
            if (!this.IsSetValueManual)
            {
                try
                {
                    string strPath = Convert.ToString(value);
                    if (File.Exists(strPath))
                    {
                        this.ptEditImage.Image = Image.FromFile(strPath);
                    }
                    else
                    {
                        this.ptEditImage.Image = null;
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Lấy giá trị của control
        /// </summary>
        /// <returns>Trả về giá trị của control</returns>
        /// Create by: dvthang:25.10.2017
        public object GetValue()
        {
            try
            {
                if (this.ptEditImage.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Bitmap bm = new Bitmap(this.ptEditImage.Image, widthImage, heightImage);
                        bm.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                MMessage.ShowError(ex.Message);
            }
            return null;
        }
        #endregion

    }
}
