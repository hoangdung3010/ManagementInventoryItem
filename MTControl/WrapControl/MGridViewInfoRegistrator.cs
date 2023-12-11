using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;

namespace MTControl
{
    public class MGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return "MGridView"; } }
        public override BaseView CreateView(GridControl grid) { return new MGridView(grid as GridControl); }
      
        
    }
}
