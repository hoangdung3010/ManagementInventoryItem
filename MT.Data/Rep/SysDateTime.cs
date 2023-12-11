using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data.Rep
{
    public class SysDateTime
    {
        private static SysDateTime _instance;

        private static object _lockInstance = new object();


        public static SysDateTime Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockInstance)
                    {
                        if (_instance == null)
                        {
                            _instance = new SysDateTime();
                        }
                    }
                }
                return _instance;

            }
        }

        public DateTime Now()
        {
            try
            {
                using (IUnitOfWork unitOfWork = new UnitOfWork(MT.Library.SessionData.ConnectString))
                 {
                    string query = "select GETDATE()";

                    return unitOfWork.ExecuteScalar<DateTime>(query);
                }
            }
            catch
            {
                return DateTime.Now;
            }
        }

    }
}
