using MT.Data.Rep;
using MT.Library.UW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Data
{
    public class DBContext:IDisposable
    {
        private IUnitOfWork _unitOfWork;

        private string _connectionString;

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    _connectionString = MT.Library.SessionData.ConnectString;
                }
                if (_unitOfWork == null)
                {
                    _unitOfWork = new UnitOfWork(_connectionString);
                }
                return _unitOfWork;
            }
        }


        private IBaseImportRepository _baseImportRepository;

        public IBaseImportRepository ImportRepository
        {
            get
            {
                if (_baseImportRepository == null)
                {
                    _baseImportRepository = new ImportBaseRepository(UnitOfWork);
                }

                return _baseImportRepository;
            }
            set
            {
                _baseImportRepository = value;
            }
        }


        private Dictionary<string, IBaseRepository> _dicRepository = new Dictionary<string, IBaseRepository>();
        private Dictionary<string, IBaseImportRepository> _dicImportRepository = new Dictionary<string, IBaseImportRepository>();

        /// <summary>
        /// Kiểm tra kết nối đến database thành công không
        /// </summary>
        /// <returns>true: Thành công, ngược lại thất bại</returns>
        public bool IsConnect()
        {
            return UnitOfWork.IsConnect();
        }

        public DBContext()
        {
        }

        public DBContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Đối tượng thao tác với database
        /// </summary>
        public IBaseRepository GetRepByTableName(string tableName) 
        {
            IBaseRepository baseRepository = null;
            string repositoryName = $"{tableName}Repository";
            if (!_dicRepository.TryGetValue(repositoryName, out baseRepository))
            {

                Type type = Type.GetType($"MT.Data.Rep.{repositoryName},MT.Data");
                if (type == null)
                {
                    return null;
                }

                baseRepository = (IBaseRepository)Activator.CreateInstance(type, UnitOfWork);
                lock (_dicRepository)
                {
                    _dicRepository.Add(repositoryName, baseRepository);
                }
            }
            return _dicRepository[repositoryName];
        }


        /// <summary>
        /// Đối tượng thao tác với database
        /// </summary>
        public IBaseImportRepository GetImportRepByType(ImportDataType importDataType)
        {
            IBaseImportRepository baseRepository = null;
            string repositoryName = $"Import{importDataType.ToString()}Repository";
            if (!_dicImportRepository.TryGetValue(repositoryName, out baseRepository))
            {

                Type type = Type.GetType($"MT.Data.Rep.{repositoryName},MT.Data");
                if (type == null)
                {
                    return null;
                }

                baseRepository = (IBaseImportRepository)Activator.CreateInstance(type, UnitOfWork);
                lock (_dicRepository)
                {
                    _dicImportRepository.Add(repositoryName, baseRepository);
                }
            }
            return _dicImportRepository[repositoryName];
        }


        /// <summary>
        /// Đối tượng thao tác với database
        /// </summary>
        /// <param name="repositoryName">Tên repository</param>
        public IBaseRepository GetRep<T>() where T: IBaseRepository
        {
            IBaseRepository baseRepository = null;
            string repositoryName = typeof(T).Name;
            if (!_dicRepository.TryGetValue(repositoryName,out baseRepository))
            {

                Type type = Type.GetType($"MT.Data.Rep.{repositoryName},MT.Data");
                if (type == null)
                {
                    return null;
                }

                baseRepository = (T)Activator.CreateInstance(type,UnitOfWork);
                lock (_dicRepository)
                {
                    _dicRepository.Add(repositoryName, baseRepository);
                }
            }
            return _dicRepository[repositoryName];
        }

        /// <summary>
        /// Đối tượng thao tác với database
        /// </summary>
        /// <param name="repositoryName">Tên repository</param>
        public T GetRep2<T>() where T : IBaseRepository
        {
            return (T)GetRep<T>();
        }


        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
