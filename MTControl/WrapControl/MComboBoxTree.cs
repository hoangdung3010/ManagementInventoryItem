using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace MTControl
{
    public class MComboBoxTree : DevExpress.XtraEditors.XtraUserControl
    {
       
        #region"Declare"
        //Danh sách các cột hiện thị trên tree
        private string columns;

        public string Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        private string displayValue;

        public string DisplayValue
        {
            get { return displayValue; }
            set { displayValue = value; }
        }

        private string valueMember;
        private MLayoutControl mLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private MPopupContainerEdit mPopupContainerEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private MTreeView mTreeViewControl;
        private MPopupContainerControl mPopupContainerControl;

        public string ValueMember
        {
            get { return valueMember; }
            set { valueMember = value; }
        }

        private object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private string columnName;

        public string ColumnName
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
        #endregion
        #region"Contructor"
        public MComboBoxTree():base()
        {
            InitializeComponent();
            SetFont();
            mTreeViewControl.OptionsSelection.EnableAppearanceFocusedCell = false;
            mTreeViewControl.OptionsSelection.EnableAppearanceFocusedRow = true;
            mTreeViewControl.OptionsBehavior.Editable=false;
            mTreeViewControl.DoubleClick+=new System.EventHandler(mTreeViewControl_DoubleClick);
            mTreeViewControl.KeyDown += new System.Windows.Forms.KeyEventHandler(mTreeViewControl_KeyDown);
            Init();
            this.AutoSize = false;
            this.Height = MHeight.mscEditControlHeight;
            this.mPopupContainerEdit.Properties.AutoHeight = false;
            this.mPopupContainerEdit.Height = MHeight.mscEditControlHeight;
        }
        #endregion
        #region"Sub/Func"
        private void Init()
        {
            if (!string.IsNullOrEmpty(Columns))
            {
                string[] strCols = Columns.Split(new char[1] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
                mTreeViewControl.Columns.Clear();
                foreach (string fieldName in strCols)
                {
                    TreeListColumn treeColumn = new TreeListColumn();
                    treeColumn.Caption = fieldName;
                    treeColumn.FieldName = fieldName;
                    treeColumn.Visible = true;
                    mTreeViewControl.Columns.Add(treeColumn);
                }
            }
            mPopupContainerControl.Controls.Add(mTreeViewControl);
            mPopupContainerControl.Dock = DockStyle.Fill;
            mTreeViewControl.Dock = DockStyle.Fill;
            mPopupContainerEdit.Properties.PopupControl = mPopupContainerControl;
           
        }

        private void InitializeComponent()
        {
            this.mLayoutControl1 = new MTControl.MLayoutControl();
            this.mPopupContainerEdit = new MTControl.MPopupContainerEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.mTreeViewControl = new MTControl.MTreeView();
            this.mPopupContainerControl = new MTControl.MPopupContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl1)).BeginInit();
            this.mLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mPopupContainerEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeViewControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPopupContainerControl)).BeginInit();
            this.mPopupContainerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // mLayoutControl1
            // 
            this.mLayoutControl1.Controls.Add(this.mPopupContainerEdit);
            this.mLayoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.mLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.mLayoutControl1.Name = "mLayoutControl1";
            this.mLayoutControl1.Root = this.layoutControlGroup1;
            this.mLayoutControl1.Size = new System.Drawing.Size(693, 26);
            this.mLayoutControl1.TabIndex = 0;
            this.mLayoutControl1.Text = "mLayoutControl1";
            // 
            // mPopupContainerEdit
            // 
            this.mPopupContainerEdit.Description = null;
            this.mPopupContainerEdit.Location = new System.Drawing.Point(2, 2);
            this.mPopupContainerEdit.Name = "mPopupContainerEdit";
            this.mPopupContainerEdit.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mPopupContainerEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mPopupContainerEdit.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mPopupContainerEdit.Properties.Appearance.Options.UseBackColor = true;
            this.mPopupContainerEdit.Properties.Appearance.Options.UseFont = true;
            this.mPopupContainerEdit.Properties.Appearance.Options.UseForeColor = true;
            this.mPopupContainerEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.mPopupContainerEdit.Size = new System.Drawing.Size(689, 22);
            this.mPopupContainerEdit.StyleController = this.mLayoutControl1;
            this.mPopupContainerEdit.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(693, 26);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.mPopupContainerEdit;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(54, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(693, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // mTreeViewControl
            // 
            this.mTreeViewControl.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.BandPanel.Options.UseFont = true;
            this.mTreeViewControl.Appearance.Caption.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.Caption.Options.UseFont = true;
            this.mTreeViewControl.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.mTreeViewControl.Appearance.Empty.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.Empty.Options.UseFont = true;
            this.mTreeViewControl.Appearance.EvenRow.BackColor = System.Drawing.Color.White;
            this.mTreeViewControl.Appearance.EvenRow.BackColor2 = System.Drawing.Color.White;
            this.mTreeViewControl.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.mTreeViewControl.Appearance.EvenRow.Options.UseBackColor = true;
            this.mTreeViewControl.Appearance.EvenRow.Options.UseFont = true;
            this.mTreeViewControl.Appearance.EvenRow.Options.UseForeColor = true;
            this.mTreeViewControl.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.FilterPanel.Options.UseFont = true;
            this.mTreeViewControl.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.FixedLine.Options.UseFont = true;
            this.mTreeViewControl.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.mTreeViewControl.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.mTreeViewControl.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.mTreeViewControl.Appearance.FocusedCell.Options.UseBackColor = true;
            this.mTreeViewControl.Appearance.FocusedCell.Options.UseFont = true;
            this.mTreeViewControl.Appearance.FocusedCell.Options.UseForeColor = true;
            this.mTreeViewControl.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.mTreeViewControl.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.mTreeViewControl.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.mTreeViewControl.Appearance.FocusedRow.Options.UseBackColor = true;
            this.mTreeViewControl.Appearance.FocusedRow.Options.UseFont = true;
            this.mTreeViewControl.Appearance.FocusedRow.Options.UseForeColor = true;
            this.mTreeViewControl.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.FooterPanel.Options.UseFont = true;
            this.mTreeViewControl.Appearance.GroupButton.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.GroupButton.Options.UseFont = true;
            this.mTreeViewControl.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.GroupFooter.Options.UseFont = true;
            this.mTreeViewControl.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.mTreeViewControl.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.mTreeViewControl.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.mTreeViewControl.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.mTreeViewControl.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.mTreeViewControl.Appearance.HeaderPanel.Options.UseFont = true;
            this.mTreeViewControl.Appearance.HeaderPanelBackground.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.HeaderPanelBackground.Options.UseFont = true;
            this.mTreeViewControl.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.mTreeViewControl.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(199)))), ((int)(((byte)(227)))));
            this.mTreeViewControl.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.mTreeViewControl.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.mTreeViewControl.Appearance.HideSelectionRow.Options.UseFont = true;
            this.mTreeViewControl.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.mTreeViewControl.Appearance.HorzLine.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.HorzLine.Options.UseFont = true;
            this.mTreeViewControl.Appearance.OddRow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mTreeViewControl.Appearance.OddRow.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.mTreeViewControl.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.mTreeViewControl.Appearance.OddRow.Options.UseBackColor = true;
            this.mTreeViewControl.Appearance.OddRow.Options.UseFont = true;
            this.mTreeViewControl.Appearance.OddRow.Options.UseForeColor = true;
            this.mTreeViewControl.Appearance.Preview.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.Preview.Options.UseFont = true;
            this.mTreeViewControl.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.Row.Options.UseFont = true;
            this.mTreeViewControl.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.SelectedRow.Options.UseFont = true;
            this.mTreeViewControl.Appearance.TreeLine.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.TreeLine.Options.UseFont = true;
            this.mTreeViewControl.Appearance.VertLine.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.mTreeViewControl.Appearance.VertLine.Options.UseFont = true;
            this.mTreeViewControl.Description = null;
            this.mTreeViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTreeViewControl.Location = new System.Drawing.Point(0, 0);
            this.mTreeViewControl.Name = "mTreeViewControl";
            this.mTreeViewControl.OptionsBehavior.ReadOnly = true;
            this.mTreeViewControl.OptionsCustomization.AllowColumnMoving = false;
            this.mTreeViewControl.OptionsMenu.EnableColumnMenu = false;
            this.mTreeViewControl.OptionsView.EnableAppearanceEvenRow = true;
            this.mTreeViewControl.OptionsView.EnableAppearanceOddRow = true;
            this.mTreeViewControl.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.mTreeViewControl.Size = new System.Drawing.Size(693, 292);
            this.mTreeViewControl.TabIndex = 1;
            // 
            // mPopupContainerControl
            // 
            this.mPopupContainerControl.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mPopupContainerControl.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mPopupContainerControl.Appearance.Options.UseBackColor = true;
            this.mPopupContainerControl.Appearance.Options.UseForeColor = true;
            this.mPopupContainerControl.Controls.Add(this.mTreeViewControl);
            this.mPopupContainerControl.Description = null;
            this.mPopupContainerControl.Location = new System.Drawing.Point(0, 26);
            this.mPopupContainerControl.Name = "mPopupContainerControl";
            this.mPopupContainerControl.Size = new System.Drawing.Size(693, 292);
            this.mPopupContainerControl.TabIndex = 2;
            // 
            // MComboBoxTree
            // 
            this.AllowDrop = true;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseTextOptions = true;
            this.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.Controls.Add(this.mPopupContainerControl);
            this.Controls.Add(this.mLayoutControl1);
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "MComboBoxTree";
            this.AutoSize = false;
            this.Size = new System.Drawing.Size(693, 26);
            ((System.ComponentModel.ISupportInitialize)(this.mLayoutControl1)).EndInit();
            this.mLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mPopupContainerEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTreeViewControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mPopupContainerControl)).EndInit();
            this.mPopupContainerControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        /// <summary>
        /// Gán data cho combo
        /// </summary>
        /// <param name="data"></param>
        public void SetDataSource(object data)
        {
            mTreeViewControl.DataSource=data;
        }

        public void SetFont()
        {
            this.BackColor = MColor.BackColorEditor;
            this.ForeColor = MColor.ColorLabel;
            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);

            mPopupContainerEdit.BackColor = MColor.BackColorEditor;
            mPopupContainerEdit.ForeColor = MColor.ColorLabel;
            mPopupContainerEdit.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Lấy về giá trị được chọn trên combo
        /// </summary>
        /// <returns></returns>
        /// dvthang-10.07.2016
        public object GetValue()
        {
            return mPopupContainerEdit.EditValue;
        }
        /// <summary>
        /// Gán value cho control
        /// </summary>
        /// <param name="value"></param>
        /// dvthang-10.07.2016
        public void SetValue(object value)
        {
            mPopupContainerEdit.EditValue = value;
        }
        #endregion
        #region"Ovrrides"
        protected override void OnCreateControl()
        {
            this.Height = 30;
            this.Dock = DockStyle.Top;


            base.OnCreateControl();

            this.Font = new Font(MFont.mscSysFontName, MSize.mscSysFontSize, FontStyle.Regular, GraphicsUnit.Pixel);

        }
        /// <summary>
        /// Thực hiện nhảy Tab khi nhấn Enter
        /// </summary>
        /// <param name="e"></param>
        /// CreatebBy-laipv.19.08.2017
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
        #endregion
        #region"Implement"

        #endregion

        #region"Event"
        /// <summary>
        /// Sự kiện kích dúp vào row trên treelist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// double click vào row thì gán value cho combo
        private void mTreeViewControl_DoubleClick(object sender, System.EventArgs e)
        {
            var nodes = mTreeViewControl.Selection;
            var text = string.Empty;
            foreach (TreeListNode node in nodes)
            {
                text = node.GetDisplayText(this.displayValue);
                value = node.GetValue(this.valueMember);
                break;
            }
            mPopupContainerEdit.EditValue = text;
            mPopupContainerEdit.ClosePopup();
        }

        /// <summary>
        /// Bắt event nhấn enter trên row thì gán giá trị cho combo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// dvthang-10.07.2016
        private void mTreeViewControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var nodes = mTreeViewControl.Selection;
                var text = string.Empty;
                foreach (TreeListNode node in nodes)
                {
                    text = node.GetDisplayText(this.displayValue);
                    value = node.GetValue(this.valueMember);
                    break;
                }
                mPopupContainerEdit.EditValue = text;
                mPopupContainerEdit.ClosePopup();
            }
        }
        #endregion
    }


   
}
