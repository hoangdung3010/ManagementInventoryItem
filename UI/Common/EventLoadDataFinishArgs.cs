using MTControl;
using System;

namespace FormUI
{
    /// <summary>
    /// Event load data cho grid thành công
    /// </summary>
    /// Create by: dvthang:11.03.2017
    public class EventLoadDataFinishArgs : EventArgs
    {
        private MBindingSource binddingSource;

        public MBindingSource BinddingSource
        {
            get { return binddingSource; }
            set { binddingSource = value; }
        }
        public EventLoadDataFinishArgs(MBindingSource binddingSource)
        {
            this.binddingSource = binddingSource;
        }
    }
}
