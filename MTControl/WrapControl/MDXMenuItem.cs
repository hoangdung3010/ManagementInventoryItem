using System.ComponentModel;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;

namespace MTControl
{
    public class MDXMenuItem : DXMenuItem
    {
        #region"Declare"
        private string decription;
        /// <summary>
        /// Đặt định danh cho menu
        /// </summary>
        private string commandName;

        public string CommandName
        {
            get { return commandName; }
            set { commandName = value; }
        }
        /// <summary>
        /// Chỉ contextmenu tren grid nào
        /// </summary>
        private GridView grdView;

        public GridView GrdView
        {
            get { return grdView; }
            set { grdView = value; }
        }
        #endregion
        #region"Sub/Func"
        #endregion
        #region"Ovrrides"
       
        #endregion
        #region"Implement"
        [Description("Control contextmenu")]
        [Category("CustomControl")]
        public string Description
        {
            get
            {
                return decription;
            }
            set
            {
                decription=value;
            }
        }
       
        #endregion
    }
}
