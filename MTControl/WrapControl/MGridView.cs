using System.ComponentModel;
using System.Drawing;
using System;
using DevExpress.Data.Helpers;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Data.Filtering;
using System.Reflection;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;
using System.Collections.Generic;
using MTControl.Models;
using DevExpress.Utils.Menu;

namespace MTControl
{
    public class MGridView :DevExpress.XtraGrid.Views.Grid.GridView
        
    {
        #region"Declare"
        protected override string ViewName { get { return "MGridView"; } }

        /// <summary>
        /// Có sử dụng filter server hay không, mặc định là không
        /// </summary>
        private bool isFilterServer;

        public bool IsFilterServer
        {
            get { return isFilterServer; }
            set { isFilterServer = value; this.OptionsView.ShowAutoFilterRow = this.isFilterServer; }
        }

        public bool RaiseEventCellValueChanged { get; set; }


        MGridControl mGrid;
        #endregion
        #region"Contructor"
        public MGridView() : this(null) {

            this.PopupMenuShowing -= gridView_PopupMenuShowing;
            this.PopupMenuShowing += gridView_PopupMenuShowing;
        }
        public MGridView(DevExpress.XtraGrid.GridControl grid)
            : base(grid)
        {

            this.PopupMenuShowing -= gridView_PopupMenuShowing;
            this.PopupMenuShowing += gridView_PopupMenuShowing;

        }

     
        #endregion
        #region"Sub/Func"

        #endregion
        #region"Ovrrides"
        protected override void OnLoaded()
        {
            base.OnLoaded();
            mGrid = (MGridControl)this.GridControl;
            if (mGrid.IsRemoteFilter)
            {
                GridColumnCollection colectionColumn = this.Columns;
                if (colectionColumn != null)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn col in colectionColumn)
                    {
                        col.OptionsFilter.AllowFilter = true;
                        col.OptionsFilter.ImmediateUpdateAutoFilter = false;//Không cho tự động filter, khi nhấn enter mới cho filter
                    }
                }

                this.CustomRowFilter -= MGridView_CustomRowFilter;
                this.CustomRowFilter += MGridView_CustomRowFilter;
            }
           
        }

        protected override void OnColumnSortInfoCollectionChanged(CollectionChangeEventArgs e)
        {
            base.OnColumnSortInfoCollectionChanged(e);
            if (mGrid!= null && mGrid.IsShowPaging && mGrid.ColumnSortInfoCollectionChanged != null)
            {
                mGrid.ColumnSortInfoCollectionChanged(this, new EventArgs());
            }
        }


        static void VisibleMenuGridColumnFilterStringAndInterger(DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            var menuFilterClauseLike = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseLike)];
            if (menuFilterClauseLike != null)
            {
                menuFilterClauseLike.Visible = false;
            }

            var menuFilterClauseNotLike = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseNotLike)];
            if (menuFilterClauseNotLike != null)
            {
                menuFilterClauseNotLike.Visible = false;
            }

            var menuFilterClauseLess = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseLess)];
            if (menuFilterClauseLess != null)
            {
                menuFilterClauseLess.Visible = false;
            }

            var menuFilterClauseLessOrEqual = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseLessOrEqual)];
            if (menuFilterClauseLessOrEqual != null)
            {
                menuFilterClauseLessOrEqual.Visible = false;
            }

            var menuFilterClauseGreater = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseGreater)];
            if (menuFilterClauseGreater != null)
            {
                menuFilterClauseGreater.Visible = false;
            }

            var menuFilterClauseGreaterOrEqual = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseGreaterOrEqual)];
            if (menuFilterClauseGreaterOrEqual != null)
            {
                menuFilterClauseGreaterOrEqual.Visible = false;
            }
        }

        public static void ProcessPopupMenuShowing(DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            switch (e.MenuType)
            {
                case DevExpress.XtraGrid.Views.Grid.GridMenuType.AutoFilter:
                    MGridColumn mGridColumn = (MGridColumn)e.HitInfo.Column;

                    switch (mGridColumn.UnboundType)
                    {
                        case DevExpress.Data.UnboundColumnType.String:
                            VisibleMenuGridColumnFilterStringAndInterger(e);
                            break;

                        case DevExpress.Data.UnboundColumnType.Integer:
                            if (!string.IsNullOrWhiteSpace(mGridColumn.EnumName))
                            {
                                VisibleMenuGridColumnFilterStringAndInterger(e);
                                var menuFilterClauseContains = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseContains)];
                                if (menuFilterClauseContains != null)
                                {
                                    menuFilterClauseContains.Visible = false;
                                }

                                var menuFilterClauseBeginsWith = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseBeginsWith)];
                                if (menuFilterClauseBeginsWith != null)
                                {
                                    menuFilterClauseBeginsWith.Visible = false;
                                }

                                var menuFilterClauseEndsWith = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseEndsWith)];
                                if (menuFilterClauseEndsWith != null)
                                {
                                    menuFilterClauseEndsWith.Visible = false;
                                }

                                var menuFilterClauseDoesNotContain = e.Menu.Items[Localizer.Active.GetLocalizedString(StringId.FilterClauseDoesNotContain)];
                                if (menuFilterClauseDoesNotContain != null)
                                {
                                    menuFilterClauseDoesNotContain.Visible = false;
                                }
                            }
                            break;
                    }
                    break;
                case DevExpress.XtraGrid.Views.Grid.GridMenuType.Column:
                    foreach (DXMenuItem item in e.Menu.Items)
                    {
                        item.Visible = false;
                    }
                    var menuItem= e.Menu.Items[MyGridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnClearSorting)];
                    if (menuItem != null)
                    {
                        menuItem.Visible = true;
                    }
                   
                    menuItem = e.Menu.Items[MyGridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnClearAllSorting)];
                    if (menuItem != null)
                    {
                        menuItem.Visible = true;
                    }
                    menuItem = e.Menu.Items[MyGridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnSortAscending)];
                    if (menuItem != null)
                    {
                        menuItem.Visible = true;
                    }
                    menuItem = e.Menu.Items[MyGridLocalizer.Active.GetLocalizedString(GridStringId.MenuColumnSortDescending)];
                    if (menuItem != null)
                    {
                        menuItem.Visible = true;
                    }
                    break;
            }
            
        }

        private void gridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            MGridView.ProcessPopupMenuShowing(e);
        }
        /// <summary>
        /// bắt event filter row trên grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MGridView_CustomRowFilter(object sender,RowFilterEventArgs e){
            if (mGrid != null && mGrid.IsRemoteFilter)
            {
                e.Handled = true;
                e.Visible = true;
            }
        }

        /// <summary>
        /// Custom điều kiện tìm kiếm trên grid
        /// </summary>
        /// <param name="column"></param>
        /// <param name="condition"></param>
        /// <param name="_value"></param>
        /// <param name="strVal"></param>
        /// <returns>Trả về danh sách kết quả tìm kiếm</returns>
        /// Create by: dvthang:18.06.2018
        protected override CriteriaOperator CreateAutoFilterCriterion(GridColumn column, AutoFilterCondition condition, object _value, string strVal)
        {
            return base.CreateAutoFilterCriterion(column, condition, _value, strVal);
        }

        protected override DevExpress.Data.Filtering.CriteriaOperator ConvertGridFilterToDataFilter(DevExpress.Data.Filtering.CriteriaOperator criteria)
        {
            FindSearchParserResults lastParserResults = null;
            if (!string.IsNullOrEmpty(FindFilterText))
            {
                lastParserResults = new FindSearchParser().Parse(FindFilterText, GetFindToColumnsCollection());
                if (!IsServerMode)
                {
                    lastParserResults.AppendColumnFieldPrefixes();
                }
                CriteriaOperator findCriteria = DxFtsContainsHelperAlt.Create(lastParserResults, FilterCondition.StartsWith, IsServerMode);
                return criteria & findCriteria;
            }

           
            if (mGrid != null && !mGrid.MarkLoading && mGrid.IsRemoteFilter)
            {
                if (mGrid.StartRemoteFilterRow != null)
                {
                    var dicData = Extract(criteria);
                    mGrid.FilterObjects = dicData;
                    mGrid.StartRemoteFilterRow(this, new EventArgs());
                }
            }
            return criteria;
        }


        private List<FilterObject> Extract(CriteriaOperator op)
        {
            List<FilterObject> filterObjects = new List<FilterObject>();
            GroupOperator opGroup = op as GroupOperator;
            if (ReferenceEquals(opGroup, null))
            {
                ExtractOne(filterObjects, op);
            }
            else
            {
                if (opGroup.OperatorType == GroupOperatorType.And)
                {
                    foreach (var opn in opGroup.Operands)
                    {
                        ExtractOne(filterObjects, opn);
                    }
                }
            }
            return filterObjects;
        }
        private static void ExtractOne(List<FilterObject> filterObjects, CriteriaOperator op)
        {
            if (op is BinaryOperator)
            {
                BinaryOperator opBinary = op as BinaryOperator;
                if (ReferenceEquals(opBinary, null)) return;

                OperandProperty opProperty = opBinary.LeftOperand as OperandProperty;
                OperandValue opValue = opBinary.RightOperand as OperandValue;
                if (ReferenceEquals(opProperty, null) || ReferenceEquals(opValue, null)) return;

                var condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.Equals;
                switch (opBinary.OperatorType)
                {
                    case BinaryOperatorType.Equal:
                        condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.Equals;
                        break;
                    case BinaryOperatorType.Greater:
                        condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.Greater;
                        break;
                    case BinaryOperatorType.GreaterOrEqual:
                        condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.GreaterOrEqual;
                        break;
                    case BinaryOperatorType.Less:
                        condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.Less;
                        break;
                    case BinaryOperatorType.LessOrEqual:
                        condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.LessOrEqual;
                        break;
                    case BinaryOperatorType.NotEqual:
                        condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.DoesNotEqual;
                        break;
                }
                filterObjects.Add(new FilterObject { FieldName= opProperty.PropertyName ,Value= opValue .Value,Condition= condition });
                return;
            }

            if (op is FunctionOperator)
            {
                FunctionOperator opFn = op as FunctionOperator;
                if (ReferenceEquals(opFn, null)) return;
                OperandProperty opProperty = opFn.Operands[0] as OperandProperty;
                OperandValue opValue = opFn.Operands[1] as OperandValue;

                if (ReferenceEquals(opProperty, null) || ReferenceEquals(opValue, null)) return;

                var condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.Equals;
                switch (opFn.OperatorType) {
                    case FunctionOperatorType.StartsWith:
                        condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.BeginsWith;
                        break;
                    case FunctionOperatorType.Contains:
                        condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.Contains;
                        break;
                    case FunctionOperatorType.EndsWith:
                        condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.EndsWith;
                        break;
                }
                filterObjects.Add(new FilterObject { FieldName = opProperty.PropertyName, Value = opValue.Value, Condition = condition });
            }

            if(op is UnaryOperator)
            {
                UnaryOperator opFn = op as UnaryOperator;
                if (ReferenceEquals(opFn, null)) return;
                switch (opFn.OperatorType)
                {
                    case UnaryOperatorType.Not:
                        if(opFn.Operand is BinaryOperator)
                        {
                            BinaryOperator opBinary = opFn.Operand as BinaryOperator;
                            if (ReferenceEquals(opBinary, null)) return;

                            OperandProperty opProperty = opBinary.LeftOperand as OperandProperty;
                            OperandValue opValue = opBinary.RightOperand as OperandValue;
                            if (ReferenceEquals(opProperty, null) || ReferenceEquals(opValue, null)) return;
                            filterObjects.Add(new FilterObject { FieldName = opProperty.PropertyName, Value = opValue.Value, Condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.DoesNotEqual });
                            break;
                        }

                        if (opFn.Operand is FunctionOperator)
                        {
                            FunctionOperator opFn2 = opFn.Operand as FunctionOperator;
                            if (ReferenceEquals(opFn, null)) return;
                            OperandProperty opProperty = opFn2.Operands[0] as OperandProperty;
                            OperandValue opValue = opFn2.Operands[1] as OperandValue;

                            if (ReferenceEquals(opProperty, null) || ReferenceEquals(opValue, null)) return;
                            filterObjects.Add(new FilterObject { FieldName = opProperty.PropertyName, Value = opValue.Value,
                                Condition = DevExpress.XtraEditors.ColumnAutoFilterCondition.NotLike });
                        }
                        break;
                }
            }
            
        }
        #endregion
        #region"Implement"

        #endregion


    }
}
