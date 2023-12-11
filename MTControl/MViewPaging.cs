using DevExpress.XtraEditors;
using MTControl.WrapControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTControl
{
    public class MViewPaging
    {
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
        private int _pageSize = 100;


        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
            }
        }

        private int _currentPage = 1;

        BindingSource bs = new BindingSource();

        Action _callBack;

        MDataNavigatorPaging _nav;

        public void SetPagedDataSource(int totalRecord, MDataNavigatorPaging nav,Action callBack=null)
        {
            nav.GetComboPageSize().SelectedIndexChanged -= new EventHandler(cbo_SelectedIndexChanged);
            nav.GetComboPageSize().SelectedIndexChanged += new EventHandler(cbo_SelectedIndexChanged);
            int numberPage= ((int)totalRecord / this.PageSize) + (totalRecord % this.PageSize == 0 ? 0 : 1);
            nav.GetDataNavigator().TextStringFormat = "Trang {0}/{1}";
            nav.SetDisplayPageInfo(totalRecord);
            nav.SetPageSize(_pageSize);
            _callBack = callBack;
            _nav = nav;
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            for (int i = 1; i <= numberPage; i++)
            {
                dt.Rows.Add(i);
            }
            bs.DataSource = dt;
            nav.GetDataNavigator().DataSource = bs;
            bs.PositionChanged -= bs_PositionChanged;
            bs.PositionChanged += bs_PositionChanged;
            bs_PositionChanged(bs, EventArgs.Empty);
        }
        void bs_PositionChanged(object sender, EventArgs e)
        {
            if (bs.Position>-1 &&_currentPage != (bs.Position+1))
            {
                _currentPage = bs.Position+1;
                if (_callBack != null)
                {
                    _callBack();
                }
            }
            
        }

        void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_nav == null)
            {
                return;
            }
            _pageSize = _nav.GetPageSize();
            _currentPage = bs.Position+1;
            if (_callBack != null)
            {
                _callBack();
            }
        }
    }

    public class MParamPaging
    {
        public int PageSize { get; set; }

        public int Page { get; set; } = 0;
    }
}
