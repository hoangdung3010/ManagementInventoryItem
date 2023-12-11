using System;
using MT.Library;
using System.ComponentModel.DataAnnotations;

namespace MT.Data.BO
{
    public class BackupHistory : BaseEntity
    {
        #region Instance Properties

        public Guid Id { get; set; }

        public string sBackupName { get; set; }

        public Guid sUserId { get; set; }

        public string sFileName { get; set; }

        public float fSize { get; set; }

        public string PathSaveData { get; set; }

        public string DatabaseName { get; set; }

        #endregion Instance Properties
    }

}
