using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data
{
    public static class FactoryReport
    {

        private static Dictionary<string, IBaseReportRepository> _dicRepository = new Dictionary<string, IBaseReportRepository>();
        public static IBaseReportRepository Create(IUnitOfWork unitOfWork,string repositoryName)
        {
            if (string.IsNullOrWhiteSpace(repositoryName))
            {
                return null;
            }
            IBaseReportRepository baseRepository = null;
            if (!_dicRepository.TryGetValue(repositoryName, out baseRepository))
            {

                Type type = Type.GetType($"MT.Data.Rep.{repositoryName},MT.Data");
                if (type == null)
                {
                    return null;
                }
                baseRepository = (IBaseReportRepository)Activator.CreateInstance(type, unitOfWork);
                lock (_dicRepository)
                {
                    _dicRepository.Add(repositoryName, baseRepository);
                }
            }
            return _dicRepository[repositoryName];
        }
    }
}
